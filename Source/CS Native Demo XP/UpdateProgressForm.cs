using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class UpdateProgressForm : Form
    {
        public bool Closed = true;

        public String MessageTxt
        {
            set { lb_msg.Text = value; }
        }

        public int Percent
        {
            set 
            {
                lb_msg.Text = String.Format("Total percent : {0}/100", value);
                pb_prog.Value = value;
            }
        }

        public bool EnableOK
        {
            set { btn_ok.Enabled = value; }
        }

        public UpdateProgressForm()
        {
            InitializeComponent();
            Closed = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Closed = true;
        }
    }
}