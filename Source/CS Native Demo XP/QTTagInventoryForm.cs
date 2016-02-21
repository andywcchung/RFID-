using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

using System.Globalization;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Tools;

    public partial class QTTagInventoryForm : Form
    {
        #region Private Member
        private SQLMethod sqlMethod = null;

        private Thread reset;
        private long totaltags = 0;
        private long totaltagsthiscycle = 0;
        private long totaltagscycle = 0;
        private long totalcrc = 0;
        private Stopwatch watchrate = new Stopwatch();
        private object MyLock = new object();
        private bool selectMode = false;
        public string EPC = "";
        private bool mStop = false;
        private int lastRingTick = 0;

        private uint AntCycleCount = 0;
        private int[] AntCycleTime = new int[5];
        private int AntCycleTimeCount = 0;

        private int numChannelBusy = 0;
        
        private bool SaveSQL = false;

        public enum ButtonState : int
        {
            Start = 0,
            Stop,
            Select,
            Save,
            Clear,
            Exit,
            ALL,
            Unknow
        }

        private Custom.Control.SortColumnHeader m_colhdrIndex;
        private Custom.Control.SortColumnHeader m_colhdrPc;
        private Custom.Control.SortColumnHeader m_colhdrEpc;
        private Custom.Control.SortColumnHeader m_colhdrPcPublic;
        private Custom.Control.SortColumnHeader m_colhdrEpcPublic;
        private Custom.Control.SortColumnHeader m_colhdrRssi;
        private Custom.Control.SortColumnHeader m_colhdrCount;
        private Custom.Control.SortColumnHeader m_colhdrAntennaPort;
        private Custom.Control.SortListView m_sortListView;

        private List<CSLibrary.Structures.TagCallbackInfo> InventoryListItems = new List<CSLibrary.Structures.TagCallbackInfo>();

        private List<CSLibrary.Structures.TagCallbackInfo> lock_InvItems
        {
            get { lock (MyLock) { return InventoryListItems; } }
            set { lock (MyLock) { InventoryListItems = value; } }
        }

        #endregion

        #region Public Member
        public bool SelectMode
        {
            get { return selectMode; }
        }

        public class OnButtonClickEventArgs : EventArgs
        {
            private ButtonState state = ButtonState.Unknow;
            private bool enable = false;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="Stat">Input TagAccess Data</param>
            public OnButtonClickEventArgs(ButtonState Stat, bool Enable)
            {
                state = Stat;
                enable = Enable;
            }
            /// <summary>
            /// State
            /// </summary>
            public ButtonState State
            {
                get { return state; }
                set { state = value; }
            }
            public bool Enable
            {
                get { return enable; }
            }
        }
        public event EventHandler<OnButtonClickEventArgs> OnButtonEnable;

        #endregion

        #region Form
        public QTTagInventoryForm(bool SelectMode)
        {
            InitializeComponent();
            InitListView();
            selectMode = SelectMode;
            try
            {
                sqlMethod = new SQLMethod();
            }
            catch
            {
                MessageBox.Show("SQL start error");
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            //Show MAC and IP
            Text = String.Format("IP = {0}, MAC = {1}", Program.IP, Program.SerialNumber);

            //Third Step (Attach to Form)
            AttachCallback(true);

            QTControlPanelForm.LaunchControlPanel(this);
        }

        private void InventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fourth Step (Dettach from Form and Stop)
            if (Program.ReaderXP.State != RFState.IDLE)
            {
                mStop = e.Cancel = true;
                Program.ReaderXP.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
            Program.ReaderXP.Options.TagRanging.QTMode = false;
        }

        #endregion

        #region Event Callback
        private void Reset()
        {
            Result rc = Result.OK;
            QTMessageForm.LaunchForm(this);
            {
                EnableButton(ButtonState.ALL, false);
                Application.DoEvents();
            RETRY:
                //Reset Reader first, it will shutdown current reader and restart reader
                //It will also reconfig back previous operation
                if ((rc = Program.ReaderXP.Reconnect(1)) == Result.OK)
                {
                    int retry = 10;
                    //Start inventory
                    while (Program.ReaderXP.StartOperation(Operation.TAG_RANGING, false) != Result.OK)
                    {
                        if (retry-- == 0)
                            break;
                    }
                }
                else
                {
                    if (ShowMsg(String.Format("ResetReader fail rc = {0}. Do you want to try?", rc)) == DialogResult.Yes)
                    {
                        goto RETRY;
                    }
                }
                EnableButton(ButtonState.ALL, true);
            }
            QTMessageForm.msgform.CloseForm();
        }
        private delegate DialogResult ShowMsgDeleg(string msg);
        private DialogResult ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                return (DialogResult)this.Invoke(new ShowMsgDeleg(ShowMsg), new object[] { msg });
                //return DialogResult.None;
            }
            return MessageBox.Show(msg, "Retry", MessageBoxButtons.YesNo);
        }

        public void AbortReset()
        {
            if (reset != null && reset.IsAlive)
            {
                reset.Abort();
            }
        }
        void ReaderXP_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            this.BeginInvoke((System.Threading.ThreadStart)delegate()
               {
                   switch (e.state)
                   {
                       case RFState.IDLE:
                           watchrate.Stop();
                           //ControlPanelForm.EnablePannel(true);
                           EnableButton(ButtonState.Start, true);
                           EnableButton(ButtonState.Stop, false);
                           EnableTimer(false);
                           if (mStop)
                               this.Close();
                           break;

                       case RFState.BUSY:
                           watchrate.Reset();
                           watchrate.Start();
                           totaltags = 0;
                           totalcrc = 0;
                           EnableButton(ButtonState.Start, false);
                           EnableButton(ButtonState.Stop, true);
                           EnableTimer(true);
                           break;

                       case RFState.RESET:
                           if (QTControlPanelForm.ControlPanel.checkBoxLog.Checked)
                           {
                               TextWriter tw = new StreamWriter("Log.Txt", true);

                               tw.WriteLine("{0} : System Reset", DateTime.Now.ToString());

                               tw.Close();
                           }

                           //Use other thread to create progress
                           reset = new Thread(new ThreadStart(Reset));
                           reset.Start();
                           break;
                       
                       case RFState.ABORT:
                           //ControlPanelForm.EnablePannel(false);
                           break;

                       case RFState.ANT_CYCLE_END:
                           AntCycleCount++;
                           totaltagscycle = totaltagsthiscycle;
                           totaltagsthiscycle = 0;

/*                           if (ControlPanelForm.ControlPanel.checkBoxSaveSummary.Checked)
                           {
                               int portbusy = 0;
                               int common = 0;

                               TextWriter tw = new StreamWriter(ControlPanelForm.SummaryFile, true);

                               tw.Write("{0} : Cycle {1}, {2} Tag/Cycle, Channel State : ", DateTime.Now.ToString(), AntCycleCount, totaltagscycle);

                               for (int cnt = 0; cnt < 16; cnt++)
                               {
                                   if (Program.ReaderXP.ChannelStatus[cnt] == RFState.CH_BUSY)
                                   {
                                       portbusy = 1;
                                       if (common == 0)
                                           tw.Write("Port Busy ");
                                       else
                                           tw.Write(", ");
                                       tw.Write("{0}", cnt);
                                       common = 1;
                                   }

                               }

                               if (portbusy == 0)
                                   tw.WriteLine("CLEAR");
                               else
                                   tw.WriteLine("");

                               tw.Close();
                           }
 */ 
                           numChannelBusy = 0;

                           if (AntCycleTimeCount <= 4)
                           {
                               AntCycleTime[AntCycleTimeCount++] = Environment.TickCount;
                           }
                           else
                           {
                               AntCycleTime[0] = AntCycleTime[1];
                               AntCycleTime[1] = AntCycleTime[2];
                               AntCycleTime[2] = AntCycleTime[3];
                               AntCycleTime[3] = AntCycleTime[4];
                               AntCycleTime[4] = Environment.TickCount;
                           }

                           break;
                   }
               });
        }

        void ReaderXP_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            /*if (!e.info.crcInvalid)
            {
                int thisTick = Environment.TickCount;
                if ((thisTick - lastRingTick) > 250)
                {
                    lastRingTick = thisTick;
                    System.Media.SystemSounds.Beep.Play();
                }
            }*/
            this.BeginInvoke((System.Threading.ThreadStart)delegate()
            {
                // Do your work here
                // UI refresh and data processing on other Thread
                // Notes :  blocking here will cause problem
                //          Please use asyn call or separate thread to refresh UI
                if (!e.info.crcInvalid)
                {
                    if ((!Program.appSetting.EnableRssiFilter) || 
                        (Program.appSetting.EnableRssiFilter && Program.appSetting.RssiFilterThreshold < e.info.rssi))
                    {
                        Interlocked.Increment(ref totaltags);
                        TagCallbackInfo data = e.info;
                        UpdateInvUI(data);
                    }
#if nouse
                    if (Program.appSetting.EnableRssiFilter)
                    {
                        if (Program.appSetting.RssiFilterThreshold < e.info.rssi)
                        {
                            Interlocked.Increment(ref totaltags);
                            TagCallbackInfo data = e.info;
                            UpdateInvUI(data);
                        }
                    }
                    else
                    {
                        Interlocked.Increment(ref totaltags);
                        TagCallbackInfo data = e.info;
                        UpdateInvUI(data);
                    }
#endif
                }
                else
                {
                    totalcrc++;
                }
                if (Program.tagLogger != null)
                {
                    Program.tagLogger.Log(CSLibrary.Diagnostics.LogLevel.Info, String.Format("CRC[{0}]:PC[{1}]:EPC[{2}]", e.info.crcInvalid, e.info.pc, e.info.epc));
                }
            });
        }

        private void UpdateInvUI(TagCallbackInfo InventoryInformation)
        {
            if (InventoryInformation.crcInvalid == true)
                return;

            int foundIndex = lock_InvItems.FindIndex(delegate(CSLibrary.Structures.TagCallbackInfo iepc) { return iepc.epc.ToString() == InventoryInformation.epc.ToString(); });
            {
                if (foundIndex >= 0)
                {
                    //found a record
                    lock_InvItems[foundIndex].count++;
                    lock_InvItems[foundIndex].rssi = InventoryInformation.rssi;
                    lock_InvItems[foundIndex].index = foundIndex;
                    lock_InvItems[foundIndex].antennaPort = InventoryInformation.antennaPort;
                    //UI update in separate thread
                    UpdateListView(lock_InvItems[foundIndex]);
                }
                else
                {
                    //record no exist
                    //add a record to item list
                    InventoryInformation.index = lock_InvItems.Count;
                    lock_InvItems.Add(InventoryInformation);

                    //UI update in separate thread
                    LVAddItem(
                        InventoryInformation.index.ToString(),
                        InventoryInformation.pc.ToString(),
                        InventoryInformation.epc.ToString (),
                        InventoryInformation.pcpublic.ToString(),
                        InventoryInformation.epcpublic.ToString (),
                        InventoryInformation.rssi.ToString(),
                        InventoryInformation.count.ToString(),
                        InventoryInformation.antennaPort.ToString());
                    if (SaveSQL)
                    {
                        sqlMethod.AddData(InventoryInformation.epc.ToString());
                    }
                }
                
            }
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
                Program.ReaderXP.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
            }
            else
            {
                Program.ReaderXP.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_TagInventoryEvent);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
        }
       

        #endregion

        #region Delegate

        private delegate void LVAddItemDeleg(string index, string pc, string epc, string rssi, string count, string antennaPort);
        private void LVAddItem(string index, string pc, string epc, string rssi, string count, string antennaPort)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new LVAddItemDeleg(LVAddItem), new object[] { index, pc, epc, rssi, count, antennaPort });
                return;
            }
            lock (MyLock)
            {
                ListViewItem item = new ListViewItem(index);
#if ENGINEERING_MODE
                item.Font = new Font("Courier New", 5, FontStyle.Regular);
#else
                item.Font = new Font("Courier New", 12, FontStyle.Regular);
#endif
                item.SubItems.Add(pc);
                item.SubItems.Add(epc);
                item.SubItems.Add(rssi);
                item.SubItems.Add(count);
#if CS468
               item.SubItems.Add(antennaPort);
#endif
                item.Tag = Environment.TickCount;
                item.ForeColor = Color.Green;
                item.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
                //item.ForeColor = Color.White;
                m_sortListView.Items.Add(item);
            }
        }

        private void LVAddItem(string index, string pc, string epc, string pcpublic, string epcpublic, string rssi, string count, string antennaPort)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new LVAddItemDeleg(LVAddItem), new object[] { index, pc, epc, rssi, count, antennaPort });
                return;
            }
            lock (MyLock)
            {
                ListViewItem item = new ListViewItem(index);
#if ENGINEERING_MODE
                item.Font = new Font("Courier New", 5, FontStyle.Regular);
#else
                item.Font = new Font("Courier New", 12, FontStyle.Regular);
#endif
                item.SubItems.Add(pc);
                item.SubItems.Add(epc);
                item.SubItems.Add(pcpublic);
                item.SubItems.Add(epcpublic);
                item.SubItems.Add(rssi);
                item.SubItems.Add(count);
                item.SubItems.Add(antennaPort);
                item.Tag = Environment.TickCount;
                item.ForeColor = Color.Green;
                item.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
                //item.ForeColor = Color.White;
                m_sortListView.Items.Add(item);
            }
        }

        private delegate void UpdateListViewDeleg(TagCallbackInfo item);
        private void UpdateListView(TagCallbackInfo item)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateListViewDeleg(UpdateListView), new object[] { item });
                return;
            }
            lock (MyLock)
            {
                for (int index = 0; index < m_sortListView.Items.Count; index++)
                {
                    if (m_sortListView.Items[index].SubItems[2].Text == item.epc.ToString().Substring (0, (int)item.epcstrlen * 4))
                    {
                        m_sortListView.Items[index].SubItems[5].Text = item.rssi.ToString();
                        m_sortListView.Items[index].SubItems[6].Text = item.count.ToString();
                        m_sortListView.Items[index].SubItems[7].Text = item.antennaPort.ToString();
                        m_sortListView.Items[index].Tag = Environment.TickCount;
                        m_sortListView.Items[index].ForeColor = Color.Green;
                        break;
                    }
                }
            }
        }

        private delegate void EnableTimerDeleg(bool en);
        private void EnableTimer(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableTimerDeleg(EnableTimer), new object[] { en });
                return;
            }
            tmrRowColor.Enabled = tmr_updatelist.Enabled = en;
        }

        #endregion

        #region ListView Handle
        private void InitListView()
        {
            this.m_sortListView = new Custom.Control.SortListView();
            // 
            // m_sortListView
            // 
            this.m_sortListView.FullRowSelect = true;
            this.m_sortListView.GridLines = true;
            this.m_sortListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.m_sortListView.Location = new System.Drawing.Point(3, 3);
            this.m_sortListView.Name = "m_sortListView";
            this.m_sortListView.Size = new System.Drawing.Size(380, 400);
            this.m_sortListView.TabIndex = 0;
            this.m_sortListView.UseCompatibleStateImageBehavior = false;
            this.m_sortListView.View = System.Windows.Forms.View.Details;
#if ENGINEERING_MODE
            this.m_sortListView.Font = new Font(FontFamily.GenericSerif, 6);
#else
            this.m_sortListView.Font = new Font(FontFamily.GenericSerif, 12);
#endif
            this.m_sortListView.SelectedIndexChanged += new System.EventHandler(this.m_sortListView_SelectedIndexChanged);
            m_colhdrIndex = new Custom.Control.SortColumnHeader();
            m_colhdrPc = new Custom.Control.SortColumnHeader();
            m_colhdrEpc = new Custom.Control.SortColumnHeader();
            m_colhdrPcPublic = new Custom.Control.SortColumnHeader();
            m_colhdrEpcPublic = new Custom.Control.SortColumnHeader();
            m_colhdrRssi = new Custom.Control.SortColumnHeader();
            m_colhdrCount = new Custom.Control.SortColumnHeader();
            m_colhdrAntennaPort = new Custom.Control.SortColumnHeader();
            m_sortListView.Columns.AddRange(new ColumnHeader[] { 
                m_colhdrIndex,
                m_colhdrPc,
                m_colhdrEpc,
                m_colhdrPcPublic,
                m_colhdrEpcPublic,
                m_colhdrRssi, 
                m_colhdrCount
                , m_colhdrAntennaPort
            });
            m_colhdrIndex.Text = "Index";
            m_colhdrIndex.Width = 80;
            m_colhdrPc.Text = "PC (Private)";
            m_colhdrPc.Width = 80;
            m_colhdrEpc.Text = "EPC (Private)";
            m_colhdrEpc.Width = 260;
            m_colhdrPcPublic.Text = "PC (Public)";
            m_colhdrPcPublic.Width = 80;
            m_colhdrEpcPublic.Text = "EPC (Public)";
            m_colhdrEpcPublic.Width = 260;
            m_colhdrRssi.Text = "RSSI";
            m_colhdrRssi.Width = 80;
            m_colhdrCount.Text = "Count";
            m_colhdrCount.Width = 100;
            m_colhdrAntennaPort.Text = "Antenna Port";
            m_colhdrAntennaPort.Width = 100;
            m_sortListView.SortColumn = 0;
            //Controls.Add(m_sortListView);
            m_sortListView.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(m_sortListView);
            // Assign specific comparers to each column header.
            m_colhdrIndex.ColumnHeaderSorter = new Custom.Control.ComparerStringAsInt();
            m_colhdrPc.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrEpc.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrPcPublic.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrEpcPublic.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrRssi.ColumnHeaderSorter = new Custom.Control.ComparerStringAsDouble();
            m_colhdrCount.ColumnHeaderSorter = new Custom.Control.ComparerStringAsInt();
            m_colhdrAntennaPort.ColumnHeaderSorter = new Custom.Control.ComparerStringAsInt();
            this.m_sortListView.Sorting = Custom.Control.SortOrder.Ascending;
        }

        private void m_sortListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectMode)
                return;
            if (m_sortListView.SelectedIndices != null && m_sortListView.SelectedIndices.Count > 0 && m_sortListView.SelectedIndices[0] >= 0)
            {
                EnableButton(ButtonState.Select, true);
            }
            else
            {
                EnableButton(ButtonState.Select, false);
                if (Program.ReaderXP.State == RFState.BUSY)
                {
                    EnableButton(ButtonState.Start, false);
                    EnableButton(ButtonState.Stop, true);
                }
                else if (Program.ReaderXP.State == RFState.IDLE)
                {
                    EnableButton(ButtonState.Start, true);
                    EnableButton(ButtonState.Stop, false);
                }
            }
        }
        #endregion

        #region Button Handle
        
        public void Start()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.SetOperationMode(RadioOperationMode.CONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                //Do Setup on SettingForm
                Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;

                Program.ReaderXP.Options.TagRanging.multibanks = 0;

                Program.ReaderXP.Options.TagRanging.QTMode = true;
                Program.ReaderXP.Options.TagRanging.accessPassword = UInt32.Parse(QTControlPanelForm.ControlPanel.textBoxAccessPassword.Text, NumberStyles.HexNumber);

                Program.ReaderXP.StartOperation(Operation.TAG_RANGING, false);
            }
        }
        public void StartOnce()
        {
            if (Program.ReaderXP.State == RFState.IDLE)
            {
                Program.ReaderXP.SetOperationMode(RadioOperationMode.NONCONTINUOUS);
                Program.ReaderXP.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderXP.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                //Do Setup on SettingForm
                Program.ReaderXP.Options.TagRanging.flags = SelectFlags.ZERO;
                Program.ReaderXP.Options.TagRanging.QTMode = false; // reset to default
                Program.ReaderXP.Options.TagRanging.accessPassword = 0x0; // reset to default
                Program.ReaderXP.StartOperation(Operation.TAG_RANGING, false);
            }
        }

        public void Stop()
        {
            if (Program.ReaderXP.State == RFState.BUSY)
            {
                Program.ReaderXP.StopOperation(true);
            }
        }

        public void Clear()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(Clear));
                return;
            }
            InventoryListItems.Clear();
            m_sortListView.Items.Clear();
        }

        public void SelectTag()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(SelectTag));
                return;
            }
            if (selectMode && m_sortListView.SelectedIndices.Count > 0)
            {
                EPC = m_sortListView.Items[m_sortListView.SelectedIndices[0]].SubItems[2].Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(CloseForm));
                return;
            }
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Save()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(Save));
                return;
            }
            if (InventoryListItems.Count == 0)
                return;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (TagCallbackInfo data in InventoryListItems)
                    {
                        sw.WriteLine(string.Format("{0:X4}-{1},{2:F1}", data.pc, data.epc, data.rssi, data.antennaPort));
                    }
                }
            }
        }

        public void Save2SQL()
        {
            if (!sqlMethod.Prepare())
            {
                MessageBox.Show("Connect to Server error! Please check connection.");
            }
            else
            {
                SaveSQL = true;
            }
        }

        private delegate void EnableButtonDeleg(ButtonState state, bool en);
        private void EnableButton(ButtonState state, bool en)
        {
            RaiseEvent<OnButtonClickEventArgs>(OnButtonEnable, this, new OnButtonClickEventArgs(state, en));
        }


        #endregion

        #region Timer
        private void tmr_updatelist_Tick(object sender, EventArgs e)
        {
            tsl_uid.Text = "Tag read = " + lock_InvItems.Count;
            tsl_rate.Text = string.Format("Rate = {0:F1} Tag/s", totaltags / watchrate.Elapsed.TotalSeconds);
            tsl_crc.Text = string.Format("CRC = {0:F1} Tag/s", totalcrc / watchrate.Elapsed.TotalSeconds);
            if (watchrate.Elapsed.TotalSeconds > 10)
            {
                watchrate.Reset();
                watchrate.Start();
                Interlocked.Exchange(ref totaltags, 0);
                Interlocked.Exchange(ref totalcrc, 0);
            }
        }
        #endregion

        #region Protected
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void RaiseEvent<T>(EventHandler<T> eventHandler, object sender, T e)
            where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            QTControlPanelForm.CloseControlPanel();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            QTControlPanelForm.SetTopMost(true);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            QTControlPanelForm.SetTopMost(false);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            QTControlPanelForm.SetResize(new Point(this.Location.X+ this.Width, this.Location.Y), this.Height);
        }

        public override Size MaximumSize
        {
            get
            {
                if (QTControlPanelForm._controlPanel != null)
                {
                    Rectangle rc = Screen.GetWorkingArea(this.DesktopBounds);
                    return new Size(rc.Width - QTControlPanelForm._controlPanel.Width, rc.Height);
                }
                else
                    return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
            }
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            QTControlPanelForm.SetResize(new Point(this.Location.X + this.Width, this.Location.Y), this.Height);
        }
        #endregion

        private void tmrRowColor_Tick(object sender, EventArgs e)
        {
#if !DETECT_TAG_BY_TIME
            for (int i = 0; i < m_sortListView.Items.Count; i++)
            {
                // Change tag color (OrangeRed < AntCycleTime[0] > OrangeRed < AntCycleTime[1] > YellowGreen < AntCycleTime[2] > LimeGreen < AntCycleTime[3] > Green < AntCycleTime[4] > Green)

                if (AntCycleTimeCount <= 1)
                {
                    m_sortListView.Items[i].ForeColor = Color.Green;
                }
                else
                {
                    int j;

                    for (j = AntCycleTimeCount - 2; j >= 0; j--)
                    {
                        if ((int)m_sortListView.Items[i].Tag > AntCycleTime[j])
                        {
                            switch (AntCycleTimeCount - j)
                            {
                                case 2:
                                    m_sortListView.Items[i].ForeColor = Color.Green;
                                    break;

                                case 3:
                                    m_sortListView.Items[i].ForeColor = Color.LimeGreen;
                                    break;
                            
                                case 4:
                                    m_sortListView.Items[i].ForeColor = Color.YellowGreen;
                                    break;
                               
                                default:
                                    m_sortListView.Items[i].ForeColor = Color.OrangeRed;
                                    break;
                            }
                            break;
                        }
                    }

                    if (j < 0)
                        m_sortListView.Items[i].ForeColor = Color.OrangeRed;

                }
            }
#else
            int curTime = Environment.TickCount;
            for (int i = 0; i < m_sortListView.Items.Count; i++)
            {
                int timeDiff = curTime - (int)m_sortListView.Items[i].Tag;
                if (timeDiff > 5000)
                {
                    m_sortListView.Items[i].ForeColor = Color.OrangeRed;
                }
                else if (timeDiff <= 5000 && timeDiff > 4000)
                {
                    m_sortListView.Items[i].ForeColor = Color.OrangeRed;
                }
                else if (timeDiff <= 4000 && timeDiff > 3000)
                {
                    m_sortListView.Items[i].ForeColor = Color.YellowGreen;
                }
                else if (timeDiff <= 3000 && timeDiff > 2000)
                {
                    m_sortListView.Items[i].ForeColor = Color.LimeGreen;
                }
                else if (timeDiff <= 1000 && timeDiff >= 0)
                {
                    m_sortListView.Items[i].ForeColor = Color.Green;
                }
            }
            //Application.DoEvents();
#endif
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }
    }
}