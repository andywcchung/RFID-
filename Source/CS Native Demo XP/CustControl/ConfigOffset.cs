using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ConfigOffset : Form
    {
        public ushort Offset
        {
            get { return (ushort)offset.Value; }
            set { offset.Value = value; }
        }

        public ushort Word
        {
            get { return (ushort)word.Value; }
            set { word.Value = value; }
        }

        //public DialogResult Result = DialogResult.Cancel;

        public ConfigOffset()
        {
            InitializeComponent();
            this.Location = new Point((320 - Width) / 2, (240 - Height) / 2);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
