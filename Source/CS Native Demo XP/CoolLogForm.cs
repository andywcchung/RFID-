using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_CALLBACK_API_DEMO
{

    public partial class CoolLogForm : Form
    {
        #region Public and Private Member
        public string TargetEPC = "";
        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
//                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
            }
            else
            {
//                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnCompleted);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_MyRunningStateEvent);
            }
        }

        void ReaderXP_MyRunningStateEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
/*
 * this.BeginInvoke((System.Threading.ThreadStart)delegate()
               {
                   switch (e.state)
                   {
                       case RFState.IDLE:
                           break;
                       case RFState.BUSY:
                           break;
                       case RFState.RESET:
                           break;
                       case RFState.ABORT:
                           //ControlPanelForm.EnablePannel(false);
                           break;
                   }
               });
*/
        }

        void ReaderXP_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {

//  if (e.access == TagAccess.LOCK)
                {
                    //                    resultForm1.UpdateResult(e.success);
                }
            });
        }

        #endregion

        public CoolLogForm()
        {
            InitializeComponent();
        }

        private void lk_epc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Stop current process
    //        if (Program.ReaderXP.State != RFState.IDLE)
            {
     //           return;
            }

            AttachCallback(false);
            using (TagSearchForm InvForm = new TagSearchForm())
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    lk_epc.Text = TargetEPC = InvForm.epc;
                }
            }
            AttachCallback(true);
        }

        private void buttonSetLogMode_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt16 value = 0;

            if (Program.ReaderXP.State != RFState.IDLE)
                Program.ReaderXP.StopOperation(true);

            try
            {
                value = UInt16.Parse(textBoxLogInterval.Text);
            }
            catch (Exception)
            {
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetLogMode.LoggingForm = (LoggingForm)comboBoxLogForm.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.StorageRule = (StorageRule)comboBoxStorageRule.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.Ext1SensorEnable = (EnableSwitch)comboBoxExt1Sensor.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.Ext2SensorEnable = (EnableSwitch)comboBoxExt2Sensor.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.TempSensorEnable = (EnableSwitch)comboBoxTempSensor.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.BatteryCheckEnable = (EnableSwitch)comboBoxBatteryCheck.SelectedIndex;
            Program.ReaderXP.Options.CLSetLogMode.LogInterval = value;
            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_LOG_MODE, true);

            textBoxSetLogModeResult.Text = ret.ToString();
        }

        private void buttonSetLogLimits_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt16 value1 = 0;
            UInt16 value2 = 0;
            UInt16 value3 = 0;
            UInt16 value4 = 0;

            try
            {
                value1 |= UInt16.Parse(textBoxUpperLimit.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                value2 |= UInt16.Parse(textBoxLowerLimit.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                value3 |= UInt16.Parse(textBoxExtUpperLimit.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                value4 |= UInt16.Parse(textBoxExtLowerLimit.Text);
            }
            catch (Exception)
            {
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetLogLimits.UpperLimit = value1;
            Program.ReaderXP.Options.CLSetLogLimits.LowerLimit = value2;
            Program.ReaderXP.Options.CLSetLogLimits.ExtUpperLimit = value3;
            Program.ReaderXP.Options.CLSetLogLimits.ExtLowerLimit = value4;
            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_LOG_LIMITS, true);

            textBoxSetLogLimitsResult.Text = ret.ToString();
        }

        private void buttongetMeasurementSetup_Click(object sender, EventArgs e)
        {
            Result ret;
            byte [] ResponseData = new byte [20];

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            ret = Program.ReaderXP.StartOperation(Operation.CL_GET_MEASUREMENT_SETUP, true);
            textBoxGetMeasurementSetupResult.Text = ret.ToString();
            
            if (ret == Result.OK)
            {
                textBoxStartTimeSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.StartTime.ToString ();
                textBoxExtLowerLimitSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.ExtLowerLimit.ToString ();
                textBoxLowerLimitSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.LowerLimit.ToString ();
                textBoxUpperLimitSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.UpperLimit.ToString ();
                textBox1ExtUpperLimitSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.ExtUpperLimit.ToString ();
                textBox1LogginFormSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.LoggingForm.ToString ();
                textBoxStorageRuleSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.StorageRule.ToString ();
                textBoxExt1SensorEnableSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.Ext1SensorEnable.ToString ();
                textBoxExt2SensorEnableSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.Ext2SensorEnable.ToString ();
                textBoxTempSensorEnableSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.TempSensorEnable.ToString ();
                textBoxBatteryCheckEnableSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.BatteryCheckEnable.ToString ();
                textBoxLogIntervalSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.LogInterval.ToString ();
                textBoxDelayTimeSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.DelayTime.ToString ();
                textBoxDelayModeSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.DelayMode.ToString ();
                textBoxTimerEnableSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.TimerEnable.ToString ();
                textBoxNumberOfWordsForApplicationDataSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.NumberOfWorldForAppData.ToString ();
                textBoxBrokeWordPointerSetup.Text = Program.ReaderXP.Options.CLGetMesurementSetup.BrokeWordPointer.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result ret;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            try
            {
                Program.ReaderXP.Options.CLStartLog.Year = byte.Parse(textBoxYear.Text);
                Program.ReaderXP.Options.CLStartLog.Month = byte.Parse(textBoxMonth.Text);
                Program.ReaderXP.Options.CLStartLog.Day = byte.Parse(textBoxDay.Text);
                Program.ReaderXP.Options.CLStartLog.Hour = byte.Parse(textBoxHour.Text);
                Program.ReaderXP.Options.CLStartLog.Minute = byte.Parse(textBoxMinute.Text);
                Program.ReaderXP.Options.CLStartLog.Second = byte.Parse(textBoxSecond.Text);
            }
            catch (Exception)
            {
            }

            ret = Program.ReaderXP.StartOperation(Operation.CL_START_LOG, true);

            textBoxStartLogResult.Text = ret.ToString();
        }

        private void CoolLogForm_Load(object sender, EventArgs e)
        {
            comboBoxPasswordLevel.DataSource = Enum.GetValues(typeof(PasswordLevel));          
            comboBoxPasswordLevel.SelectedIndex = 0;
            textBoxPassword.Text = "00000000";

            comboBoxLogForm.DataSource = Enum.GetValues(typeof(LoggingForm));
            comboBoxLogForm.SelectedIndex = 0;
            comboBoxStorageRule.DataSource = Enum.GetValues(typeof(StorageRule));
            comboBoxStorageRule.SelectedIndex = 0;
            comboBoxExt1Sensor.SelectedIndex = 0;
            comboBoxExt2Sensor.SelectedIndex = 0;
            comboBoxTempSensor.SelectedIndex = 0;
            comboBoxBatteryCheck.DataSource = Enum.GetValues(typeof(EnableSwitch));
            comboBoxBatteryCheck.SelectedIndex = 0;
            textBoxLogInterval.Text = "0";

            textBoxLowerLimit.Text = "0";
            textBoxUpperLimit.Text = "0";
            textBoxExtLowerLimit.Text = "0";
            textBoxExtUpperLimit.Text = "0";

            comboBox3.DataSource = Enum.GetValues(typeof(FeedbackResistor));
            textBoxSeti.Text = "0";
            comboBoxExt1.DataSource = Enum.GetValues(typeof(Ext1SensorType));
            comboBoxExt1.SelectedIndex = 0;
            comboBoxExt2.DataSource = Enum.GetValues(typeof(Ext2SensorType));
            comboBoxExt2.SelectedIndex = 0;
            comboBoxAutoRangeDisable.DataSource = Enum.GetValues(typeof(EnableSwitch));
            comboBoxAutoRangeDisable.SelectedIndex = 0;
            comboBoxVerifySensorID.SelectedIndex = 0;

            textBoxCalData.Text = "00000000000000";

            textBoxTmax.Text = "0";
            textBoxTmin.Text = "0";
            textBoxTstd.Text = "0";
            textBoxEa.Text = "0";
            textBoxSLInit.Text = "0";
            textBoxTinit.Text = "0";
            comboBoxshelfLifeSensorID.SelectedIndex = 0;
            comboBoxEnableNegativeLife.SelectedIndex = 0;
            comboBoxShelfAlgorithmEnable.SelectedIndex = 0;

            textBoxYear.Text = "0";
            textBoxMonth.Text = "0";
            textBoxDay.Text = "0";
            textBoxHour.Text = "0";
            textBoxMinute.Text = "0";
            textBoxSecond.Text = "0";

            comboBoxBatteryRetrigger.SelectedIndex = 0;

            comboBox1.DataSource = Enum.GetValues(typeof(Sensor));
            comboBox1.SelectedIndex = 0;

            textBoxDelayTime.Text = "0";
            comboBoxDelayMode.SelectedIndex = 0;
            comboBoxTimerEnable.DataSource = Enum.GetValues(typeof(EnableSwitch));
            comboBoxTimerEnable.SelectedIndex = 0;
            textBoxAppDataLen.Text = "0";
            textBoxBWP.Text = "0";

            comboBox2.DataSource = Enum.GetValues(typeof(CSLibrary.Structures.PasswordLevel));
            comboBox2.SelectedIndex = 0;

            comboBox9.DataSource = Enum.GetValues(typeof(FIFOSubcommand));
            comboBox9.SelectedIndex = 0;
            textBox65.Text = "0000000000000000";

        }

        private void buttonSetPassword_Click(object sender, EventArgs e)
        {
            Result ret;
            uint value = 0;

            if (Program.ReaderXP.State != RFState.IDLE)
                Program.ReaderXP.StopOperation(true);
            
            if (textBoxPassword.Text.Length != 8)
            {
                textBoxPassword.Focus ();
                textBoxResult.Text = "Password length incorrect";
                return;
            }

            textBoxResult.Text = "Processing";

            try
            {
                value = uint.Parse(textBoxPassword.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch (Exception)
            {
                textBoxPassword.Focus();
                textBoxResult.Text = "Password not is HEX digital";
                return;
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            //Enum.Parse(typeof(PasswordLevel), s);

            Program.ReaderXP.Options.CLSetPassword.PasswordLevel = (PasswordLevel)comboBoxPasswordLevel.SelectedIndex;
            Program.ReaderXP.Options.CLSetPassword.Password = value;

            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_PASSWORD, true);

            textBoxResult.Text = ret.ToString();
        }

        private void buttonSetSFEPara_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt16 value = 0;

            try
            {
                value |= (UInt16)((UInt32)comboBox3.SelectedValue << 11);
                value |= (UInt16)((UInt16.Parse(textBoxSeti.Text)) << 6);
                value |= (UInt16)(comboBoxExt1.SelectedIndex << 4);
                value |= (UInt16)(comboBoxExt2.SelectedIndex << 3);
                value |= (UInt16)(comboBoxAutoRangeDisable.SelectedIndex << 2);
                value |= (UInt16)(comboBoxVerifySensorID.SelectedIndex);
            }
            catch (Exception)
            {
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetSFEPara.SFEParameters = value;
            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_SFE_PARA, true);

            textBoxSetSFEParaResult.Text = ret.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt64 value = 0;

            if (Program.ReaderXP.State == RFState.BUSY)
                Program.ReaderXP.StopOperation(true);

            if (textBoxCalData.Text.Length != 14)
            {
                textBoxCalData.Focus();
                textBoxSetCalDataResult.Text = "Password length incorrect";
                return;
            }

            textBoxSetCalDataResult.Text = "Processing";

            try
            {
                value = UInt64.Parse(textBoxCalData.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch (Exception)
            {
                textBoxCalData.Focus();
                textBoxSetCalDataResult.Text = "Password not is HEX digital";
                return;
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetCalData.CalibrationData = value;
            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_CAL_DATA, true);

            textBoxSetCalDataResult.Text = ret.ToString();
        }

        private void buttonEndLog_Click(object sender, EventArgs e)
        {
            Result ret;

            if (Program.ReaderXP.State == RFState.BUSY)
                Program.ReaderXP.StopOperation(true);

            textBoxEndLogResult.Text = "Processing";

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            ret = Program.ReaderXP.StartOperation(Operation.CL_END_LOG, true);

            textBoxEndLogResult.Text = ret.ToString();
        }

        private void buttonSetShelfLife_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt32 value0 = 0;
            UInt32 value1 = 0;

            if (Program.ReaderXP.State == RFState.BUSY)
                Program.ReaderXP.StopOperation(true);

            textBoxSetShelfLife.Text = "Processing";

            try
            {
                value0 |= (UInt32)(byte.Parse (textBoxTmax.Text.ToString()) << 24);
                value0 |= (UInt32)(byte.Parse (textBoxTmin.Text)) << 16;
                value0 |= (UInt32)(byte.Parse (textBoxTstd.Text)) << 8;
                value0 |= (UInt32)(byte.Parse (textBoxEa.Text));

                value1 |= (UInt32)(UInt16.Parse (textBoxSLInit.Text.ToString()) << 16);
                value1 |= (UInt32)(UInt16.Parse (textBoxTmin.Text)) << 6;
                value1 |= (UInt32)(comboBoxshelfLifeSensorID.SelectedIndex) << 4;
                value1 |= (UInt32)(comboBoxEnableNegativeLife.SelectedIndex) << 3;
                value1 |= (UInt32)(comboBoxShelfAlgorithmEnable.SelectedIndex) << 2;
            }
            catch (Exception)
            {
                textBoxCalData.Focus();
                textBoxSetCalDataResult.Text = "Password not is HEX digital";
                return;
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetShelfLife.SLBlock0 = value0;
            Program.ReaderXP.Options.CLSetShelfLife.SLBlock1 = value1;
            ret = Program.ReaderXP.StartOperation(Operation.CL_SET_SHELF_LIFE, true);

            textBoxSetShelfLife.Text = ret.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt16 value0 = 0;
            UInt16 value1 = 0;

            if (Program.ReaderXP.State == RFState.BUSY)
                Program.ReaderXP.StopOperation(true);

            textBoxInitResult.Text = "Processing";

            try
            {
                Program.ReaderXP.Options.CLInit.DelayTime = UInt16.Parse(textBoxDelayTime.Text);
                Program.ReaderXP.Options.CLInit.DelayMode = (byte)comboBoxDelayMode.SelectedIndex;
                Program.ReaderXP.Options.CLInit.TimerEnable = (EnableSwitch)comboBoxTimerEnable.SelectedIndex;
                Program.ReaderXP.Options.CLInit.NumberOfWordsForApplicationData = UInt16.Parse (textBoxAppDataLen.Text);
                Program.ReaderXP.Options.CLInit.BrokenWordPointer = byte.Parse (textBoxBWP.Text);
            }
            catch (Exception)
            {
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            ret = Program.ReaderXP.StartOperation(Operation.CL_INIT, true);

            textBoxInitResult.Text = ret.ToString();
        }

        private void textBoxTempSensorEnableSetup_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTimerEnableSetup_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Result ret;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            ret = Program.ReaderXP.StartOperation(Operation.CL_GET_CAL_DATA, true);

            textBoxGetCalDataResult.Text = ret.ToString();

            if (ret == Result.OK)
            {
                textBoxCalnSFEData.Text = "";
                for (int a = 0; a < 9; a++)
                {
                    textBoxCalnSFEData.Text += Program.ReaderXP.Options.CLGetCalData.CalData[a].ToString ("X02");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result ret;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            
            Program.ReaderXP.Options.CLGetBatLv.Retrigger = (byte)comboBoxBatteryRetrigger.SelectedIndex;
            ret = Program.ReaderXP.StartOperation(Operation.CL_GET_BAT_LV, true);

            textBox2.Text = ret.ToString();

            if (ret == Result.OK)
            {
                textBoxADError.Text = Program.ReaderXP.Options.CLGetBatLv.ADError.ToString ();
                textBoxBatteryType.Text = Program.ReaderXP.Options.CLGetBatLv.BatteryType.ToString ();
                textBoxBatteryLevel.Text = Program.ReaderXP.Options.CLGetBatLv.BatteryLevel.ToString ();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Result ret;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);


            Program.ReaderXP.Options.CLGetSensorValue.SensorType = (Sensor)comboBox1.SelectedValue;
            ret = Program.ReaderXP.StartOperation(Operation.CL_GET_SENSOR_VALUE, true);

            textBox6.Text = ret.ToString();

            if (ret == Result.OK)
            {
                textBox3.Text = Program.ReaderXP.Options.CLGetSensorValue.ADError.ToString();
                textBox4.Text = Program.ReaderXP.Options.CLGetSensorValue.RangeLimit.ToString();
                textBox5.Text = Program.ReaderXP.Options.CLGetSensorValue.SensorValue.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Result ret;

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            Program.ReaderXP.Options.CLGetLogState.ShelfLifeFlag = EnableSwitch.Disable;
            ret = Program.ReaderXP.StartOperation(Operation.CL_GET_LOG_STATE, true);

            textBox7.Text = ret.ToString();

            if (ret == Result.OK)
            {
                textBox43.Text = (Program.ReaderXP.Options.CLGetLogState.LogStateData[7] >> 1).ToString ();
                //textBox3.Text = Program.ReaderXP.Options.CLGetSensorValue.ADError.ToString();
                //textBox4.Text = Program.ReaderXP.Options.CLGetSensorValue.RangeLimit.ToString();
                //textBox5.Text = Program.ReaderXP.Options.CLGetSensorValue.SensorValue.ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Result ret;
            uint value = 0;

            if (Program.ReaderXP.State != RFState.IDLE)
                Program.ReaderXP.StopOperation(true);

            if (textBox9.Text.Length != 8)
            {
                textBox9.Focus();
                textBox8.Text = "Password length incorrect";
                return;
            }

            textBox8.Text = "Processing";

            try
            {
                value = uint.Parse(textBox9.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch (Exception)
            {
                textBoxPassword.Focus();
                textBox8.Text = "Password not is HEX digital";
                return;
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLSetPassword.PasswordLevel = (PasswordLevel)comboBox2.SelectedValue;
            Program.ReaderXP.Options.CLSetPassword.Password = value;

            ret = Program.ReaderXP.StartOperation(Operation.CL_OPEN_AREA, true);

            textBox8.Text = ret.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Result ret;
            UInt64 value;

            if (Program.ReaderXP.State != RFState.IDLE)
                Program.ReaderXP.StopOperation(true);

            if (textBox65.Text.Length != 16)
            {
                textBox65.Focus();
                textBox10.Text = "Password length incorrect";
                return;
            }

            textBox10.Text = "Processing";

            try
            {
                value = ulong.Parse(textBox65.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch (Exception)
            {
                textBox65.Focus();
                textBox10.Text = "Password not is HEX digital";
                return;
            }

            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);

            ret = Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);
            if (ret != Result.OK)
            {
                MessageBox.Show("Selected tag failed");
                return;
            }

            Program.ReaderXP.Options.CLAccessFifo.Subcommand = (FIFOSubcommand)comboBox9.SelectedValue;
            Program.ReaderXP.Options.CLAccessFifo.PayloadLen = 1;
            Program.ReaderXP.Options.CLAccessFifo.Payload = value;

            ret = Program.ReaderXP.StartOperation(Operation.CL_ACCESS_FIFO, true);

            textBox10.Text = ret.ToString();

            if (ret == Result.OK)
                textBox11.Text = Program.ReaderXP.Options.CLAccessFifo.PayloadInReg.ToString("X16");
            else
                textBox11.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxYear.Text = (DateTime.Now.Year - 2010).ToString ();
            textBoxMonth.Text = DateTime.Now.Month.ToString();
            textBoxDay.Text = DateTime.Now.Day.ToString();
            textBoxHour.Text = DateTime.Now.Day.ToString();
            textBoxMinute.Text = DateTime.Now.Minute.ToString();
            textBoxSecond.Text = DateTime.Now.Second.ToString();
        }
    }
}
