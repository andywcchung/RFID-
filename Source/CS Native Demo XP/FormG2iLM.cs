using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

using CSLibrary.Text;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormG2iLM : Form
    {
        public FormG2iLM()
        {
            InitializeComponent();
        }

        void ReaderXP_TagCompletedEvent(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                if (e.access == TagAccess.READ)
                {
                    {
                        switch (e.bank)
                        {
                            case Bank.EPC:
                                if (e.success)
                                {
                                    byte [] configword = Program.ReaderXP.Options.TagReadEPC.epc.ToBytes();

                                    checkBox0.Checked = (configword[0] & 0x80) != 0;
                                    checkBox1.Checked = (configword[0] & 0x40) != 0;
                                    checkBox4.Checked = (configword[0] & 0x08) != 0;
                                    checkBox5.Checked = (configword[0] & 0x04) != 0;
                                    checkBox6.Checked = (configword[0] & 0x02) != 0;
                                    checkBox7.Checked = (configword[0] & 0x01) != 0;
                                    checkBox8.Checked = (configword[1] & 0x80) != 0;
                                    checkBox9.Checked = (configword[1] & 0x40) != 0;
                                    checkBox10.Checked = (configword[1] & 0x20) != 0;
                                    checkBox11.Checked = (configword[1] & 0x10) != 0;
                                    checkBox12.Checked = (configword[1] & 0x08) != 0;
                                    checkBox13.Checked = (configword[1] & 0x04) != 0;
                                    checkBox14.Checked = (configword[1] & 0x02) != 0;
                                    checkBox15.Checked = (configword[1] & 0x01) != 0;
                                }
                                break;

                            case Bank.PC:
                                if (e.success)
                                {
//                                    textBoxPublicPC.Text = Program.ReaderXP.Options.TagReadPC.pc.ToString();
                                }
                                break;

                            case Bank.TID:
//                                if (checkBoxPublicTID.Checked)
//                                    textBoxPublicTID.Text = Program.ReaderXP.Options.TagReadTid.tid.ToString().Substring(0, 24);
                                break;
                        }
                    }
                }
            });
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                //                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
//                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
            else
            {
                //                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
//                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
        }

        private void buttonSlecetTag_Click(object sender, EventArgs e)
        {
            AttachCallback(false);
            using (TagSearchForm InvForm = new TagSearchForm())
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    textBoxTagID.Text = InvForm.epc;
                }
            }
            AttachCallback(true);
        }


        bool ReadDataCB(TAG_ACCESS_PKT pkt)
        {
            Console.WriteLine(pkt.cmd);

            return true;
        }

        private void buttonChangePrivateMode_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagWriteEPC.offset = 0x20-2;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;
            Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC("00060000");

            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
            {
                MessageBox.Show("Change to Protect Mode Success, please re-select Tag ID");
            }
            else
            {
                MessageBox.Show("Change to Protect Mode Fail");
            }
        }

        private void buttonChangePublicMode_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagWriteEPC.offset = 0x20 - 2;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;
            Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC("00020000");

            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
            {
                MessageBox.Show("Change to Normal Mode Success, please re-select Tag ID");
            }
            else
            {
                MessageBox.Show("Change to Normal Mode Fail");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.TagReadEPC.retryCount = 7;
            Program.ReaderXP.Options.TagReadEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagReadEPC.offset = 0x20 - 2;
            Program.ReaderXP.Options.TagReadEPC.count = 1;

            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_EPC, true) == Result.OK)
            {
                MessageBox.Show("Read Config Success");
            }
            else
            {
                MessageBox.Show("Read Config Word Fail");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            UInt16 configword = 0;

            configword &= 0xfe00; // reset permanent bits 1111 1110 0000 0000

            if (checkBox7.Checked)
                configword |= 1 << 8;

            if (checkBox8.Checked)
                configword |= 1 << 7;

            if (checkBox9.Checked)
                configword |= 1 << 6;

            if (checkBox10.Checked)
                configword |= 1 << 5;

            if (checkBox11.Checked)
                configword |= 1 << 4;

            if (checkBox12.Checked)
                configword |= 1 << 3;

            if (checkBox13.Checked)
                configword |= 1 << 2;

            if (checkBox14.Checked)
                configword |= 1 << 1;

            if (checkBox15.Checked)
                configword |= 1;

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagWriteEPC.offset = 0x20 - 2;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;
            Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC(configword.ToString ("X4"));

            int writeretry = Convert.ToInt16(textBox1.Text);
            int cnt;

            for (cnt = 0; cnt <= writeretry; cnt++)
            {
                if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
                {
                    MessageBox.Show("Write Config Success");
                    break;
                }
            }

            if (cnt > writeretry)
            {
                MessageBox.Show("Write Config Fail");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormG2iLM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UInt16 [] data = new UInt16 [1];

            if (Program.TagSelectedEPC(textBoxTagID.Text) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            if (Program.TagRead(MemoryBank.BANK1, 0x1f, 1, UInt32.Parse (textBoxPassword.Text), ref data) == Result.OK)
            {
                textBox_ConfigWord.Text = data[0].ToString("X4");
                MessageBox.Show("Read Config Success");
            }
            else
            {
                MessageBox.Show("Read Config Word Fail");
            }
        }
    }
}
