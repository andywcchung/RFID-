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
    public partial class FormG2iLFuncTest : Form
    {
        public FormG2iLFuncTest()
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
                                    //byte [] configword = Program.ReaderXP.Options.TagReadEPC.epc.ToBytes();
                                }
                                break;

                            case Bank.PC:
                                if (e.success)
                                {
                                }
                                break;

                            case Bank.TID:
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
            byte []     Iconfigword;
            UInt16      Oconfigword;
            int         cnt;
            bool        Connected = false;

            Program.ReaderXP.Options.TagReadEPC.retryCount = 7;
            Program.ReaderXP.Options.TagReadEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagReadEPC.offset = 0x20 - 2;
            Program.ReaderXP.Options.TagReadEPC.count = 1;

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);
            Program.ReaderXP.Options.TagWriteEPC.offset = 0x20 - 2;
            Program.ReaderXP.Options.TagWriteEPC.count = 1;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            cnt = 0;
            while (true)
            {
                if (Program.ReaderXP.StartOperation(Operation.TAG_READ_EPC, true) != Result.OK)
                {
                    MessageBox.Show("Read Config Word Fail");
                    return;
                }

                if ((Program.ReaderXP.Options.TagReadEPC.epc.ToBytes()[1] & 0x60) == 0x60)              // 0x40 | 0x20 = 0x60
                    break;

                Oconfigword = 0x60;

                Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC(Oconfigword.ToString ("X4"));

                for (cnt = 0; cnt < 5; cnt++)
                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
                        break;

                if (cnt >= 5)
                {
                    MessageBox.Show("Write Config Fail");
                    return;
                }
            }

            for (cnt = 0; cnt < 3; cnt++)
            {
                if (Program.ReaderXP.StartOperation(Operation.TAG_READ_EPC, true) == Result.OK)
                    if ((Program.ReaderXP.Options.TagReadEPC.epc.ToBytes()[0] & 0x80) != 0x00)
                    {
                        Connected = true;
                        break;
                    }
            }

            if (Connected)
            {
                label2.Text = "Connected";
                label2.BackColor = Color.Green;
            }
            else
            {
                label2.Text = "Disconnected";
                label2.BackColor = Color.Red;
            }

            MessageBox.Show("Read Success");
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
