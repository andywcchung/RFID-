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
    using CSLibrary.Text;

    public partial class FormCS9010 : Form
    {
        public FormCS9010()
        {
            InitializeComponent();
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
            }
        }

        void CS9010Info(TagCallbackInfo info)
        {
            string EPC;
            string LowBatAlarm;
            bool find = false;

            EPC = info.epc.ToString().Substring(0, (int)(info.pc.EPCLength * 4));

            if ((info.epc.ToUshorts()[info.pc.EPCLength + 2] & 0x02) != 00)
                LowBatAlarm = "Fail";
            else
                LowBatAlarm = "OK";

            for (int cnt = 0; cnt < listView1.Items.Count; cnt++)
            {
                if (listView1.Items[cnt].SubItems[0].Text == EPC)
                {
                    find = true;
                    listView1.Items[cnt].SubItems[3].Text = LowBatAlarm;
                    break;
                }
            }

            if (find == false)
            {
                ListViewItem ins = new ListViewItem(EPC);
                ins.SubItems.Add("");
                ins.SubItems.Add("");
                ins.SubItems.Add(LowBatAlarm);

                listView1.Items.Add(ins);
            }
        }

        void Reader_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            Invoke((System.Threading.ThreadStart)delegate()
            {
                UInt32 tid;

                try
                {
                    if (e.type == CallbackType.TAG_RANGING)
                    {
                        if (e.info.epc.GetLength() < e.info.pc.EPCLength + 3)
                            return;

                        tid = (UInt32)((e.info.epc.ToUshorts()[e.info.pc.EPCLength] << 16) | e.info.epc.ToUshorts()[e.info.pc.EPCLength + 1]);
                        if (tid != 0xe200b001U && tid != 0xe200b002U)
                            return;

                        CS9010Info (e.info);
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }


        void StartInventory()
        {
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
            Program.ReaderXP.Options.TagRanging.bank1 = MemoryBank.TID;
            Program.ReaderXP.Options.TagRanging.offset1 = 0;
            Program.ReaderXP.Options.TagRanging.count1 = 2;
            Program.ReaderXP.Options.TagRanging.bank2 = MemoryBank.BANK3;
            Program.ReaderXP.Options.TagRanging.offset2 = 45;
            Program.ReaderXP.Options.TagRanging.count2 = 1;
            Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
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

        private void FormCS9010_Load(object sender, EventArgs e)
        {
            AttachCallback(true);

            this.listView1.Columns[0].Width = 260;  // EPC
            this.listView1.Columns[1].Width = 0;
            this.listView1.Columns[2].Width = 0;
            this.listView1.Columns[3].Width = 30;   // Battery Alert
            this.listView1.Columns[4].Width = 0;    // Sensor Data MSW
            this.listView1.Columns[5].Width = 0;    // Sensor Data LSW
            this.listView1.Columns[6].Width = 0;    // UTC MSW
            this.listView1.Columns[7].Width = 0;    // UTC LSW
            this.listView1.Columns[8].Width = 0;    // Start Time MSW
            this.listView1.Columns[9].Width = 0;    // Start Time LSW
        }

        private void FormCS9010_Closing(object sender, CancelEventArgs e)
        {
            AttachCallback(false);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                btn_start.Text = "Stop";

                listView1.Clear();

                this.listView1.Columns.Add(this.columnHeader1);
                this.listView1.Columns.Add(this.columnHeader2);
                this.listView1.Columns.Add(this.columnHeader3);
                this.listView1.Columns.Add(this.columnHeader4);

                StartInventory();
            }
            else
            {
                btn_start.Text = "Start";
                Program.ReaderXP.StopOperation(true);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
                Program.ReaderXP.StopOperation(true);

            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                btn_start.Text = "Start";
                Program.ReaderXP.StopOperation(true);
            }

            if (tabControl1.SelectedIndex == 2)
                this.Close();

            if (listView1.SelectedIndices.Count > 0)
            {
                int a = listView1.SelectedIndices[0];
                textBox1.Text = listView1.Items[a].SubItems[0].Text;
            }
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
    }
}
