using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSLibrary.Data;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagInventoryWithSyncQueue : Form
    {
        private SyncQueue syncQueue = null;
        private bool mStop = false;
        private uint totalGoodRead = 0, totalBadRead = 0;

        public TagInventoryWithSyncQueue()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void TagInventoryWithSyncQueue_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            syncQueue = new SyncQueue();
            syncQueue.OnCheckDataExist += new SyncQueue.CheckDataExistEventHandler(syncQueue_OnCheckDataExist);
            Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_OnAsyncCallback);
            Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
        }

        void syncQueue_OnCheckDataExist(object sender, CheckDataExistEventArgs e)
        {
            this.BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                if (!e.IsExist)
                {
                    this.listView1.BeginUpdate();
                    ListViewItem item = new ListViewItem(string.Format("{0}", listView1.Items.Count + 1));
                    item.SubItems.Add(e.Data);
                    this.listView1.Items.Add(item);
                    this.listView1.EndUpdate();
                }
            });
        }

        void ReaderXP_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
           {
               switch (e.state)
               {
                   case RFState.IDLE:
                       syncQueue.Stop();
                       stopToolStripMenuItem.Enabled = false;
                       startToolStripMenuItem.Enabled = true;
                       if (mStop)
                           this.Close();
                       break;
                   case RFState.BUSY:
                       syncQueue.Start();
                       stopToolStripMenuItem.Enabled = true;
                       startToolStripMenuItem.Enabled = false;
                       break;
                   case RFState.RESET:
                   case RFState.ABORT:
                       break;
               }
           });
        }

        void ReaderXP_OnAsyncCallback(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            if (e.type == CallbackType.TAG_RANGING)
            {
                if (!e.info.crcInvalid)
                {
                    totalGoodRead++;
                    syncQueue.Write(e.info.epc.ToString());
                }
                else
                {
                    totalBadRead++;
                }
            }
        }

        private void TagInventoryWithSyncQueue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
                mStop = e.Cancel = true;
            }
            else
            {
                syncQueue.OnCheckDataExist -= new SyncQueue.CheckDataExistEventHandler(syncQueue_OnCheckDataExist);
                syncQueue.Dispose();
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_OnAsyncCallback);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);

            }
        }

        public void Start()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                //Do Setup on SettingForm
                Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                Program.ReaderXP.Options.TagRanging.QTMode = false; // reset to default
                Program.ReaderXP.Options.TagRanging.accessPassword = 0x0; // reset to default
                Program.ReaderXP.StartOperation(Operation.TAG_RANGING, false);
            }
        }
        public void StartOnce()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.SetOperationMode(RadioOperationMode.NONCONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                //Do Setup on SettingForm
                Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                Program.ReaderXP.Options.TagRanging.QTMode = false; // reset to default
                Program.ReaderXP.Options.TagRanging.accessPassword = 0x0; // reset to default
                Program.ReaderXP.StartOperation(Operation.TAG_RANGING, false);
            }
        }

        public void Stop()
        {
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
            }
        }

        public void Clear()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(Clear));
                return;
            }
            listView1.Items.Clear();
            syncQueue.Clear();
        }

    }
}