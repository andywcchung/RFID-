using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CSLibrary.Text;
using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary;


namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagKillForm : Form
    {
        #region private member
        private const string m_epc_info = "Click here to select a tag to destroy.";
        
        private bool m_stop = false;
        #endregion

        #region Form
        public TagKillForm()
        {
            InitializeComponent();
        }

        private void TagKillForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
            cb_extCmd.SelectedIndex = 0;
        }

        private void TagKillForm_Closing(object sender, CancelEventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                e.Cancel = m_stop = true;
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }
        #endregion

        #region Button Handle
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_kill_Click(object sender, EventArgs e)
        {
            if (/*tb_access_password.ToUInt32 == 0 ||*/tb_kill_password.ToUInt32 == 0 || lk_epc.Text == m_epc_info)
            {
                MessageBox.Show("kill password must be non-zero, please change it and do it again.", "Warning!");
                return;
            }
            if (Program.ReaderXP.State == CSLibrary.Constants.RFState.IDLE)
            {
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(lk_epc.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(lk_epc.Text);

                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected a tag failed");
                    return;
                }
                Program.ReaderXP.Options.TagKill.retryCount = 7;
                Program.ReaderXP.Options.TagKill.killPassword = tb_kill_password.ToUInt32;
                Program.ReaderXP.Options.TagKill.extCommand = EnumExtCommand();
                Program.ReaderXP.Options.TagKill.flags = SelectFlags.SELECT;

                if (Program.ReaderXP.StartOperation(Operation.TAG_KILL, false) != Result.OK)
                {
                    MessageBox.Show("StartOperation failed");
                    return;
                }
            }
        }
        private void lk_epc_Click(object sender, EventArgs e)
        {
            //Stop current process
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
            }
            AttachCallback(false);
            using (TagSearchForm InvForm = new TagSearchForm())
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    lk_epc.Text = InvForm.epc;
                }
            }
            AttachCallback(true);
        }
        #endregion

        #region Event callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
            else
            {
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
        }

        void ReaderXP_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                if (e.access == TagAccess.KILL)
                {
                    resultForm1.UpdateResult(e.success);
                }
            });
        }

        void ReaderXP_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case RFState.IDLE:
                        if (!m_stop)
                        {
                            //Device.MelodyPlay(CSLibrary.Device.RingTone.T1, BUZZER_SOUND.HIGH);
                        }
                        else
                        {
                            CloseForm();
                        }
                        EnableForm(true);
                        break;
                    case RFState.BUSY:
                        //Device.MelodyPlay(CSLibrary.Device.RingTone.T2, BUZZER_SOUND.HIGH);
                        break;
                    case RFState.ABORT:
                        EnableForm(false);
                        break;
                }
            });
        }

        #endregion

        #region Delegate
        private delegate void CloseFormDeleg();
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseFormDeleg(CloseForm), new object[] { });
                return;
            }
            this.Close();
        }
        private delegate void EnableFormDeleg(bool en);
        private void EnableForm(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableFormDeleg(EnableForm), new object[] { en });
                return;
            }
            this.Enabled = en;
        }
        #endregion

        private ExtendedKillCommand EnumExtCommand()
        {
            switch (cb_extCmd.SelectedIndex)
            {
                case 0: return ExtendedKillCommand.NORMAL;
                case 1: return ExtendedKillCommand.DISABLE_PERMALOCK;
                case 2: return ExtendedKillCommand.DISABLE_USER_MEMORY;
                case 3: return ExtendedKillCommand.UNLOCK_ALL_BANKS;
            }
            return ExtendedKillCommand.UNKNOWN;
        }

        private void lk_epc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}