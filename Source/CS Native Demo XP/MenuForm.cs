using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace CS203_CALLBACK_API_DEMO
{
    

    public partial class MenuForm : Form
    {
        #region Member
        public string TargetEPC = "";
        #endregion

        #region Form
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            labelInterface.Text = "Interface : " + Program.ReaderXP.CurrentInterfaceType.ToString ();
            label_ConfigFilePath.Text = "Config File Path : " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CSLReader";

            if (Program.ReaderXP.CurrentInterfaceType == CSLibrary.HighLevelInterface.INTERFACETYPE.IPV4)
            {
                button7.Enabled = true;
                button9.Enabled = true;
            }
            else
            {
                button7.Enabled = false;
                button9.Enabled = false;
            }

            try
            {
                //Show MAC and IP
                Text = String.Format("IP = {0}, MAC = {1}", Program.IP, Program.SerialNumber);

                labelDeviceType.Text = Program.ReaderXP.OEMDeviceType.ToString ();

                //Get RFID Library Version
                CSLibrary.Structures.Version rfidVers = Program.ReaderXP.GetDriverVersion();
                //Get Firmware Version
                CSLibrary.Structures.Version FirmVers = Program.ReaderXP.GetFirmwareVersion();
                //Get CSLibrary Version
                CSLibrary.Structures.Version cslib = Program.ReaderXP.GetCSLibraryVersion();
#if NET_BUILD
                //Get 8051 Ethernet Application Version
                CSLibrary.Structures.Version c51app = Program.ReaderXP.GetC51AppVersion();
                if (c51app.major == 0)
                {
                    c51app = Program.ReaderXP.GetImageVersion();
                }

                //Get 8051 Ethernet Bootloader Version
                CSLibrary.Structures.Version c51bldr = Program.ReaderXP.GetC51BootLoaderVersion();
                if (c51bldr.major == 0)
                {
                    c51bldr = Program.ReaderXP.GetBootLoaderVersion();
                }
#endif
                //Get User Interface Version
                lb_software.Text = Program.GetDemoVersion().ToString(); ;
                //lb_rfidlib.Text = rfidVers.ToString(); // Not support in CSLibrary 3.0
                lb_firmware.Text = FirmVers.ToString();

                if (FirmVers.major == 1 && FirmVers.minor == 0)
                    label_BootloaderMode.Visible = true;

#if NET_BUILD

                lb_c51App.Text = c51app.ToString();
                lb_c51bldr.Text = c51bldr.ToString();
#endif
                lb_cslib.Text = cslib.ToString();

                CSLibrary.Constants.ApiMode Mode;
                if (Program.ReaderXP.GetApiMode(out Mode) == CSLibrary.Constants.Result.OK)
                    labelApiMode.Text = "API Mode : " + Mode.ToString ();
                else
                    labelApiMode.Text = "API Mode : Read Error";

                //No use
                //Program.Power.Show();

                //Refresh Reader Configuration, e.g. frequency channel, power, country
                UpdateSetting();

                CSLibrary.Windows.UI.SplashScreen.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Reader Startup fail : {0}", ex));
                this.Close();
            }
        }

        #endregion

        #region Button Handle
        private void btn_rw_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagReadWriteForm rw = new TagReadWriteForm())
            {
                rw.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_geiger_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (GeigerSearchForm search = new GeigerSearchForm())
            {
                search.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_security_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagSecurityForm security = new TagSecurityForm())
            {
                security.TargetEPC = TargetEPC;
                security.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_inv_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagInventoryForm InvForm = new TagInventoryForm(false))
            //using (TagInventoryWithSyncQueue InvForm = new TagInventoryWithSyncQueue())
            {
                InvForm.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_setup_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagSettingForm setting = new TagSettingForm())
            {
                setting.ShowDialog();
                {
                    UpdateSetting();
                }
            }
            this.Show();
        }
        private void pb_logo_Click(object sender, EventArgs e)
        {
            // Goto CSL Homepage
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.convergence.com.hk/";
            proc.Start();
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagKillForm kill = new TagKillForm())
            {
                kill.ShowDialog();
            }
            this.Show();
        }
        private void btn_writeany_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagWriteAnyEPCForm form = new TagWriteAnyEPCForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        #endregion

        #region Private Function
        private void UpdateSetting()
        {
            uint link = 0, power = 0;
            Program.ReaderXP.GetPowerLevel(ref power);

            Program.ReaderXP.GetCurrentLinkProfile(ref link);

            lb_freqProfile.Text = string.Format("Frequency Profile : {0}", Program.ReaderXP.SelectedRegionCode);
            lb_freqtype.Text = Program.ReaderXP.IsFixedChannel ? String.Format("Fixed Frequency : {0} MHz", Program.ReaderXP.SelectedFrequencyBand) : "Frequency : Hopping";
            lb_profile.Text = String.Format("Profile : {0}", link);
            lb_power.Text = String.Format("Power : {0}", power);
        }
        private void UpdatePower()
        {
            uint power = 0;
            Program.ReaderXP.GetPowerLevel(ref power);
            lb_power.Text = String.Format("Power : {0}", power);
        }

        private void pb_logo_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pb_logo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
#if false
            using (FormCoolLog coollog = new FormCoolLog())
            {
                coollog.ShowDialog();
            }
#else
            using (CoolLogForm CoolLog = new CoolLogForm())
            {
                CoolLog.TargetEPC = TargetEPC;
                CoolLog.ShowDialog();
            }
#endif
            UpdatePower();
            this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            using (FormCoolLog coollog = new FormCoolLog())
            {
                coollog.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormQT QT = new FormQT())
            {
                QT.ShowDialog();
            }
            UpdatePower();
            this.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormG2iLM G2 = new FormG2iLM())
            {
                G2.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void labelDeviceType_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormCS9010 Form = new FormCS9010())
            {
                Form.ShowDialog();
            }
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormColdChainFeatures Form = new FormColdChainFeatures())
            {
                Form.ShowDialog();
            }
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormTempMonitor form = new FormTempMonitor())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();

            using (FormSetInterface Form = new FormSetInterface())
            {
                Form.ShowDialog();
            }

            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagInventoryWithGpioForm InvForm = new TagInventoryWithGpioForm(false))
            {
                InvForm.ShowDialog();
            }
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormG2iLFuncTest G2 = new FormG2iLFuncTest())
            {
                G2.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (TagInventoryWithAsyncGpioForm InvForm = new TagInventoryWithAsyncGpioForm(false))
            {
                InvForm.ShowDialog();
            }
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool exit;

            this.Hide();

            using (FormSetApiMode Form = new FormSetApiMode())
            {
                Form.ShowDialog();
                exit = Form.exit;
            }

            if (exit)
                this.Close();
            else
                this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormUCODE7 UCODE7 = new FormUCODE7())
            {
                UCODE7.ShowDialog();
            }
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Program.appSetting.tagGroup.selected != CSLibrary.Constants.Selected.ALL)
                MessageBox.Show("Warning : MASK IS SET !!!");

            this.Hide();
            using (FormTIDDemo form = new FormTIDDemo())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void lb_firmware_Click(object sender, EventArgs e)
        {

        }
    }
}
