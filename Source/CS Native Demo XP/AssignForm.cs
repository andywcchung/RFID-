using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class AssignForm : Form
    {
        public string CS203IP
        {
            get { return ipTextBox1.IP; }
            set { ipTextBox1.IP = value; }
        }

        public byte DHCPRetry
        {
            get { return (byte)nb_timeout.Value; }
            set { nb_timeout.Value = value; }
        }

        public string DeviceName
        {
            get { return tb_devicename.Text; }
            set { tb_devicename.Text = value; }
        }

        public bool DHCPEnable
        {
            get { return cb_dhcp.Checked; }
            set { cb_dhcp.Checked = value; }
        }

        public bool TrustedEnable
        {
            get { return cbTrustedEnable.Checked; }
            set { cbTrustedEnable.Checked = value; }
        }

        public string TrustedServer
        {
            get { return tbTrustedServer.IP; }
            set { tbTrustedServer.IP = value; }
        }

        public string Subnet
        {
            get { return ipTxtSubnet.IP; }
            set { ipTxtSubnet.IP = value; }
        }

        public string Gateway
        {
            get { return ipTxtGateway.IP; }
            set { ipTxtGateway.IP = value; }
        }

        public AssignForm()
        {
            InitializeComponent();
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CS203IP = ipTextBox1.IP;
            this.Close();
        }

        private void cb_dhcp_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_dhcp.Checked)
            {
                ipTextBox1.Enabled = false;
            }
            else
                ipTextBox1.Enabled = true;
        }
    }
}