using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using System.Globalization;

using CSLibrary.Text;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormQT : Form
    {
        int accessmode = 0; // 0 = P

        public FormQT()
        {
            InitializeComponent();
        }

        void ReaderXP_MyRunningStateEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            
            this.BeginInvoke((System.Threading.ThreadStart)delegate()
                           {
                               switch (e.state)
                               {
                                   case RFState.IDLE:
                                       break;
                                   case RFState.BUSY:
                                       break;
                                   case RFState.RESET:
                                       break;
                                   case RFState.ABORT:
                                       //ControlPanelForm.EnablePannel(false);
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
                    if (groupBoxPrivate.Enabled)
                    {
                        switch (e.bank)
                        {
                            case Bank.ACC_PWD:
                                if (e.success)
                                {
                                    textBoxPrivateAccessPassword.Text = Program.ReaderXP.Options.TagReadAccPwd.password.ToString();
                                }
                                break;
                            case Bank.EPC:
                                if (e.success)
                                {
                                    textBoxPrivateEPC.Text = Program.ReaderXP.Options.TagReadEPC.epc.ToString();
                                }
                                break;
                            case Bank.KILL_PWD:
                                if (e.success)
                                {
                                    textBoxPrivateKillPassword.Text = Program.ReaderXP.Options.TagReadKillPwd.password.ToString();
                                }
                                break;
                            case Bank.PC:
                                if (e.success)
                                {
                                    textBoxPrivatePC.Text = Program.ReaderXP.Options.TagReadPC.pc.ToString();
                                }
                                break;
                            case Bank.TID:
                                if (e.success)
                                {
                                    if (checkBoxPrivateTID.Checked)
                                        textBoxPrivateTID.Text = Program.ReaderXP.Options.TagReadTid.tid.ToString().Substring(0, 24);

                                    if (checkBoxPrivateEPCPublic.Checked)
                                        textBoxPrivateEPCPublic.Text = Program.ReaderXP.Options.TagReadTid.tid.ToString().Substring(24, 24);
                                }
                                break;
                            case Bank.USER:
                                if (e.success)
                                {
                                    textBoxPrivateUser.Text = Program.ReaderXP.Options.TagReadUser.pData.ToString();
                                }
                                break;
                        }
                    }

                    if (groupBoxPublic.Enabled)
                    {
                        switch (e.bank)
                        {
                            case Bank.EPC:
                                if (e.success)
                                {
                                    textBoxPublicEPC.Text = Program.ReaderXP.Options.TagReadEPC.epc.ToString();
                                }
                                break;

                            case Bank.PC:
                                if (e.success)
                                {
                                    textBoxPublicPC.Text = Program.ReaderXP.Options.TagReadPC.pc.ToString();
                                }
                                break;

                            case Bank.TID:
                                if (checkBoxPublicTID.Checked)
                                    textBoxPublicTID.Text = Program.ReaderXP.Options.TagReadTid.tid.ToString();
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
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
            else
            {
                //                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_TagCompletedEvent);
            }
        }

        private void FormQT_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangePublicMode_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, read will fail
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.QTCommand.RW = 1;
            Program.ReaderXP.Options.QTCommand.TP = 1;
                Program.ReaderXP.Options.QTCommand.SR = 1;
            Program.ReaderXP.Options.QTCommand.MEM = 1;
            Program.ReaderXP.Options.QTCommand.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.StartOperation(Operation.QT_COMMAND, true) == Result.OK)
            {
                MessageBox.Show("Change to Public Mode Success, please re-select Tag ID");
                groupBoxPublic.Enabled = true;
                groupBoxPrivate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Change to Public Mode Fail");
                groupBoxPrivate.Enabled = false;
                groupBoxPublic.Enabled = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangePrivateMode_Click(object sender, EventArgs e)
        {
            accessmode = 0;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.QTCommand.RW = 1;
            Program.ReaderXP.Options.QTCommand.TP = 1;
            Program.ReaderXP.Options.QTCommand.SR = 1;
            Program.ReaderXP.Options.QTCommand.MEM = 0;
            Program.ReaderXP.Options.QTCommand.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.StartOperation(Operation.QT_COMMAND, true) == Result.OK)
            {
                MessageBox.Show("Change to Private Mode Success, please re-select Tag ID");
                groupBoxPrivate.Enabled = true;
                groupBoxPublic.Enabled = false;
            }
            else
            {
                MessageBox.Show("Change to Private Mode Fail");
                groupBoxPrivate.Enabled = false;
                groupBoxPublic.Enabled = false;
            }
        }

        private void groupBoxPrivate_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void buttonSlecetTag_Click(object sender, EventArgs e)
        {
            //Stop current operation
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
            }
            while (Program.ReaderXP.State != RFState.IDLE)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }

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

        private void buttonReadPrivateData_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (QTTagInventoryForm InvForm = new QTTagInventoryForm(false))
            {
                InvForm.ShowDialog();
            }
            this.Show();

            
/*            accessmode = 1;

            MessageBox.Show("Please select tagid in Public Mode");
            groupBoxPrivate.Enabled = true;
            groupBoxPublic.Enabled = false;
*/
        }

        private void buttonReadPublicData_Click(object sender, EventArgs e)
        {
            UInt32 accpassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, read will fail
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(/*m_record.pc.ToString() + */textBoxTagID.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }

                // Read Privae PC
                if (checkBoxPublicPC.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadPC.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadPC.retryCount = 7;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_PC, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconPc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconPc = ReadAllBank.ReadState.FAILED;
                    }

                }

                if (checkBoxPublicEPC.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadEPC.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadEPC.retryCount = 7;
                    Program.ReaderXP.Options.TagReadEPC.count = 6;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_EPC, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconEpc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconEpc = ReadAllBank.ReadState.FAILED;
                    }

                }

                //if tid bank is checked, read it.
                if (checkBoxPublicTID.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadTid.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadTid.retryCount = 7;
                    Program.ReaderXP.Options.TagReadTid.offset = 0;
                    Program.ReaderXP.Options.TagReadTid.count = 2;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_TID, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconTid = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconTid = ReadAllBank.ReadState.FAILED;
                    }
                }

                MessageBox.Show("Data Read Finish");
            }
            else
            {
                MessageBox.Show("Reader is busy now, please try later.");
            }
        }

        private void buttonReadData_Click(object sender, EventArgs e)
        {
            UInt32 accpassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, read will fail
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(/*m_record.pc.ToString() + */textBoxTagID.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }

                if (accessmode == 1)
                {
                    Program.ReaderXP.Options.QTCommand.RW = 1;
                    Program.ReaderXP.Options.QTCommand.TP = 0;
                    Program.ReaderXP.Options.QTCommand.SR = 0;
                    Program.ReaderXP.Options.QTCommand.MEM = 0;
                    Program.ReaderXP.Options.QTCommand.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

                    if (Program.ReaderXP.StartOperation(Operation.QT_COMMAND, true) != Result.OK)
                    {
                        MessageBox.Show("Change to Private Mode fail");
                        return;
                    }
                }

                // Read Privae PC
                if (checkBoxPrivatePC.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadPC.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadPC.retryCount = 7;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_PC, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconPc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconPc = ReadAllBank.ReadState.FAILED;
                    }

                }

                if (checkBoxPrivateEPC.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadEPC.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadEPC.retryCount = 7;
                    Program.ReaderXP.Options.TagReadEPC.count = 6;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_EPC, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconEpc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconEpc = ReadAllBank.ReadState.FAILED;
                    }

                }


                //if access bank is checked, read it.
                if (checkBoxPrivateAccessPassword.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadAccPwd.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadAccPwd.retryCount = 7;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_ACC_PWD, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconAcc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconAcc = ReadAllBank.ReadState.FAILED;
                    }
                }

                //if kill bank is checked, read it.
                if (checkBoxPrivateKillPassword.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadKillPwd.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadKillPwd.retryCount = 7;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_KILL_PWD, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconKill = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconKill = ReadAllBank.ReadState.FAILED;
                    }
                }

                //if tid bank is checked, read it.
                if (checkBoxPrivateTID.Checked || checkBoxPrivateEPCPublic.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadTid.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadTid.retryCount = 7;
                    Program.ReaderXP.Options.TagReadTid.offset = 0;
                    Program.ReaderXP.Options.TagReadTid.count = 12;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_TID, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconTid = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconTid = ReadAllBank.ReadState.FAILED;
                    }
                }

                //if user bank is checked, read it.
                if (checkBoxPrivateUser.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagReadUser.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagReadUser.retryCount = 7;
                    Program.ReaderXP.Options.TagReadUser.offset = 0;
                    Program.ReaderXP.Options.TagReadUser.count = 32;

                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) == Result.OK)
                    {
                        //                        m_readAllBank.IconUser = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        //                        m_readAllBank.IconUser = ReadAllBank.ReadState.FAILED;
                    }
                }

                MessageBox.Show("Data Read Finish");
            }
            else
            {
                MessageBox.Show("Reader is busy now, please try later.");
            }
        }

        private void buttonWriteData_Click(object sender, EventArgs e)
        {
            UInt32 accpassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(/*m_record.pc.ToString() +*/ textBoxTagID.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
                if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }

                //if access bank is checked, read it.
                if (checkBoxPrivateAccessPassword.Checked)
                {
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagWriteAccPwd.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteAccPwd.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagWriteAccPwd.password = UInt32.Parse(textBoxPrivateAccessPassword.Text, NumberStyles.HexNumber);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_ACC_PWD, true) == Result.OK)
                    {
//                        m_writeAllBank.IconAcc = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
//                        m_writeAllBank.IconAcc = WriteAllBank.WriteState.FAILED;
                    }

                }
                //if kill bank is checked, read it.
                if (checkBoxPrivateKillPassword.Checked)
                {
//                    lb_WriteInfo.Text = "Start writing kill pwd";
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagWriteKillPwd.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteKillPwd.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagWriteKillPwd.password = UInt32.Parse(textBoxPrivateKillPassword.Text, NumberStyles.HexNumber);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_KILL_PWD, true) == Result.OK)
                    {
//                        m_writeAllBank.IconKill = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
//                        m_writeAllBank.IconKill = WriteAllBank.WriteState.FAILED;
                    }
                }

                //if user bank is checked, read it.
                if (checkBoxPrivateUser.Checked)
                {
//                    lb_WriteInfo.Text = "Start writing user memory";
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteUser.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagWriteUser.offset = 0;
                    Program.ReaderXP.Options.TagWriteUser.count = 64;
                    Program.ReaderXP.Options.TagWriteUser.pData = Hex.ToUshorts(textBoxPrivateUser.Text);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) == Result.OK)
                    {
//                        m_writeAllBank.IconUser = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
//                        m_writeAllBank.IconUser = WriteAllBank.WriteState.FAILED;
                    }

                }

                if (checkBoxPrivatePC.Checked)
                {
//                    lb_WriteInfo.Text = "Start writing PC";
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagWritePC.retryCount = 7;
                    Program.ReaderXP.Options.TagWritePC.accessPassword = accpassword;

                    Program.ReaderXP.Options.TagWritePC.pc = Hex.ToUshort(textBoxPrivatePC.Text);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_PC, true) == Result.OK)
                    {
//                        m_writeAllBank.IconPc = WriteAllBank.WriteState.OK;
//                        m_tagTable.Items[nTable1.CurrentRowIndex].pc = m_record.pc = new S_PC(m_writeAllBank.pc);
                    }
                    else
                    {
                        //Write failed
//                        m_writeAllBank.IconPc = WriteAllBank.WriteState.FAILED;
                    }
                }
                //Write EPC must put in last order to prevent it get lost
                if (checkBoxPrivateEPC.Checked)
                {
//                    lb_WriteInfo.Text = "Start writing EPC";
                    Application.DoEvents();

                    Program.ReaderXP.Options.TagWriteEPC.retryCount = 7;
                    Program.ReaderXP.Options.TagWriteEPC.accessPassword = accpassword;
                    Program.ReaderXP.Options.TagWriteEPC.offset = 0;
                    Program.ReaderXP.Options.TagWriteEPC.count = Hex.GetWordCount(textBoxPrivateEPC.Text);
                    Program.ReaderXP.Options.TagWriteEPC.epc = new S_EPC(textBoxPrivateEPC.Text);

                    if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
                    {
                        //EPC Changed 
//                        m_writeAllBank.IconEpc = WriteAllBank.WriteState.OK;
//                        m_tagTable.Items[nTable1.CurrentRowIndex].epc = m_record.epc = new S_EPC(m_writeAllBank.epc);
                    }
                    else
                    {
                        //Write failed
//                        m_writeAllBank.IconEpc = WriteAllBank.WriteState.FAILED;
                    }
                }

                Application.DoEvents();
                MessageBox.Show("Data Write Finish");
            }
            else
            {
                MessageBox.Show("Reader is busy now, please try later.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            accessmode = 0;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.QTCommand.RW = 1;
            Program.ReaderXP.Options.QTCommand.TP = 1;
            Program.ReaderXP.Options.QTCommand.SR = 0;
            Program.ReaderXP.Options.QTCommand.MEM = 0;
            Program.ReaderXP.Options.QTCommand.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.StartOperation(Operation.QT_COMMAND, true) == Result.OK)
            {
                MessageBox.Show("Change to Private Mode Success, please re-select Tag ID");
                groupBoxPrivate.Enabled = true;
                groupBoxPublic.Enabled = false;
            }
            else
            {
                MessageBox.Show("Change to Private Mode Fail");
                groupBoxPrivate.Enabled = false;
                groupBoxPublic.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, read will fail
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBoxTagID.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.QTCommand.RW = 1;
            Program.ReaderXP.Options.QTCommand.TP = 1;
            Program.ReaderXP.Options.QTCommand.SR = 0;
            Program.ReaderXP.Options.QTCommand.MEM = 1;
            Program.ReaderXP.Options.QTCommand.accessPassword = UInt32.Parse(textBoxPassword.Text, NumberStyles.HexNumber);

            if (Program.ReaderXP.StartOperation(Operation.QT_COMMAND, true) == Result.OK)
            {
                MessageBox.Show("Change to Public Mode Success, please re-select Tag ID");
                groupBoxPublic.Enabled = true;
                groupBoxPrivate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Change to Public Mode Fail");
                groupBoxPrivate.Enabled = false;
                groupBoxPublic.Enabled = false;
            }

        }

        private void FormQT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
//                e.Cancel = m_stop = true;
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }
    }
}
