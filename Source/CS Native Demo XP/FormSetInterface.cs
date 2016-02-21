using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormSetInterface : Form
    {
        public bool exit = false;

        public FormSetInterface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CSLibrary.Constants.Result result = CSLibrary.Constants.Result.UNKNOWN_OPERATION;

            if (radioButton1.Checked)
                result = Program.ReaderXP.SetInterface(CSLibrary.HighLevelInterface.INTERFACETYPE.IPV4);
            else if (radioButton2.Checked)
                result = Program.ReaderXP.SetInterface(CSLibrary.HighLevelInterface.INTERFACETYPE.USB);
            else if (radioButton3.Checked)
                result = Program.ReaderXP.SetInterface(CSLibrary.HighLevelInterface.INTERFACETYPE.SERIAL);
            else
                this.Close();

            if (result == CSLibrary.Constants.Result.OK)
            {
                exit = true;
                this.Close();
            }
            else
                MessageBox.Show("Set Interface Error : " + result.ToString ());
        }
    }
}
