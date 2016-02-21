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
    public partial class QTMessageForm : Form
    {
        public static QTMessageForm msgform = null;
        protected static QTTagInventoryForm inv = null;
        private static Thread msgThread = null;

        public QTMessageForm()
        {
            InitializeComponent();
        }

        public static Thread MsgThread
        {
            get { return QTMessageForm.msgThread; }
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

        public static Thread LaunchForm(QTTagInventoryForm form)
        {
            if (form == null) throw new ArgumentNullException("form");

            inv = form;

            //if (MsgThread != null) return MsgThread;

            QTMessageForm.msgThread = new Thread(MsgThreadProc);
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
            msgform = new QTMessageForm();

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
    }
}