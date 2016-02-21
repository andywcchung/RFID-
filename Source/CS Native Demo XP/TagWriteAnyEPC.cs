using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagWriteAnyEPCForm : Form
    {
        private object MyLock = new object();
        private string currentWrittenEpc = String.Empty;
        private int currentCount = 0;
        private int spaceForIncremental = 0;
        private int mStop = 0;
        public TagWriteAnyEPCForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AttachEvent(true);
        }
        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            AttachEvent(false);
        }
        private void AttachEvent(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_OnStateChanged);
            }
            else
            {
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_OnStateChanged);
            }
        }

        void ReaderCE_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case RFState.IDLE:
                        //
                        //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                        break;
                    case RFState.BUSY:
                        btnStop.Enabled = true;
                        break;
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
                        if (e.success && e.bank == Bank.EPC)
                        {
                            //Increase tag count
                            currentCount++;
                            txtSuccessTag.Text = currentCount.ToString();
                            if (currentCount == nbCount.Value)
                            {
                                ThreadStop();
                            }
                        }
                        break;
                    case TagAccess.READ:
                        if (e.success && e.bank == Bank.EPC)
                        {
                            Debug.WriteLine("EPC = " + e.data.ToString());
                        }
                        else
                        {
                            Debug.WriteLine(string.Format("Read {0} error", e.bank));
                        }
                        break;
                }
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Result rc = Result.OK;
            currentCount = 0;
            txtSuccessTag.Text = "0";
            if (txtMask.Text.Length == 0)
            {
                MessageBox.Show("Please enter your filter first");
                return;
            }
            else if( Program.ReaderXP.State != RFState.IDLE)
            {
                MessageBox.Show("Reader not ready!");
                return;
            }
            btnExit.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            //lock all tag this is not same as our filter

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;

            if (checkBox_Toggle.Checked)
                Program.ReaderXP.Options.TagSelected.flags |= SelectMaskFlags.ENABLE_TOGGLE;
            
            if (radioButton_MatchMask.Checked)
            {
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(hexOnlyTextBox_InputMask.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(hexOnlyTextBox_InputMask.Text);
                Program.ReaderXP.Options.TagSelected.Qvalue = (uint)numericUpDownQvalue.Value;
                Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            }
            else
            {
                Program.ReaderXP.Options.TagSelected.flags |= SelectMaskFlags.ENABLE_NON_MATCH;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(txtMask.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(txtMask.Text);
                Program.ReaderXP.Options.TagSelected.Qvalue = (uint)numericUpDownQvalue.Value;
                Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            }

            Program.ReaderXP.Options.TagWriteEPC.retryCount = (uint)numericUpDown_ProcessRetry.Value;
            Program.ReaderXP.Options.TagWriteEPC.writeRetryCount = (uint)numericUpDown_WriteRetry.Value;

            new Thread(new ThreadStart(ThreadRun)).Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ThreadStop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nbCount_ValueChanged(object sender, EventArgs e)
        {
            txtMask.Text = "";
            spaceForIncremental = (int)(((int)nbCount.Value + (int)nbInitialValue.Value).ToString("x").Length);
            if (spaceForIncremental > 24)
            {
                MessageBox.Show("Not supported too many tags exception");
                return;
            }
            //Assume 96 bit EPC is using.
            txtMask.MaxLength = 24 - spaceForIncremental;
        }

        private void ThreadStop()
        {
            Interlocked.Exchange(ref mStop, 1);
        }

        private void ThreadRun()
        {
            Interlocked.Exchange(ref mStop, 0);

            while(!Interlocked.Equals(mStop, 1))
            {
                //config Write Options
                Program.ReaderXP.Options.TagWriteEPC.accessPassword = 0x0;  //Assume all tag with no access password
                Program.ReaderXP.Options.TagWriteEPC.count = 6;             //Assume 96bit epc only
                Program.ReaderXP.Options.TagWriteEPC.offset = 0;            //Assume offset start from zero
                Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC(GetEPC());

                /*Program.ReaderXP.Options.TagReadEPC.accessPassword = 0x0;
                Program.ReaderXP.Options.TagReadEPC.count = 6;
                Program.ReaderXP.Options.TagReadEPC.offset = 0;
                Program.ReaderXP.Options.TagReadEPC.retryCount = 7;*/
                Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true);
            }
            TriggerButton();
        }

        private delegate void TriggerButtonDel();
        private void TriggerButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TriggerButtonDel(TriggerButton), new object[] { });
                return;
            }
            btnExit.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        private delegate string GetEPCDel();
        private string GetEPC()
        {
            if (this.InvokeRequired)
            {
                return (string)Invoke(new GetEPCDel(GetEPC), new Object[] { });
            }
            char[] rightPartEpc = txtMask.Text.ToCharArray();

            char[] leftPartEpc = (currentCount + (int)nbInitialValue.Value).ToString("X").ToCharArray();

            char[] epcArray = "000000000000000000000000".ToCharArray();

            Array.Copy(leftPartEpc, 0, epcArray, epcArray.Length - leftPartEpc.Length, leftPartEpc.Length);
            Array.Copy(rightPartEpc, 0, epcArray, 0, rightPartEpc.Length);

            return new string(epcArray);
        }

        private void TagWriteAnyEPCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ReaderXP.Options.TagWriteEPC.retryCount = 37;
            Program.ReaderXP.Options.TagWriteEPC.writeRetryCount = 31;
            Program.ReaderXP.Options.TagSelected.Qvalue = 0;
        }

        private void radioButton_MatchMask_CheckedChanged(object sender, EventArgs e)
        {
            label_InputMask.Enabled = true;
            hexOnlyTextBox_InputMask.Enabled = true;
        }

        private void radioButtonNonMatchMask_CheckedChanged(object sender, EventArgs e)
        {
            label_InputMask.Enabled = false;
            hexOnlyTextBox_InputMask.Enabled = false;
            hexOnlyTextBox_InputMask.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSuccessTag_Click(object sender, EventArgs e)
        {

        }
    }
}