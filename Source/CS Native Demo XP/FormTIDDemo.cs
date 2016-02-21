using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormTIDDemo : Form
    {
        CSLibrary.Structures.S_PC SelectedPC;
        
        public FormTIDDemo()
        {
            InitializeComponent();
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                //HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                //Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                //Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
            else
            {
                //HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKey_OnKeyEvent);

                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(Reader_TagInventoryEvent);
                //Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(Reader_StateChangedEvent);
                //Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
            }
        }

        void Reader_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            // Check Callback Type
            if (e.type != CSLibrary.Constants.CallbackType.TAG_RANGING)
                return;

            BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                try
                {
                    string TID;
                    string EPC;
                    string PC;
                    int cnt;

                    // Get EPC string
                    EPC = e.info.epc.ToString().Substring(0, (int)(e.info.pc.EPCLength * 4));
                    TID = e.info.epc.ToString().Substring((int)(e.info.pc.EPCLength * 4));
                    PC = e.info.pc.ToString();
                    for (cnt = 0; cnt < listView1.Items.Count; cnt++)
                    {
                        if (listView1.Items[cnt].SubItems[1].Text == TID)
                            break;
                    }

                    if (cnt == listView1.Items.Count)
                    {
                        ListViewItem ins = new ListViewItem((listView1.Items.Count + 1).ToString());
                        ins.SubItems.Add(TID);
                        ins.SubItems.Add(PC);
                        ins.SubItems.Add(EPC);
                        listView1.Items.Add(ins);
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State == CSLibrary.Constants.RFState.IDLE)
            {
                button1.Text = "Stop";

                listView1.Clear();

                this.listView1.Columns.Add(this.columnHeader1);
                this.listView1.Columns.Add(this.columnHeader2);
                this.listView1.Columns.Add(this.columnHeader3);
                this.listView1.Columns.Add(this.columnHeader4);

                // Start Inventory
                Program.ReaderXP.SetOperationMode(CSLibrary.Constants.RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                Program.ReaderXP.Options.TagRanging.flags = CSLibrary.Constants.SelectFlags.ZERO;
                Program.ReaderXP.Options.TagRanging.multibanks = 1;
                Program.ReaderXP.Options.TagRanging.bank1 = CSLibrary.Constants.MemoryBank.TID;     // Read TID
                Program.ReaderXP.Options.TagRanging.offset1 = 0;
                Program.ReaderXP.Options.TagRanging.count1 = UInt16.Parse (textBox_TidUidLength.Text);
                Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_RANGING, false);
            }
            else
            {
                button1.Text = "Scan";
                Program.ReaderXP.StopOperation(true);

                while (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
                    System.Threading.Thread.Sleep(1000);
            }

        }

        private void FormTIDDemo_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        private void FormTIDDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            AttachCallback(false);

            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
                System.Threading.Thread.Sleep(100);
            }

/*            this.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
            {
                MessageBox.Show("Reader busy, please stop scan tag");
                return;
            }

            if (listView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Please select tag");
                return;
            }

            string TID = textBox_Value.Text.Substring(0, int.Parse(textBox_Length.Text));
            Program.ReaderXP.Options.TagSelected.flags = CSLibrary.Constants.SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.bank = CSLibrary.Constants.MemoryBank.TID;
            Program.ReaderXP.Options.TagSelected.Mask = CSLibrary.Text.HexEncoding.ToBytes (TID);
            Program.ReaderXP.Options.TagSelected.MaskOffset = uint.Parse (textBox_Offset.Text);
            Program.ReaderXP.Options.TagSelected.MaskLength = uint.Parse(textBox_Length.Text) * 4;
            if (Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_SELECTED, true) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show("Selected Tag Error!!");
                return;
            }

            Program.ReaderXP.Options.TagWriteEPC.retryCount = 30;
            Program.ReaderXP.Options.TagWriteEPC.accessPassword = 0x0;
            Program.ReaderXP.Options.TagWriteEPC.offset = 0;
            Program.ReaderXP.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(textBox_NewEpc.Text);
            Program.ReaderXP.Options.TagWriteEPC.count = CSLibrary.Text.Hex.GetWordCount(textBox_NewEpc.Text);

            if (Program.ReaderXP.StartOperation(CSLibrary.Constants.Operation.TAG_WRITE_EPC, true) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show("Write Tag Error!!");
                return;
            }

            MessageBox.Show("Write Tag Success.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            textBox_Value.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
            textBox_Length.Text = textBox_Value.Text.Length.ToString ();
            SelectedPC = new CSLibrary.Structures.S_PC(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text);
            textBox_Offset.Text = "0";
            textBox_NewEpc.MaxLength = (int)SelectedPC.EPCLength * 4;
        }
    }
}
