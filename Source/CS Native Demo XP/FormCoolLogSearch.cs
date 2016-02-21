#define NONBLOCKING
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Text;



    public partial class FormCoolLogSearch : Form
    {
        #region Private Member

        private int m_totaltag = 0;

        private bool m_stop = false;

        private bool m_selected = false;

        private TagDataModel m_tagTable = new TagDataModel(SlowFlags.INDEX | SlowFlags.PC | SlowFlags.EPC);

        private DateTime timeStarted = DateTime.MinValue;

        enum ButtonState : int
        {
            Start = 0,
            Stop,
            Select,
            Unknow
        }

        #endregion

        #region Form
        public FormCoolLogSearch()
        {
            InitializeComponent();
        }

        public FormCoolLogSearch(bool selectable)
        {
            InitializeComponent();

            m_selected = selectable;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            //Third Step (Attach to Form)
            AttachCallback(true);
            nTable.BindModel(m_tagTable);
            nTable.SetColumnWidth(0, 50);
            nTable.SetColumnWidth(1, 50);

//            startMenu1.ShowSortFlag = SlowFlags.PC | SlowFlags.EPC | SlowFlags.INDEX;
        }

        private void SearchForm_Closing(object sender, CancelEventArgs e)
        {
            //Fourth Step (Dettach from Form and Stop)
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
                Program.ReaderXP.OnStateChanged +=new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
//                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
//                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
        }

        void ReaderXP_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            Invoke((System.Threading.ThreadStart)delegate()
            {
                //Using asyn delegate to update UI
                if (e.type == CallbackType.TAG_INVENTORY)
                {
                    string tid = e.info.epc.ToString().Substring((int)e.info.pc.EPCLength * 4, 8);

                    // E0361094 / E03610A1
                    if (tid.Substring (0, 6) == "E03610")
                    {
                        m_totaltag++;

                        e.info.epc = new S_EPC(e.info.epc.ToString().Substring(0, (int)e.info.pc.EPCLength * 4));

                        UpdateRecords(e.info);
                    }

                    if (Program.appSetting.Cfg_blocking_mode)
                    {
                        Application.DoEvents();
                    }
                }
            });
        }

        void ReaderXP_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case RFState.IDLE:
                        EnableUpdate(false);
                        if (!m_stop)
                        {
                            m_totaltag = 0;
//                            Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                            //startMenu1.ToggleStartButton();
                            EnableForm(true);
                            RefreshListView();
                        }
                        else
                        {
                            CloseForm();
                        }
                        break;
                    case RFState.BUSY:
                        EnableUpdate(true);
//                        Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                        //startMenu1.ToggleStartButton();
//                        timeStarted = DateTime.Now;
                        break;
                    case RFState.ABORT:
                        EnableForm(false);
                        break;
                    case RFState.RESET:
                        EnableUpdate(false);
                        Program.ReaderXP.Reconnect(10);
                        Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
                        EnableUpdate(true);
                        break;
                }
            });
        }

        void ReaderXP_TagCompletedEvent(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                if (e.access == TagAccess.READ)
                {
                    switch (e.bank)
                    {
                        case Bank.USER:
                            if (e.success)
                            {
//                                UpdateBankInfo(e.bank, Program.ReaderXP.Options.TagReadUser.pData.ToString());
                            }
                            break;
                    }
                }
            });
        }

        #endregion

        #region UI Update
        private void UpdateRecords(object data)
        {
            TagCallbackInfo record = (TagCallbackInfo)data;
            if (record != null)
            {
                m_tagTable.AddItem(record);
            }
        }
        private void EnableUpdate(bool en)
        {
            tmr_readrate.Enabled = en;
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void EnableForm(bool en)
        {
            this.Enabled = en;
        }
        private void RefreshListView()
        {
//            m_tagTable.Redraw();
        }
        private void nTable_RowChanged(int rowIndex)
        {
            if (m_selected)
            {
                //startMenu1.UpdateStartBtn(true);
            }
        }

        private void tmr_readrate_Tick(object sender, EventArgs e)
        {
            RefreshListView();
            //startMenu1.UpdateTagCount(m_totaltag);
            //startMenu1.UpdateTimeElapsed(((TimeSpan)DateTime.Now.Subtract(timeStarted)).TotalSeconds);
//            Device.BuzzerOn(3000, 40, BuzzerVolume.HIGH);
        }
        #endregion

        #region Button Handle

        public void Start()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                m_tagTable.Clear();
                Program.ReaderXP.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);

                Program.ReaderXP.Options.TagInventory.flags = SelectFlags.ZERO;

                Program.ReaderXP.Options.TagInventory.multibanks = 2;
                Program.ReaderXP.Options.TagInventory.bank1 = MemoryBank.TID;
                Program.ReaderXP.Options.TagInventory.offset1 = 0;
                Program.ReaderXP.Options.TagInventory.count1 = 2;

                Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
//                Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
            }
        }

        private void Stop()
        {
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
            }
        }

        private void Save()
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.OpenOrCreate))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        if (m_tagTable.Items.Count > 0)
                        {
                            DateTime date = DateTime.Now;
                            foreach (TagCallbackInfo data in m_tagTable.Items)
                                sw.WriteLine(string.Format("{0},{1},{2},{3}", date, data.pc.ToString(), data.epc.ToString(), data.rssi));
                        }
                        sw.Flush();
                    }
                }
            }
        }
        /*
         * void startMenu1_OnButtonClick(ButtonClickType type)
                {
                    switch (type)
                    {
                        case ButtonClickType.Clear:
                            m_tagTable.Clear();
                            break;
                        case ButtonClickType.Exit:
                            this.Close();
                            break;
                        case ButtonClickType.Hide:
                        case ButtonClickType.Unhide:
                            //Resize list
                            //nTable.Height = 240 - startMenu1.Height;
                            break;
                        case ButtonClickType.Save:
                            Save();
                            break;
                        case ButtonClickType.Start:
                            Start();
                            break;
                        case ButtonClickType.Stop:
                            Stop();
                            break;
                        case ButtonClickType.Sorting:
                            switch (startMenu1.SortingMethod)
                            {
                                case Sorting.EPC_Ascending:
                                    m_tagTable.SortMethod = SortIndex.EPC;
                                    m_tagTable.Ascending = true;
                                    break;
                                case Sorting.EPC_Decending:
                                    m_tagTable.SortMethod = SortIndex.EPC;
                                    m_tagTable.Ascending = false;
                                    break;
                                case Sorting.PC_Ascending:
                                    m_tagTable.SortMethod = SortIndex.PC;
                                    m_tagTable.Ascending = true;
                                    break;
                                case Sorting.PC_Decending:
                                    m_tagTable.SortMethod = SortIndex.PC;
                                    m_tagTable.Ascending = false;
                                    break;
                                case Sorting.INDEX_Ascending:
                                    m_tagTable.SortMethod = SortIndex.INDEX;
                                    m_tagTable.Ascending = true;
                                    break;
                                case Sorting.INDEX_Decending:
                                    m_tagTable.SortMethod = SortIndex.INDEX;
                                    m_tagTable.Ascending = false;
                                    break;
                            }
                            m_tagTable.Sort();
                            m_tagTable.Redraw();
                            break;
                    }
                }
        */

        #endregion

        private void startMenu1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
//            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;

            for (int cnt = 0; cnt < nTable.Model.GetRowCount(); cnt++)
            {
                if (!nTable.IsRowSelected(cnt))
                    continue;

                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(m_tagTable.Items[cnt].epc.ToString());
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)m_tagTable.Items[cnt].pc.EPCLength * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed : " + m_tagTable.Items[cnt].epc.ToString());
                    return;
                }

                Thread.Sleep(10);
                Program.ReaderXP.Options.CLInit.TimerEnable = EnableSwitch.Enable;
                if (Program.ReaderXP.StartOperation(Operation.CL_INIT, true) != Result.OK)
                {
                    MessageBox.Show("Tag Init failed : " + m_tagTable.Items[cnt].epc.ToString());
                    return;
                }

                Thread.Sleep(10);
                Program.ReaderXP.Options.CLSetLogMode.LoggingForm = LoggingForm.Dense;
                Program.ReaderXP.Options.CLSetLogMode.LogInterval = (ushort)(FormCoolLog.TimeInterval);
                Program.ReaderXP.Options.CLSetLogMode.StorageRule = StorageRule.Normal;
                Program.ReaderXP.Options.CLSetLogMode.Ext1SensorEnable = EnableSwitch.Disable;
                Program.ReaderXP.Options.CLSetLogMode.Ext2SensorEnable = EnableSwitch.Disable;
                Program.ReaderXP.Options.CLSetLogMode.BatteryCheckEnable = EnableSwitch.Disable;
                Program.ReaderXP.Options.CLSetLogMode.TempSensorEnable = EnableSwitch.Enable;
                if (Program.ReaderXP.StartOperation(Operation.CL_SET_LOG_MODE, true) != Result.OK)
                {
                    MessageBox.Show("Set Log Mode failed : " + m_tagTable.Items[cnt].epc.ToString());
                    return;
                }

                Thread.Sleep(10);
                Program.ReaderXP.Options.CLStartLog.Year = (byte)(DateTime.Now.Year - 2010);
                Program.ReaderXP.Options.CLStartLog.Month = (byte)(DateTime.Now.Month);
                Program.ReaderXP.Options.CLStartLog.Day = (byte)(DateTime.Now.Day);
                Program.ReaderXP.Options.CLStartLog.Hour = (byte)(DateTime.Now.Hour);
                Program.ReaderXP.Options.CLStartLog.Minute = (byte)(DateTime.Now.Minute);
                Program.ReaderXP.Options.CLStartLog.Second = (byte)(DateTime.Now.Second);
                Program.ReaderXP.Options.CLStartLog.StartTime = 0;
                if (Program.ReaderXP.StartOperation(Operation.CL_START_LOG, true) != Result.OK)
                {
                    MessageBox.Show("Start Log failed : " + m_tagTable.Items[cnt].epc.ToString());
                    return;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < nTable.Model.GetRowCount(); cnt++)
            {
                if (!nTable.IsRowSelected(cnt))
                    continue;

                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(m_tagTable.Items[cnt].epc.ToString());
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)m_tagTable.Items[cnt].pc.EPCLength * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed : " + m_tagTable.Items[cnt].epc.ToString());
                    return;
                }

                if (Program.ReaderXP.StartOperation(Operation.CL_END_LOG, true) != Result.OK)
                {
                    MessageBox.Show("End Log failed : " + m_tagTable.Items[cnt].epc.ToString());
                }

                button1.Enabled = true;
                //            button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int totaltag = 0;
            int totalrecord = 0;

            string LogFileName = FormCoolLog.datapath + "CoolLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            System.IO.StreamWriter logFilehandler;
            
            
//            bool fe = System.IO.File.Exists(LogFileName);

            try
            {
                logFilehandler = new System.IO.StreamWriter(LogFileName, true, Encoding.Unicode);
            }
            catch (Exception err)
            {
                MessageBox.Show("Can not write to log file : " + LogFileName + " reson : " + err.ToString ());
                return;
            }

            for (int cnt1 = 0; cnt1 < nTable.Model.GetRowCount(); cnt1++)
            {
                if (!nTable.IsRowSelected(cnt1))
                    continue;

                totaltag++;
                
                // Select Tag
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(m_tagTable.Items[cnt1].epc.ToString());
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)m_tagTable.Items[cnt1].pc.EPCLength * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    logFilehandler.WriteLine("Can not Select the tag : {0}", m_tagTable.Items[cnt1].epc.ToString());
                }
                else
                {
                    logFilehandler.WriteLine("Tag ID : {0}", m_tagTable.Items[cnt1].epc.ToString());

                    // Get Log State
                    Program.ReaderXP.Options.CLGetLogState.ShelfLifeFlag = EnableSwitch.Disable;

                    if (Program.ReaderXP.StartOperation(Operation.CL_GET_LOG_STATE, true) != Result.OK)
                    {
                        MessageBox.Show("Get Log State failed");
                        logFilehandler.WriteLine("Can not get Log State");
                    }
                    else
                    {
                        int record = Program.ReaderXP.Options.CLGetLogState.LogStateData[7] >> 1;
                        //                    int record = 840;

                        totalrecord += record;

                        // Get data Log
                        Program.ReaderXP.Options.TagReadUser.accessPassword = 0;
                        Program.ReaderXP.Options.TagReadUser.retryCount = 2;
                        Program.ReaderXP.Options.TagReadUser.offset = 0;
                        Program.ReaderXP.Options.TagReadUser.count = (ushort)((record * 10 + 15) / 16);

                        if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                        {
                            MessageBox.Show("Read Bank 3 failed");
                            logFilehandler.WriteLine("Can not read User Bank");
                        }
                        else
                        {
                            byte[] Data = Program.ReaderXP.Options.TagReadUser.pData.ToBytes();

                            for (int cnt = 0; cnt < record; cnt++)
                            {
                                int value = 0;
                                int block = cnt * 10 / 8;
                                double temp;

                                switch (cnt % 4)
                                {
                                    case 0:
                                        value = (Data[block] << 2 | Data[block + 1] >> 6) & 0x3ff;
                                        break;

                                    case 1:
                                        value = (Data[block] << 4 | Data[block + 1] >> 4) & 0x3ff;
                                        break;

                                    case 2:
                                        value = (Data[block] << 6 | Data[block + 1] >> 2) & 0x3ff;
                                        break;

                                    case 3:
                                        value = (Data[block] << 8 | Data[block + 1]) & 0x3ff;
                                        break;
                                }

                                // temp = value * 0.32436 + 58.99713; // for notmatch tag
                                temp = ((short)value) * 0.1505965 - 118.938511; // for original tag
                                logFilehandler.WriteLine("{0}", temp);
                            }

                            MessageBox.Show("Finish : Total " + totaltag.ToString () + " tags / total " + totalrecord.ToString() + " records");
                        }
                    }
                }
            }
            logFilehandler.Close ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Search")
            {
                if (Program.ReaderXP.State == RFState.IDLE)
                {
                    m_tagTable.Clear();

                    button1.Text = "Stop";
//                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;

                    Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                    Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                    Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);

                    Program.ReaderXP.Options.TagInventory.flags = SelectFlags.ZERO;
                    Program.ReaderXP.Options.TagInventory.multibanks = 2;
                    Program.ReaderXP.Options.TagInventory.bank1 = MemoryBank.TID;
                    Program.ReaderXP.Options.TagInventory.offset1 = 0;
                    Program.ReaderXP.Options.TagInventory.count1 = 2;
                    /*
                     * Program.ReaderXP.Options.TagInventory.bank2 = MemoryBank.USER;
                                    Program.ReaderXP.Options.TagInventory.offset2 = 0;
                                    Program.ReaderXP.Options.TagInventory.count2 = 2;
                    */

                    Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
                    //                Program.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
                }
            }
            else if (button1.Text == "Stop")
            {
                button1.Text = "Search";
//                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;

                if (Program.ReaderXP.State == RFState.BUSY)
                {
                    Program.ReaderXP.StopOperation(true);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = FormCoolLog.datapath;
            dialog.Title = "Select a Cool Log file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
//                LogFileName = logFilePath + CSLibrary.Device.Device.GetSerialNumber() + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                System.Diagnostics.ProcessStartInfo viewLog = new System.Diagnostics.ProcessStartInfo("Notepad.exe", "\"" + dialog.FileName + "\"");

                System.Diagnostics.Process.Start(viewLog);
            }
        }

/*
 * private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Select All")
            {
                button3.Text = "Deselect All";

                for (int cnt = 0; cnt < nTable.Model.GetRowCount(); cnt++)
                {
                    nTable.Select(cnt, 1);
                }
            }
            else
            {
                button3.Text = "Select All";

                for (int cnt = 0; cnt < nTable.Model.GetRowCount(); cnt++)
                {
                    nTable.Deselect(cnt);
                }
            }

            nTable.Refresh();

        }
*/
    }
}
