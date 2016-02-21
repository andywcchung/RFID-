using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ConfigureOperation : Form
    {
        private CustomDataGridViewTextBoxColumn antennaColumn =
            new CustomDataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn indexColumn =
            new DataGridViewTextBoxColumn();
        private BindingList<byte> antennaSequence = new BindingList<byte>();
        public ConfigureOperation()
        {
            InitializeComponent();
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMode.SelectedIndex == 1 || cbMode.SelectedIndex == 3)
            {
                nbSequenceSize.Enabled = true;
                view.Enabled = true;
            }
            else
            {
                nbSequenceSize.Enabled = false;
                view.Enabled = false;
            }
            view.Refresh();
        }

        private void ConfigureOperation_Load(object sender, EventArgs e)
        {
            antennaSequence.Add(0);
            this.cbMode.SelectedIndex = 0;
            view.AutoGenerateColumns = false;
            view.AllowUserToResizeRows = false;
            view.AllowUserToResizeColumns = false;
            view.AllowUserToOrderColumns = false;
            view.AllowUserToAddRows = false;
            view.AllowUserToDeleteRows = false;
            view.MultiSelect = false;
            view.RowHeadersVisible = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.CellContentClick += new DataGridViewCellEventHandler(view_CellContentClick);
            view.CellFormatting += new DataGridViewCellFormattingEventHandler(view_CellFormatting);
            view.CellValueChanged += new DataGridViewCellEventHandler(view_CellValueChanged);

            view.Columns.Clear();

            indexColumn.HeaderText = "Index";
            indexColumn.MinimumWidth = 100;
            indexColumn.Name = "Index";
            indexColumn.ReadOnly = true;
            indexColumn.Resizable = DataGridViewTriState.False;
            indexColumn.Width = 100;
            indexColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            indexColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns.Add(indexColumn);
            // powerColumn
            antennaColumn.HeaderText = "AntennaPort (0 - 15)";
            antennaColumn.MinimumWidth = 150;
            antennaColumn.Name = "Sequence";
            //powerColumn.ReadOnly = true;
            antennaColumn.Resizable = DataGridViewTriState.False;
            antennaColumn.Width = 150;
            //antennaColumn.DataPropertyName = "Sequence";
            antennaColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            antennaColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns.Add(antennaColumn);

            this.view.DataSource = this.antennaSequence;
        }

        void view_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    break;
                case 1:
                    byte val = 0;
                    if (byte.TryParse((string)view[e.ColumnIndex, e.RowIndex].Value, out val))
                    {
                        antennaSequence[e.RowIndex] = val;
                    }
                    break;
            }
        }

        void view_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = e.RowIndex.ToString();
                    break;
                case 1:
                    byte val = 0;
                    if (byte.TryParse((string)e.Value, out val))
                    {
                        if (val > 15)
                        {
                            e.Value = "15";
                        }
                        if (val < 0)
                        {
                            e.Value = "0";
                        }
                    }
                    else
                    {
                        e.Value = "0";
                    }
                    break;
            }
        }

        void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void nbSequenceSize_ValueChanged(object sender, EventArgs e)
        {
            if(nbSequenceSize.Value != antennaSequence.Count)
            {
                if (nbSequenceSize.Value > antennaSequence.Count)
                {
                    int count = (int)nbSequenceSize.Value - antennaSequence.Count;
                    for (int i = 0; i < count; i++)
                    {
                        antennaSequence.Add(0);
                    }
                }
                else
                {
                    int count = antennaSequence.Count - (int)nbSequenceSize.Value;
                    for (int i = 0; i < count; i++)
                    {
                        antennaSequence.RemoveAt(antennaSequence.Count - 1);
                    }
                }
                view.Refresh();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            CSLibrary.Constants.AntennaSequenceMode mode = CSLibrary.Constants.AntennaSequenceMode.UNKNOWN;
            switch(cbMode.SelectedIndex)
            {
                case 0:
                    mode = CSLibrary.Constants.AntennaSequenceMode.NORMAL;
                    break;
                case 1:
                    mode = CSLibrary.Constants.AntennaSequenceMode.SEQUENCE;
                    break;
                case 2:
                    mode = CSLibrary.Constants.AntennaSequenceMode.SMART_CHECK;
                    break;
                case 3:
                    mode = CSLibrary.Constants.AntennaSequenceMode.SEQUENCE | CSLibrary.Constants.AntennaSequenceMode.SMART_CHECK;
                    break;
            }
            if (Program.ReaderXP.SetOperationMode((ushort)nbCycles.Value, mode, (uint)nbSequenceSize.Value) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show("SetOperationMode failed");
            }
            if ((mode & CSLibrary.Constants.AntennaSequenceMode.SEQUENCE) != 0)
            {
                byte[] seq = new Byte[antennaSequence.Count];
                for (int i = 0; i < antennaSequence.Count; i++)
                {
                    seq[i] = antennaSequence[i];
                }
                if (Program.ReaderXP.SetAntennaSequence(seq) != CSLibrary.Constants.Result.OK)
                {
                    MessageBox.Show("SetOperationMode failed");
                }
            }
        }
    }
}
