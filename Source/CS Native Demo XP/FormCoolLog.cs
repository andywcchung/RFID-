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
    public partial class FormCoolLog : Form
    {
        public static int TimeInterval = 0;
        public static string datapath;

        public FormCoolLog()
        {
            InitializeComponent();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            using (FormCoolLogConfig config = new FormCoolLogConfig())
            {
                config.ShowDialog();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (FormCoolLogSearch search = new FormCoolLogSearch())
            {
                search.ShowDialog();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}