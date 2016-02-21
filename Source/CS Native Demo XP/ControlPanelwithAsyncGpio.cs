using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using CSLibrary;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ControlPanelWithAsyncGpioForm : Form
    {
        public static ControlPanelWithAsyncGpioForm _controlPanel = null;
        private static Thread           _controlPanelThread = null;
        private static TagInventoryWithAsyncGpioForm _mainForm = null;

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

        public static TagInventoryWithAsyncGpioForm MainForm
        {
            get { return ControlPanelWithAsyncGpioForm._mainForm; }
            set { ControlPanelWithAsyncGpioForm._mainForm = value; }
        }

        public ControlPanelWithAsyncGpioForm()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
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

        public static ControlPanelWithAsyncGpioForm ControlPanel
        {
            get { return ControlPanelWithAsyncGpioForm._controlPanel; }
        }

        public static Thread ControlPanelThread
        {
            get { return ControlPanelWithAsyncGpioForm._controlPanelThread; }
        }

        public static Thread LaunchControlPanel(TagInventoryWithAsyncGpioForm form)
        {
            if (form == null)
                throw new ArgumentNullException("form");

            if (ControlPanelThread != null) return ControlPanelThread;

            _mainForm = form;

            ControlPanelWithAsyncGpioForm._controlPanelThread = new Thread(ControlPanelThreadProc);
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
            _controlPanel = new ControlPanelWithAsyncGpioForm();

            _controlPanel.StartPosition = FormStartPosition.Manual;
            _controlPanel.ShowInTaskbar = false;
            Application.Run(_controlPanel);
            System.Diagnostics.Debug.WriteLine("ControlPanel Thread is exiting");
        }

        private void ControlPanelForm_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(MainForm != null);

            Point pt = MainForm.Location;
            pt.Offset(MainForm.Width, 0);
            Rectangle r = Screen.GetBounds(this.DesktopBounds);
            if (pt.X + Width > r.Width)
                pt.X = r.Right - Width;

            this.Location = pt;

            //this.Height = MainForm.Height;

            MainForm.OnButtonEnable += new EventHandler<TagInventoryWithAsyncGpioForm.OnButtonClickEventArgs>(MainForm_OnButtonEnable);

            EnableStop = false;
            EnableSelect = _mainForm.SelectMode;

            //Program.ReaderXP.GPIOCallBackEvent += new EventHandler<CSLibrary.HighLevelInterface.GPIO_ASYNC_CALLBACK>(GPIOCallBackEventHandler);
        }
        void MainForm_OnButtonEnable(object sender, TagInventoryWithAsyncGpioForm.OnButtonClickEventArgs e)
        {
            ButtonHandle(e.State, e.Enable);
        }

        private delegate void OnButtonHandleDeleg(TagInventoryWithAsyncGpioForm.ButtonState btnState, bool en);
        private void ButtonHandle(TagInventoryWithAsyncGpioForm.ButtonState btnState, bool en)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new OnButtonHandleDeleg(ButtonHandle), new object[] { btnState , en});
                return;
            }
            switch (btnState)
            {
                case TagInventoryWithAsyncGpioForm.ButtonState.Clear:
                    btn_clear.Enabled = en;
                    break;
                case TagInventoryWithAsyncGpioForm.ButtonState.Save:
                    btn_save.Enabled = en;
                    break;
                case TagInventoryWithAsyncGpioForm.ButtonState.Select:
                    btn_select.Enabled = en;
                    break;
                case TagInventoryWithAsyncGpioForm.ButtonState.Start:
                    btn_once.Enabled = btn_run.Enabled = en;
                    break;
                case TagInventoryWithAsyncGpioForm.ButtonState.Stop:
                    btn_stop.Enabled = en;
                    break;
                case TagInventoryWithAsyncGpioForm.ButtonState.ALL:
                    this.Enabled = en;
                    break;
                default: break;
            }
        }

        private void ControlPanelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LEDFlash = false;
            MainForm.OnButtonEnable -= new EventHandler<TagInventoryWithAsyncGpioForm.OnButtonClickEventArgs>(MainForm_OnButtonEnable);
            //Program.ReaderXP.GPIOCallBackEvent -= new EventHandler<CSLibrary.HighLevelInterface.GPIO_ASYNC_CALLBACK>(GPIOCallBackEventHandler);
        }

        private void cb_sql_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sql.Checked)
            {
                _mainForm.Save2SQL();
            }
        }

        void GPIOCallBackEventHandler(object sender, CSLibrary.HighLevelInterface.GPIO_ASYNC_CALLBACK e)
        {
            switch (e.Type)
            {
                case HighLevelInterface.GPIOPROCTYPE.GETGPI:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Get GPI0 =" + (e.Status[0] ? "On" : "Off") + ", GPI1 = " + (e.Status[1] ? "On" : "Off"));
                    else
                        MessageBox.Show("Get GPI Fail");
                    break;
                case HighLevelInterface.GPIOPROCTYPE.GETGPI0:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show ("Get GPI0 =" + (e.Status[0] ? "On" : "Off" ));
                    else
                        MessageBox.Show ("Get GPI0 Fail");
                    break;
                case HighLevelInterface.GPIOPROCTYPE.GETGPI1:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Get GPI1 =" + (e.Status[0] ? "On" : "Off" ));
                    else
                        MessageBox.Show("Get GPI1 Fail");
                    break;

                case HighLevelInterface.GPIOPROCTYPE.GETGPO:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Get GPO0 =" + (e.Status[0] ? "On" : "Off" ) + ", GPO1 = " + (e.Status[1]? "On" : "Off" ));
                    else
                        MessageBox.Show("Get GPO Fail");
                    break;
                case HighLevelInterface.GPIOPROCTYPE.GETGPO0:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Get GPO0 =" + (e.Status[0]? "On" : "Off" ));
                    else
                        MessageBox.Show("Get GPO0 Fail");
                    break;
                case HighLevelInterface.GPIOPROCTYPE.GETGPO1:
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Get GPO1 =" + (e.Status[0] ? "On" : "Off" ));
                    else
                        MessageBox.Show("Get GPO1 Fail");
                    break;

                case HighLevelInterface.GPIOPROCTYPE.SETGPO0:
/*
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Set GPO1 OK");
                    else
                        MessageBox.Show("Set GPO1 Fail");
*/
                    break;

                case HighLevelInterface.GPIOPROCTYPE.SETGPO1:
/*                    
                    if (e.ret == CSLibrary.Constants.Result.OK)
                        MessageBox.Show("Set GPO1 OK");
                    else
                        MessageBox.Show("Set GPO1 Fail");
*/
                    break;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.SetGPO0Async(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.SetGPO0Async(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.SetGPO1Async(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.SetGPO1Async(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.GetGPIOAsync(CSLibrary.HighLevelInterface.GPIOPROCTYPE.GETGPI0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.GetGPIOAsync(CSLibrary.HighLevelInterface.GPIOPROCTYPE.GETGPI1);
        }

        public bool LEDFlash = false;

        private void button7_Click(object sender, EventArgs e)
        {
            //Thread Process;

            button7.Enabled = false;
            LEDFlash = true;
/*
            Process = new Thread((ThreadStart)delegate
            {
                while (LEDFlash)
                {
                    Program.ReaderXP.SetGPO0Async(true);
                    Program.ReaderXP.SetGPO1Async(false);
                    Thread.Sleep(1000);
                    Program.ReaderXP.SetGPO0Async(false);
                    Program.ReaderXP.SetGPO1Async(true);
                    Thread.Sleep(1000);
                }
            });
            Process.Start();
*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LEDFlash = false;
            button7.Enabled = true;
        }
    }
}
