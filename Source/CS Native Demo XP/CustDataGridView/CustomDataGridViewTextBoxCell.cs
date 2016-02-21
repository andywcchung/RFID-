using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public class CustomDataGridViewTextBoxCell
    : DataGridViewTextBoxCell
    {
        public override Type EditType
        {
            get { return typeof(CustomDataGridViewTextBoxEditingControl); }
        }
    }
}
