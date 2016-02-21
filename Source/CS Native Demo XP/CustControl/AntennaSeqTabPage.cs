using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Structures;
    using CSLibrary.Constants;
    using CSLibrary.Tools;
    public partial class AntennaSeqTabPage : TabPage
    {
        private CustomDataGridViewTextBoxColumn antennaColumn =
            new CustomDataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn indexColumn =
            new DataGridViewTextBoxColumn();
        private BindingList<byte> antennaSequence = new BindingList<byte>();

        public AntennaSeqTabPage()
        {
            InitializeComponent();

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


            this.cbMode.SelectedIndex = (int)Program.ReaderXP.AntennaSequenceMode;
            
            if (Program.ReaderXP.AntennaSequenceMode == AntennaSequenceMode.SEQUENCE ||
                Program.ReaderXP.AntennaSequenceMode == AntennaSequenceMode.SEQUENCE_SMART_CHECK)
            {
                for (uint i = 0; i < Program.ReaderXP.AntennaSequenceSize; i++)
                {
                    antennaSequence.Add(Program.ReaderXP.AntennaPortSequence[i]);
                }
                this.nbSequenceSize.Enabled = true;
            }
            else
            {
                antennaSequence.Add(0); 
                this.nbSequenceSize.Enabled = false;
            }

            if ((int)Program.ReaderXP.AntennaSequenceSize < 1 || (int)Program.ReaderXP.AntennaSequenceSize > 48)
            {
                this.nbSequenceSize.Value = 1;
            }
            else
            {
                this.nbSequenceSize.Value = (int)Program.ReaderXP.AntennaSequenceSize; 
            }

            this.view.DataSource = this.antennaSequence;
            this.view.Refresh();
        }

        void view_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    break;
                case 1:
                    byte val = 0;
                    byte.TryParse((string)view[e.ColumnIndex, e.RowIndex].Value, out val);
                    if (val > 15)
                    {
                        Program.ReaderXP.AntennaPortSequence[e.RowIndex] = antennaSequence[e.RowIndex] = 15;
                    }
                    else if (val < 0)
                    {
                        Program.ReaderXP.AntennaPortSequence[e.RowIndex] = antennaSequence[e.RowIndex] = 0;
                    }
                    else
                    {
                        Program.ReaderXP.AntennaPortSequence[e.RowIndex] = antennaSequence[e.RowIndex] = val;
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
                    e.Value = Program.ReaderXP.AntennaPortSequence[e.RowIndex].ToString();
                    break;
            }
        }

        void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /* 
         * mode 0:NORMAL
         * mode 1:SEQUENCE -> editable list
         * mode 2:SMART_CHECK
         * mode 3:SEQUENCE & SMART_CHECK -> editable list
        */

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            nbSequenceSize.Enabled = false;
            view.Enabled = false;

            switch (cbMode.SelectedIndex)
            {
                case 0:
                    Program.ReaderXP.AntennaSequenceMode = AntennaSequenceMode.NORMAL;
                    break;
                case 1:
                    Program.ReaderXP.AntennaSequenceMode = AntennaSequenceMode.SEQUENCE;
                    nbSequenceSize.Enabled = true;
                    view.Enabled = true;
                    break;
                case 2:
                    Program.ReaderXP.AntennaSequenceMode = AntennaSequenceMode.SMART_CHECK;
                    break;
                case 3:
                    Program.ReaderXP.AntennaSequenceMode = AntennaSequenceMode.SEQUENCE | AntennaSequenceMode.SMART_CHECK;
                    nbSequenceSize.Enabled = true;
                    view.Enabled = true;
                    break;
            }
            view.Refresh();
        }

        private void nbSequenceSize_ValueChanged(object sender, EventArgs e)
        {
            if (nbSequenceSize.Value != antennaSequence.Count)
            {
                Program.ReaderXP.AntennaSequenceSize = (uint)nbSequenceSize.Value;

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

                for (int i = 0; i < antennaSequence.Count; i++)
                {
                    Program.ReaderXP.AntennaPortSequence[i] = antennaSequence[i];
                }                
            }
            view.Refresh();
        }
    }
}