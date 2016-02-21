using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class NumBox : TextBox
    {
        public NumBox()
        {

        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (IsHex(e.KeyChar) || (e.KeyChar == '\b' || e.KeyChar == 0x16 || e.KeyChar == 0x3))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private bool IsHex(char hex)
        {
            if ((hex >= '0' && hex <= '9'))
                return true;
            return false;
        }
    }
}
