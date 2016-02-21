using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class IPTextBox : UserControl
    {
        public String IP
        {
            get { return string.Format("{0}.{1}.{2}.{3}", numBox1.Text, numBox2.Text, numBox3.Text, numBox4.Text); }
            set
            {
                if (value != null)
                {
                    string[] ip = value.Split(new char[] { '.' });
                    if (ip.Length == 4)
                    {
                        numBox1.Text = ip[0];
                        numBox2.Text = ip[1];
                        numBox3.Text = ip[2];
                        numBox4.Text = ip[3];
                    }
                    else return;
                }
            }
        }

        public IPTextBox()
        {
            InitializeComponent();
        }

    }
}
