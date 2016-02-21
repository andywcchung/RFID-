using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CSLibrary.Structures;
using CSLibrary.Constants;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class AntennaPortCfgForm : Form
    {
        public AntennaPortCfgForm()
        {
            InitializeComponent();
        }

        private void AntennaPortCfgForm_Load(object sender, EventArgs e)
        {
            cb_enable.DataSource = Enum.GetValues(typeof(AntennaPortState));
            cb_enable.SelectedItem = AntennaPortState.UNKNOWN;
        }

        private void state_SelectedIndexChanged(object sender, EventArgs e)
        {
            AntennaPortStatus ant = new AntennaPortStatus();
            AntennaPortConfig antCfg = new AntennaPortConfig();
            if (state.SelectedIndex >= 0)
            {
                if (Program.ReaderXP.GetAntennaPortStatus((uint)state.SelectedIndex, ref ant) == Result.OK)
                {
                    cb_enable.SelectedItem = ant.state;
                }
                if (Program.ReaderXP.GetAntennaPortConfiguration((uint)state.SelectedIndex, ref antCfg) == Result.OK)
                {
                    txPhysicalPort.Text = antCfg.physicalTxPort.ToString();
                    rxPhysicalPort.Text = antCfg.physicalRxPort.ToString();
                    dwellTime.Value = antCfg.dwellTime;
                    inventoryCycles.Value = antCfg.numberInventoryCycles;
                    powerLevel.Value = antCfg.powerLevel;
                    senseThreshold.Value = antCfg.antennaSenseThreshold;
                }
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            status.Text = "Applying Configuration";
            AntennaPortConfig antCfg = new AntennaPortConfig();
            if (Program.ReaderXP.GetAntennaPortConfiguration((uint)state.SelectedIndex, ref antCfg) != Result.OK)
            {
                status.Text = "Apply config Failed";
                return;
            }
            antCfg.dwellTime = (uint)dwellTime.Value;
            antCfg.numberInventoryCycles = (uint)inventoryCycles.Value;
            antCfg.powerLevel = (uint)powerLevel.Value;
            antCfg.antennaSenseThreshold = (uint)senseThreshold.Value;
            if (Program.ReaderXP.SetAntennaPortState((uint)state.SelectedIndex,
                (AntennaPortState)cb_enable.SelectedItem) != Result.OK)
            {
                status.Text = "Apply config Failed";
                return;
            }
            if (Program.ReaderXP.SetAntennaPortConfiguration((uint)state.SelectedIndex, antCfg) != Result.OK)
            {
                status.Text = "Apply config Failed";
                return;
            }
            status.Text = "Applied Sucessfully";
        }

        
    }
}