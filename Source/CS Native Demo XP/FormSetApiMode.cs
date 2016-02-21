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
    public partial class FormSetApiMode : Form
    {
        public bool exit = false;

        public FormSetApiMode()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CSLibrary.Constants.Result result = CSLibrary.Constants.Result.UNKNOWN_OPERATION;

            if (radioButton1.Checked)
                result = Program.ReaderXP.SetApiMode(CSLibrary.Constants.ApiMode.HIGHLEVEL);
            else if (radioButton2.Checked)
                result = Program.ReaderXP.SetApiMode(CSLibrary.Constants.ApiMode.LOWLEVEL);
            else
                this.Close();

            if (result == CSLibrary.Constants.Result.OK)
            {
                exit = true;
                this.Close();
            }
            else
                MessageBox.Show("Set Api Mode Error : " + result.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
