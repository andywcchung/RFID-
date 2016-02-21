using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CSLibrary;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormTempMonitor : Form
    {
        public FormTempMonitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                button1.Text = "Start";
                timer1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CSLibrary.Structures.TemperatureParms temp = new CSLibrary.Structures.TemperatureParms ();

            if (Program.ReaderXP.GetCurrentTemperature(ref temp) == CSLibrary.Constants.Result.OK)
            {
                textBox1.Text = temp.amb.ToString("D");
                textBox2.Text = temp.xcvr.ToString("D");
                textBox3.Text = temp.pwramp.ToString("D");
            }
            else
            {
                textBox1.Text = "NA";
                textBox2.Text = "NA";
                textBox3.Text = "NA";
            }
        }
    }
}
