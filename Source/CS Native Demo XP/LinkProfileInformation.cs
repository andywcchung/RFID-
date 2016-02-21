using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class LinkProfileInformation : Form
    {
        public LinkProfileInformation()
        {
            InitializeComponent();
        }

        public LinkProfileInformation(uint link)
            : this()
        {
            CSLibrary.LinkProfileInfo info = Program.ReaderXP.GetActiveLinkProfileInfo(link);

            lb_dataDifference.Text = info.LinkProfileConfig.data01Difference.ToString();
            lb_denseReaderMode.Text = info.DenseReaderMode ? "Enable" : "Disable";
            lb_divideRatio.Text = info.LinkProfileConfig.divideRatio.ToString();
            lb_millerNumber.Text = info.LinkProfileConfig.millerNumber.ToString();
            lb_modulationType.Text = info.LinkProfileConfig.modulationType.ToString();
            lb_nbRssiSamples.Text = info.NarrowbandRssiSamples.ToString();
            lb_profileID.Text = info.ProfileId.ToString();
            lb_profileState.Text = info.Enabled ? "Enable" : "Disable";
            lb_profileUID.Text = info.ProfileUniqueId;
            lb_profileVersion.Text = info.ProfileVersion.ToString();
            lb_radioProtocol.Text = info.ProfileProtocol.ToString();
            lb_realtimeNBRssiSamples.Text = info.RealtimeNarrowbandRssiSamples.ToString();
            lb_realtimeRssiEnable.Text = info.RealtimeRssiEnabled ? "Enable" : "Disable";
            lb_realTimeWBRssiSamples.Text = info.RealtimeWidebandRssiSamples.ToString();
            lb_wbRssiSamples.Text = info.WidebandRssiSamples.ToString();

        }
    }
}