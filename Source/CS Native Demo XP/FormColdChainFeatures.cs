using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    //using CSLibrary.Device;
    using CSLibrary.Text;
    //using CSLibrary.HotKeys;

    public partial class FormColdChainFeatures : Form
    {
        private void AttachCallback(bool en)
        {
            if (en)
            {
                //HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
            else
            {
                //HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
        }

/*        void HotKey_OnKeyEvent(Key KeyCode, bool KeyDown)
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
            }
        }
*/
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

        void Reader_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            // Check Callback Type
            if (e.type != CallbackType.TAG_RANGING)
                return;

            // If no TID code
            if (e.info.epc.GetLength() < e.info.pc.EPCLength + 2)
                return;

            BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                try
                {
                    UInt16[] tagdata = e.info.epc.ToUshorts();
                    UInt32 tid;
                    string EPC;
                    int cnt = 0;

                    // Get EPC string
                    EPC = e.info.epc.ToString().Substring(0, (int)(e.info.pc.EPCLength * 4));

                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            lock (listView1)
                            {
                                // Check TID code (exclude if scan temp)
                                tid = (UInt32)((tagdata[e.info.pc.EPCLength] << 16) | tagdata[e.info.pc.EPCLength + 1]) & 0xffffffc0U;
                                if (tid != 0xe280b040U)
                                    return;

                                
                                for (cnt = 0; cnt < listView1.Items.Count; cnt++)
                                {
                                    if (listView1.Items[cnt].SubItems[1].Text == EPC)
                                    {
                                        //listView1.Items[cnt].SubItems[2].Text = "UNKNOW";
                                        //listView1.Items[cnt].SubItems[3].Text = LowBatAlarm;
                                        break;
                                    }
                                }
                                if (cnt == listView1.Items.Count)
                                {
                                    ListViewItem ins = new ListViewItem((listView1.Items.Count + 1).ToString());
                                    ins.SubItems.Add(EPC);
                                    if (tagdata[e.info.pc.EPCLength + 2] != 0x0000 || (tagdata[e.info.pc.EPCLength + 3] & 0xf000) != 0x0000)
                                    {
                                        string Model = "CS" + tagdata[e.info.pc.EPCLength + 2].ToString("X4") + "-" + (tagdata[e.info.pc.EPCLength + 3] >> 12).ToString("X");
                                        ins.SubItems.Add(Model);
                                    }
                                    else
                                    {
                                        ins.SubItems.Add("UNKNOWN");
                                    }
                                    listView1.Items.Add(ins);
                                }
                            }
                            break;

                        case 1:
                            lock (listView2)
                            {
                                if (tagdata[e.info.pc.EPCLength] != 0x8300)
                                    break;
                                
                                string BAP;

                                if ((tagdata[e.info.pc.EPCLength + 2] & 0x01) != 0)
                                    BAP = "Enable";
                                else
                                    BAP = "Disable";

                                for (cnt = 0; cnt < listView2.Items.Count; cnt++)
                                {
                                    if (listView2.Items[cnt].SubItems[1].Text == EPC)
                                    {
                                        listView2.Items[cnt].SubItems[2].Text = BAP;
                                        break;
                                    }
                                }

                                if (cnt == listView2.Items.Count)
                                {
                                    ListViewItem ins = new ListViewItem((listView2.Items.Count + 1).ToString());
                                    ins.SubItems.Add(EPC);
                                    ins.SubItems.Add(BAP);
                                    listView2.Items.Add(ins);
                                }
                            }
                            break;

                        case 2:
                            lock (listView4)
                            {
                                string LowBatAlarm;
                                bool find = false;
                                UInt16 SensorDataMsw, SensorDataLsw;
                                UInt16 UtcMsw, UtcLsw;
                                UInt16 StartTimeMsw, StartTimeLsw;
                                string Temperature;
                                string TempAlarm;
                                bool bap = false;

                                if (!((radioButton1.Checked && tagdata[e.info.pc.EPCLength] == 0x8300) ||
                                    (radioButton2.Checked && tagdata[e.info.pc.EPCLength] == 0x8301) || 
                                    (radioButton3.Checked && tagdata[e.info.pc.EPCLength] == 0x8302)))
                                    break;

                                SensorDataMsw = tagdata[e.info.pc.EPCLength + 2 + 2];
                                SensorDataLsw = tagdata[e.info.pc.EPCLength + 3 + 2];
                                UtcMsw = tagdata[e.info.pc.EPCLength + 4 + 2];
                                UtcLsw = tagdata[e.info.pc.EPCLength + 5 + 2];
                                StartTimeMsw = tagdata[e.info.pc.EPCLength + 7 + 2];
                                StartTimeLsw = tagdata[e.info.pc.EPCLength + 8 + 2];

                                if ((tagdata[e.info.pc.EPCLength + 15 + 2] & 0x0001) == 0x0001)
                                    bap = true;

                                if (bap)
                                {
                                    if ((SensorDataMsw & 0x0400) != 0)
                                    {
                                        double Temp;

                                        if ((SensorDataMsw & 0x01ff) == 0x0100)
                                        {
                                            Temperature = "Invalid";
                                        }
                                        else
                                        {

                                            if (checkBox1.Checked)
                                            {
                                                ColdChain_SetBilinearParams((byte)(tagdata[e.info.pc.EPCLength + 1] & 0xff), tagdata[e.info.pc.EPCLength + 2], tagdata[e.info.pc.EPCLength + 3]);
                                                Temp = ColdChain_BilinearConversion(SensorDataMsw);
                                            }
                                            else
                                            {
                                                Temp = (SensorDataMsw & 0x00ff);
                                                if ((SensorDataMsw & 0x0100) != 00)
                                                    Temp -= 256;
                                                Temp *= 0.25;
                                            }

                                            Temperature = Temp.ToString();
                                        }
                                    }
                                    else
                                        Temperature = "Disable";

                                    if ((SensorDataMsw & 0x3000) != 00)
                                        TempAlarm = "Fail";
                                    else
                                        TempAlarm = "OK";

                                    if ((SensorDataMsw & 0x8000) != 00)
                                        LowBatAlarm = "Fail";
                                    else
                                        LowBatAlarm = "OK";



#if nouse
                                    if ((SensorDataMsw & 0x0500) != 0)
                                    {
                                        double Temp;
                                        Temp = (SensorDataMsw & 0x00ff);
                                        if ((SensorDataMsw & 0x0100) != 00)
                                            Temp -= 256;
                                        Temp *= 0.25;
                                        
                                        if (checkBox1.Checked)
                                        {
                                            double RefTemp, A1, B1, A2, B2;

                                            RefTemp = ((double)(tagdata[e.info.pc.EPCLength] & 0xff) / 4) - 40;
                                            A1 = ((char)(tagdata[e.info.pc.EPCLength + 1] >> 8)) * 1000;
                                            B1 = ((char)(tagdata[e.info.pc.EPCLength + 1] & 0xff)) * 100;
                                            A2 = ((char)(tagdata[e.info.pc.EPCLength + 2] >> 8)) * 1000;
                                            B2 = ((char)(tagdata[e.info.pc.EPCLength + 2] & 0xff)) * 100;

                                            if (Temp < RefTemp)
                                                Temp = A1 * Temp + B1;
                                            else if (Temp > RefTemp)
                                                Temp = A2 * Temp + B2;
                                        }

                                        if (Temp != -64)
                                            Temperature = Temp.ToString();
                                        else
                                            Temperature = "NA";
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
#endif
                                }
                                else
                                {
                                    Temperature = "BAPOFF";
                                    TempAlarm = "";
                                    LowBatAlarm = "";
                                }

                                for (cnt = 0; cnt < listView4.Items.Count; cnt++)
                                {
                                    if (listView4.Items[cnt].SubItems[1].Text == EPC)
                                    {
                                        listView4.Items[cnt].SubItems[2].Text = Temperature;
                                        listView4.Items[cnt].SubItems[3].Text = TempAlarm;
                                        listView4.Items[cnt].SubItems[4].Text = LowBatAlarm;
                                        listView4.Items[cnt].SubItems[5].Text = SensorDataMsw.ToString();
                                        listView4.Items[cnt].SubItems[6].Text = SensorDataLsw.ToString();
                                        listView4.Items[cnt].SubItems[7].Text = UtcMsw.ToString();
                                        listView4.Items[cnt].SubItems[8].Text = UtcLsw.ToString();
                                        listView4.Items[cnt].SubItems[9].Text = StartTimeMsw.ToString();
                                        listView4.Items[cnt].SubItems[10].Text = StartTimeLsw.ToString();
                                        listView4.Items[cnt].ForeColor = Color.Black;
                                        break;
                                    }
                                }

                                if (cnt == listView4.Items.Count)
                                {
                                    ListViewItem ins = new ListViewItem((listView4.Items.Count + 1).ToString());
                                    ins.SubItems.Add(EPC);
                                    ins.SubItems.Add(Temperature);
                                    ins.SubItems.Add(TempAlarm);
                                    ins.SubItems.Add(LowBatAlarm);
                                    ins.SubItems.Add(SensorDataMsw.ToString());
                                    ins.SubItems.Add(SensorDataLsw.ToString());
                                    ins.SubItems.Add(UtcMsw.ToString());
                                    ins.SubItems.Add(UtcLsw.ToString());
                                    ins.SubItems.Add(StartTimeMsw.ToString());
                                    ins.SubItems.Add(StartTimeLsw.ToString());
                                    ins.ForeColor = Color.Black;
                                    listView4.Items.Add(ins);
                                }
                            }
                            break;

                        case 3:
                            lock (listView5)
                            {
                                if (tagdata[e.info.pc.EPCLength] != 0x8304 && tagdata[e.info.pc.EPCLength] != 0x8305)
                                    break;

                                for (cnt = 0; cnt < listView5.Items.Count; cnt++)
                                {
                                    if (listView5.Items[cnt].SubItems[1].Text == EPC)
                                    {
                                        switch (tagdata[e.info.pc.EPCLength + 6] & 0x03)
                                        {
                                            case 0:
                                            case 2:
                                                listView5.Items[cnt].SubItems[2].Text = "Stop";
                                                break;
                                            case 1:
                                                listView5.Items[cnt].SubItems[2].Text = "Recording";
                                                break;
                                            case 3:
                                                listView5.Items[cnt].SubItems[2].Text = "Error";
                                                break;
                                        }

                                        if ((tagdata[e.info.pc.EPCLength + 10] & 0x02) != 0)
                                            listView5.Items[cnt].SubItems[3].Text = "Fail";
                                        else
                                            listView5.Items[cnt].SubItems[3].Text = "OK";

                                        if ((tagdata[e.info.pc.EPCLength + 10] & 0x04) != 0)
                                            listView5.Items[cnt].SubItems[4].Text = "Fail";
                                        else
                                            listView5.Items[cnt].SubItems[4].Text = "OK";

                                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x8000) != 0)
                                            listView5.Items[cnt].SubItems[5].Text = "Fail";
                                        else
                                            listView5.Items[cnt].SubItems[5].Text = "OK";

                                        break;
                                    }
                                }

                                if (cnt == listView5.Items.Count)
                                {
                                    ListViewItem ins = new ListViewItem((listView5.Items.Count + 1).ToString());
                                    ins.SubItems.Add(EPC);
                                    switch (tagdata[e.info.pc.EPCLength + 6] & 0x03)
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

                                    if ((tagdata[e.info.pc.EPCLength + 10] & 0x02) != 0)
                                        ins.SubItems.Add("Fail");
                                    else
                                        ins.SubItems.Add("OK");

                                    if ((tagdata[e.info.pc.EPCLength + 10] & 0x04) != 0)
                                        ins.SubItems.Add("Fail");
                                    else
                                        ins.SubItems.Add("OK");

                                    if ((tagdata[e.info.pc.EPCLength + 2] & 0x8000) != 0)
                                        ins.SubItems.Add ("Fail");
                                    else
                                        ins.SubItems.Add ("OK");

                                    listView5.Items.Add(ins);
                                }
                            }
                            break;
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

        /// <summary>
        /// TagModle:0 = CS8300, 1 = CS8301, 2 = CS802 .........
        /// </summary>
        /// <param name="TagModle"></param>
        /// <param name="Epc"></param>
        /// <param name="Enable"></param>
        /// <returns></returns>
        private bool TagColdChain_SetBapMode(string Epc, uint Password, bool Enable, bool ShowMessage)
        {
            UInt16 TagModel;

            if (!SelectTag (Epc))
            {
                if (ShowMessage)
                    MessageBox.Show("Selected tag failed");
                return false;
            }


            System.Threading.Thread.Sleep(100);

            //config Write Options
            Program.ReaderXP.Options.TagWriteUser.accessPassword = Password;  //Assume all tag with no access password
            Program.ReaderXP.Options.TagWriteUser.retryCount = 7;

            //config Read Options
            Program.ReaderXP.Options.TagReadUser.accessPassword = Password;
            Program.ReaderXP.Options.TagReadUser.retryCount = 7;

            Program.ReaderXP.Options.TagReadUser.offset = 188;
            Program.ReaderXP.Options.TagReadUser.count = 1;
            Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[1]);
            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                return false;

            TagModel = Program.ReaderXP.Options.TagReadUser.pData.ToUshorts ()[0];

            if (Enable)
            {
                switch (TagModel)
                {
                    case 0x8304: // CS8304
                    case 0x8305: // CS8305
                        Program.ReaderXP.Options.TagWriteUser.offset = 269;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 1;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        Program.ReaderXP.Options.TagWriteUser.offset = 260;
                        Program.ReaderXP.Options.TagWriteUser.count = 6;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[6];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[1] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[2] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[3] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[4] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[5] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(100);

                        Program.ReaderXP.Options.TagWriteUser.offset = 236;
                        Program.ReaderXP.Options.TagWriteUser.count = 3;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[3];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[1] = 0x0000;
                        Program.ReaderXP.Options.TagWriteUser.pData[2] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(100);

                        Program.ReaderXP.Options.TagWriteUser.offset = 240;
                        Program.ReaderXP.Options.TagWriteUser.count = 3;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[3];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
                        Program.ReaderXP.Options.TagWriteUser.pData[1] = 0xe000;
                        Program.ReaderXP.Options.TagWriteUser.pData[2] = 0xc003;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;

                    default:
                        Program.ReaderXP.Options.TagWriteUser.offset = 269;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;
                }
            }
            else
            {
                switch (TagModel)
                {
                    case 0x8302: // CS8302
                    case 0x8303: // CS8303
                        // 3.3 when 240 = 0x0088 268 = 0x8000 269 = 0x0001 and set 269 to 0, tag normal, led will on, after read tag led change to mid1, write 268 = 0x8008 and read, led change to mid2
                        Program.ReaderXP.Options.TagWriteUser.offset = 269;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagWriteUser.offset = 240;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0088;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagWriteUser.offset = 268;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x8008;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagWriteUser.offset = 269;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagWriteUser.offset = 268;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x8000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                            return false;

                        break;

                    case 0x8304: // CS8304
                    case 0x8305: // CS8305
                        Program.ReaderXP.Options.TagWriteUser.offset = 265;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0001;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagReadUser.offset = 265;
                        Program.ReaderXP.Options.TagReadUser.count = 1;
                        Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                        DateTime starttime = DateTime.Now;
                        while (true)
                        {
                            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                                return false;

                            if ((Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x0001) == 0x0000)
                                break;

                            if ((DateTime.Now - starttime).TotalSeconds > 2)
                                return false;

                            System.Threading.Thread.Sleep(20);
                        }

                        Program.ReaderXP.Options.TagWriteUser.offset = 240;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        System.Threading.Thread.Sleep(20);

                        Program.ReaderXP.Options.TagWriteUser.offset = 269;          //Assume offset start from zero
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                        {
                            Program.ReaderXP.Options.TagWriteUser.offset = 240;
                            Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
                            Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true);
                            return false;
                        }

                        Program.ReaderXP.Options.TagReadUser.offset = 269;
                        Program.ReaderXP.Options.TagReadUser.count = 1;
                        Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                        Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true);

                        break;

                    default:
                        Program.ReaderXP.Options.TagWriteUser.offset = 269;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                            return false;

                        break;
                }
            }

            return true;
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

            value = (Int16)(OverTempThreshold);
            v = (UInt16)((UInt16)(value & 0x1ff) | 0x4400);
            Cmd += v.ToString("X4");

            UInt16 TSCW3 = (UInt16)((DelayUnit << 14) | (DelayValue << 8) | (IntervalUnit << 6) | IntervalValue);
            Cmd += TSCW3.ToString("X4");

            if (!SelectTag (EPC))
            {
                if (ShowError)
                    MessageBox.Show("Selected tag failed");
                return false;
            }

            Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
            //Program.ReaderXP.Options.TagWriteUser.accessPassword = UInt32.Parse(textBox2.Text);
            Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x00000000;

            Program.ReaderXP.Options.TagWriteUser.offset = 236;
            Program.ReaderXP.Options.TagWriteUser.count = 3;
            Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts(Cmd);
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Set Parameter");
                return false;
            }

            Program.ReaderXP.Options.TagWriteUser.offset = 240;
            Program.ReaderXP.Options.TagWriteUser.count = 4;
            Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0188E00080070000");
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Set Parameter");
                return false;
            }

            Program.ReaderXP.Options.TagWriteUser.offset = 269;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0001");
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
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
            Now[3] = (UInt16)((UInt32)(UnixTime(DateTime.Now)) >> 16);
            Now[4] = (UInt16)((UInt32)(UnixTime(DateTime.Now)) & 0xffff);

            Program.ReaderXP.Options.TagWriteUser.offset = 258;
            Program.ReaderXP.Options.TagWriteUser.count = 5;
            Program.ReaderXP.Options.TagWriteUser.pData = Now;
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Cannot Enable Monitor");
                return false;
            }

            Program.ReaderXP.Options.TagReadUser.accessPassword = 0;
            Program.ReaderXP.Options.TagReadUser.retryCount = 7;
            Program.ReaderXP.Options.TagReadUser.offset = 256;
            Program.ReaderXP.Options.TagReadUser.count = 1;
            Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[2]);

            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                if (ShowError)
                    MessageBox.Show("Monitor can not work");
                return false;
            }

            // Check Monitor Bit

            if ((Program.ReaderXP.Options.TagReadUser.pData.ToBytes()[0] & 0x04) == 0x000)
            {
                if (ShowError)
                    MessageBox.Show("Monitor can not work");
                return false;
            }

            return true;
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

        public FormColdChainFeatures()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                button1.Text = "Stop";

                listView1.Clear();

                this.listView1.Columns.Add(this.columnHeader1);
                this.listView1.Columns.Add(this.columnHeader2);
                this.listView1.Columns.Add(this.columnHeader3);
                //this.listView1.Columns.Add(this.columnHeader4);

                // Start Inventory
                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                if (Program.appSetting.tagGroup.selected == Selected.ALL)
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                }
                else
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.SELECT;

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
                Program.ReaderXP.Options.TagRanging.multibanks = 2;
                Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.TID;     // Read TID
                Program.ReaderXP.Options.TagRanging.offset1 = 0;
                Program.ReaderXP.Options.TagRanging.count1 = 2;
                Program.ReaderXP.Options.TagRanging.bank2 = MemoryBank.BANK3;   // Read 188 - 189 (Page 47)
                Program.ReaderXP.Options.TagRanging.offset2 = 188;
                Program.ReaderXP.Options.TagRanging.count2 = 2;
                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button1.Text = "Start";
                Program.ReaderXP.StopOperation(true);

                while (Program.ReaderXP.State != RFState.IDLE)
                    System.Threading.Thread.Sleep(1000);
            }
        }

        private void FormColdChainFeatures_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            AttachCallback(true);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                button3.Text = "Stop";
                button4.Enabled = false;
                button5.Enabled = false;

                listView2.Clear();

                this.listView2.Columns.Add(this.columnHeader5);
                this.listView2.Columns.Add(this.columnHeader6);
                this.listView2.Columns.Add(this.columnHeader7);

                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                if (Program.appSetting.tagGroup.selected == Selected.ALL)
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                }
                else
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.SELECT;

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
                Program.ReaderXP.Options.TagRanging.multibanks = 2;
                Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.BANK3;
                Program.ReaderXP.Options.TagRanging.offset1 = 188;
                Program.ReaderXP.Options.TagRanging.count1 = 2;
                //Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.TID;
                //Program.ReaderXP.Options.TagRanging.offset1 = 0;
                //Program.ReaderXP.Options.TagRanging.count1 = 2;
                Program.ReaderXP.Options.TagRanging.bank2 = MemoryBank.BANK3;
                Program.ReaderXP.Options.TagRanging.offset2 = 269;
                Program.ReaderXP.Options.TagRanging.count2 = 1;
                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button3.Text = "Scan";

                Program.ReaderXP.StopOperation(true);

                while (Program.ReaderXP.State != RFState.IDLE)
                    System.Threading.Thread.Sleep(1000);

                button4.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cnt;
            bool AllDone = true;

            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            for (cnt = 0; cnt < listView2.Items.Count; cnt++)
                if (listView2.Items[cnt].SubItems[2].Text != "Enable")
                    if (TagColdChain_SetBapMode(listView2.Items[cnt].SubItems[1].Text, 0x00000000, true, false))
                    {
                        listView2.Items[cnt].SubItems[2].Text = "Enable";
                    }
                    else
                    {
                        listView2.Items[cnt].SubItems[2].Text = "Error";
                        AllDone = false;
                    }

            if (AllDone)
                MessageBox.Show("All Done!");
            else
                MessageBox.Show("Some Error, Please Check!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cnt;
            bool AllDone = true;

            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            for (cnt = 0; cnt < listView2.Items.Count; cnt++)
                if (listView2.Items[cnt].SubItems[2].Text != "Disable")
                    if (TagColdChain_SetBapMode(listView2.Items[cnt].SubItems[1].Text, 0x00000000, false, false))
                    {
                        listView2.Items[cnt].SubItems[2].Text = "Disable";
                    }
                    else
                    {
                        listView2.Items[cnt].SubItems[2].Text = "Error";
                        AllDone = false;
                    }

            if (AllDone)
                MessageBox.Show("All Done!");
            else
                MessageBox.Show("Some Error, Please Check!");
        }

        double RefTemp = 0;
        double CurveA1;
        double CurveB1;
        double CurveA2;
        double CurveB2;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RawRefTemp"></param>
        /// <param name="RawCurve1Value"></param>
        /// <param name="RawCurve2Value"></param>
        /// <returns></returns>
        bool ColdChain_SetBilinearParams(byte RawRefTemp, UInt16 RawCurve1Value, UInt16 RawCurve2Value)
        {
            try
            {
                RefTemp = RawRefTemp - 40;
                CurveA1 = (double)((sbyte)(RawCurve1Value >> 8)) / 1000.0;
                CurveB1 = (double)((sbyte)(RawCurve1Value & 0xff)) / 100.0;
                CurveA2 = (double)((sbyte)(RawCurve2Value >> 8)) / 1000.0;
                CurveB2 = (double)((sbyte)(RawCurve2Value & 0xff)) / 100.0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Convert to Calibrated Temperature from ColdChain Tag Raw Temp value
        /// </summary>
        /// <returns></returns>
        double ColdChain_BilinearConversion(UInt16 RawValue)
        {
            double CaledTemp;

            RawValue = (UInt16)(RawValue & 0x1ffU);

            if (RawValue <= 255)
                CaledTemp = (double)RawValue / 4;
            else
                CaledTemp = (double)((RawValue & 0xff) - 0x100) / 4;

            if (CaledTemp < RefTemp)
                CaledTemp = CaledTemp + CaledTemp * CurveA1 + CurveB1;
            else if (CaledTemp > RefTemp)
                CaledTemp = CaledTemp + CaledTemp * CurveA2 + CurveB2;

            return CaledTemp;
        }

        double ColdChain_BilinearConversion(UInt16 RawTemp, byte RawRefTemp, UInt16 RawCurve1Value, UInt16 RawCurve2Value)
        {
            return ColdChain_BilinearConversion(ColdChain_RawTempConversion(RawTemp), RawRefTemp, RawCurve1Value, RawCurve2Value);
        }

        double ColdChain_BilinearConversion(double Temp, byte RawRefTemp, UInt16 RawCurve1Value, UInt16 RawCurve2Value)
        {
            double RefTemp = (RawRefTemp - 40);

            if (Temp < RefTemp)
                return ColdChain_BilinearConversion(Temp, RawCurve1Value);
            else if (Temp > RefTemp)
                return ColdChain_BilinearConversion(Temp, RawCurve2Value);

            return Temp;
        }

        double ColdChain_BilinearConversion(UInt16 RawTemp, UInt16 RawCurve)
        {
            return ColdChain_BilinearConversion(ColdChain_RawTempConversion(RawTemp), (sbyte)(RawCurve >> 8), (sbyte)(RawCurve & 0xff));
        }

        double ColdChain_BilinearConversion(double Temp, UInt16 RawCurve)
        {
            return ColdChain_BilinearConversion(Temp, (sbyte)(RawCurve >> 8), (sbyte)(RawCurve & 0xff));
        }

        double ColdChain_BilinearConversion(double Temp, sbyte RawA, sbyte RawB)
        {
            return (ColdChain_BilinearConversion(Temp, (double)(RawA) / 1000.0, (double)(RawB) / 100.0));
        }

        double ColdChain_BilinearConversion(double Temp, double CurveA, double CurveB)
        {
            return (Temp + Temp * CurveA + CurveB);
        }

        double ColdChain_RawTempConversion(UInt16 RawTemp)
        {
            RawTemp = (UInt16)(RawTemp & 0x1ffU);

            if (RawTemp <= 255)
                return (double)RawTemp / 4;
            else
                return (double)((RawTemp & 0xff) - 0x100) / 4;
        }

        private string CheckTemp(double TargetTemp, double CurrentTemp)
        {
            return (CurrentTemp < (TargetTemp - 0.5) || CurrentTemp > (TargetTemp + 0.5)) ? " Fail" : " Scuuess";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                button8.Text = "Stop";
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;

                listView4.Clear();
                this.listView4.Columns.Add(this.columnHeader18);
                this.listView4.Columns.Add(this.columnHeader8);
                this.listView4.Columns.Add(this.columnHeader9);
                this.listView4.Columns.Add(this.columnHeader10);
                this.listView4.Columns.Add(this.columnHeader11);
                this.listView4.Columns.Add(this.columnHeader12);
                this.listView4.Columns.Add(this.columnHeader19);
                this.listView4.Columns.Add(this.columnHeader20);
                this.listView4.Columns.Add(this.columnHeader21);
                this.listView4.Columns.Add(this.columnHeader22);
                this.listView4.Columns.Add(this.columnHeader23);

                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                if (Program.appSetting.tagGroup.selected == Selected.ALL)
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                }
                else
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.SELECT;

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

                Program.ReaderXP.Options.TagRanging.multibanks = 2;
                Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.BANK3;
                Program.ReaderXP.Options.TagRanging.offset1 = 188;
                Program.ReaderXP.Options.TagRanging.count1 = 4;
                Program.ReaderXP.Options.TagRanging.bank2 = MemoryBank.BANK3;  // Read 256 - 269
                Program.ReaderXP.Options.TagRanging.offset2 = 256;
                Program.ReaderXP.Options.TagRanging.count2 = 14;

                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button8.Text = "Scan";

                Program.ReaderXP.StopOperation(true);

                while (Program.ReaderXP.State != RFState.IDLE)
                    System.Threading.Thread.Sleep(1000);

                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AttachCallback(false);

            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
                System.Threading.Thread.Sleep(100);
            }

            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
            }

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    button1.Text = "Start";
                    button2.Text = "Exit";
                    button1.Enabled = true;
                    button2.Enabled = true;
                    break;
                case 1:
                    button3.Text = "Start";
                    button4.Text = "Enable";
                    button5.Text = "Disable";
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    break;
                case 2:
                    button8.Text = "Scan";
                    button9.Text = "Enable";
                    button10.Text = "Disable";
                    button11.Text = "Config";
                    button8.Enabled = true;
                    button9.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                    break;
                case 3:
                    button12.Text = "Scan";
                    button13.Text = "Start Log";
                    button14.Text = "End Log";
                    button12.Enabled = true;
                    button13.Enabled = true;
                    button14.Enabled = true;
                    break;
                case 4:
                    AttachCallback(false);
                    Close();
                    break;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                button12.Text = "Stop";
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;

                listView5.Clear();
                this.listView5.Columns.Add(this.columnHeader24);
                this.listView5.Columns.Add(this.columnHeader25);
                this.listView5.Columns.Add(this.columnHeader26);
                this.listView5.Columns.Add(this.columnHeader27);
                this.listView5.Columns.Add(this.columnHeaderT5_28);
                this.listView5.Columns.Add(this.columnHeaderT5_29);

                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                if (Program.appSetting.tagGroup.selected == Selected.ALL)
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                }
                else
                {
                    Program.ReaderXP.Options.TagRanging.flags = SelectFlags.SELECT;

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

                Program.ReaderXP.Options.TagRanging.multibanks = 2;
                Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.BANK3;
                Program.ReaderXP.Options.TagRanging.offset1 = 188;
                Program.ReaderXP.Options.TagRanging.count1 = 2;
                Program.ReaderXP.Options.TagRanging.bank2 = MemoryBank.BANK3;
                //Program.ReaderXP.Options.TagRanging.offset2 = 260;
                //Program.ReaderXP.Options.TagRanging.count2 = 5;
                Program.ReaderXP.Options.TagRanging.offset2 = 256;
                Program.ReaderXP.Options.TagRanging.count2 = 9;
                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button12.Text = "Scan";

                Program.ReaderXP.StopOperation(true);

                while (Program.ReaderXP.State != RFState.IDLE)
                    System.Threading.Thread.Sleep(1000);

                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool AllDone = true;

            if (listView5.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            ColdChain_DebugLog("Start Log");
            
            for (int cnt = 0; cnt < listView5.Items.Count; cnt++)
            {
                if (listView5.Items[cnt].SubItems[2].Text != "Recording")
                {
                    if (!SelectTag(listView5.Items[cnt].SubItems[1].Text))
                        return;

                    System.Threading.Thread.Sleep(100);

                    UInt32 uut = (UInt32)UnixTime(DateTime.Now);
                    UInt16 Offset = (UInt16)(Math.Abs (double.Parse(textBox_TempOffset.Text)) * 4);
                    UInt16 UTemp1 = (UInt16)(double.Parse(textBox_UTH1.Text) * 4);
                    UInt16 OTemp1 = (UInt16)(double.Parse(textBox_OTH1.Text) * 4);
                    UInt16 UTemp2 = (UInt16)(double.Parse(textBox_UTH2.Text) * 4);
                    UInt16 OTemp2 = (UInt16)(double.Parse(textBox_OTH2.Text) * 4);
                    UInt16 Count = (UInt16)((UInt16.Parse (textBox_THC1.Text) << 3) | (UInt16.Parse (textBox_THC2.Text) << 9));

                    Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x0;

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 0;
                    Program.ReaderXP.Options.TagWriteUser.count = 4;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[4];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = (UInt16)(uut >> 16);
                    Program.ReaderXP.Options.TagWriteUser.pData[1] = (UInt16)(uut & 0xffff);
                    Program.ReaderXP.Options.TagWriteUser.pData[2] = UInt16.Parse(textBox15.Text);
                    Program.ReaderXP.Options.TagWriteUser.pData[3] = (UInt16)(Offset);
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 262;
                    Program.ReaderXP.Options.TagWriteUser.count = 3;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[3];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = (UInt16)(OTemp1);
                    Program.ReaderXP.Options.TagWriteUser.pData[1] = (UInt16)(UTemp1);
                    Program.ReaderXP.Options.TagWriteUser.pData[2] = Count;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 266;
                    Program.ReaderXP.Options.TagWriteUser.count = 2;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[2];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = (UInt16)(OTemp2);
                    Program.ReaderXP.Options.TagWriteUser.pData[1] = (UInt16)(UTemp2);
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 260;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0001;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    System.Threading.Thread.Sleep(100);

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa000;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    // Dummy read
                    {
                        S_DATA value = new S_DATA("0000");
                        ReadUserData(240, 1, ref value);
                    }
                    
                    listView5.Items[cnt].SubItems[2].Text = "Recording";
                    listView5.Items[cnt].SubItems[3].Text = "";
                    listView5.Items[cnt].SubItems[4].Text = "";
                }
            }

            for (int cnt = 0; cnt < listView5.Items.Count; cnt++)
            {
                ColdChain_DebugLog( listView5.Items[cnt].SubItems[0].Text + ", " + 
                                    listView5.Items[cnt].SubItems[1].Text + ", " + 
                                    listView5.Items[cnt].SubItems[2].Text);
            }

            if (AllDone)
                MessageBox.Show("All Done!");
            else
                MessageBox.Show("Some Error, Please Check!");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool AllDone = true;

            if (listView5.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            ColdChain_DebugLog("End Log");
            
            for (int cnt = 0; cnt < listView5.Items.Count; cnt++)
            {
                if (listView5.Items[cnt].SubItems[2].Text != "Stop")
                {
                    if (!SelectTag (listView5.Items[cnt].SubItems[1].Text))
                    {
                        AllDone = false;
                        continue;
                    }

                    System.Threading.Thread.Sleep(100);

                    Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x0;

                    Program.ReaderXP.Options.TagWriteUser.offset = 260;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0002;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue; 
                    }

                    System.Threading.Thread.Sleep(100);

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    System.Threading.Thread.Sleep(100);

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    System.Threading.Thread.Sleep(100);

                    Program.ReaderXP.Options.TagReadUser.retryCount = 7;
                    Program.ReaderXP.Options.TagReadUser.offset = 264;
                    Program.ReaderXP.Options.TagReadUser.count = 1;
                    Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new UInt16[1]);
                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    System.Threading.Thread.Sleep(100);

                    listView5.Items[cnt].SubItems[3].Text = "OK";
                    listView5.Items[cnt].SubItems[4].Text = "OK";
                    if ((Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x0006) != 0x0000)
                    {
                        if ((Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x0002) != 0x0000)
                            listView5.Items[cnt].SubItems[3].Text = "Fail";
                        
                        if ((Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x0004) != 0x0000)
                            listView5.Items[cnt].SubItems[4].Text = "Fail";

                        System.Threading.Thread.Sleep(100);
                        // Show Temperature alarm on LED
                        Program.ReaderXP.Options.TagWriteUser.offset = 264;
                        Program.ReaderXP.Options.TagWriteUser.count = 1;
                        Program.ReaderXP.Options.TagWriteUser.pData[0] = (UInt16)(Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] | 0x01);
                        if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                        {
                            AllDone = false;
                            continue;
                        }
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
                    Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        AllDone = false;
                        continue;
                    }

                    // Dummy read
                    {
                        S_DATA value = new S_DATA("0000");
                        ReadUserData(240, 1, ref value);
                    }

                    listView5.Items[cnt].SubItems[2].Text = "Stop";
                    listView5.Items[cnt].SubItems[5].Text = "";
                }
            }

            for (int cnt = 0; cnt < listView5.Items.Count; cnt++)
            {
                ColdChain_DebugLog(listView5.Items[cnt].SubItems[0].Text + ", " +
                                    listView5.Items[cnt].SubItems[1].Text + ", " +
                                    listView5.Items[cnt].SubItems[2].Text + ", " +
                                    listView5.Items[cnt].SubItems[3].Text + ", " +
                                    listView5.Items[cnt].SubItems[4].Text);
            }

            if (AllDone)
                MessageBox.Show("All Done!");
            else
                MessageBox.Show("Some Error, Please Check!");

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Please select tag first");
                return;
            }
            
            using (FormColdChainViewLog form = new FormColdChainViewLog())
            {
                form.textBox14.Text = listView5.Items[listView5.SelectedIndices[0]].SubItems[1].Text;
                form.ShowDialog();
            }
        }

        Double UnderTempThreshold = -40;
        Double OverTempThreshold = 63;
        int DelayUnit = 0;
        UInt16 DelayValue = 1;
        int IntervalUnit = 0;
        UInt16 IntervalValue = 1;
        UInt16 UnderTempCount = 1;
        UInt16 OverTempCount = 1;

        private void button11_Click(object sender, EventArgs e)
        {
            using (FormColdChainMonitorConfig form = new FormColdChainMonitorConfig())
            {
                form.textBox3.Text = UnderTempThreshold.ToString ();
                form.textBox4.Text = OverTempThreshold.ToString ();
                form.comboBox1.SelectedIndex = DelayUnit;
                form.textBox5.Text = DelayValue.ToString ();
                form.comboBox2.SelectedIndex = IntervalUnit;
                form.textBox6.Text = IntervalValue.ToString ();
                form.textBoxD8.Text = UnderTempCount.ToString ();
                form.textBoxD9.Text = OverTempCount.ToString();

                form.ShowDialog();

                UnderTempThreshold = double.Parse (form.textBox3.Text);
                OverTempThreshold = double.Parse (form.textBox4.Text);
                DelayUnit = form.comboBox1.SelectedIndex;
                DelayValue = UInt16.Parse(form.textBox5.Text);
                IntervalUnit = form.comboBox2.SelectedIndex;
                IntervalValue = UInt16.Parse(form.textBox6.Text);
                UnderTempCount = UInt16.Parse (form.textBoxD8.Text);
                OverTempCount = UInt16.Parse (form.textBoxD9.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool AllDone = true;

            if (listView4.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            //UnderTempThreshold = Double.Parse(textBox3.Text) / .25;
            //OverTempThreshold = Double.Parse(textBox4.Text) / .25;

            for (int cnt = 0; cnt < listView4.Items.Count; cnt++)
            {
                listView4.Items[cnt].SubItems[3].Text = "";
                listView4.Items[cnt].SubItems[4].Text = "";


/*                if (listView4.Items[cnt].SubItems[2].Text != "Disable")
                {
                    Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                    Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(listView4.Items[cnt].SubItems[1].Text);
                    Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) == Result.OK)
                        listView4.Items[cnt].SubItems[2].Text = "Disable";
                    else
                        listView4.Items[cnt].SubItems[2].Text = "Disable Failed";
                }
*/
                if (listView4.Items[cnt].SubItems[2].Text == "Disable")
                {
                    Int16 value;
                    UInt16 v;
                    string Cmd;

                    //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);

                    Double UnderTempThresholdRaw = UnderTempThreshold / .25;
                    Double OverTempThresholdRaw = OverTempThreshold / .25;

                    value = (Int16)(UnderTempThresholdRaw);
                    v = (UInt16)(0x4000 | (UInt16)((UnderTempCount & 0x1f) << 9) | (UInt16)(value & 0x1ff));
                    Cmd = v.ToString("X4");

                    value = (Int16)(OverTempThresholdRaw);
                    v = (UInt16)(0x4000 | (UInt16)((OverTempCount & 0x1f) << 9) | (UInt16)(value & 0x1ff));
                    Cmd += v.ToString("X4");

                    UInt16 TSCW3 = (UInt16)((DelayUnit << 14) | (DelayValue << 8) | (IntervalUnit << 6) | IntervalValue);
                    Cmd += TSCW3.ToString("X4");

                    if (!SelectTag (listView4.Items[cnt].SubItems[1].Text))
                    {
                        //MessageBox.Show("Selected tag failed");
                        return;
                    }

                    Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x00000000;

                    Program.ReaderXP.Options.TagWriteUser.offset = 236;
                    Program.ReaderXP.Options.TagWriteUser.count = 3;
                    Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts(Cmd);
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Cannot Set Parameter");
                        return;
                    }

                    Program.ReaderXP.Options.TagWriteUser.offset = 240;
                    Program.ReaderXP.Options.TagWriteUser.count = 4;
                    Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0188E00080070000");
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Cannot Set Parameter");
                        return;
                    }


                    Program.ReaderXP.Options.TagWriteUser.offset = 269;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0001");
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Cannot Set Parameter");
                        return;
                    }

                    // Start Monitoring

                    UInt16[] Now = new UInt16[5];
                    Now[0] = 0x8000;
                    Now[1] = 0x0000;
                    Now[2] = 0x0000;
                    Now[3] = (UInt16)((UInt32)(UnixTime(DateTime.Now)) >> 16);
                    Now[4] = (UInt16)((UInt32)(UnixTime(DateTime.Now)) & 0xffff);

                    Program.ReaderXP.Options.TagWriteUser.offset = 258;
                    Program.ReaderXP.Options.TagWriteUser.count = 5;
                    Program.ReaderXP.Options.TagWriteUser.pData = Now;
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Cannot Enable Monitor");
                        return;
                    }

                    Program.ReaderXP.Options.TagReadUser.accessPassword = 0;
                    Program.ReaderXP.Options.TagReadUser.retryCount = 7;
                    Program.ReaderXP.Options.TagReadUser.offset = 256;
                    Program.ReaderXP.Options.TagReadUser.count = 1;
                    Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[2]);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Monitor can not work");
                        return;
                    }

                    // Check Monitor Bit

                    if ((Program.ReaderXP.Options.TagReadUser.pData.ToBytes()[0] & 0x04) == 0x000)
                    {
                        //MessageBox.Show("Monitor can not work");
                        return;
                    }

                    listView4.Items[cnt].SubItems[2].Text = "Enable";
                }
            }
        }

        private bool DisableMonitor(string EPC, UInt32 Password)
        {
            if (!SelectTag(EPC))
                return false;

            Program.ReaderXP.Options.TagWriteUser.retryCount = 30;
            Program.ReaderXP.Options.TagWriteUser.accessPassword = Password;
            Program.ReaderXP.Options.TagWriteUser.offset = 238;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0406");
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                return false;

            return true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool AllDone = true;

            if (listView4.Items.Count == 0)
            {
                MessageBox.Show("No Tag found, please 'Scan' tag first");
                return;
            }

            for (int cnt = 0; cnt < listView4.Items.Count; cnt++)
            {
                if (listView4.Items[cnt].SubItems[2].Text != "Disable")
                {
                    if (!SelectTag(listView4.Items[cnt].SubItems[1].Text))
                        return;

                    // Start Monitoring
                    Program.ReaderXP.Options.TagWriteUser.retryCount = 30;
                    Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x00000000;
                    Program.ReaderXP.Options.TagWriteUser.offset = 238;
                    Program.ReaderXP.Options.TagWriteUser.count = 1;
                    Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts("0406");
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    {
                        //MessageBox.Show("Cannot Stop Monitor");
                        return;
                    }

                    listView4.Items[cnt].SubItems[2].Text = "Disable";
                }
            }
        }

        Boolean OnePointCal = false;
        double MinCalTemp = -24;
        double MidCalTemp = 4;
        double MaxCalTemp = 64;
        UInt32 TagNumber = 20;
        UInt32 ReadAvg = 3;
        bool MonitorEnable = true;
        private void button16_Click(object sender, EventArgs e)
        {
            using (FormColdChainTempCalConfig form = new FormColdChainTempCalConfig())
            {
                if (OnePointCal)
                {
                    form.radioButton1.Checked = true;
                    form.radioButton2.Checked = false;
                }
                else
                {
                    form.radioButton1.Checked = false;
                    form.radioButton2.Checked = true;
                }

                form.textBox1.Text = MinCalTemp.ToString();
                form.textBox2.Text = MidCalTemp.ToString();
                form.textBox3.Text = MaxCalTemp.ToString();
                form.textBox4.Text = ReadAvg.ToString();
                form.textBox5.Text = TagNumber.ToString();
                form.checkBox1.Checked = MonitorEnable;

                form.ShowDialog();

                OnePointCal = form.radioButton1.Checked;
                MinCalTemp = double.Parse (form.textBox1.Text);
                MidCalTemp = double.Parse(form.textBox2.Text);
                MaxCalTemp = double.Parse(form.textBox3.Text);
                ReadAvg = UInt32.Parse(form.textBox4.Text);
                TagNumber = UInt32.Parse(form.textBox5.Text);
                MonitorEnable = form.checkBox1.Checked;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP...");
            return;

            if (listView4.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Please select tag first");
                return;
            }

            if (!SelectTag (listView1.Items[listView4.SelectedIndices[0]].SubItems[1].Text))
            {
                MessageBox.Show("Select Tag Fail");
                return;
            }


            Program.ReaderXP.Options.TagReadUser.accessPassword = 0x00000000;
            Program.ReaderXP.Options.TagReadUser.offset = 256;
            Program.ReaderXP.Options.TagReadUser.count = 14;

            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                MessageBox.Show("Read Tag Fail");
                return;
            }

            //Program.ReaderXP.Options.TagRanging..bank2 = MemoryBank.BANK3;  // Read 256 - 269
            //Program.ReaderXP.Options.TagRanging.offset2 = 256;
            //Program.ReaderXP.Options.TagRanging.count2 = 14;


            UInt16 SensorDataMsw, SensorDataLsw;
            DateTime D10, D11;
            UInt32 StartTime, AlarmTime;

            if (listView1.SelectedIndices.Count <= 0)
                return;

            SensorDataMsw = UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[5].Text);
            SensorDataLsw = UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text);

            StartTime = (UInt32)((UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[9].Text) << 16) | UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[10].Text));
            AlarmTime = (UInt32)(((UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[7].Text) ^ 0x8000) << 16) | UInt16.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text));

            D10 = DateTime.Now;
            //D10 = ConvertFromUnixTimestamp(StartTime);
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






        // new routine for teting

        bool SelectTag(string EPC)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.bank = MemoryBank.EPC;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(EPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            return (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) == Result.OK);
        }

        bool WriteUserData(ushort Offset, ushort Count, UInt16[] data)
        {
            Console.Write("Write User Data Offset:{0} Count:{1} Data:{2}", Offset, Count, data);

            Program.ReaderXP.Options.TagWriteUser.accessPassword = 0;
            Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
            Program.ReaderXP.Options.TagWriteUser.offset = Offset;
            Program.ReaderXP.Options.TagWriteUser.count = Count;
            Program.ReaderXP.Options.TagWriteUser.pData = data;
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) == Result.OK)
            {
                Console.WriteLine(" OK");
                return true;
            };

            Console.WriteLine(" Fail");
            return false;
        }

        bool ReadUserData(ushort Offset, ushort Count, ref S_DATA data)
        {
            Console.Write ("Read User Data Offset:{0} Count:{1}", Offset, Count);

            Program.ReaderXP.Options.TagWriteUser.accessPassword = 0;
            Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
            Program.ReaderXP.Options.TagReadUser.offset = Offset;
            Program.ReaderXP.Options.TagReadUser.count = Count;
            Program.ReaderXP.Options.TagReadUser.pData = data;
            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) == Result.OK)
            {
                Console.WriteLine(" OK");
                data = Program.ReaderXP.Options.TagReadUser.pData;
                Console.WriteLine(" Data:{0} OK", data);
                return true;
            }

            Console.WriteLine(" Fail");
            return false;
        }

        void ColdChain_RefreashTemperature()
        {
            Program.ReaderXP.Options.TagWriteUser.accessPassword = 0;
            Program.ReaderXP.Options.TagWriteUser.retryCount = 0;
            Program.ReaderXP.Options.TagWriteUser.offset = 256;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = new UInt16 [1] {0x100};
            Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true);
        }

        bool ColdChain_ReadRawTemperature(out UInt16 value)
        {
            S_DATA buf = new S_DATA(new UInt16 [1]);

            for (int cnt = 0; cnt < 2; cnt++)
            {
                ColdChain_RefreashTemperature();

                if (ReadUserData(256, 1, ref buf))
                {
                    value = (UInt16)(Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x1ff);
                    if (value != 0x100)
                        return true;
                }
            }

            value = 0;
            return false;
        }

        private bool ColdChain_ReadAvgTemp(UInt32 AvgTime, out double AvgTemp)
        {
            UInt16 RawTemp;
            AvgTemp = 0;

            for (UInt16 cnt1 = 0; cnt1 < AvgTime; cnt1++)
            {
                if (!ColdChain_ReadRawTemperature (out RawTemp))
                    return false;

                AvgTemp += ColdChain_RawTempConversion(RawTemp);
            }

            AvgTemp = AvgTemp / AvgTime;
            return true;
        }

        private bool ColdChain_ReadCaledAvgTemp(UInt32 AvgTime, out double AvgTemp)
        {
            UInt16 RawTemp;
            AvgTemp = 0;

            for (UInt16 cnt1 = 0; cnt1 < AvgTime; cnt1++)
            {
                if (!ColdChain_ReadRawTemperature(out RawTemp))
                {
                    Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                    return false;
                }

                AvgTemp += ColdChain_RawTempConversion(RawTemp);
            }

            AvgTemp = AvgTemp / AvgTime;

            S_DATA buf = new S_DATA(new UInt16[3]);

            if (ReadUserData(189, 3, ref buf))
            {
                UInt16[] CalData = buf.ToUshorts();
                AvgTemp = ColdChain_BilinearConversion(AvgTemp, (byte)(CalData[0] & 0xff), CalData[1], CalData[2]);
            }

            return true;
        }

        bool ColdChain_WriteTSCW(UInt16 value)
        {
            UInt16[] buf = new UInt16 [1] {value};

            return WriteUserData(239, 1, buf);
        }

        bool ColdChain_ReadTSCW (out UInt16 value)
        {
            S_DATA buf = new S_DATA (new UInt16 [1]);

            if (ReadUserData(239, 1, ref buf))
            {
                value = buf.ToUshorts()[0];
                return true;
            }

            value = 0x00;
            return false;
        }

        private void textBox_TempOffset_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TempOffset_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox_TempOffset_Validating_1(object sender, CancelEventArgs e)
        {
            double value;

            try
            {
                value = Math.Round(double.Parse(textBox_TempOffset.Text) * 4) / 4;

                if (value < -20)
                    value = -20;
                else if (value > 0)
                    value = 0;

                textBox_TempOffset.Text = value.ToString();
                label_TempRange.Text = "(Cur. Range " + textBox_TempOffset.Text + "~" + (value + 63.75).ToString() + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input error!");
                textBox_TempOffset.Text = "-20";
            }
        }

        public static void ColdChain_DebugLog(string info)
        {
            try
            {
                System.IO.StreamWriter tw = new System.IO.StreamWriter("ColdChainDebugLog.txt", true);
                tw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + info);
                tw.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public static void ColdChain_DataLog(string info)
        {
            try
            {
                System.IO.StreamWriter tw = new System.IO.StreamWriter("ColdChainDataLog.csv", true);
                tw.WriteLine(info);
                tw.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_DateTimeNow.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void FormColdChainFeatures_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void textBox_THC1_Validating(object sender, CancelEventArgs e)
        {
            UInt16 value;

            try
            {
                value = UInt16.Parse(textBox_THC1.Text);
                if (value > 63)
                    textBox_THC1.Text = "63";
                else
                    textBox_THC1.Text = value.ToString();
            }
            catch (Exception ex)
            {
                textBox_THC1.Text = "1";
            }
        }

        private void textBox_THC2_Validating(object sender, CancelEventArgs e)
        {
            UInt16 value;

            try
            {
                value = UInt16.Parse(textBox_THC2.Text);
                if (value > 63)
                    textBox_THC2.Text = "63";
                else
                    textBox_THC2.Text = value.ToString();
            }
            catch (Exception ex)
            {
                textBox_THC2.Text = "1";
            }
        }

        private void textBox_THC1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_OTH1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
