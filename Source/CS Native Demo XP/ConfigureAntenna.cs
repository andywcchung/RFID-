#if CS468
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CSLibrary;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ConfigureAntenna : Form
    {
        private const int ENABLE_BUTTON_INDEX = 0;
        //private const int ANTENNA_INDEX = 1;
        private const int PORT_INDEX = 1;
        private const int POWER_INDEX = 2;
        private const int DWELL_INDEX = 3;
        private const int ROUNDS_INDEX = 4;
        private const int SENSE_THRE_INDEX = 6;
        private const int SENSE_VALUE_INDEX = 6;

        private const int ENABLE_LOCAL_INV_INDEX = 7;
        private const int INV_ALGO_INDEX = 8;
        private const int STARTQ_INDEX = 9;
        private const int ENABLE_LOCAL_PROFILE_INDEX = 10;
        private const int LINK_PROFILE_INDEX = 11;
        private const int ENABLE_FREQ_INDEX = 12;
        private const int FREQ_CHANNEL_INDEX = 13;

        public string error = "";

        private DataGridViewButtonColumn enableColumn =
           new DataGridViewButtonColumn();

        private DataGridViewTextBoxColumn portColumn =
            new DataGridViewTextBoxColumn();
        private CustomDataGridViewTextBoxColumn powerColumn =
            new CustomDataGridViewTextBoxColumn();
        private CustomDataGridViewTextBoxColumn dwellColumn =
            new CustomDataGridViewTextBoxColumn();
        private CustomDataGridViewTextBoxColumn roundsColumn =
            new CustomDataGridViewTextBoxColumn();
        private CustomDataGridViewTextBoxColumn antennaSenseThresholdColumn =
            new CustomDataGridViewTextBoxColumn();
        private CustomDataGridViewTextBoxColumn antennaSenseValueColumn =
            new CustomDataGridViewTextBoxColumn();

        private DataGridViewCheckBoxColumn enableLocalInv =
            new DataGridViewCheckBoxColumn();
        private DataGridViewComboBoxColumn Inv_AlgoColumn =
            new DataGridViewComboBoxColumn();
        private CustomDataGridViewTextBoxColumn StartQColumn =
            new CustomDataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn enableLocalProfile =
            new DataGridViewCheckBoxColumn();
        private CustomDataGridViewTextBoxColumn ProfileColumn =
            new CustomDataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn enableLocalFreq =
            new DataGridViewCheckBoxColumn();
        private CustomDataGridViewTextBoxColumn FreqChnColumn =
            new CustomDataGridViewTextBoxColumn();

        private BindingSource bindingSource =
            new BindingSource();

        public ConfigureAntenna()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

#if nouse
            TagSettingForm parent = this.TopLevelControl as TagSettingForm;

            if (null == parent)
            {
                System.Diagnostics.Debug.Assert(false, String.Format("Unknown parent form: {0}", this.TopLevelControl.GetType()));
            }
            else
            {
                //parent.DialogClose += new DialogCloseDelegate(OnDialogClose);
            }
#endif

            view.AutoGenerateColumns = false;
            view.AllowUserToResizeRows = false;
            view.AllowUserToResizeColumns = false;
            view.AllowUserToOrderColumns = false;
            view.AllowUserToAddRows = false;
            view.AllowUserToDeleteRows = false;
            view.MultiSelect = false;
            view.RowHeadersVisible = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.CellContentClick += new DataGridViewCellEventHandler(CellContentClick);
            view.CellFormatting += new DataGridViewCellFormattingEventHandler(CellFormatting);

            view.Columns.Clear();


            // editColumn
            enableColumn.HeaderText = "";
            enableColumn.Text = "Active";
            enableColumn.UseColumnTextForButtonValue = true;
            enableColumn.MinimumWidth = 50;
            enableColumn.Resizable = DataGridViewTriState.False;
            enableColumn.Width = 50;
            enableColumn.Frozen = true;

            view.Columns.Add(enableColumn);


            // portColumn
            portColumn.HeaderText = " #";
            portColumn.MinimumWidth = 50;
            portColumn.Name = "portColumn";
            portColumn.ReadOnly = true;
            portColumn.Resizable = DataGridViewTriState.False;
            portColumn.Width = 50;
            portColumn.DataPropertyName = "Port";
            portColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            portColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            portColumn.Frozen = true;

            view.Columns.Add(portColumn);

            // powerColumn
            powerColumn.HeaderText = "Power Level 1/10 dBm";
            powerColumn.MinimumWidth = 100;
            powerColumn.Name = "powerColumn";
            //powerColumn.ReadOnly = true;
            powerColumn.Resizable = DataGridViewTriState.False;
            powerColumn.Width = 100;
            powerColumn.DataPropertyName = "PowerLevel";
            powerColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            powerColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns.Add(powerColumn);


            // dwellColumn
            dwellColumn.HeaderText = "Dwell Time (milliseconds)";
            dwellColumn.MinimumWidth = 100;
            dwellColumn.Name = "dwellColumn";
            //dwellColumn.ReadOnly = true;
            dwellColumn.Resizable = DataGridViewTriState.False;
            dwellColumn.Width = 100;
            dwellColumn.DataPropertyName = "DwellTime";
            dwellColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dwellColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns.Add(dwellColumn);


            // roundsColumn
            roundsColumn.HeaderText = "Inventory Rounds";
            roundsColumn.MinimumWidth = 100;
            roundsColumn.Name = "roundsColumn";
            //roundsColumn.ReadOnly = true;
            roundsColumn.Resizable = DataGridViewTriState.False;
            roundsColumn.Width = 100;
            roundsColumn.DataPropertyName = "NumberInventoryCycles";
            roundsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            roundsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns.Add(roundsColumn);


            // antennaSenseThresholdColumn
            antennaSenseThresholdColumn.HeaderText = "Antenna Sense Threshold (Ohms)";
            antennaSenseThresholdColumn.MinimumWidth = 100;
            antennaSenseThresholdColumn.Name = "antennaSenseThresholdColumn";
            //antennaSenseThresholdColumn.ReadOnly = true;
            antennaSenseThresholdColumn.Resizable = DataGridViewTriState.False;
            antennaSenseThresholdColumn.Width = 100;
            antennaSenseThresholdColumn.DataPropertyName = "AntennaSenseThreshold";
            antennaSenseThresholdColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            antennaSenseThresholdColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            antennaSenseThresholdColumn.Visible = false;
            view.Columns.Add(antennaSenseThresholdColumn);


            // antennaSenseValueColumn
            antennaSenseValueColumn.HeaderText = "Antenna Sense Value (Ohms)";
            antennaSenseValueColumn.MinimumWidth = 100;
            antennaSenseValueColumn.Name = "antennaSenseValueColumn";
            //antennaSenseValueColumn.ReadOnly = true;
            antennaSenseValueColumn.Resizable = DataGridViewTriState.False;
            antennaSenseValueColumn.Width = 100;
            antennaSenseValueColumn.DataPropertyName = "AntennaSenseValue";
            antennaSenseValueColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            antennaSenseValueColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            antennaSenseValueColumn.Visible = false;
            view.Columns.Add(antennaSenseValueColumn);

            enableLocalInv.HeaderText = "Enable Local Inventory";
            enableLocalInv.Name = "EnableLocalInv";
            enableLocalInv.FlatStyle = FlatStyle.Standard;
            enableLocalInv.ThreeState = false;
            enableLocalInv.TrueValue =true;
            enableLocalInv.FalseValue = false;
            enableLocalInv.DataPropertyName = "EnableLocalInv";
            enableLocalInv.CellTemplate = new DataGridViewCheckBoxCell();
            enableLocalInv.CellTemplate.Style.BackColor = Color.Beige;
            enableLocalInv.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            view.Columns.Add(enableLocalInv);

            Inv_AlgoColumn.HeaderText = "Inventory Algorithm";
            Inv_AlgoColumn.DropDownWidth = 160;
            Inv_AlgoColumn.Name = "InventoryAlgorithm";
            Inv_AlgoColumn.Width = 100;
            Inv_AlgoColumn.FlatStyle = FlatStyle.Flat;
            Inv_AlgoColumn.MaxDropDownItems = 3;
            Inv_AlgoColumn.DataPropertyName = "InventoryAlgorithm";
            Inv_AlgoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Inv_AlgoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Inv_AlgoColumn.DataSource = Enum.GetValues(typeof(SingulationAlgorithm));
            view.Columns.Add(Inv_AlgoColumn);

            StartQColumn.HeaderText = "StartQ";
            StartQColumn.MinimumWidth = 100;
            StartQColumn.Name = "StartQ";
            StartQColumn.Resizable = DataGridViewTriState.False;
            StartQColumn.Width = 100;
            StartQColumn.DataPropertyName = "StartQ";
            StartQColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StartQColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns.Add(StartQColumn);

            enableLocalProfile.HeaderText = "Enable Local LinkProfile";
            enableLocalProfile.Name = "EnableLocalProfile";
            enableLocalProfile.FlatStyle = FlatStyle.Standard;
            enableLocalProfile.ThreeState = false;
            enableLocalProfile.TrueValue = true;
            enableLocalProfile.FalseValue = false;
            enableLocalProfile.DataPropertyName = "EnableLocalProfile";
            enableLocalProfile.CellTemplate = new DataGridViewCheckBoxCell();
            enableLocalProfile.CellTemplate.Style.BackColor = Color.Beige;
            enableLocalProfile.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            view.Columns.Add(enableLocalProfile);

            ProfileColumn.HeaderText = "Profile";
            ProfileColumn.MinimumWidth = 100;
            ProfileColumn.Name = "Profile";
            ProfileColumn.Resizable = DataGridViewTriState.False;
            ProfileColumn.Width = 100;
            ProfileColumn.DataPropertyName = "LinkProfile";
            ProfileColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProfileColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns.Add(ProfileColumn);

            enableLocalFreq.HeaderText = "Enable Local Frequency";
            enableLocalFreq.Name = "EnableLocalFreq";
            enableLocalFreq.FlatStyle = FlatStyle.Standard;
            enableLocalFreq.ThreeState = false;
            enableLocalFreq.TrueValue = true;
            enableLocalFreq.FalseValue = false;
            enableLocalFreq.DataPropertyName = "EnableLocalFreq"; 
            enableLocalFreq.CellTemplate = new DataGridViewCheckBoxCell();
            enableLocalFreq.CellTemplate.Style.BackColor = Color.Beige;
            enableLocalFreq.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            view.Columns.Add(enableLocalFreq);

            FreqChnColumn.HeaderText = "Frequency";
            FreqChnColumn.MinimumWidth = 100;
            FreqChnColumn.Name = "Frequency";
            FreqChnColumn.Resizable = DataGridViewTriState.False;
            FreqChnColumn.Width = 100;
            FreqChnColumn.DataPropertyName = "FreqChannel";
            FreqChnColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FreqChnColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns.Add(FreqChnColumn);

            this.bindingSource.DataSource = Program.appSetting.AntennaList;

            this.view.DataSource = this.bindingSource;
        }

        void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            switch (e.ColumnIndex)
            {
                case ENABLE_BUTTON_INDEX:
                    switch (Program.appSetting.AntennaList[e.RowIndex].State)
                    {
                        case AntennaPortState.ENABLED:
                            Program.appSetting.AntennaList[e.RowIndex].State = AntennaPortState.DISABLED;
                            break;
                        case AntennaPortState.DISABLED:
                        case AntennaPortState.UNKNOWN:
                            Program.appSetting.AntennaList[e.RowIndex].State = AntennaPortState.ENABLED;
                            break;
                    }
                    break;
                case ENABLE_FREQ_INDEX:
                    Program.appSetting.AntennaList[e.RowIndex].EnableLocalFreq = !Program.appSetting.AntennaList[e.RowIndex].EnableLocalFreq;
                    break;
                case ENABLE_LOCAL_INV_INDEX:
                    Program.appSetting.AntennaList[e.RowIndex].EnableLocalInv = !Program.appSetting.AntennaList[e.RowIndex].EnableLocalInv;
                    break;
                case ENABLE_LOCAL_PROFILE_INDEX:
                    Program.appSetting.AntennaList[e.RowIndex].EnableLocalProfile = !Program.appSetting.AntennaList[e.RowIndex].EnableLocalProfile;
                    break;
            }
            view.Refresh();
        }

        void CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if
            (
                Program.appSetting.AntennaList[e.RowIndex].State ==
                AntennaPortState.DISABLED
            )
            {
                e.CellStyle.ForeColor = SystemColors.GrayText;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                e.CellStyle.BackColor = SystemColors.ButtonFace;
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                this.view[e.ColumnIndex, e.RowIndex].ReadOnly = true;

                switch (e.ColumnIndex)
                {
                    case PORT_INDEX:
                        break;
                    case ENABLE_BUTTON_INDEX:
                        e.Value = "Inactive";
                        break;
                    /*case ENABLE_FREQ_INDEX:
                    case ENABLE_LOCAL_INV_INDEX:
                    case ENABLE_LOCAL_PROFILE_INDEX:
                        e.Value = "false";
                        break;*/
                    case ENABLE_FREQ_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalFreq;
                        break;
                    case ENABLE_LOCAL_INV_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalInv;
                        break;
                    case ENABLE_LOCAL_PROFILE_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalProfile;
                        break;
                    case INV_ALGO_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].InventoryAlgorithm;
                        break;
                    default:
                        e.Value = "";
                        break;
                }
            }
            else
            {
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                if (e.ColumnIndex == SENSE_THRE_INDEX || e.ColumnIndex == SENSE_VALUE_INDEX || e.ColumnIndex == PORT_INDEX)
                {
                    this.view[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                }
                else
                {
                    this.view[e.ColumnIndex, e.RowIndex].ReadOnly = false;
                }

                switch (e.ColumnIndex)
                {

                    case DWELL_INDEX:
                    case ROUNDS_INDEX:
                        if (e.Value.ToString() == "0")
                        {
                            e.Value = "No Limit";
                        }
                        break;
                    case ENABLE_FREQ_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalFreq;
                        if (!Program.appSetting.AntennaList[e.RowIndex].EnableLocalFreq)
                        {
                            this.view[FREQ_CHANNEL_INDEX, e.RowIndex].ReadOnly = true;
                        }
                        else
                        {
                            this.view[FREQ_CHANNEL_INDEX, e.RowIndex].ReadOnly = false;
                        }
                        break;
                    case ENABLE_LOCAL_INV_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalInv;
                        if (!Program.appSetting.AntennaList[e.RowIndex].EnableLocalInv)
                        {
                            this.view[INV_ALGO_INDEX, e.RowIndex].ReadOnly = true;
                            this.view[STARTQ_INDEX, e.RowIndex].ReadOnly = true;
                        }
                        else
                        {
                            this.view[INV_ALGO_INDEX, e.RowIndex].ReadOnly = false;
                            this.view[STARTQ_INDEX, e.RowIndex].ReadOnly = false;
                        }
                        break;
                    case ENABLE_LOCAL_PROFILE_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].EnableLocalProfile;
                        if (!Program.appSetting.AntennaList[e.RowIndex].EnableLocalProfile)
                        {
                            this.view[LINK_PROFILE_INDEX, e.RowIndex].ReadOnly = true;
                        }
                        else
                        {
                            this.view[LINK_PROFILE_INDEX, e.RowIndex].ReadOnly = false;
                        }
                        break;
                    case INV_ALGO_INDEX:
                        e.Value = Program.appSetting.AntennaList[e.RowIndex].InventoryAlgorithm;
                        break;
                    default:
                        break;
                }
            }
        }

        private void restoreDefaultsButton_Click(object sender, EventArgs e)
        {
            Program.appSetting.AntennaList = AntennaList.DEFAULT_ANTENNA_LIST;

            this.view.Refresh();
        }

        private void btnApplyChange_Click(object sender, EventArgs e)
        {
            Program.appSetting.AntennaList.Store(Program.ReaderXP);
            this.view.Refresh();
            Program.appSetting.Save();
            Close();
        }

        private void ConfigureAntenna_Load(object sender, EventArgs e)
        {

        }
    }
}
#endif