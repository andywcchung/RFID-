using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class PowerForm : Form
    {
        private int power = 300;
        private bool m_close = false;
        #region Form
        public PowerForm()
        {
            InitializeComponent();
        }

        private void PowerForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(320 - Width, 240 - Height);
            //Program.ReaderXP.GetPowerLevel(ref power);
            power = (int)Program.appSetting.Power;
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);
        }
        private void PowerForm_LostFocus(object sender, EventArgs e)
        {
            CloseAndApply();
        }

        private void PowerForm_GotFocus(object sender, EventArgs e)
        {
            m_close = false;
        }
        #endregion

        private void tmr_autohide_Tick(object sender, EventArgs e)
        {
            CloseAndApply();
        }

        #region Function
        public void PowerUp()
        {
            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
                return;
            this.Show();
            power += 5;
            if (power > Program.ReaderXP.GetActiveMaxPowerLevel())
            {
                power = (int)Program.ReaderXP.GetActiveMaxPowerLevel();
            }
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);

            ResetTimer();
        }

        public void PowerDown()
        {
            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
                return;
            this.Show();
            power -= 5;
            if (power < 0)
            {
                power = 0;
            }
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);
            
            ResetTimer();
        }

        private void ResetTimer()
        {
            tmr_autohide.Enabled = false;
            tmr_autohide.Enabled = true;
        }

        
        private void PowerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                CloseAndApply();
            }
        }

        private void CloseAndApply()
        {
            if (!m_close)
            {
                m_close = true;
                if (Program.ReaderXP.State == CSLibrary.Constants.RFState.IDLE)
                {
                    Program.ReaderXP.SetPowerLevel((uint)power);
                    Program.appSetting.Power = (uint)power;
                }
                else
                {

                }
                this.Hide();
                tmr_autohide.Enabled = false;
            }
        }
        #endregion

    }
}