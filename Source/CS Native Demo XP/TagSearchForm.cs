using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagSearchForm : Form
    {
        private TagDataModel m_tagTable = new TagDataModel(SlowFlags.INDEX | SlowFlags.PC | SlowFlags.EPC);
        private bool m_toggleStartBtn = false;
        private bool m_stop = false;

        public string pc
        {
            get
            {
                if (nTable1.CurrentRowIndex != -1)
                {
                    return m_tagTable.Items[nTable1.CurrentRowIndex].pc.ToString();
                }
                return String.Empty;
            }
        }
        public string epc
        {
            get
            {
                if (nTable1.CurrentRowIndex != -1)
                {
                    return m_tagTable.Items[nTable1.CurrentRowIndex].epc.ToString();
                }
                return String.Empty;
            }
        }
        #region Form
        public TagSearchForm()
        {
            InitializeComponent();
        }

        private void TagSearchForm_Load(object sender, EventArgs e)
        {
            //Table setting
            nTable1.BindModel(m_tagTable);//Bind empty table to draw column header
            nTable1.SetColumnWidth(0, 50);//Index column width
            nTable1.SetColumnWidth(1, 50);//Rssi column width
            
            //Attach Callback Event
            AttachCallback(true);
        }

        private void TagSearchForm_Closing(object sender, CancelEventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                m_stop = e.Cancel = true;
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }
        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
        }


        void ReaderXP_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                //Using asyn delegate to update UI
                if (e.type == CallbackType.TAG_INVENTORY)
                {
                    //Device.BuzzerOn(2000, 40, BUZZER_SOUND.HIGH);

                    UpdateRecords(e.info);
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
                            //Device.MelodyPlay(RingTone.T1, BUZZER_SOUND.HIGH);
                            ToggleButton();
                            EnableForm(true);
                        }
                        else
                        {
                            CloseForm();
                        }
                        break;
                    case RFState.BUSY:
                        //Device.MelodyPlay(RingTone.T2, BUZZER_SOUND.HIGH);
                        ToggleButton();
                        break;
                    case RFState.ABORT:
                        EnableForm(false); ;
                        break;
                }
            });
        }

        #endregion

        #region Delegate
        private delegate void ToggleButtonDel();
        private void ToggleButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ToggleButtonDel(ToggleButton), new object[] { });
                return;
            }
            if (m_toggleStartBtn)
            {
                m_toggleStartBtn = false;
                btn_search.Text = "Search";
                btn_search.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                m_toggleStartBtn = true;
                btn_search.Text = "Stop";
                btn_search.BackColor = Color.Red;
            }
        }

        private delegate void UpdateRecordsDel(object data);
        private void UpdateRecords(object data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateRecordsDel(UpdateRecords), new object[] { data });
                return;
            }
            TagCallbackInfo record = (TagCallbackInfo)data;
            if (record != null)
            {
                m_tagTable.AddItem(record);
                lb_tagCount.Text = m_tagTable.Items.Count.ToString();
            }
        }

        private delegate void CloseFormDeleg();
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseFormDeleg(CloseForm), new object[] { });
                return;
            }
            DialogResult = DialogResult.OK;
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

        #region Control Handle
        public void Start()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                //Clear list
                m_tagTable.Clear();
                Program.ReaderXP.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);

                if (Program.appSetting.tagGroup.selected == Selected.ALL)
                {
                    Program.ReaderXP.Options.TagInventory.flags = SelectFlags.ZERO;
                }
                else
                {
                    Program.ReaderXP.Options.TagInventory.flags = SelectFlags.SELECT;

                    Program.ReaderXP.Options.TagGeneralSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                    switch (Program.appSetting.MaskBank)
                    {
                        case 0:
                            Program.ReaderXP.Options.TagGeneralSelected.bank = MemoryBank.EPC;
                            Program.ReaderXP.Options.TagGeneralSelected.epcMask = new S_MASK(Program.appSetting.Mask);
                            Program.ReaderXP.Options.TagGeneralSelected.epcMaskOffset = Program.appSetting.MaskOffset;
                            Program.ReaderXP.Options.TagGeneralSelected.epcMaskLength = Program.appSetting.MaskBitLength;
                            break;

                        case 1:
                            Program.ReaderXP.Options.TagGeneralSelected.bank = MemoryBank.EPC;
                            Program.ReaderXP.Options.TagGeneralSelected.flags |= SelectMaskFlags.ENABLE_PC_MASK;
                            Program.ReaderXP.Options.TagGeneralSelected.epcMask = new S_MASK(Program.appSetting.Mask);
                            Program.ReaderXP.Options.TagGeneralSelected.epcMaskOffset = Program.appSetting.MaskOffset;
                            Program.ReaderXP.Options.TagGeneralSelected.epcMaskLength = Program.appSetting.MaskBitLength;
                            break;

                        case 2:
                        case 3:
                            Program.ReaderXP.Options.TagGeneralSelected.bank = (MemoryBank)Program.appSetting.MaskBank;
                            Program.ReaderXP.Options.TagGeneralSelected.Mask = CSLibrary.Text.HexEncoding.ToBytes(Program.appSetting.Mask);
                            Program.ReaderXP.Options.TagGeneralSelected.MaskOffset = Program.appSetting.MaskOffset;
                            Program.ReaderXP.Options.TagGeneralSelected.MaskLength = Program.appSetting.MaskBitLength;
                            break;
                    }
                    Program.ReaderXP.StartOperation(Operation.TAG_GENERALSELECTED, true);
                }


                Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
            }
        }

        private void Stop()
        {
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
//                while (Program.ReaderXP.State == RFState.BUSY)
//                    Thread.Sleep(1);
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Start();
            }
            else if (Program.ReaderXP.State == RFState.BUSY)
            {
                Stop();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nTable1_RowChanged(int rowIndex)
        {
            btn_select.Enabled = (rowIndex != -1);
        }
        #endregion
    }
}