using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.IO;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ControlPanelForm : Form
    {
        public static ControlPanelForm  _controlPanel = null;
        private static Thread           _controlPanelThread = null;
        private static TagInventoryForm _mainForm = null;

        //public event EventHandler OnSQLCheck;

        public bool EnableStart
        {
            get { return btn_once.Enabled; }
            set { btn_once.Enabled = btn_run.Enabled = value; }
        }

        public bool EnableStop
        {
            get { return btn_stop.Enabled; }
            set { btn_stop.Enabled = value; }
        }

        public bool EnableClear
        {
            get { return btn_clear.Enabled; }
            set { btn_clear.Enabled = value; }
        }

        public bool EnableSelect
        {
            get { return btn_select.Enabled; }
            set { btn_select.Enabled = value; }
        }

        public bool EnableSave
        {
            get { return btn_save.Enabled; }
            set { btn_save.Enabled = value; }
        }

        public static TagInventoryForm MainForm
        {
            get { return ControlPanelForm._mainForm; }
            set { ControlPanelForm._mainForm = value; }
        }

        public ControlPanelForm()
        {
            InitializeComponent();
        }

        public int TagLogFileSizeLimit = 0;
        public int TagLogFileLimit = 0;
        public int TagLogFileCurrentNumber = 1;

        private void btn_run_Click(object sender, EventArgs e)
        {
            int cnt;

            TagLogFileSizeLimit = int.Parse(textBox1.Text) * 1024 * 1024;
            TagLogFileLimit = int.Parse(textBox2.Text);
            TagLogFileCurrentNumber = 1;

            if (checkBoxTagLog.Checked)
            {
                MessageBox.Show("Old Tag Log Files will be delete!!!");

                for (cnt = 1; cnt <= TagLogFileLimit; cnt++)
                {
                    string TagLogFileName = "TagLog" + cnt + ".csv";
                    File.Delete(TagLogFileName);
                }
            }
            
            if (_mainForm != null)
                _mainForm.Start();
        }

        private void btn_once_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.StartOnce();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.Stop();

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.SelectTag();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.Save();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.CloseForm();
        }

        public static ControlPanelForm ControlPanel
        {
            get { return ControlPanelForm._controlPanel; }
        }

        public static Thread ControlPanelThread
        {
            get { return ControlPanelForm._controlPanelThread; }
        }

        public static Thread LaunchControlPanel(TagInventoryForm form)
        {
            if (form == null)
                throw new ArgumentNullException("form");

            if (ControlPanelThread != null) return ControlPanelThread;

            _mainForm = form;

            ControlPanelForm._controlPanelThread = new Thread(ControlPanelThreadProc);
            ControlPanelThread.Name = "ControlPanel";
            ControlPanelThread.Priority = ThreadPriority.Highest;
            ControlPanelThread.IsBackground = false;
            ControlPanelThread.Start();
            return ControlPanelThread;
        }

        public static void EnablePannel(bool enable)
        {
            try
            {
                if (_controlPanelThread != null && _controlPanelThread.IsAlive)
                {
                    _controlPanel.Enabled = enable;
                }
            }
            catch (Exception) { }
        }

        public static void CloseControlPanel()
        {
            try
            {
                if (_controlPanelThread != null && _controlPanelThread.IsAlive)
                {
                    _controlPanel.Invoke(new MethodInvoker(_controlPanel.Close));
                    _controlPanelThread.Join();
                    _controlPanelThread = null;
                }
            }
            catch (Exception) { }
        }

        public static void SetResize(Point location, int height)
        {
            if (_controlPanelThread != null && _controlPanelThread.IsAlive && ControlPanel != null && ControlPanel.Created)
            {
                _controlPanel.Invoke(new ResizeFormDeleg(_controlPanel.SetResizeForm), new object[] { location, height });
            }
        }

        public static void SetTopMost(bool topMost)
        {
            if (_controlPanelThread != null && _controlPanelThread.IsAlive && ControlPanel != null && ControlPanel.Created)
            {
                if (topMost)
                    _controlPanel.Invoke(new MethodInvoker(_controlPanel.SetAsTopMost));
                else
                    _controlPanel.Invoke(new MethodInvoker(_controlPanel.ResetAsTopMost));
            }
        }

        public static void ShowControlPanel(bool show)
        {
            if (_controlPanelThread != null && _controlPanelThread.IsAlive && ControlPanel != null && ControlPanel.Created)
            {
                if (show)
                    _controlPanel.Invoke(new MethodInvoker(_controlPanel.ShowControlPanel));
                else
                    _controlPanel.Invoke(new MethodInvoker(_controlPanel.HideControlPanel));
            }
        }

        private delegate void ResizeFormDeleg(Point location, int height);
        private void SetResizeForm(Point location, int height)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ResizeFormDeleg(SetResizeForm), new object[] { location, height });
                return;
            }
            this.Height = height;
            this.Location = location;
        }

        private void SetAsTopMost()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(SetAsTopMost));
                return;
            }
            this.TopMost = true;
        }

        private void ResetAsTopMost()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(SetAsTopMost));
                return;
            }
            this.TopMost = false;
        }

        private void ShowControlPanel()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(ShowControlPanel));
                return;
            }
            this.Visible = true;
        }

        private void HideControlPanel()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(HideControlPanel));
                return;
            }
            this.Visible = false;
        }

        [STAThread]
        static void ControlPanelThreadProc()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0} is threadID {1}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.ManagedThreadId));
            _controlPanel = new ControlPanelForm();

            _controlPanel.StartPosition = FormStartPosition.Manual;
            _controlPanel.ShowInTaskbar = false;
            Application.Run(_controlPanel);
            System.Diagnostics.Debug.WriteLine("ControlPanel Thread is exiting");
        }

        private void ControlPanelForm_Load(object sender, EventArgs e)
        {
            textBox_LogPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CSLReader";

            System.Diagnostics.Debug.Assert(MainForm != null);

            Point pt = MainForm.Location;
            pt.Offset(MainForm.Width, 0);
            Rectangle r = Screen.GetBounds(this.DesktopBounds);
            if (pt.X + Width > r.Width)
                pt.X = r.Right - Width;

            this.Location = pt;

            this.Height = MainForm.Height;

            MainForm.OnButtonEnable += new EventHandler<TagInventoryForm.OnButtonClickEventArgs>(MainForm_OnButtonEnable);

            EnableStop = false;
            EnableSelect = _mainForm.SelectMode;
        }
        void MainForm_OnButtonEnable(object sender, TagInventoryForm.OnButtonClickEventArgs e)
        {
            ButtonHandle(e.State, e.Enable);
        }

        private delegate void OnButtonHandleDeleg(TagInventoryForm.ButtonState btnState, bool en);
        private void ButtonHandle(TagInventoryForm.ButtonState btnState, bool en)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new OnButtonHandleDeleg(ButtonHandle), new object[] { btnState , en});
                return;
            }
            switch (btnState)
            {
                case TagInventoryForm.ButtonState.Clear:
                    btn_clear.Enabled = en;
                    break;
                case TagInventoryForm.ButtonState.Save:
                    btn_save.Enabled = en;
                    break;
                case TagInventoryForm.ButtonState.Select:
                    btn_select.Enabled = en;
                    break;
                case TagInventoryForm.ButtonState.Start:
                    btn_once.Enabled = btn_run.Enabled = en;
                    break;
                case TagInventoryForm.ButtonState.Stop:
                    btn_stop.Enabled = en;
                    break;
                case TagInventoryForm.ButtonState.ALL:
                    this.Enabled = en;
                    break;
                default: break;
            }
        }

        private void ControlPanelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.OnButtonEnable -= new EventHandler<TagInventoryForm.OnButtonClickEventArgs>(MainForm_OnButtonEnable);
        }

        private void cb_sql_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sql.Checked)
            {
                _mainForm.Save2SQL();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_LogPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_clearcount_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
                _mainForm.ClearCount();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}