using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

//Import RFID Library
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagSettingForm : Form
    {
        //private Singulation_FixedQ singulation_fixedQ;
        //private Singulation_DynamicQ singulation_dynamicQ;
        //private Singulation_DynamicQ singulation_dynamicQAdjust;
        //private Singulation_DynamicQ singulation_dynamicQThreshold;
        private bool m_stop = false;
        private double[] CurrentFreqList = null;

        private AntennaSeqTabPage tp_antenna_seq = new AntennaSeqTabPage();

        public TagSettingForm()
        {
            InitializeComponent();

            tp_antenna_seq.Text = "Antenna Sequence";
            tp_antenna_seq.BackColor = Color.FromArgb(192, 255, 192);
            tabControl1.Controls.Add(tp_antenna_seq);
            tabControl1.ResumeLayout();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //RFID Initial start here
            {
                //Load DataSource

                UInt16 ms = 0;

                Program.ReaderXP.GetTxOnTime(ref ms);

                textBox1.Text = ms.ToString("D");

                this.cb_linkprofile.DataSource = Program.ReaderXP.GetActiveLinkProfile();

                this.cb_country.DataSource = Program.ReaderXP.GetActiveRegionCode();

                //this.cb_algorithm.DataSource = EnumGetValues(typeof(SingulationAlgorithm));

                //this.cb_selected.DataSource = EnumGetValues(typeof(Selected));

                //this.cb_session.DataSource = EnumGetValues(typeof(Session));

                //this.cb_target.DataSource = EnumGetValues(typeof(SessionTarget));

                if (Program.ReaderXP.IsFixedChannelOnly)
                {
                    cb_fixed.Enabled = false;
                    cb_fixed.Checked = true;
                }
                else
                {
                    cb_fixed.Enabled = true;
                    cb_fixed.Checked = Program.appSetting.FixedChannel;

                }

                //Load Setting
                if (Program.ReaderXP.SelectedRegionCode == CSLibrary.Constants.RegionCode.JP)
                {
                    cb_lbt.Enabled = true;
                    cb_lbt.Checked = Program.appSetting.Lbt;
                }
                else
                    cb_lbt.Enabled = Program.appSetting.Lbt;

                if (Program.ReaderXP.SelectedRegionCode == CSLibrary.Constants.RegionCode.ETSI || 
                    Program.ReaderXP.SelectedRegionCode == CSLibrary.Constants.RegionCode.JP)
                {
                    checkBoxFreqAgile.Enabled = true;
                    checkBoxFreqAgile.Checked = Program.appSetting.FreqAgile;
                }
                else
                    checkBoxFreqAgile.Enabled = false;

                if (cb_fixed.Checked && !checkBoxFreqAgile.Checked)
                    cb_freqlist.Enabled = cb_fixed.Checked;
                else
                    cb_freqlist.Enabled = false;

                //highlight the current link profile
                cb_linkprofile.SelectedItem = Program.appSetting.Link_profile;

                //current select frequency profile index
                cb_country.SelectedItem = Program.ReaderXP.SelectedRegionCode;

                //this.cb_algorithm.SelectedItem = Program.appSetting.Singulation;
                switch (Program.appSetting.Singulation)
                {
                    case SingulationAlgorithm.FIXEDQ:
                        this.cb_algorithm.SelectedIndex = 0;
                        break;

                    case SingulationAlgorithm.DYNAMICQ:
                        this.cb_algorithm.SelectedIndex = 1;
                        break;
                }

                //this.cb_selected.SelectedItem = Program.appSetting.tagGroup.selected;
                switch (Program.appSetting.tagGroup.selected)
                {
                    case Selected.ASSERTED:
                        this.cb_selected.SelectedIndex = 1;
                        break;

                    case Selected.DEASSERTED:
                        this.cb_selected.SelectedIndex = 2;
                        break;

                    default:
                        this.cb_selected.SelectedIndex = 0;
                        break;
                }

                //this.cb_session.SelectedItem = Program.appSetting.tagGroup.session;
                switch (Program.appSetting.tagGroup.session)
                {
                    case Session.S1:
                        this.cb_session.SelectedIndex = 1;
                        break;

                    case Session.S2:
                        this.cb_session.SelectedIndex = 2;
                        break;

                    case Session.S3:
                        this.cb_session.SelectedIndex = 3;
                        break;

                    default:
                        this.cb_session.SelectedIndex = 0;
                        break;
                }

                //this.cb_target.SelectedItem = Program.appSetting.tagGroup.target;

                if (Program.appSetting.Singulation== SingulationAlgorithm.DYNAMICQ)
                {
                    DynamicQParms dq = (DynamicQParms)Program.appSetting.SingulationAlg;
                    if (dq.toggleTarget != 0)
                        this.cb_target.SelectedIndex = 2;
                    else
                        this.cb_target.SelectedIndex = (int)Program.appSetting.tagGroup.target;

                    nb_startqvalue.Value = dq.startQValue;
                    nb_minqvalue.Value = dq.minQValue;
                    nb_maxqvalue.Value = dq.maxQValue;
                    nb_thresholdMultiplier.Value = dq.thresholdMultiplier;
                    numericUpDown_Retry.Value = dq.retryCount;
                    checkBox_Toggle.Checked = (dq.toggleTarget != 0);
                }
                else
                {
                    FixedQParms fq = (FixedQParms)Program.appSetting.SingulationAlg;
                    if (fq.toggleTarget != 0)
                        this.cb_target.SelectedIndex = 2;
                    else
                        this.cb_target.SelectedIndex = (int)Program.appSetting.tagGroup.target;
                    nb_qvalue.Value = fq.qValue;
                    nb_retry.Value = fq.retryCount;
                    cb_toggle.Checked = (fq.toggleTarget != 0);
                    cb_repeat.Checked = (fq.repeatUntilNoTags != 0);
                }

                this.cb_custInvtryCont.Checked = Program.appSetting.Cfg_continuous_mode;

                this.cb_custInvtryBlocking.Checked = Program.appSetting.Cfg_blocking_mode;

                if (Program.appSetting.FixedChannel)
                {
                    cb_freqlist.SelectedItem = CurrentFreqList[(int)Program.appSetting.Channel_number];
                }

                this.cb_debug_log.Checked = Program.appSetting.Debug_log;

                cbRssiFilterEnable.Checked = Program.appSetting.EnableRssiFilter;

                nbRssiFilter.Value = Program.appSetting.RssiFilterThreshold;
                //Update maximum power
                UpdateMaxPower();

                //Update Frequency list
                UpdateFreqList();

#if nouse
                //get power level
                nb_power.Value = Program.appSetting.Power;
                if (Program.ReaderXP.OEMDeviceType == Machine.CS203)
                {
                    nb_power.Enabled = true;
                    lk_antenna_port_cfg.Enabled = false;
                }
                else
                {
                    nb_power.Enabled = false;
                    lk_antenna_port_cfg.Enabled = true;
                }
#endif

                nb_reconnectTimeout.Value = Program.appSetting.ReconnectTimeout;



                comboBox_MaskBank.SelectedIndex = (int)Program.appSetting.MaskBank;
                textBox_MaskOffset.Text = Program.appSetting.MaskOffset.ToString();
                textBox_MaskLength.Text = Program.appSetting.MaskBitLength.ToString();
                textBox_Mask.Text = Program.appSetting.Mask;
            }

            tabControl1.SelectedIndex = 0;

            AttachCallback(true);

#if ENGINEERING_MODE
            btnRegister.Visible = true;
#else
            btnRegister.Visible = false;
#endif

        }

        private void TagSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
            {
                m_stop = e.Cancel = true;
                Program.ReaderXP.TurnCarrierWaveOff();
            }
            else
            {
                AttachCallback(false);
            }
        }

        private void AttachCallback(bool attach)
        {
            if (attach)
            {
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
            }
            else
            {
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
            }
        }

        void ReaderXP_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case CSLibrary.Constants.RFState.IDLE:
                        if (!m_stop)
                        {
                            UpdateCWBtn(true);
                        }
                        else
                        {
                            this.Close();
                        }
                        break;
                    case CSLibrary.Constants.RFState.BUSY:
                        UpdateCWBtn(false);
                        break;
                }
            });
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateFreqList()
        {
            //Retrieve all available frequency channels
            cb_freqlist.DataSource = CurrentFreqList = Program.ReaderXP.GetAvailableFrequencyTable(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex]);
        }

        private void UpdateMaxPower()
        {
            nb_power.Maximum = Program.ReaderXP.GetActiveMaxPowerLevel((RegionCode)cb_country.SelectedItem);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }

        private void cb_algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_algorithm.SelectedIndex)
            {
                case 0:
                    groupBox_DYNAMICQ.Visible = false;
                    groupBox_FIXEDQ.Visible = true;
                    if (cb_target.SelectedIndex == 2)
                        cb_toggle.Checked = true;
                    else
                        cb_toggle.Checked = false;
                    break;


                case 1:
                    groupBox_FIXEDQ.Visible = false;
                    groupBox_DYNAMICQ.Visible = true;
                    if (cb_target.SelectedIndex == 2)
                        checkBox_Toggle.Checked = true;
                    else
                        checkBox_Toggle.Checked = false;
                    break;

                default:
                    groupBox_DYNAMICQ.Visible = false;
                    groupBox_FIXEDQ.Visible = false;
                    break;
            }

#if nouse
            
            tabControl1.SuspendLayout();

            tabControl1.Controls.Remove(singulation_fixedQ);
            tabControl1.Controls.Remove(singulation_dynamicQ);
            tabControl1.Controls.Remove(singulation_dynamicQAdjust);
            tabControl1.Controls.Remove(singulation_dynamicQThreshold);

#if ENGINEERING_MODE
            tabControl1.Controls.Remove(this.tp_cwonoff);
#endif
            switch (cb_algorithm.SelectedIndex)
            {
                case 0: //Add fixed Q Form
                    //Program.appSetting.Singulation = SingulationAlgorithm.FIXEDQ;
                    singulation_fixedQ = new Singulation_FixedQ
                        (
                            Program.appSetting.SingulationAlg
                        );
                    singulation_fixedQ.Text = "FixedQ";
                    singulation_fixedQ.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_fixedQ);
                    break;
                case 1:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ;
                    singulation_dynamicQ = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ
                        );
                    singulation_dynamicQ.Text = "DynamicQ";
                    singulation_dynamicQ.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQ);
                    break;
                /*case 2:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ_ADJUST;
                    singulation_dynamicQAdjust = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ_ADJUST
                        );
                    singulation_dynamicQAdjust.Text = "DynamicQAdj";
                    singulation_dynamicQAdjust.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQAdjust);
                    break;
                case 3:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ_THRESH;
                    singulation_dynamicQThreshold = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ_THRESH
                        );
                    singulation_dynamicQThreshold.Text = "DynamicQThres";
                    singulation_dynamicQThreshold.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQThreshold);
                    break;*/
            }

#if ENGINEERING_MODE
            tabControl1.Controls.Add(this.tp_cwonoff);
#endif
            tabControl1.ResumeLayout();

//            tabControl1.SelectedIndex = 3;
#endif
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Text = "Applying configuration : Please wait...";
            this.Enabled = false;
            //Start to apply all settings

            try
            {
                UInt16 ms = UInt16.Parse(textBox1.Text);

                Program.ReaderXP.SetTxOnTime(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not set Tx On Time");
            }
            
            //Set PowerLevel
            Result res = Result.OK;

            if ((cb_custInvtryBlocking.Checked && cb_custInvtryCont.Checked))
            {
                if (MessageBox.Show("Please don't run in blocking and continuous mode in the same time, otherwise you can't abort the operation", "warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                }
                else
                {
                    goto ERROR;
                }
            }

#if nouse
            if (nb_power.Enabled == true)
            if ((res = Program.ReaderXP.SetPowerLevel((uint)nb_power.Value)) != Result.OK)
            {
                ts_status.Text = string.Format("SetPowerLevel fail with err {0}", res);
                goto ERROR;
            }
#endif

            //Set LinkProfile
            if ((res = Program.ReaderXP.SetCurrentLinkProfile(uint.Parse(cb_linkprofile.Text))) != Result.OK)
            {
                ts_status.Text = string.Format("SetCurrentLinkProfile fail with err {0}", res);
                goto ERROR;
            }

            //Set Region and Frequency
            if (cb_fixed.Checked)
            {
                if (!checkBoxFreqAgile.Checked)
                {
                    //if (freq.ListItems.SelectedIndices.Count == 0 || freq.ListItems.SelectedIndices[0] < 0 || freq.ListItems.SelectedIndices[0] >= freq.ListItems.Items.Count)
                    if (cb_freqlist.SelectedIndex < 0 || cb_freqlist.SelectedIndex >= cb_freqlist.Items.Count)
                    {
                        ts_status.Text = "Please select a channel first";
                        goto ERROR;
                    }
                    //if ((res = Program.ReaderXP.SetFixedChannel(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex], (uint)freq.ListItems.SelectedIndices[0], cb_lbt.Checked ? LBT.ON : LBT.OFF)) != CSLibrary.Constants.Result.OK)
                    if ((res = Program.ReaderXP.SetFixedChannel(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex], (uint)cb_freqlist.SelectedIndex, cb_lbt.Checked ? LBT.SCAN : LBT.OFF)) != CSLibrary.Constants.Result.OK)
                    {
                        ts_status.Text = string.Format("SetFixedChannel fail with err {0}", res);
                        goto ERROR;
                    }
                }
                else
                {
                    res = Program.ReaderXP.SetAgileChannels(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex]);
                    if (res != CSLibrary.Constants.Result.OK)
                    {
                        ts_status.Text = string.Format("SetAgileChannel fail with err {0}", res);
                        goto ERROR;
                    }
                }
            }
            else
            {
                if ((res = Program.ReaderXP.SetHoppingChannels(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex])) != CSLibrary.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetHoppingChannels fail with err {0}", res);
                    goto ERROR;
                }
            }

            {

                Program.appSetting.Cfg_blocking_mode = cb_custInvtryBlocking.Checked;

                //Program.appSetting.Singulation = (SingulationAlgorithm)cb_algorithm.
                switch (cb_algorithm.SelectedIndex)
                {
                    case 0:
                        Program.appSetting.Singulation = SingulationAlgorithm.FIXEDQ;
                        break;

                    default:
                        Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ;
                        break;
                }

                Program.appSetting.Cfg_continuous_mode = cb_custInvtryCont.Checked;

                Program.appSetting.FixedChannel = cb_fixed.Checked;

#if nouse
                Program.appSetting.tagGroup = new TagGroup
                                            (
                                                (Selected)cb_selected.SelectedItem,
                                                (Session)cb_session.SelectedItem,
                                                (SessionTarget)cb_target.SelectedItem
                                            );
#endif
                Program.appSetting.tagGroup = new TagGroup
                                            (
                                                ((cb_selected.SelectedIndex == 1) ? Selected.ASSERTED : (cb_selected.SelectedIndex == 2) ? Selected.DEASSERTED : Selected.ALL),
                                                (Session)cb_session.SelectedIndex,
                                                (cb_target.SelectedIndex == 2) ?  SessionTarget.A : (SessionTarget)cb_target.SelectedIndex
                                            );

                switch (Program.appSetting.Singulation)
                {
                    case SingulationAlgorithm.DYNAMICQ:
                        DynamicQParms dynQ = new DynamicQParms();
                        dynQ.startQValue = (uint)nb_startqvalue.Value;
                        dynQ.minQValue = (uint)nb_minqvalue.Value;
                        dynQ.maxQValue = (uint)nb_maxqvalue.Value;
                        dynQ.retryCount = (uint)numericUpDown_Retry.Value;
                        dynQ.toggleTarget = (checkBox_Toggle.Checked) ? 1U : 0U;
                        dynQ.thresholdMultiplier = (uint)nb_thresholdMultiplier.Value;
                        Program.appSetting.SingulationAlg = dynQ;
                        break;
                    /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                        Program.appSetting.SingulationAlg = singulation_dynamicQAdjust.DynamicQAdjust;
                        break;
                    case SingulationAlgorithm.DYNAMICQ_THRESH:
                        Program.appSetting.SingulationAlg = singulation_dynamicQThreshold.DynamicQThreshold;
                        break;*/
                    case SingulationAlgorithm.FIXEDQ:
                        FixedQParms m_fixedQ = new FixedQParms();
                        m_fixedQ.qValue = (uint)nb_qvalue.Value;
                        m_fixedQ.retryCount = (uint)nb_retry.Value;
                        m_fixedQ.toggleTarget = cb_toggle.Checked ? 1U : 0U;
                        m_fixedQ.repeatUntilNoTags = cb_repeat.Checked ? 1U : 0U;
                        Program.appSetting.SingulationAlg = m_fixedQ;
                        break;
                }




#if nouse
                switch (Program.appSetting.Singulation)
                {
                    case SingulationAlgorithm.DYNAMICQ:
                        Program.appSetting.SingulationAlg = singulation_dynamicQ.DynamicQ;
                        break;
                    /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                        Program.appSetting.SingulationAlg = singulation_dynamicQAdjust.DynamicQAdjust;
                        break;
                    case SingulationAlgorithm.DYNAMICQ_THRESH:
                        Program.appSetting.SingulationAlg = singulation_dynamicQThreshold.DynamicQThreshold;
                        break;*/
                    case SingulationAlgorithm.FIXEDQ:
                        Program.appSetting.SingulationAlg = singulation_fixedQ.FixedQ;
                        break;
                }

#endif        
            }
            Program.appSetting.Lbt = cb_lbt.Checked;
            Program.appSetting.FreqAgile = checkBoxFreqAgile.Checked;
            //CSLibrary.Diagnostics.CoreDebug.Enable = Program.appSetting.Debug_log = this.cb_debug_log.Checked;
#if NET_BUILD
            Program.ReaderXP.ReconnectTimeout = Program.appSetting.ReconnectTimeout = (uint)this.nb_reconnectTimeout.Value;
#endif
            Program.appSetting.EnableRssiFilter = cbRssiFilterEnable.Checked;
            Program.appSetting.RssiFilterThreshold = (uint)nbRssiFilter.Value;

            Program.appSetting.MaskBank = (uint)comboBox_MaskBank.SelectedIndex;
            Program.appSetting.MaskOffset = (uint.Parse)(textBox_MaskOffset.Text);
            Program.appSetting.MaskBitLength = (uint.Parse)(textBox_MaskLength.Text);
            Program.appSetting.Mask = textBox_Mask.Text;

            //#region === Antenna Port setting ===
            //
            //Program.ReaderXP.AntennaList.Store(Program.ReaderXP);
            //
            //#endregion === Antenna Port setting ===


            #region === Antenna Sequence setting ===

            Program.appSetting.AntennaSequenceMode = Program.ReaderXP.AntennaSequenceMode;
            Program.appSetting.AntennaSequenceSize = Program.ReaderXP.AntennaSequenceSize;
            Program.appSetting.AntennaPortSequence = Program.ReaderXP.AntennaPortSequence;

            if (Program.ReaderXP.SetOperationMode(
                Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS,
                Program.appSetting.AntennaSequenceMode,
                (int)Program.appSetting.AntennaSequenceSize
                ) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show("SetOperationMode failed");
            }

            if ((Program.ReaderXP.AntennaSequenceMode & AntennaSequenceMode.SEQUENCE) != 0)
            {
                byte[] seq = new byte[Program.appSetting.AntennaPortSequence.Length];
                for (int i = 0; i < Program.appSetting.AntennaSequenceSize; i++)
                {
                    seq[i] = (byte)Program.appSetting.AntennaPortSequence[i];
                    //MessageBox.Show(Program.appSetting.AntennaPortSequence[i].ToString());
                }

                if (Program.ReaderXP.SetAntennaSequence(seq, (uint)Program.appSetting.AntennaSequenceSize, Program.appSetting.AntennaSequenceMode) != CSLibrary.Constants.Result.OK)
                {
                    MessageBox.Show("SetAntennaSequence failed");
                }
            }

            #endregion === Antenna Sequence setting ===








            //Save all settings to config file
            if (cb_save.Checked)
            {
                Program.SaveSettings();
            }

            ts_status.Text = string.Format("Apply Configuration Successful");

            this.Enabled = true;

            this.DialogResult = DialogResult.OK;

            Text = "Apply Configuration Successful";

            return;

        ERROR:
            //ts_status.Text = string.Format("Apply Configuration failed");

            this.Enabled = true;

            //this.DialogResult = DialogResult.Cancel;

            Text = "Apply Configuration failed";
        }

        private void cb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFreqList();
            UpdateMaxPower();
        }

        private void cb_fixed_CheckedChanged(object sender, EventArgs e)
        {
            cb_freqlist.Enabled = cb_fixed.Checked;
        }
        /// <summary>
        /// Same as full framework Enum.GetValues
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private object[] EnumGetValues(Type enumType)
        {
            if (enumType.BaseType ==
                typeof(Enum))
            {
                //get the public static fields (members of the enum)  
                FieldInfo[] fi = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
                //create a new enum array  
                object[] values = new object[fi.Length];
                //populate with the values  
                for (int iEnum = 0; iEnum < fi.Length; iEnum++)
                {
                    values[iEnum] = fi[iEnum].GetValue(null);
                }
                //return the array  
                return values;
            }

            //the type supplied does not derive from enum  
            throw new ArgumentException("enumType parameter is not a System.Enum");

        }

        private void btn_cwon_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.TurnCarrierWaveOn(cb_withData.Checked);
        }

        private void btn_cwoff_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.TurnCarrierWaveOff();
        }

        private void UpdateCWBtn(bool en)
        {
            cb_withData.Enabled = btn_cwon.Enabled = en;
            btn_cwoff.Enabled = !en;
        }

        private void lk_antenna_port_cfg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //using (AntennaPortCfgForm ant = new AntennaPortCfgForm())
            using (ConfigureAntenna ant = new ConfigureAntenna())
            {
                ant.ShowDialog();
            }
        }

        private void lb_detail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (LinkProfileInformation info = new LinkProfileInformation(uint.Parse(cb_linkprofile.Text)))
            {
                info.ShowDialog();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
#if ENGINEERING_MODE
            new ReadRegisterForm().ShowDialog();
#endif
        }

        private void lbOperationConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
#if NCS468
            using (ConfigureOperation op = new ConfigureOperation())
            {
                op.ShowDialog();
            }
#endif
        }

        private void checkBoxFreqAgile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFreqAgile.Checked)
            {
                cb_fixed.Checked = true;
                cb_freqlist.Enabled = false;
            }
            else if (cb_fixed.Checked == true)
                cb_freqlist.Enabled = true;
            else
                cb_freqlist.Enabled = false;
        }

        private void tp_gerenal_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cb_selected_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_selected.SelectedIndex)
            {
                case 0:
                    groupBox_Mask.Visible = false;
                    break;

                case 1:
                    groupBox_Mask.Text = "Asserted Mask";
                    groupBox_Mask.Visible = true;
                    break;

                case 2:
                    groupBox_Mask.Text = "Deasserted Mask";
                    groupBox_Mask.Visible = true;
                    break;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cb_target_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_target.SelectedIndex == 2) // Toggle A/B
            {
                if (cb_algorithm.SelectedIndex == 0) // Fixed Q
                {
                    cb_toggle.Checked = true;
                }
                else
                {
                    checkBox_Toggle.Checked = true;
                }
            }
            else
            {
                if (cb_algorithm.SelectedIndex == 0) // Fixed Q
                {
                    cb_toggle.Checked = false;
                }
                else
                {
                    checkBox_Toggle.Checked = false;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}