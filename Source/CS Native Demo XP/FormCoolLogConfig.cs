using System;
//using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormCoolLogConfig : Form
    {
        public FormCoolLogConfig()
        {
            InitializeComponent();
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormCoolLog.TimeInterval = Convert.ToInt32(textBox1.Text) * 60 + Convert.ToInt32(textBox2.Text);
                if (FormCoolLog.TimeInterval > 0)
                    FormCoolLog.TimeInterval--;
                else if (FormCoolLog.TimeInterval < 0)
                    FormCoolLog.TimeInterval = 0;
            }
            catch { }

            try
            {
                FormCoolLog.datapath = textBox3.Text;
            }
            catch { }

            Close();
        }

        private void FormCoolLogConfig_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((FormCoolLog.TimeInterval + 1) / 60).ToString ();
            textBox2.Text = ((FormCoolLog.TimeInterval + 1) % 60).ToString ();
            textBox3.Text = FormCoolLog.datapath;
        }
    }
}