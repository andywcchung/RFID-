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
    using CSLibrary.Structures;
    using CSLibrary.Constants;

    public partial class FormColdChainViewLog : Form
    {
        DateTime UnixTimeStampBase = new DateTime(1970, 1, 1, 00, 0, 0, 0);
        DateTime UnixTime(double second)
        {
            return UnixTimeStampBase.AddSeconds(second);
        }

        double UnixTime(DateTime st)
        {
            return (st - UnixTimeStampBase).TotalSeconds;
        }

        public FormColdChainViewLog()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormColdChainViewLog_Load(object sender, EventArgs e)
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

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.bank = MemoryBank.EPC;
            //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(textBox14.Text);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = (uint)Program.ReaderXP.Options.TagSelected.epcMask.Length * 8;
            if (Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                return;

            System.Threading.Thread.Sleep(100);

            Program.ReaderXP.Options.TagWriteUser.offset = 240;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
            Program.ReaderXP.Options.TagWriteUser.pData[0] = 0xa600;
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                return;

            Program.ReaderXP.Options.TagReadUser.retryCount = 7;
            Program.ReaderXP.Options.TagReadUser.offset = 264;
            Program.ReaderXP.Options.TagReadUser.count = 1;
            Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new UInt16[1]);
            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                return;

            System.Threading.Thread.Sleep(100);

            Program.ReaderXP.Options.TagWriteUser.offset = 264;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
            Program.ReaderXP.Options.TagWriteUser.pData[0] = (UInt16)(Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0xFFFEU);
            
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                return;

            Program.ReaderXP.Options.TagReadUser.accessPassword = 0;
            Program.ReaderXP.Options.TagReadUser.retryCount = 7;
            Program.ReaderXP.Options.TagReadUser.offset = 0; // Temp Sensor Calibration Word
            Program.ReaderXP.Options.TagReadUser.count = 5;
            Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[5]);
            if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
            {
                MessageBox.Show("Read Data Length Error");
                return;
            }

            UInt16[] TagData = Program.ReaderXP.Options.TagReadUser.pData.ToUshorts();

            StartTime = UnixTime(TagData[0] << 16 | TagData[1]);
            Interval = TagData[2];
            TempOffset = 0.25 * (TagData[3]);
            Total = TagData[4];
            label17.Text = "Total : " + Total.ToString();
            if (Total >= 10752)
                label17.Text += " (MemoryBank Full)";

            while (ReadOffset < Total)
            {
                Program.ReaderXP.Options.TagWriteUser.retryCount = 7;
                Program.ReaderXP.Options.TagWriteUser.accessPassword = 0x00000000;
                Program.ReaderXP.Options.TagWriteUser.offset = 260;
                Program.ReaderXP.Options.TagWriteUser.count = 2;
                Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[2];
                Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x000a;
                Program.ReaderXP.Options.TagWriteUser.pData[1] = ReadOffset;
                if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                    return;

                System.Threading.Thread.Sleep(2500);

                Program.ReaderXP.Options.TagReadUser.offset = 260; // Temp Sensor Calibration Word
                Program.ReaderXP.Options.TagReadUser.count = 1;  // 183 * 2 records will be read
                Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[1]);
                while (true)
                {
                    if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                    {
                        MessageBox.Show("Read Data Length Error");
                        return;
                    }

                    if ((Program.ReaderXP.Options.TagReadUser.pData.ToUshorts()[0] & 0x04) != 0x0000)
                        break;

                    System.Threading.Thread.Sleep(100);
                }

                ReadRecord = (UInt16)(Total - ReadOffset);

                if (ReadRecord > 366)
                    ReadRecord = 366;

                ReadUInt16 = (UInt16)((ReadRecord + 1) / 2);

                Program.ReaderXP.Options.TagReadUser.offset = 5;
                Program.ReaderXP.Options.TagReadUser.count = ReadUInt16;
                Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[ReadUInt16]);
                ReadOffset += (UInt16)(ReadUInt16 * 2);

                if (Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true) != Result.OK)
                {
                    MessageBox.Show("Read Data Length Error");
                    return;
                }

                UInt16[] DataPtr = Program.ReaderXP.Options.TagReadUser.pData.ToUshorts();

                for (int cnt = 0; cnt < ReadUInt16; cnt++)
                {
                    ListViewItem ins;
                    double temp;

                    temp = ((DataPtr[cnt] >> 8) * 0.25) - TempOffset;
                    ins = new ListViewItem((listView5.Items.Count + 1).ToString());
                    ins.SubItems.Add(StartTime.ToString());
                    ins.SubItems.Add(temp.ToString());
                    listView5.Items.Add(ins);

                    StartTime = StartTime.AddSeconds(Interval);

                    if (listView5.Items.Count == Total)
                        break;

                    temp = ((DataPtr[cnt] & 0xff) * 0.25) - TempOffset;
                    ins = new ListViewItem((listView5.Items.Count + 1).ToString());
                    ins.SubItems.Add(StartTime.ToString());
                    ins.SubItems.Add(temp.ToString());
                    listView5.Items.Add(ins);

                    StartTime = StartTime.AddSeconds(Interval);
                }
            }

            FormColdChainFeatures.ColdChain_DataLog("[Read Temp Log]," + textBox14.Text + "," + "Current Time," + DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss"));

            for (int cnt = 0; cnt < listView5.Items.Count; cnt++)
                FormColdChainFeatures.ColdChain_DataLog(listView5.Items[cnt].SubItems[0].Text + "," + listView5.Items[cnt].SubItems[1].Text + "," + listView5.Items[cnt].SubItems[2].Text);

            Program.ReaderXP.Options.TagWriteUser.offset = 240;
            Program.ReaderXP.Options.TagWriteUser.count = 1;
            Program.ReaderXP.Options.TagWriteUser.pData = new UInt16[1];
            Program.ReaderXP.Options.TagWriteUser.pData[0] = 0x0000;
            if (Program.ReaderXP.StartOperation(Operation.TAG_WRITE_USER, true) != Result.OK)
                return;

            // Dummy read
            {
                S_DATA value = new S_DATA("0000");
                //FormColdChainFeatures.ReadUserData(240, 1, ref value);

                Program.ReaderXP.Options.TagReadUser.offset = 240;
                Program.ReaderXP.Options.TagReadUser.count = 1;
                Program.ReaderXP.Options.TagReadUser.pData = new S_DATA(new byte[ReadUInt16]);
                Program.ReaderXP.StartOperation(Operation.TAG_READ_USER, true);
            }

        }
    }
}
