using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    using rfid.Constants;

    using Reader.Constants;
    using Reader.Structures;
    using Reader.Utility;
    //using Reader.Device;

    public partial class CustomReadForm : Form
    {
        //Only custom read on EPC bank

        #region Private Member
        private StringBuilder LogBuilder = new StringBuilder();
        private string targetEpc = "";

        public string TargetEPC
        {
            get { return targetEpc; }
            set { targetEpc = value; }
        }
        #endregion

        #region Form
        public CustomReadForm()
        {
            InitializeComponent();
        }

        private void CustomReadForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
            cb_alg.SelectedIndex = 0;
            cb_tg_select.SelectedIndex = 0;
            cb_tg_session.SelectedIndex = 0;
            cb_tg_target.SelectedIndex = 0;
            cb_alg_toggle.Checked = false;
            nb_alg_qsize.Value = 1;
            nb_alg_retry.Value = 10;
            cb_sel_target.SelectedIndex = 0;
            cb_sel_action.SelectedIndex = 0;
        }

        private void CustomReadForm_Closing(object sender, CancelEventArgs e)
        {
            AttachCallback(false);
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                Program.ReaderCE.Stop();
            while (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
        }
        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.MyErrorEvent += new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyTagAccessEvent += new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent += new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
            }
            else
            {
                Program.ReaderCE.MyErrorEvent -= new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyTagAccessEvent -= new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
            }
        }

        void ReaderCE_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Write)
            {
                ShowMsg(e.ErrorCode.ToString());
            }
        }

        void ReaderCE_MyTagAccessEvent(object sender, Reader.Events.TagAccessEventArgs e)
        {
            TagAccessDataStruct data = (TagAccessDataStruct)e.TagAccessInformation;

            LogBuilder.Insert(0, "Time = " + data.ms_ctr.ToString() + "\r\n");
            LogBuilder.Insert(0, "Data = " + Reader.Utility.HexEncoding.ToString(data.data) + "\r\n");
            LogBuilder.Insert(0, "Operation Type = " + data.accessType.ToString() + "   Result = " + data.resultType + "\r\n");
            UpdateLogTb(LogBuilder.ToString());
        }

        void ReaderCE_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            switch (e.State)
            {
                case ReaderOperationMode.Idle:
                    //Device.MelodyPlay(Device.RingTone.T1, Device.BUZZER_SOUND.HIGH);
                    break;
                case ReaderOperationMode.Running:
                    //Device.MelodyPlay(Device.RingTone.T2, Device.BUZZER_SOUND.HIGH);
                    break;
                case ReaderOperationMode.SearchDone:
                    break;
                case ReaderOperationMode.Stopping:
                    break;
                case ReaderOperationMode.WriteDone:
                    break;
                case ReaderOperationMode.DeviceNotFound:
                    break;
            }
        }

        #endregion

        #region Delegate
        private delegate void UpdateLogTbDeleg(string msg);
        private void UpdateLogTb(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateLogTbDeleg(UpdateLogTb), new object[] { msg });
                return;
            }
            tb_log.Text = msg;
        }
        private delegate void ShowMsgDeleg(string msg);
        private void ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowMsgDeleg(ShowMsg), new object[] { msg });
                return;
            }
            MessageBox.Show(msg);
        }
        #endregion

        #region Button Handle
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            //Program.ReaderCE.SetQueryParms(GetSelect(), (Session)cb_tg_session.SelectedIndex, (SessionTarget)cb_tg_target.SelectedIndex, (uint)nb_alg_qsize.Value, (uint)(cb_alg_toggle.Checked ? 1 : 0), (uint)nb_alg_retry.Value, (SingulationAlgorithm)cb_alg.SelectedIndex);
            Program.ReaderCE.SelectTag(32, 96, MemoryBank.EPC, (Action)cb_sel_action.SelectedIndex, (Target)cb_sel_target.SelectedIndex, false, HexEncoding.GetBytes(TargetEPC));
            Program.ReaderCE.RdrOpParms.RunBasicReadParms.Flags = Reader.Constants.ReaderFlag.SELECT;
            Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
            Program.ReaderCE.RdrOpParms.RunBasicReadParms.Offset = 2;
            Program.ReaderCE.RdrOpParms.RunBasicReadParms.Count = 6;
            Program.ReaderCE.RdrOpParms.TargetMemBank = MemoryBank.EPC;
            Program.ReaderCE.RdrOpParms.Operation = Operation.Read;
            Program.ReaderCE.Start();
        }
        private Selected GetSelect()
        {
            switch (cb_tg_select.SelectedIndex)
            {
                case 0: return Selected.ALL;
                case 1: return Selected.ON;
                case 2: return Selected.OFF;
            }
            return Selected.UNKNOWN;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            LogBuilder.Remove(0, LogBuilder.Length);
            tb_log.Text = String.Empty;
        }
        #endregion
    }
}