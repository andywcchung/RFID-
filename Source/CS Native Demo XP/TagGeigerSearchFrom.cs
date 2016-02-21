using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Text;

    public partial class GeigerSearchForm : Form
    {
        #region Private Member
#if CS101
        private RingTone[] RingMelody = new RingTone[4]
            {
                RingTone.T1,
                RingTone.T1,
                RingTone.T3,
                RingTone.T5,
            };
#endif
        private int[] ThresholdArr = new int[] { 0, 50, 65, 70};
        private int rssi = 0;
        private bool bTone = true;
        private string TargetEPC = "";
        private bool m_stop = false;

        #endregion

        #region Form
        public GeigerSearchForm()
        {
            InitializeComponent();
        }
        private void GeigerSearchForm_Load(object sender, EventArgs e)
        {
            lb_threshold.Text = tk_threshold.Value.ToString();
            tb_epc.Text = TargetEPC;
            AttachCallback(true);
        }

        private void GeigerSearchForm_Closing(object sender, CancelEventArgs e)
        {
            tmr_tone.Enabled = tmr_ZeroDetector.Enabled = false;
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                e.Cancel = m_stop = true;
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }
        #endregion

        #region Button Handle

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
                return;
            }

            Start();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stop()
        {
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                Program.ReaderXP.StopOperation(true);
            }
        }

        private void Start()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(tb_epc.Text);
                Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(tb_epc.Text);

                Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

                Program.ReaderXP.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderXP.Options.TagSearchOne.avgRssi = cb_averaging.Checked;
                Program.ReaderXP.StartOperation(Operation.TAG_SEARCHING, false);
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            //Stop current operation
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
            }
            while (Program.ReaderXP.State != RFState.IDLE)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }

            AttachCallback(false);

            using (TagSearchForm inv = new TagSearchForm())
            {
                if (inv.ShowDialog() == DialogResult.OK)
                {
                    TargetEPC = tb_epc.Text = inv.epc;
                }
            }
            AttachCallback(true);
        }

        #endregion

        #region Timer Handle

        void StopOORDetectTmr()
        {
            tmr_ZeroDetector.Enabled = false;
        }

        private void tmr_ZeroDetector_Tick(object sender, EventArgs e)
        {
            StopOORDetectTmr();
            UpdateRssiLb(String.Empty);
            UpdateProgressValue(0);
            tmr_tone.Enabled = false;
        }
        private void tmr_tone_Tick(object sender, EventArgs e)
        {
            if (bTone)
            {
                if (rssi > ThresholdArr[3])
                {
#if CS101
                    Device.MelodyPlay(RingMelody[3], BUZZER_SOUND.HIGH);
#else
                    Console.Beep((int)523.2, 300);
#endif
                }
                else if (rssi <= ThresholdArr[3] && rssi > ThresholdArr[2])
                {
#if CS101
                    Device.MelodyPlay(RingMelody[2], BUZZER_SOUND.HIGH);
#else
                    Console.Beep((int)523.2, 300);
#endif
                }
                else if (rssi <= ThresholdArr[2] && rssi > ThresholdArr[1])
                {
#if CS101
                    Device.MelodyPlay(RingMelody[1], BUZZER_SOUND.HIGH);
#else
                    Console.Beep((int)523.2, 300);
#endif
                }
                else if (rssi <= ThresholdArr[1])
                {
#if CS101
                    Device.MelodyPlay(RingMelody[0], BUZZER_SOUND.HIGH);
#else
                    Console.Beep((int)523.2, 300);
#endif
                }
            }
        }

        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagSearchOneEvent);
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagSearchOneEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
        }

        void ReaderXP_TagSearchOneEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.type)
                {
                    case CallbackType.TAG_SEARCHING:
                        rssi = (int)((TagCallbackInfo)e.info).rssi;

                        UpdateRssiLb(rssi.ToString());
                        //lb_rssi.Text = rssi.ToString();

                        UpdateProgressValue(rssi);

                        //Tone
                        EnToneTmr(true);

                        if (rssi < 0)
                            UpdateRssiLb(String.Empty);
                        else
                            RestartOORDetectTmr();
                        break;
                }
            });
        }

        void ReaderXP_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.Invoke((System.Threading.ThreadStart)delegate()
            {
                switch (e.state)
                {
                    case RFState.IDLE:
                        if (!m_stop)
                        {
                            //Device.MelodyPlay(RingTone.T1, BUZZER_SOUND.HIGH);
                            UpdateStartButton(true);
                            EnableForm(true);
                        }
                        else
                        {
                            CloseForm();
                        }
                        break;
                    case RFState.BUSY:
                        //Device.MelodyPlay(RingTone.T2, BUZZER_SOUND.HIGH);
                        UpdateStartButton(false);
                        break;
                    case RFState.ABORT:
                        EnableForm(false);
                        break;
                }
            });
        }

        #endregion

        #region Delegate
        private delegate void UpdateStartButtonDeleg(bool start);
        private void UpdateStartButton(bool start)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStartButtonDeleg(UpdateStartButton), new object[] { start });
                return;
            }
            if (start)
            {
                btn_start.Text = "Start";
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.ForeColor = Color.Black;
                cb_averaging.Enabled = true;
                tmr_tone.Enabled = false;
                tmr_ZeroDetector.Enabled = false;
            }
            else
            {
                btn_start.Text = "Stop";
                btn_start.BackColor = Color.Red;
                btn_start.ForeColor = Color.White;
                cb_averaging.Enabled = false;
                tmr_tone.Enabled = true;
                tmr_ZeroDetector.Enabled = true;
            }
        }
        private delegate void RestartOORDetectTmrDeleg();
        void RestartOORDetectTmr()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RestartOORDetectTmrDeleg(RestartOORDetectTmr), new object[] { });
                return;
            }
            tmr_ZeroDetector.Enabled = false;
            tmr_ZeroDetector.Enabled = true; // OK?
        }
        private delegate void ShowMsgDeleg(string msg);
        private void ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowMsgDeleg(ShowMsg), new object[] { msg });
                return;
            }
            MessageBox.Show(msg);
        }
        private delegate void EnToneTmrDeleg(bool en);
        private void EnToneTmr(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnToneTmrDeleg(EnToneTmr), new object[] { en });
                return;
            }
            if (tmr_tone.Enabled != en)
                tmr_tone.Enabled = en;
        }
        private delegate void UpdateRssiLbDeleg(string msg);
        private void UpdateRssiLb(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateRssiLbDeleg(UpdateRssiLb), new object[] { msg });
                return;
            }
            lb_rssi.Text = msg;
        }
        private delegate void UpdateProgressValueDeleg(int value);
        private void UpdateProgressValue(int value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateProgressValueDeleg(UpdateProgressValue), new object[] { value });
                return;
            }
            if (value > 100)
                pg_rssi.Value = 100;
            else if (value < 0)
                pg_rssi.Value = 0;
            else
                pg_rssi.Value = value;
        }
        private delegate void CloseFormDeleg();
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseFormDeleg(CloseForm), new object[] { });
                return;
            }
            this.Close();
        }
        private delegate void EnableFormDeleg(bool en);
        private void EnableForm(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableFormDeleg(EnableForm), new object[] { en });
                return;
            }
            this.Enabled = en;
        }
        #endregion

        #region Other Handle
        private void tk_threshold_ValueChanged(object sender, EventArgs e)
        {
            ThresholdArr[3] = tk_threshold.Value;
            lb_threshold.Text = tk_threshold.Value.ToString();
        }
        private void cb_sound_CheckStateChanged(object sender, EventArgs e)
        {
            bTone = cb_sound.Checked;
        }

        private void tb_epc_TextChanged(object sender, EventArgs e)
        {
            TargetEPC = tb_epc.Text;
        }
        #endregion

    }
}