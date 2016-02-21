using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public class CustomDataGridViewTextBoxColumn
    : DataGridViewColumn
    {
        public CustomDataGridViewTextBoxColumn()
            : base(new CustomDataGridViewTextBoxCell())
        {
        }
    }
}
