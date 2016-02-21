using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class MessageForm : Form
    {
        public static MessageForm msgform = null;
        protected static TagInventoryForm inv = null;
        private static Thread msgThread = null;

        public MessageForm()
        {
            InitializeComponent();
        }

        public static Thread MsgThread
        {
            get { return MessageForm.msgThread; }
        }
        private delegate void CloseFormDeleg();
        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseFormDeleg(CloseForm), new object[] { });
                return;
            }
            if (MessageForm.msgform != null)
            {
                MessageForm.msgform.Close();
            }
        }

        public static Thread LaunchForm(TagInventoryForm form)
        {
            if (form == null) throw new ArgumentNullException("form");

            inv = form;

            //if (MsgThread != null) return MsgThread;

            MessageForm.msgThread = new Thread(MsgThreadProc);
            MsgThread.Name = "MessageForm";
            MsgThread.Priority = ThreadPriority.Highest;
            MsgThread.IsBackground = false;
            MsgThread.Start();
            return MsgThread;
        }

        [STAThread]
        static void MsgThreadProc()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0} is threadID {1}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.ManagedThreadId));
            msgform = new MessageForm();

            msgform.StartPosition = FormStartPosition.CenterScreen;
            msgform.ShowInTaskbar = false;
            Application.Run(msgform);
            System.Diagnostics.Debug.WriteLine("ControlPanel Thread is exiting");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            inv.AbortReset();
        }


        private void MessageForm_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            this.Location = new System.Drawing.Point((workingRectangle.Width - this.Width) / 2, (workingRectangle.Height - this.Height) / 2 + 150);
        }
    }
}