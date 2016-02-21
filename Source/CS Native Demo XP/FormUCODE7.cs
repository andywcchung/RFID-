using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CSLibrary;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormUCODE7 : Form
    {
        public FormUCODE7()
        {
            InitializeComponent();
        }

        void Reader_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            // Check Callback Type
            if (e.type != CSLibrary.Constants.CallbackType.TAG_RANGING)
                return;

            UInt32 TID, TID1;
            string EPC;
            UInt16[] tagdata = e.info.epc.ToUshorts();

            // Check TID code (exclude if scan temp)
            //TID = (UInt32)((tagdata[e.info.pc.EPCLength] << 16) | tagdata[e.info.pc.EPCLength + 1]) & 0xffffffc0U;
            //if (TID != 0xe2806e80U && TID != 0xe2806e8fU && TID != 0xe2806800U)
            //    return;

            TID = (UInt32)((tagdata[e.info.pc.EPCLength] << 16) | tagdata[e.info.pc.EPCLength + 1]);
            TID1 = TID & 0xffffffc0U;
            if (TID1 != 0xe2806e80U && TID1 != 0xe2806e8fU && TID1 != 0xe2806800U)
                return;

            EPC = e.info.epc.ToString().Substring(0, (int)(e.info.pc.EPCLength * 4)) + ":" + TID.ToString("X8");

            BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                lock (listView1)
                {
                    int cnt;

                    for (cnt = 0; cnt < listView1.Items.Count; cnt++)
                        if (listView1.Items[cnt].SubItems[1].Text == EPC)
                            break;

                    if (cnt == listView1.Items.Count)
                    {
                        ListViewItem ins = new ListViewItem((listView1.Items.Count + 1).ToString());
                        ins.SubItems.Add(EPC);

                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0800) != 0x0000)
                            ins.SubItems.Add("1");
                        else
                            ins.SubItems.Add("0");

                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0040) != 0x0000)
                            ins.SubItems.Add("1");
                        else
                            ins.SubItems.Add("0");

                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0001) != 0x0000)
                            ins.SubItems.Add("1");
                        else
                            ins.SubItems.Add("0");

                        listView1.Items.Add(ins);
                    }
                    else
                    {
                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0800) != 0x0000)
                            listView1.Items[cnt].SubItems[2].Text = "1";
                        else
                            listView1.Items[cnt].SubItems[2].Text = "0";

                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0040) != 0x0000)
                            listView1.Items[cnt].SubItems[3].Text = "1";
                        else
                            listView1.Items[cnt].SubItems[3].Text = "0";

                        if ((tagdata[e.info.pc.EPCLength + 2] & 0x0001) != 0x0000)
                            listView1.Items[cnt].SubItems[4].Text = "1";
                        else
                            listView1.Items[cnt].SubItems[4].Text = "0";
                    }
                }
            });
        }

        // System Function
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                //Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                //Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                //Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                //Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
        }

        private void FormUCODE7_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        bool SelectTag()
        {
            Program.ReaderXP.Options.TagSelected.ParallelEncoding = true;
            Program.ReaderXP.Options.TagSelected.flags = CSLibrary.Constants.SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.bank = CSLibrary.Constants.MemoryBank.EPC;
            Program.ReaderXP.Options.TagSelected.epcMask = new  CSLibrary.Structures.S_MASK ("8000");
            Program.ReaderXP.Options.TagSelected.epcMaskOffset = 0x202 - 0x20;
            Program.ReaderXP.Options.TagSelected.epcMaskLength = 0x1;
            return (Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_SELECTED, true) == CSLibrary.Constants.Result.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UInt32 repeat = UInt32.Parse(textBox_Repeat.Text) + 1;
            UInt16 offset;
            string wordstr;

            SelectTag();

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = 0x00000000;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;

            for (; repeat > 0; repeat--)
            {
                offset = UInt16.Parse(textBox_Offset.Text);

                for (int cnt = 0; cnt < textBox_EPC.Text.Length; cnt += 4)
                {
                    int r = textBox_EPC.Text.Length - cnt;

                    if (r >= 4)
                        wordstr = textBox_EPC.Text.Substring(cnt, 4);
                    else
                        wordstr = textBox_EPC.Text.Substring(cnt, r) + new String('0', 4 - r);

                    Program.ReaderXP.Options.TagWriteEPC.offset = offset;
                    Program.ReaderXP.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(wordstr);
                    Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_WRITE_EPC, true);
                    offset++;
                }
            }

            MessageBox.Show("Complete!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Scan")
            {
                button2.Text = "Stop";

                listView1.Clear();
                this.listView1.Columns.Add(this.columnHeader1);
                this.listView1.Columns.Add(this.columnHeader2);
                this.listView1.Columns.Add(this.columnHeader3);
                this.listView1.Columns.Add(this.columnHeader4);
                this.listView1.Columns.Add(this.columnHeader5);

                // Scan Tag
                Program.ReaderXP.SetOperationMode(CSLibrary.Constants.RadioOperationMode.CONTINUOUS);
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
                Program.ReaderXP.Options.TagRanging.bank1 = CSLibrary.Constants.MemoryBank.TID;     // Read TID
                Program.ReaderXP.Options.TagRanging.offset1 = 0;
                Program.ReaderXP.Options.TagRanging.count1 = 2;
                Program.ReaderXP.Options.TagRanging.bank2 = CSLibrary.Constants.MemoryBank.BANK1;   // Read Configuration Word
                Program.ReaderXP.Options.TagRanging.offset2 = 32;
                Program.ReaderXP.Options.TagRanging.count2 = 1;
                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button2.Text = "Scan";

                if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
                {
                    Program.ReaderXP.StopOperation(true);
                    
                    while (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }

        private void FormUCODE7_FormClosing(object sender, FormClosingEventArgs e)
        {
            AttachCallback(false);
            Program.ReaderXP.Options.TagSelected.ParallelEncoding = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //CSLibrary.Structures.re
            UInt16 [] value = new UInt16 [1];

            if (checkBox2.Checked)
                value[0] |= 0x040;

            if (checkBox3.Checked)
                value[0] |= 0x001;

            SelectTag();

            Program.ReaderXP.Options.TagWriteEPC.accessPassword = 0x00000000;
            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.offset = 30;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;

            Program.ReaderXP.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC (value);
            Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_WRITE_EPC, true);

            MessageBox.Show("Complete!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "Char Count : " + textBox_EPC.Text.Length;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Offset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_Offset.Text = UInt16.Parse(textBox_Offset.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox_Offset.Text = "0";
            }
        }

        private void textBox_Repeat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_Repeat.Text = UInt32.Parse(textBox_Repeat.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox_Repeat.Text = "0";
            }
        }
    }
}
