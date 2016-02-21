using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS101_CALLBACK_API_DEMO
{
    public partial class FormColdChainMenu : Form
    {
        public FormColdChainMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FormColdChainFeatures form = new FormColdChainFeatures())
            {
                form.tabControl1.SelectedIndex = 0;
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FormColdChainFeatures form = new FormColdChainFeatures())
            {
                form.tabControl1.SelectedIndex = 1;
                form.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FormColdChainFeatures form = new FormColdChainFeatures())
            {
                form.tabControl1.SelectedIndex = 2;
                form.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FormColdChainFeatures form = new FormColdChainFeatures())
            {
                form.tabControl1.SelectedIndex = 3;
                form.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FormColdChainFeatures form = new FormColdChainFeatures())
            {
                form.tabControl1.SelectedIndex = 4;
                form.ShowDialog();
            }
        }
    }
}