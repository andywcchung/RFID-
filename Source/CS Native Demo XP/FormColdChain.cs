using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS101_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Device;
    using CSLibrary.Text;

    using CSLibrary.HotKeys;

    public partial class FormColdChain : Form
    {
        private int mStop = 0;

        public FormColdChain()
        {
            InitializeComponent();
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderCE.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                Program.ReaderCE.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                Program.ReaderCE.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderCE.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
        }

        void ColdChainInfo(TagCallbackInfo info)
        {
            string EPC;
            string LowBatAlarm;
            bool find = false;
            UInt16 SensorDataMsw, SensorDataLsw;
            UInt16 UtcMsw, UtcLsw;
            UInt16 StartTimeMsw, StartTimeLsw;
            string Temperature;
            string TempAlarm;
            bool bap = false;

            EPC = info.epc.ToString().Substring(0, (int)(info.pc.EPCLength * 4));

            SensorDataMsw = info.epc.ToUshorts()[info.pc.EPCLength + 2];
            SensorDataLsw = info.epc.ToUshorts()[info.pc.EPCLength + 3];
            UtcMsw = info.epc.ToUshorts()[info.pc.EPCLength + 4];
            UtcLsw = info.epc.ToUshorts()[info.pc.EPCLength + 5];
            StartTimeMsw = info.epc.ToUshorts()[info.pc.EPCLength + 7];
            StartTimeLsw = info.epc.ToUshorts()[info.pc.EPCLength + 8];

            if ((info.epc.ToUshorts()[info.pc.EPCLength + 15] & 0x0001) == 0x0001)
                bap = true;

            if (bap)
            {
                if ((SensorDataMsw & 0x0400) != 0)
                {
                    double Temp;
                    Temp = (SensorDataMsw & 0x00ff);
                    if ((SensorDataMsw & 0x0100) != 00)
                        Temp -= 256;
                    Temp *= 0.25;
                    if (Temp != -64)
                        Temperature = Temp.ToString();
                    else
                        Temperature = "";
                }
                else
                    Temperature = "NA";

                if ((SensorDataMsw & 0x3000) != 00)
                    TempAlarm = "Fail";
                else
                    TempAlarm = "OK";

                if ((SensorDataMsw & 0x8000) != 00)
                    LowBatAlarm = "Fail";
                else
                    LowBatAlarm = "OK";
            }
            else
            {
                Temperature = "BAPOFF";
                TempAlarm = "";
                LowBatAlarm = "";
            }

            for (int cnt = 0; cnt < listView1.Items.Count; cnt++)
            {
                if (listView1.Items[cnt].SubItems[1].Text == EPC)
                {
                    find = true;
                    listView1.Items[cnt].SubItems[2].Text = Temperature;
                    listView1.Items[cnt].SubItems[3].Text = TempAlarm;
                    listView1.Items[cnt].SubItems[4].Text = LowBatAlarm;
                    listView1.Items[cnt].SubItems[5].Text = SensorDataMsw.ToString();
                    listView1.Items[cnt].SubItems[6].Text = SensorDataLsw.ToString();
                    listView1.Items[cnt].SubItems[7].Text = UtcMsw.ToString();
                    listView1.Items[cnt].SubItems[8].Text = UtcLsw.ToString();
                    listView1.Items[cnt].SubItems[9].Text = StartTimeMsw.ToString();
                    listView1.Items[cnt].SubItems[10].Text = StartTimeLsw.ToString();
                    listView1.Items[cnt].ForeColor = Color.Black;
                    break;
                }
            }

            if (find == false)
            {
                ListViewItem ins = new ListViewItem((listView1.Items.Count + 1).ToString ());
                ins.SubItems.Add(EPC);
                ins.SubItems.Add(Temperature);
                ins.SubItems.Add(TempAlarm);
                ins.SubItems.Add(LowBatAlarm);
                ins.SubItems.Add(SensorDataMsw.ToString ());
                ins.SubItems.Add(SensorDataLsw.ToString());
                ins.SubItems.Add(UtcMsw.ToString());
                ins.SubItems.Add(UtcLsw.ToString());
                ins.SubItems.Add(StartTimeMsw.ToString());
                ins.SubItems.Add(StartTimeLsw.ToString());
                ins.ForeColor = Color.Black;
                listView1.Items.Add(ins);
            }
        }

        void BapInfo(TagCallbackInfo info)
        {
            string EPC;
            string BAP;
            bool find = false;

            EPC = info.epc.ToString().Substring(0, (int)((info.pc.EPCLength) * 4));

            if ((info.epc.ToUshorts()[info.pc.EPCLength + 2] & 0x01) != 0)
                BAP = "Enable";
            else
                BAP = "Disable";

            for (int cnt = 0; cnt < listView2.Items.Count; cnt++)
            {
                if (listView2.Items[cnt].SubItems[1].Text == EPC)
                {
                    find = true;
                    listView2.Items[cnt].SubItems[2].Text = BAP;
                    break;
                }
            }

            if (find == false)
            {
                ListViewItem ins = new ListViewItem((listView2.Items.Count + 1).ToString ());
                ins.SubItems.Add(EPC);
                ins.SubItems.Add(BAP);
                listView2.Items.Add(ins);
            }
        }

        void Reader_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                UInt32 tid;
                UInt64 uid;
                UInt16[] tagdata = e.info.epc.ToUshorts();

                try
                {
                    if (e.type == CallbackType.TAG_RANGING)
                    {
                        if (e.info.epc.GetLength() < e.info.pc.EPCLength + 2)
                            return;

                        tagdata = e.info.epc.ToUshorts();
                        //tid = (UInt32)((e.info.epc.ToUshorts()[e.info.pc.EPCLength] << 16) | e.info.epc.ToUshorts()[e.info.pc.EPCLength + 1]) & 0xffffffc0U;
                        tid = (UInt32)((tagdata[e.info.pc.EPCLength] << 16) | tagdata[e.info.pc.EPCLength + 1]) & 0xffffffc0U;
                        
                        if (tid != 0xe280b040U && tid != 0xe2801100U)
                            return;

                        switch (tabControl1.SelectedIndex)
                        {
                            case 0: // Info Page
                                ColdChainInfo(e.info);
                                break;

                            case 1: // Tag Monitor
                                break;

                            case 2: // Temp Log
                                {
                                    string EPC = e.info.epc.ToString().Substring(0, (int)((e.info.pc.EPCLength) * 4));
                                    bool find = false;

                                    for (int cnt = 0; cnt < listView4.Items.Count; cnt++)
                                    {
                                        if (listView4.Items[cnt].SubItems[1].Text == EPC)
                                        {
                                            find = true;
                                            switch (tagdata[e.info.pc.EPCLength + 2] & 0x03)
                                            {
                                                case 0:
                                                case 2:
                                                    listView4.Items[cnt].SubItems[2].Text = "Stop";
                                                    break;
                                                case 1:
                                                    listView4.Items[cnt].SubItems[2].Text = "Recording";
                                                    break;
                                                case 3:
                                                    listView4.Items[cnt].SubItems[2].Text = "Error";
                                                    break;
                                            }

                                            if ((tagdata[e.info.pc.EPCLength + 6] & 0x02) != 0)
                                                listView4.Items[cnt].SubItems[3].Text = "Fail";
                                            else
                                                listView4.Items[cnt].SubItems[3].Text = "OK";

                                            break;
                                        }
                                    }

                                    if (!find)
                                    {
                                        ListViewItem ins = new ListViewItem((listView4.Items.Count + 1).ToString ());
                                        ins.SubItems.Add(EPC);
                                        switch (tagdata[e.info.pc.EPCLength + 2] &0x03)
                                        {
                                            case 0:
                                            case 2:
                                                ins.SubItems.Add("Stop");
                                                break;
                                            case 1:
                                                ins.SubItems.Add("Recording");
                                                break;
                                            case 3:
                                                ins.SubItems.Add("Error");
                                                break;
                                        }

                                        if ((tagdata[e.info.pc.EPCLength + 6] & 0x02) != 0)
                                            ins.SubItems.Add("Fail");
                                        else
                                            ins.SubItems.Add("OK");
                                        
                                        listView4.Items.Add(ins);
                                    }
                                }
                                break;

                            case 3: // Get Log
                                BapInfo(e.info);
                                break;

                            case 4: // Init Tag
                                BapInfo(e.info);
                                break;

                            case 5: // Calibration
                                {
                                    string EPC = e.info.epc.ToString().Substring(0, (int)((e.info.pc.EPCLength) * 4));
                                    bool find = false;

                                    uid = (UInt64)((tagdata[e.info.pc.EPCLength + 2] << 48) | (tagdata[e.info.pc.EPCLength + 3] << 32) | (tagdata[e.info.pc.EPCLength + 4] << 16) | tagdata[e.info.pc.EPCLength + 5]);
                                    for (int cnt = 0; cnt < listView3.Items.Count; cnt++)
                                    {
                                        if (listView3.Items[cnt].SubItems[1].Text == EPC)
                                        {
                                            find = true;
                                            break;
                                        }
                                    }

                                    if (!find)
                                    {
                                        ListViewItem ins = new ListViewItem((listView3.Items.Count + 1).ToString ());
                                        ins.SubItems.Add(EPC);
                                        ins.SubItems.Add("Found");
                                        ins.SubItems.Add(uid.ToString ("X16"));
                                        listView3.Items.Add(ins);
                                    }
                                }

                                break;

                            case 6: // Exit
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }

        void ReaderCE_OnAccessCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.access)
                {
                    case TagAccess.WRITE:
                        if (e.success)
                        {

                        }
                        else
                        {
                        }
                        break;

                    case TagAccess.READ:
                        if (e.success && e.bank == Bank.EPC)
                        {
//                            Debug.WriteLine("EPC = " + e.data.ToString());
                        }
                        else
                        {
//                            Debug.WriteLine(string.Format("Read {0} error", e.bank));
                        }
                        break;
                }
            });
        }

        void StartInventory()
        {
            Program.ReaderCE.SetOperationMode(RadioOperationMode.CONTINUOUS);
            Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
            Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
            Program.ReaderCE.Options.TagRanging.flags = SelectFlags.ZERO;

            Program.ReaderCE.Options.TagRanging.multibanks = 2;
            Program.ReaderCE.Options.TagRanging.bank1 = MemoryBank.TID;
            Program.ReaderCE.Options.TagRanging.offset1 = 0;
            Program.ReaderCE.Options.TagRanging.count1 = 2;
            Program.ReaderCE.Options.TagRanging.bank2 = MemoryBank.BANK3;  // Read 256 - 269
            Program.ReaderCE.Options.TagRanging.offset2 = 256;
            Program.ReaderCE.Options.TagRanging.count2 = 14;
            Program.ReaderCE.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING_READ_BANKS, false);
        }

        void StartInventoryBapMode()
        {
            Program.ReaderCE.SetOperationMode(RadioOperationMode.CONTINUOUS);
            Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
            Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
            Program.ReaderCE.Options.TagRanging.flags = SelectFlags.ZERO;

            Program.ReaderCE.Options.TagRanging.multibanks = 2;
            Program.ReaderCE.Options.TagRanging.bank1 = MemoryBank.TID;
            Program.ReaderCE.Options.TagRanging.offset1 = 0;
            Program.ReaderCE.Options.TagRanging.count1 = 2;
            Program.ReaderCE.Options.TagRanging.bank2 = MemoryBank.BANK3;
            Program.ReaderCE.Options.TagRanging.offset2 = 269;
            Program.ReaderCE.Options.TagRanging.count2 = 1;
            Program.ReaderCE.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING_READ_BANKS, false);
        }

        void StartInventoryTempLog()
        {
            Program.ReaderCE.SetOperationMode(RadioOperationMode.CONTINUOUS);
            Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
            Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
            Program.ReaderCE.Options.TagRanging.flags = SelectFlags.ZERO;

            Program.ReaderCE.Options.TagRanging.multibanks = 2;
            Program.ReaderCE.Options.TagRanging.bank1 = MemoryBank.TID;
            Program.ReaderCE.Options.TagRanging.offset1 = 0;
            Program.ReaderCE.Options.TagRanging.count1 = 2;
            Program.ReaderCE.Options.TagRanging.bank2 = MemoryBank.BANK3;
            Program.ReaderCE.Options.TagRanging.offset2 = 260;
            Program.ReaderCE.Options.TagRanging.count2 = 5;
            Program.ReaderCE.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING_READ_BANKS, false);
        }

        void Reader_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case RFState.IDLE:
                        break;
                    case RFState.BUSY:
                        //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                        break;
                    case RFState.ABORT:
                        break;
                    case RFState.RESET:
                        break;
                }
            });
        }

        void HotKey_OnKeyEvent(Key KeyCode, bool KeyDown)
        {
            switch (KeyCode)
            {
                case Key.F4:
                    //PowerUp
                    if (KeyDown)
                        Program.Power.PowerUp();
                    break;

                case Key.F5:
                    //PowerDown
                    if (KeyDown)
                        Program.Power.PowerDown();
                    break;

                case Key.F11:
                    if (KeyDown)
                        btn_start_Click(this, null);
                    break;
            }
        }

        private void FormColdChain_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            AttachCallback(true);

            timer1.Enabled = true;
        }

        private void FormColdChain_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
            AttachCallback(false);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                btn_start.Text = "Stop";

                listView1.Clear();

                this.listView1.Columns.Add(this.columnHeader18);
                this.listView1.Columns.Add(this.columnHeader1);
                this.listView1.Columns.Add(this.columnHeader2);
                this.listView1.Columns.Add(this.columnHeader3);
                this.listView1.Columns.Add(this.columnHeader4);

                StartInventory();
            }
            else
            {
                btn_start.Text = "Start";
                Program.ReaderCE.StopOperation(true);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                Program.ReaderCE.StopOperation(true);
                Thread.Sleep(5000);
            }
            this.Close();
        }


        bool Monitor_Enable(string EPC, Double UnderTempThreshold, Double OverTempThreshold, UInt16 DelayUnit, UInt16 DelayValue, UInt16 IntervalUnit, UInt16 IntervalValue, bool ShowError)
        {
            Int16 value;
            UInt16 v;
            string Cmd;

            UnderTempThreshold = UnderTempThreshold / .25;
            OverTempThreshold = OverTempThreshold / .25;

            value = (Int16)(UnderTempThreshold);
            v = (UInt16)((UInt16)(value & 0x1ff) | 0x4800);
            Cmd = v.ToString("X4");

            value = (Int16)(OverTempThreshold) ;
            v = (UInt16)((UInt16)(value & 0x1ff) | 0x4400);
            Cmd += v.ToString("X4");

            UInt16 TSCW3 = (UInt16)((DelayUnit << 14) | (DelayValue << 8) | (IntervalUnit << 6) | IntervalValue);
            Cmd += TSCW3.ToString("X4");

            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(EPC);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

            if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Selected tag failed");
                return false;
            }

            Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
            Program.ReaderCE.Options.TagWriteUser.accessPassword = UInt32.Parse (textBox2.Text);

            Program.ReaderCE.Options.TagWriteUser.offset = 236;
            Program.ReaderCE.Options.TagWriteUser.count = 3;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts(Cmd);
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Set Parameter");
                return false;
            }

            Program.ReaderCE.Options.TagWriteUser.offset = 240;
            Program.ReaderCE.Options.TagWriteUser.count = 4;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("0188E00080070000");
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Set Parameter");
                return false;
            }

            Program.ReaderCE.Options.TagWriteUser.offset = 269;
            Program.ReaderCE.Options.TagWriteUser.count = 1;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("0001");
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Set Parameter");
                return false;
            }

            // Start Monitoring

            UInt16[] Now = new UInt16[5];
            Now[0] = 0x8000;
            Now[1] = 0x0000;
            Now[2] = 0x0000;
            Now[3] = (UInt16)(ConvertToUnixTimestamp(DateTime.Now) >> 16);
            Now[4] = (UInt16)(ConvertToUnixTimestamp (DateTime.Now) & 0xffff);

            Program.ReaderCE.Options.TagWriteUser.offset = 258;
            Program.ReaderCE.Options.TagWriteUser.count = 5;
            Program.ReaderCE.Options.TagWriteUser.pData = Now;
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Enable Monitor");
                return false;
            }

            Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
            Program.ReaderCE.Options.TagReadUser.retryCount = 7;
            Program.ReaderCE.Options.TagReadUser.offset = 256;
            Program.ReaderCE.Options.TagReadUser.count = 1;
            Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[2]);

            if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Monitor can not work");
                return false;
            }

            // Check Monitor Bit

            if ((Program.ReaderCE.Options.TagReadUser.pData.ToBytes()[0] & 0x04) == 0x000)
            {
                if (ShowError)
                    MessageBox.Show("Monitor can not work");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Int16 value;
                UInt16 v; 
                string Cmd;

                Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);

                Application.DoEvents();

                Double UnderTempThreshold = Double.Parse(textBox3.Text) / .25;
                Double OverTempThreshold = Double.Parse(textBox4.Text) / .25;

                value = (Int16)(UnderTempThreshold);
                v = (UInt16)((UInt16)(value & 0x1ff) | 0x4800);
                Cmd = v.ToString("X4");

                value = (Int16)(OverTempThreshold) ;
                v = (UInt16)((UInt16)(value & 0x1ff) | 0x4400);
                Cmd += v.ToString("X4");

                UInt16 TSCW3 = (UInt16)((comboBox1.SelectedIndex << 14) | (UInt16.Parse(textBox5.Text) << 8) | (comboBox2.SelectedIndex << 6) | UInt16.Parse(textBox6.Text));
                Cmd += TSCW3.ToString("X4");

                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(textBox1.Text);
                Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }

                Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                Program.ReaderCE.Options.TagWriteUser.accessPassword = UInt32.Parse (textBox2.Text);

#if nouse
                Program.ReaderCE.Options.TagWriteUser.offset = 236;
                Program.ReaderCE.Options.TagWriteUser.count = 8;
                //Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("480044C804064CC00188E00080070000");
                Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts(Cmd + "4CC00188E00080070000");
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                {
                    MessageBox.Show ("Cannot Set Parameter");
                    return;
                }

#else

            Program.ReaderCE.Options.TagWriteUser.offset = 236;
            Program.ReaderCE.Options.TagWriteUser.count = 3;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts(Cmd);
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                MessageBox.Show("Cannot Set Parameter");
                return;
            }

            Program.ReaderCE.Options.TagWriteUser.offset = 240;
            Program.ReaderCE.Options.TagWriteUser.count = 4;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("0188E00080070000");
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                MessageBox.Show("Cannot Set Parameter");
                return;
            }
#endif


                Program.ReaderCE.Options.TagWriteUser.offset = 269;
                Program.ReaderCE.Options.TagWriteUser.count = 1;
                Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("0001");
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                {
                    MessageBox.Show("Cannot Set Parameter");
                    return;
                }

                // Start Monitoring

                UInt16[] Now = new UInt16[5];
                Now[0] = 0x8000;
                Now[1] = 0x0000;
                Now[2] = 0x0000;
                Now[3] = (UInt16)(ConvertToUnixTimestamp(DateTime.Now) >> 16);
                Now[4] = (UInt16)(ConvertToUnixTimestamp (DateTime.Now) & 0xffff);

                Program.ReaderCE.Options.TagWriteUser.offset = 258;
                Program.ReaderCE.Options.TagWriteUser.count = 5;
                Program.ReaderCE.Options.TagWriteUser.pData = Now;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                {
                    MessageBox.Show("Cannot Enable Monitor");
                    return;
                }

                Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
                Program.ReaderCE.Options.TagReadUser.retryCount = 7;
                Program.ReaderCE.Options.TagReadUser.offset = 256;
                Program.ReaderCE.Options.TagReadUser.count = 1;
                Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[2]);

                if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                {
                    MessageBox.Show("Monitor can not work");
                    return;
                }

                // Check Monitor Bit

                if ((Program.ReaderCE.Options.TagReadUser.pData.ToBytes()[0] & 0x04) == 0x000)
                {
                    MessageBox.Show("Monitor can not work");
                    return;
                }

                MessageBox.Show("Enable Monitor Success");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                btn_start.Text = "Start";
                Program.ReaderCE.StopOperation(true);
            }

            switch (tabControl1.SelectedIndex)
            {
                case 0: // Info
                    break;

                case 1: // Monitor
                    if (listView1.SelectedIndices.Count > 0)
                    {
                        int a = listView1.SelectedIndices[0];
                        textBox1.Text = listView1.Items[a].SubItems[1].Text;
                    }
                    break;

                case 3: // CS8304 Get Log
                    if (listView4.SelectedIndices.Count > 0)
                    {
                        int a = listView4.SelectedIndices[0];
                        textBox14.Text = listView4.Items[a].SubItems[1].Text;
                    }
                    break;

                case 2: // CS8304 Temp Log
                case 4: // Init Tag
                case 5: // Calibration
                    break;

                default: // Exit
                    timer1.Enabled = false;
                    this.Close();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(textBox1.Text);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

            if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            // Start Monitoring
            Program.ReaderCE.Options.TagWriteUser.retryCount = 30;
            Program.ReaderCE.Options.TagWriteUser.accessPassword = UInt32.Parse(textBox2.Text);
            Program.ReaderCE.Options.TagWriteUser.offset = 238;
            Program.ReaderCE.Options.TagWriteUser.count = 1;
            Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts("0406");
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                MessageBox.Show("Cannot Stop Monitor");
                return;
            }

            MessageBox.Show("Stop Monitor Success");
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static UInt32 ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return (UInt32)diff.TotalSeconds;
        }
        
        void ViewDetail ()
        {
            UInt16 SensorDataMsw, SensorDataLsw;
            DateTime D10, D11;
            UInt32 StartTime, AlarmTime;

            if (listView1.SelectedIndices.Count <= 0)
                return;

            SensorDataMsw = UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[5].Text);
            SensorDataLsw = UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text);

            StartTime = (UInt32)((UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[9].Text) << 16) | UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[10].Text));
            AlarmTime = (UInt32)(((UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[7].Text) ^ 0x8000) << 16) | UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text));

            D10 = ConvertFromUnixTimestamp(StartTime);
            D11 = D10.AddSeconds(AlarmTime);
            
            FormColdChainDetail Detail = new FormColdChainDetail();

            if ((SensorDataMsw & 0x0400) != 0)
                Detail.textBoxD1.Text = "Enable";
            else
                Detail.textBoxD1.Text = "Disable";

            if ((SensorDataMsw & 0x1000) != 0)
                Detail.textBoxD2.Text = "Fail";
            else
                Detail.textBoxD2.Text = "OK";

            if ((SensorDataMsw & 0x2000) != 0)
                Detail.textBoxD3.Text = "Fail";
            else
                Detail.textBoxD3.Text = "OK";

            if ((SensorDataMsw & 0x0200) != 0)
                Detail.textBoxD4.Text = "SS";
            else
                Detail.textBoxD4.Text = "notSS";

            if ((SensorDataMsw & 0x4000) != 0)
                Detail.textBoxD5.Text = "1";
            else
                Detail.textBoxD5.Text = "0";

            if ((SensorDataMsw & 0x0800) != 0)
                Detail.textBoxD6.Text = "1";
            else
                Detail.textBoxD6.Text = "0";

            Detail.textBoxD7.Text = (SensorDataLsw >> 10).ToString ();

            Detail.textBoxD8.Text = ((SensorDataLsw >> 5) & 0x1f).ToString();

            Detail.textBoxD9.Text = (SensorDataLsw & 0x1f).ToString();

            Detail.textBoxD10.Text = D10.ToString ();

            Detail.textBoxD11.Text = D11.ToString ();

            Detail.Show();
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewDetail ();
        }

        private void textBox4_LostFocus(object sender, EventArgs e)
        {
            Double value;

            try
            {
                value = Double.Parse(textBox4.Text);

                if (value < -63.75)
                    value = -63.75;
                else if (value > 63.75)
                    value = 63.75;

                textBox4.Text = value.ToString();
            }
            catch (Exception)
            {
                textBox4.Text = "0";
            }
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            Double value;

            try
            {
                value = Double.Parse(textBox3.Text);

                if (value < -63.75)
                    value = -63.75;
                else if (value > 63.75)
                    value = 63.75;

                textBox3.Text = value.ToString();
            }
            catch (Exception)
            {
                textBox3.Text = "0";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, ColumnClickEventArgs e)
        {
            ViewDetail ();
         }

        private void listView1_GotFocus(object sender, EventArgs e)
        {
            ViewDetail();
        }

        private bool TagCS8304_SetMonitorMode(string Epc, uint Password, bool Enable, bool ShowMessage)
        {
            return true;
        }
        
        /// <summary>
        /// TagModle:0 = CS8300, 1 = CS8301, 2 = CS802 .........
        /// </summary>
        /// <param name="TagModle"></param>
        /// <param name="Epc"></param>
        /// <param name="Enable"></param>
        /// <returns></returns>
        private bool TagColdChain_SetBapMode(uint TagModle, string Epc, uint Password, bool Enable, bool ShowMessage)
        {
            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderCE.Options.TagSelected.bank = MemoryBank.EPC;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(Epc);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

            if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                if (ShowMessage)
                    MessageBox.Show("Selected tag failed");
                return false;
            }

            System.Threading.Thread.Sleep(100);

            //config Write Options
            Program.ReaderCE.Options.TagWriteUser.accessPassword = Password;  //Assume all tag with no access password
            Program.ReaderCE.Options.TagWriteUser.retryCount = 7;

            //config Read Options
            Program.ReaderCE.Options.TagReadUser.accessPassword = Password;
            Program.ReaderCE.Options.TagReadUser.retryCount = 7;

            if (Enable)
            {
                switch (TagModle)
                {
                    case 4: // CS8304
                    case 5: // CS8305
                        Program.ReaderCE.Options.TagWriteUser.offset = 269;
                        Program.ReaderCE.Options.TagWriteUser.count = 1;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 1;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Program.ReaderCE.Options.TagWriteUser.offset = 260;
                        Program.ReaderCE.Options.TagWriteUser.count = 6;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[6];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[1] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[2] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[3] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[4] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[5] = 0x0000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Program.ReaderCE.Options.TagWriteUser.offset = 236;
                        Program.ReaderCE.Options.TagWriteUser.count = 3;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[1] = 0x0000;
                        Program.ReaderCE.Options.TagWriteUser.pData[2] = 0x0000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Program.ReaderCE.Options.TagWriteUser.offset = 240;
                        Program.ReaderCE.Options.TagWriteUser.count = 3;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xa600;
                        Program.ReaderCE.Options.TagWriteUser.pData[1] = 0xe000;
                        Program.ReaderCE.Options.TagWriteUser.pData[2] = 0xc003;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;

                    default:
                        Program.ReaderCE.Options.TagWriteUser.offset = 269;
                        Program.ReaderCE.Options.TagWriteUser.count = 1;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;
                }
            }
            else
            {
                switch (TagModle)
                {
                    case 2: // CS8302
                    case 3: // CS8303
                        // 3.3 when 240 = 0x0088 268 = 0x8000 269 = 0x0001 and set 269 to 0, tag normal, led will on, after read tag led change to mid1, write 268 = 0x8008 and read, led change to mid2
                        Program.ReaderCE.Options.TagWriteUser.offset = 269;
                        Program.ReaderCE.Options.TagWriteUser.count = 1;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        Program.ReaderCE.Options.TagWriteUser.offset = 240;
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0088;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        Program.ReaderCE.Options.TagWriteUser.offset = 268;
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x8008;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        Program.ReaderCE.Options.TagWriteUser.offset = 269;
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        Program.ReaderCE.Options.TagWriteUser.offset = 268;
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x8000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);
                        
                        if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                            return false;

                        break;

                    case 4: // CS8304
                    case 5: // CS8305
                        Program.ReaderCE.Options.TagWriteUser.offset = 265;
                        Program.ReaderCE.Options.TagWriteUser.count = 1;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        Program.ReaderCE.Options.TagReadUser.offset = 265;
                        Program.ReaderCE.Options.TagReadUser.count = 1;
                        Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                        while (true)
                        {
                            if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                                return false;

                            if ((Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] & 0x0001) == 0x0000)
                                break;

                            Thread.Sleep(20);
                        }

                        //                        Thread.Sleep(1000);

                        Program.ReaderCE.Options.TagWriteUser.offset = 240;
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Thread.Sleep(20);

                        int cnt;
                        for (cnt = 0; cnt < 10; cnt++)
                        {
                            Program.ReaderCE.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                            Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) == Result.OK)
                                break;
                        }

                        if (cnt == 10)
                        {
                            Program.ReaderCE.Options.TagWriteUser.offset = 240;
                            Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xa600;
                            Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true);
                            return false;
                        }

                        break;

                    default:
                        Program.ReaderCE.Options.TagWriteUser.offset = 269;
                        Program.ReaderCE.Options.TagWriteUser.count = 1;
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;
                }
            }

            return true;
        }

#if nouse        
        private bool SetBap(string Epc, bool Enable)
        {
            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderCE.Options.TagSelected.bank = MemoryBank.EPC;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(Epc);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

            if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return false;
            }

            System.Threading.Thread.Sleep(100);

            //config Write Options

            Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
            Program.ReaderCE.Options.TagWriteUser.accessPassword = 0x0;  //Assume all tag with no access password

            Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
            Program.ReaderCE.Options.TagReadUser.retryCount = 7;
            Program.ReaderCE.Options.TagReadUser.offset = 269;
            Program.ReaderCE.Options.TagReadUser.count = 1;
            Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[1]);

            if (Enable)
            {
                Program.ReaderCE.Options.TagWriteUser.offset = 269;
                Program.ReaderCE.Options.TagWriteUser.count = 1;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 1;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Program.ReaderCE.Options.TagWriteUser.offset = 260;
                Program.ReaderCE.Options.TagWriteUser.count = 6;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[6];
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[1] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[2] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[3] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[4] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[5] = 0x0000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Program.ReaderCE.Options.TagWriteUser.offset = 236;
                Program.ReaderCE.Options.TagWriteUser.count = 3;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[1] = 0x0000;
                Program.ReaderCE.Options.TagWriteUser.pData[2] = 0x0000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Program.ReaderCE.Options.TagWriteUser.offset = 240;
                Program.ReaderCE.Options.TagWriteUser.count = 3;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xa600;
                Program.ReaderCE.Options.TagWriteUser.pData[1] = 0xe000;
                Program.ReaderCE.Options.TagWriteUser.pData[2] = 0xc003;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;
            }
            else
            {
                // for CS8304
                Program.ReaderCE.Options.TagWriteUser.count = 1;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];

                Program.ReaderCE.Options.TagWriteUser.offset = 265;
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                while (true)
                {
                    Program.ReaderCE.Options.TagReadUser.offset = 265;
                    Program.ReaderCE.Options.TagWriteUser.count = 1;
                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                        return false;

                    if ((Program.ReaderCE.Options.TagReadUser.pData.ToShorts ()[0] & 0x0001) == 0x0000)
                        break;
                }

                Program.ReaderCE.Options.TagWriteUser.offset = 240;
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                Program.ReaderCE.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);


#if CS8302
                // 3.3 when 240 = 0x0088 268 = 0x8000 269 = 0x0001 and set 269 to 0, tag normal, led will on, after read tag led change to mid1, write 268 = 0x8008 and read, led change to mid2
                Program.ReaderCE.Options.TagWriteUser.count = 1;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];

                Program.ReaderCE.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                Program.ReaderCE.Options.TagWriteUser.offset = 240;          //Assume offset start from zero
                //Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0088;
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xA000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                Program.ReaderCE.Options.TagWriteUser.offset = 268;          //Assume offset start from zero
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x8008;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                Program.ReaderCE.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);

                Program.ReaderCE.Options.TagWriteUser.offset = 268;          //Assume offset start from zero
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x8000;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return false;

                Thread.Sleep(20);
                if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    return false;
#endif
            }

            return true;
        }
#endif
 

        /*
         * private void ThreadRunSetBap(bool Enable)
                {
                    Interlocked.Exchange(ref mStop, 0);

                    while (!Interlocked.Equals(mStop, 1))
                    {
                        //config Write Options
                        Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                        Program.ReaderCE.Options.TagWriteUser.accessPassword = 0x0;  //Assume all tag with no access password
                        Program.ReaderCE.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                        Program.ReaderCE.Options.TagWriteUser.count = 1;             //Assume 96bit epc only
                        Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                
                        if (Enable)
                            Program.ReaderCE.Options.TagWriteUser.pData[0] = 1;
                        else
                            Program.ReaderCE.Options.TagWriteUser.pData[0] = 0;

                        Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true);
                    }
                    //TriggerButton();
                }

                private void ThreadRunBapEnable()
                {
                    ThreadRunSetBap(true);
                }

                private void ThreadRunBapDisable()
                {
                    ThreadRunSetBap(false);
                }
        */

        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                button5.Text = "Stop";
                button6.Enabled = false;
                button3.Enabled = false;

                listView2.Clear();

                this.listView2.Columns.Add(this.columnHeader19);
                this.listView2.Columns.Add(this.columnHeader11);
                this.listView2.Columns.Add(this.columnHeader12);

                StartInventoryBapMode();
            }
            else
            {
                button5.Text = "Enable";
                button6.Enabled = true;
                button3.Enabled = true;

                Program.ReaderCE.StopOperation(true);
            }


/*
 * if (Program.ReaderCE.State == RFState.IDLE)
            {
                button5.Text = "Stop";
                button6.Enabled = false;

                listView2.Clear();

                //this.listView2.Columns.Add(this.columnHeader1);
                //this.listView2.Columns.Add(this.columnHeader2);

                //lock all tag this is not same as our filter
                Program.ReaderCE.Options.TagSelected.bank =  MemoryBank.TID;
                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderCE.Options.TagSelected.Mask = new byte[4];
                Program.ReaderCE.Options.TagSelected.MaskLength = 32;
                Program.ReaderCE.Options.TagSelected.Mask[0] = 0xE2;
                Program.ReaderCE.Options.TagSelected.Mask[1] = 0x80;
                Program.ReaderCE.Options.TagSelected.Mask[2] = 0xB0;
                Program.ReaderCE.Options.TagSelected.Mask[3] = 0x40;
                
                //Start Operation with synchronuous.
                Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true);
                new Thread(new ThreadStart(ThreadRunBapEnable)).Start();
            }
            else
            {
                button5.Text = "Enable";
                button6.Enabled = true;
                Interlocked.Exchange(ref mStop, 1);
            }
 */
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                button6.Text = "Stop";
                button5.Enabled = false;
                button3.Enabled = false;

                listView2.Clear();

                this.listView2.Columns.Add(this.columnHeader19);
                this.listView2.Columns.Add(this.columnHeader11);
                this.listView2.Columns.Add(this.columnHeader12);

                StartInventoryBapMode();
            }
            else
            {
                button6.Text = "Disable";
                button5.Enabled = true;
                button3.Enabled = true;

                Program.ReaderCE.StopOperation(true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            switch (tabControl1.SelectedIndex)
            {
                case 4: // Init Page
                    if (button5.Text == "Stop")
                    {
                        for (int cnt = 0; cnt < listView2.Items.Count; cnt++)
                        {
                            if (listView2.Items[cnt].SubItems[2].Text == "Disable")
                            {
                                if (Program.ReaderCE.State != RFState.IDLE)
                                {
                                    Program.ReaderCE.StopOperation(true);

                                    while (Program.ReaderCE.State != RFState.IDLE)
                                        Thread.Sleep(1);
                                }
                                TagColdChain_SetBapMode(4, listView2.Items[cnt].SubItems[1].Text, 0x00000000, true, false);
                                //SetBap(listView2.Items[cnt].SubItems[1].Text, true);     
                            }
                        }

                        if (Program.ReaderCE.State == RFState.IDLE)
                            StartInventoryBapMode();
                    }
                    else if (button6.Text == "Stop")
                    {
                        for (int cnt = 0; cnt < listView2.Items.Count; cnt++)
                        {
                            if (listView2.Items[cnt].SubItems[2].Text == "Enable")
                            {
                                if (Program.ReaderCE.State != RFState.IDLE)
                                {
                                    Program.ReaderCE.StopOperation(true);

                                    while (Program.ReaderCE.State != RFState.IDLE)
                                        Thread.Sleep(1);
                                }
                                TagColdChain_SetBapMode(4, listView2.Items[cnt].SubItems[1].Text, 0x00000000, false, false);
                                //SetBap(listView2.Items[cnt].SubItems[1].Text, false);
                            }
                        }

                        if (Program.ReaderCE.State == RFState.IDLE)
                            StartInventoryBapMode();
                    }
                    
                    break;

                case 2: // Temp Log Page
                    if (button8.Text == "Stop")
                    {
                        for (int cnt = 0; cnt < listView4.Items.Count; cnt++)
                        {
                            if (listView4.Items[cnt].SubItems[2].Text != "Recording")
                            {
                                if (Program.ReaderCE.State != RFState.IDLE)
                                {
                                    Program.ReaderCE.StopOperation(true);

                                    while (Program.ReaderCE.State != RFState.IDLE)
                                        Thread.Sleep(1);
                                }

                                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                                Program.ReaderCE.Options.TagSelected.bank = MemoryBank.EPC;
                                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
                                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(listView4.Items[cnt].SubItems[1].Text);
                                Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

                                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                                    return;

                                System.Threading.Thread.Sleep(100);

                                UInt32 uut = (UInt32)UnixTime(DateTime.Now);
                                Int16 UTemp = (Int16)(double.Parse (textBox12.Text) / 0.25);
                                Int16 OTemp = (Int16)(double.Parse (textBox13.Text) / 0.25);

                                Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                                Program.ReaderCE.Options.TagWriteUser.accessPassword = 0x0;
                                Program.ReaderCE.Options.TagWriteUser.offset = 0;
                                Program.ReaderCE.Options.TagWriteUser.count = 3;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = (UInt16)(uut >> 16);
                                Program.ReaderCE.Options.TagWriteUser.pData[1] = (UInt16)(uut & 0xffff);
                                Program.ReaderCE.Options.TagWriteUser.pData[2] = UInt16.Parse (textBox15.Text);
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;

                                Program.ReaderCE.Options.TagWriteUser.offset = 262;
                                Program.ReaderCE.Options.TagWriteUser.count = 3;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[3];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = (UInt16)(OTemp);
                                Program.ReaderCE.Options.TagWriteUser.pData[1] = (UInt16)(UTemp);
                                Program.ReaderCE.Options.TagWriteUser.pData[2] = 0x0000;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;

                                Program.ReaderCE.Options.TagWriteUser.offset = 260;
                                Program.ReaderCE.Options.TagWriteUser.count = 1;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0001;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;

                                Program.ReaderCE.Options.TagWriteUser.offset = 240;
                                Program.ReaderCE.Options.TagWriteUser.count = 1;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xa000;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;
                            }
                        }

                        if (Program.ReaderCE.State == RFState.IDLE)
                            StartInventoryTempLog();
                    }
                    else if (button9.Text == "Stop")
                    {
                        for (int cnt = 0; cnt < listView4.Items.Count; cnt++)
                        {
                            if (listView4.Items[cnt].SubItems[2].Text != "Stop")
                            {
                                if (Program.ReaderCE.State != RFState.IDLE)
                                {
                                    Program.ReaderCE.StopOperation(true);

                                    while (Program.ReaderCE.State != RFState.IDLE)
                                        Thread.Sleep(1);
                                }

                                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                                Program.ReaderCE.Options.TagSelected.bank = MemoryBank.EPC;
                                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
                                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(listView4.Items[cnt].SubItems[1].Text);
                                Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

                                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                                    continue;

                                System.Threading.Thread.Sleep(100);

                                Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                                Program.ReaderCE.Options.TagWriteUser.accessPassword = 0x0;

                                Program.ReaderCE.Options.TagWriteUser.offset = 240;
                                Program.ReaderCE.Options.TagWriteUser.count = 1;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0xa600;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;

                                Program.ReaderCE.Options.TagWriteUser.offset = 260;
                                Program.ReaderCE.Options.TagWriteUser.count = 1;
                                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0002;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                    continue;

                                Program.ReaderCE.Options.TagReadUser.retryCount = 7;
                                Program.ReaderCE.Options.TagReadUser.offset = 264;
                                Program.ReaderCE.Options.TagReadUser.count = 1;
                                Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                                if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                                    continue;

                                if ((Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] & 0x0002) != 0x0000)
                                {
                                    // Show Temperature alarm on LED
                                    Program.ReaderCE.Options.TagWriteUser.offset = 264;
                                    Program.ReaderCE.Options.TagWriteUser.count = 1;
                                    Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0003;
                                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                        continue;
                                }
                            }
                        }

                        if (Program.ReaderCE.State == RFState.IDLE)
                            StartInventoryTempLog();
                    }

                    break;
            
            }

            timer1.Enabled = true;
        }

        private void label8_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label6_ParentChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_LostFocus(object sender, EventArgs e)
        {
            try
            {
                UInt16 value = UInt16.Parse(textBox5.Text);
                if (value > 0x3f)
                    value = 0x3f;
                textBox5.Text = value.ToString();
            }
            catch(Exception)
            {
                textBox5.Text = "1";
            }
        }

        private void textBox6_LostFocus(object sender, EventArgs e)
        {
            try
            {
                UInt16 value = UInt16.Parse(textBox6.Text);
                if (value > 0x3f)
                    value = 0x3f;
                textBox6.Text = value.ToString();
            }
            catch (Exception)
            {
                textBox6.Text = "1";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                button3.Text = "Stop";
                button5.Enabled = false;
                button6.Enabled = false;

                listView2.Clear();

                this.listView2.Columns.Add(this.columnHeader19);
                this.listView2.Columns.Add(this.columnHeader11);
                this.listView2.Columns.Add(this.columnHeader12);

                StartInventoryBapMode();
            }
            else
            {
                button3.Text = "Scan";
                button5.Enabled = true;
                button6.Enabled = true;

                Program.ReaderCE.StopOperation(true);
            }

        }

        void TempoCal (Double Temp)
        {
            Int16 Test_Coarse_Trim;
            Int16 Test_Fine_Trim;
            Int16 Curr_Coarse_Trim;
            Int16 Curr_Fine_Trim;
            UInt16 Curr_Reserved_EM;

            // 1. Set up the calibration environment such that the EM4325 device is ensured to be operating at the desired target
                // temperature.
            // 2. Read the Temp Sensor Calibration and save the 6 MSB’s as EM_Reserved
                // a. Test_Coarse_Trim = 01111 (max value)
                // b. Test_Fine_Trim = 00000
                // c. Read the Temp Sensor Calibration and save the 6 MSB’s as EM_Reserved.
            // 3. Determine best value for Coarse Trim to minimize temp sensor measurement error:
                // a. Update the Temp Sensor Calibration Word using EM_Reserved, Test_Coarse_Trim, and Test_Fine_Trim.
                // b. The EM4325 device must perform a Boot Sequence before the new value of the Temp Sensor Calibration
                // Word is used by the device.
                // c. Command EM4325 to make a temp sensor measurement.
                // d. If the temp sensor measurement is greater than the desired target temperature, then decrement
                // Test_Coarse_Trim and goto 3a and make another attempt to find the best value for Coarse Trim. (NOTE:
                // max value to min value is the following: 01111, 01101, … , 00001, 00000, 10001, … ,
            
            // 4. Determine the best value for Fine Trim to minimize temp sensor measurement error:
                // a. The Fine Trim value is a constant offset applied to all temp sensor measurements. The best value for Fine
                // Trim can be computed by determining which value for Fine Trim produces the best accuracy when added
                // to the measurement made for the best value for Coarse Trim.
                // b. Update the Temp Sensor Calibration Word using EM_Reserved and the best values for Coarse Trim and
                // Fine Trim.
                // c. The EM4325 device must perform a Boot Sequence before the new value of the Temp Sensor Calibration
                // Word is used by the device.
                // d. Command EM4325 to make a temp sensor measurement.
                // e. Verify the measured temperature is the same as the desired target temperature within a given tolerance.

            // 2
            Test_Coarse_Trim = 0x0f;
            Test_Fine_Trim = 0;


            Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
            Program.ReaderCE.Options.TagReadUser.retryCount = 7;
            Program.ReaderCE.Options.TagReadUser.offset = 239; // Temp Sensor Calibration Word
            Program.ReaderCE.Options.TagReadUser.count = 1;
            Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[2]);

            if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                MessageBox.Show("Monitor can not work");
                return;
            }

            //Curr_Reserved_EM = (Program.ReaderCE.Options.TagReadUser.pData.ToUshorts[0] >> 10);
            //Curr_Coarse_Trim = (Program.ReaderCE.Options.TagReadUser.pData.ToUshorts[0] >> 5) & 0x1f;
            //Curr_Fine_Trim = (Program.ReaderCE.Options.TagReadUser.pData.ToUshorts[0] & 0x1f);
        }


        double Current, End;
        private void button4_Click(object sender, EventArgs e)
        {
            Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);

            //Start Task
            System.Threading.Thread service = new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                Invoke((System.Threading.ThreadStart)delegate()
                {
                    bool AllDone = true;

                    for (int cnt = 0; cnt < listView3.Items.Count; cnt++)
                    {
                        if (listView3.Items[cnt].SubItems[2].Text.Substring(0, 4) != "Done")
                        {
                            // Enable BAP
                            listView3.Items[cnt].SubItems[2].Text = "Enable BAP";
                            //                            if (SetBap(listView3.Items[cnt].SubItems[1].Text, true) != true)
                            if (TagColdChain_SetBapMode(4, listView3.Items[cnt].SubItems[1].Text, 0x00000000, true, false) != true)
                            {
                                AllDone = false;
                                listView3.Items[cnt].SubItems[2].Text = "BAP Enable Fail";
                                continue;
                            }

                            Double TargetTemp;
                            UInt16 TSCW = 0; // Temp Sensor Calibration Word (236)
                            UInt16 SetTSCW;
                            Int16 TestCoarseTrim;
                            UInt16 CoarseTrim;
                            Int16 TestFineTrim;
                            UInt16 FineTrim;
                            Double Diff;

                            Double CurrentTemp, AvgTemp;
                            Double TempDiff;
                            Double minErrTemp;
                            UInt16 minErrCoarse;


                            TargetTemp = Double.Parse(textBox7.Text);
                            TSCW = 0; // Temp Sensor Calibration Word (236)
                            SetTSCW = 0;
                            TestCoarseTrim = 0;
                            CoarseTrim = 0;
                            TestFineTrim = 0;
                            FineTrim = 0;
                            Diff = 0;

                            CurrentTemp = 0;
                            TempDiff = 0;
                            minErrTemp = 100.0;
                            minErrCoarse = 0;



                            Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
                            Program.ReaderCE.Options.TagReadUser.retryCount = 7;
                            Program.ReaderCE.Options.TagReadUser.offset = 239; // Temp Sensor Calibration Word
                            Program.ReaderCE.Options.TagReadUser.count = 1;
                            Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[2]);

                            if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                            {
                                AllDone = false;
                                continue;
                            }

                            TSCW = Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0];

                            TSCW &= 0xfc00; //1111 1100 0000 0000
                            //TSCW = 0x4c00; // for test only by Mephist

                            // Cal CoarseTrim
                            for (TestCoarseTrim = 0x0f; TestCoarseTrim > -16; TestCoarseTrim--)
                            {
                                if (TestCoarseTrim >= 0)
                                {
                                    CoarseTrim = (UInt16)(TestCoarseTrim << 5);
                                }
                                else
                                {
                                    CoarseTrim = (UInt16)(1 << 9 | Math.Abs(TestCoarseTrim) << 5);
                                }

                                SetTSCW = (UInt16)(TSCW | CoarseTrim);

                                // Write TSCW
                                Program.ReaderCE.Options.TagWriteUser.accessPassword = 0;
                                Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                                Program.ReaderCE.Options.TagWriteUser.offset = 239;
                                Program.ReaderCE.Options.TagWriteUser.pData[0] = SetTSCW;
                                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                                {
                                    AllDone = false;
                                    continue;
                                }

                                int retry = 10;

                                while (retry > 0)
                                {
                                    Program.ReaderCE.Options.TagWriteUser.retryCount = 0;
                                    Program.ReaderCE.Options.TagWriteUser.offset = 256;
                                    Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0100;
                                    Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true);

                                    // Read Temp.
                                    Program.ReaderCE.Options.TagReadUser.offset = 256; // Temp Sensor Calibration Word
                                    Program.ReaderCE.Options.TagReadUser.count = 1;
                                    Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[2]);
                                    Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true);

                                    if (Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] != 0x0100)
                                        break;

                                    retry--;
                                }

                                if (retry == 0)
                                {
                                    listView3.Items[cnt].SubItems[1].Text = "Invalid measurement";
                                    AllDone = false;
                                    continue;
                                }

                                AvgTemp = 0;
                                UInt32 avg = UInt32.Parse (textBox9.Text);
                                for (UInt16 cnt1 = 0; cnt1 < avg; cnt1++)
                                {
                                    CurrentTemp = (Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] & 0x00ff);
                                    if ((Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] & 0x0100) != 0)
                                        CurrentTemp -= 256;
                                    CurrentTemp *= 0.25;

                                    AvgTemp += CurrentTemp;
                                }
                                AvgTemp = AvgTemp / avg;

                                if (Math.Abs(TargetTemp - AvgTemp) < Math.Abs(TargetTemp - minErrTemp))
                                {
                                    minErrTemp = AvgTemp;
                                    minErrCoarse = CoarseTrim;
                                }
                                else
                                    break;
                            }

                            // Cal FineTrim

                            TempDiff = TargetTemp - minErrTemp;
                            if (TempDiff > 3.75)
                                TempDiff = 3.75;
                            else if (TempDiff < -4.00)
                                TempDiff = -4.00;

                            FineTrim = (UInt16)(((int)(TempDiff / 0.25)) & 0x1f);
                            SetTSCW = (UInt16)(TSCW | minErrCoarse | FineTrim);

                            Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                            Program.ReaderCE.Options.TagWriteUser.offset = 239;
                            Program.ReaderCE.Options.TagWriteUser.pData[0] = SetTSCW;
                            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            {
                                AllDone = false;
                                continue;
                            }

                            {
                                using (System.IO.FileStream file = new System.IO.FileStream("ColdChainCalibrationData.txt", System.IO.FileMode.Append))
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
                                {
                                    sw.WriteLine(CSLibrary.Tools.DateTimeEx.Now + "\tEPC=" + listView3.Items[cnt].SubItems[1].Text +  ", UID=" + listView3.Items[cnt].SubItems[3].Text +  ", Target Temp=" + TargetTemp + ", cal value=0x" + SetTSCW.ToString("X4"));
                                    sw.Flush();
                                }
                            }

                            if (checkBox1.Checked && Monitor_Enable(listView3.Items[cnt].SubItems[1].Text, -63, 63, 0, 1, 0, 1, false) == false)
                                listView3.Items[cnt].SubItems[2].Text = "Monitor can not enable";
                            else
                                listView3.Items[cnt].SubItems[2].Text = "Done " + SetTSCW.ToString("X4");
                        }
                    }

                    if (AllDone)
                        MessageBox.Show("All Done");
                    else
                        MessageBox.Show("Tag Fail, please check tag status");
                });

                Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
            });
            service.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;

            listView3.Clear ();
            this.listView3.Columns.Add(this.columnHeader16);
            this.listView3.Columns.Add(this.columnHeader13);
            this.listView3.Columns.Add(this.columnHeader14);
            this.listView3.Columns.Add(this.columnHeader15);


            Program.ReaderCE.SetInventoryDuration(UInt32.Parse (textBox11.Text) * 1000);
            Program.ReaderCE.SetOperationMode(RadioOperationMode.NONCONTINUOUS);
            Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
            Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
            Program.ReaderCE.Options.TagRanging.flags = SelectFlags.ZERO;
            Program.ReaderCE.Options.TagRanging.multibanks = 1;
            Program.ReaderCE.Options.TagRanging.bank1 = MemoryBank.TID;
            Program.ReaderCE.Options.TagRanging.offset1 = 0;
            Program.ReaderCE.Options.TagRanging.count1 = 6;
            Program.ReaderCE.StartOperation(Operation.TAG_RANGING_READ_BANKS, true);

            listView3.EnsureVisible (listView3.Items.Count - 1);

            if (listView3.Items.Count < int.Parse (textBox8.Text))
                MessageBox.Show("Number of tags not enough, Please check");

            button7.Enabled = true;
        }

        private void textBox10_LostFocus(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = int.Parse(textBox10.Text) * 1000;
            }
            catch (Exception ex)
            {
                textBox10.Text = "3";
                timer1.Interval = 3000;
            }
        }

        private void textBox8_Validated(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = (uint.Parse (textBox8.Text)).ToString ();
            }
            catch (Exception ex)
            {
                textBox8.Text = "20";
            }
        }

        private void textBox7_Validated(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = (Double.Parse(textBox7.Text)).ToString();
            }
            catch (Exception ex)
            {
                textBox7.Text = "0";
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            UInt32 value;

            try
            {
                value = UInt32.Parse(textBox11.Text);
                if (value > (0xffffffff / 1000))
                    throw new Exception();

                textBox11.Text = value.ToString ();
            }
            catch (Exception ex)
            {
                textBox11.Text = "5";
                MessageBox.Show("Input Error");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            UInt32 value;

            try
            {
                value = UInt32.Parse(textBox9.Text);

                if (value == 0)
                    throw new Exception();

                textBox9.Text = value.ToString();
            }
            catch (Exception ex)
            {
                textBox9.Text = "3";
                MessageBox.Show("Input Error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        DateTime UnixTimeStampBase = new DateTime(1970, 1, 1, 00, 0, 0, 0);
        DateTime UnixTime(double second)
        {
            return UnixTimeStampBase.AddSeconds(second);
        }

        double UnixTime(DateTime st)
        {
            return (st - UnixTimeStampBase).TotalSeconds;
        }


        /// <summary>
        /// rawbase: actual calibration temperature translated by 40 degrees (0 means -40, 256 means 216, our web announced operation range is from -24 to 64 only, calibration can only be integer value)
        /// rawa1offset, rawb1offset: A1*1000 and B1 * 100 of the first ax+b curve (the curve left of calibration temp)   (2’s complement, and A1 you have to divide by 1000, B1 you have to divide by 100)
        /// rawc2offset, rawb2offset: A2*1000 and B2 * 100 of the second ax+b curve (the curve right of calibration temp) (2’s complement, and A2 you have to divide by 1000, B2 you have to divide by 100)
        /// </summary>
        /// <param name="rawbase"></param>
        /// <param name="rawc1offset"></param>
        /// <param name="rawc2offset"></param>
        /// <returns></returns>
        double CalTempBase;
        double CalCurveA1;
        double CalCurveB1;
        double CalCurveA2;
        double CalCurveB2;
        private bool SetTemperatureConventionParameter(byte rawbase, char rawa1, char rawb1, char rawa2, char rawb2)
        {
            try
            {
                CalTempBase = rawbase - 40;
                double CalCurveA1 = rawa1 / 1000;
                double CalCurveB1 = rawb1 / 100;
                double CalCurveA2 = rawa2 / 1000;
                double CalCurveB2 = rawb2 / 100;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        Int16 TemperatureConvention(double RealTemp)
        {
            double RawTemp;
            Int16 TagRawTemp;

            if (RealTemp < CalTempBase)
            {
                // use curve 1
                RawTemp = CalCurveA1 * RealTemp + CalCurveB1;
            }
            else
            {
                // use curve 2
                RawTemp = CalCurveA2 * RealTemp + CalCurveB2;
            }

            TagRawTemp = (Int16)(RawTemp / 0.25);

            return TagRawTemp;
        }

/*
        double TemperatureConvention(Int16 rawTemp)
        {
            double RealTemp;
            Int16 TagRawTemp;

            if (RealTemp < CalTempBase)
            {
                // use curve 1
                RealTemp = CalCurveA1 * RealTemp + CalCurveB1;
            }
            else
            {
                // use curve 2
                RealTemp = CalCurveA2 * RealTemp + CalCurveB2;
            }

            return RealTemp;
        }
*/

        private void button12_Click(object sender, EventArgs e)
        {
            DateTime StartTime = DateTime.Now;
            UInt16 Interval = 0;
            double TempOffset = 0;
            UInt16 Total = 0;

            UInt16 ReadOffset = 0;
            UInt16 ReadRecord = 0;
            UInt16 ReadUInt16 = 0;

            listView5.Clear();

            this.listView5.Columns.Add(this.columnHeader26);
            this.listView5.Columns.Add(this.columnHeader24);
            this.listView5.Columns.Add(this.columnHeader25);

            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderCE.Options.TagSelected.bank = MemoryBank.EPC;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(textBox14.Text);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                return;

            System.Threading.Thread.Sleep(100);

            // disable
            Program.ReaderCE.Options.TagWriteUser.offset = 264;
            Program.ReaderCE.Options.TagWriteUser.count = 1;
            Program.ReaderCE.Options.TagWriteUser.pData = new UInt16[1];
            Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x0000;
            if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                return;

            Program.ReaderCE.Options.TagReadUser.accessPassword = 0;
            Program.ReaderCE.Options.TagReadUser.retryCount = 7;
            Program.ReaderCE.Options.TagReadUser.offset = 0; // Temp Sensor Calibration Word
            Program.ReaderCE.Options.TagReadUser.count = 5;
            Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[5]);
            if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                MessageBox.Show("Read Data Length Error");
                return;
            }

            UInt16[] TagData = Program.ReaderCE.Options.TagReadUser.pData.ToUshorts();

            StartTime = UnixTime(TagData[0] << 16 | TagData[1]);
            Interval = TagData[2];
            TempOffset = 0.25 * (TagData[3]);
            Total = TagData[4];
            label17.Text = "Total : " + Total.ToString();
            if (Total >= 10752)
                label17.Text += " (MemoryBank Full)";

            while (ReadOffset < Total)
            {
                Program.ReaderCE.Options.TagWriteUser.retryCount = 7;
                Program.ReaderCE.Options.TagWriteUser.accessPassword = UInt32.Parse(textBox2.Text);
                Program.ReaderCE.Options.TagWriteUser.offset = 260;
                Program.ReaderCE.Options.TagWriteUser.count = 2;
                Program.ReaderCE.Options.TagWriteUser.pData = new UInt16 [2];
                Program.ReaderCE.Options.TagWriteUser.pData[0] = 0x000a;
                Program.ReaderCE.Options.TagWriteUser.pData[1] = ReadOffset;
                if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return;

                Thread.Sleep(2500);

                Program.ReaderCE.Options.TagReadUser.offset = 260; // Temp Sensor Calibration Word
                Program.ReaderCE.Options.TagReadUser.count = 1;  // 183 * 2 records will be read
                Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                while (true)
                {
                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    {
                        MessageBox.Show("Read Data Length Error");
                        return;
                    }

                    if ((Program.ReaderCE.Options.TagReadUser.pData.ToUshorts()[0] & 0x04) != 0x0000)
                        break;

                    Thread.Sleep(100);
                }

                ReadRecord = (UInt16)(Total - ReadOffset);

                if (ReadRecord > 366)
                    ReadRecord = 366;

                ReadUInt16 = (UInt16)((ReadRecord + 1) / 2);

                Program.ReaderCE.Options.TagReadUser.offset = 5;
                Program.ReaderCE.Options.TagReadUser.count = ReadUInt16;
                Program.ReaderCE.Options.TagReadUser.pData = new S_DATA(new byte[ReadUInt16]);
                ReadOffset += (UInt16)(ReadUInt16 * 2);

                if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                {
                    MessageBox.Show("Read Data Length Error");
                    return;
                }

                UInt16[] DataPtr = Program.ReaderCE.Options.TagReadUser.pData.ToUshorts();

                for (int cnt = 0; cnt < ReadUInt16; cnt++)
                {
                    ListViewItem ins;
                    double temp;

                    temp = ((DataPtr[cnt] >> 8) * 0.25) - TempOffset;
                    ins = new ListViewItem((listView5.Items.Count + 1).ToString());
                    ins.SubItems.Add(StartTime.ToString ());
                    ins.SubItems.Add(temp.ToString ());
                    listView5.Items.Add(ins);

                    StartTime = StartTime.AddSeconds(Interval);

                    if (listView5.Items.Count == Total)
                        break;

                    temp = ((DataPtr[cnt] & 0xff) * 0.25) - TempOffset;
                    ins = new ListViewItem((listView5.Items.Count + 1).ToString());
                    ins.SubItems.Add(StartTime.ToString());
                    ins.SubItems.Add(temp.ToString ());
                    listView5.Items.Add(ins);

                    StartTime = StartTime.AddSeconds(Interval);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label17_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label16_ParentChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
