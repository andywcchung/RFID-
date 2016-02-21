using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagBlockPermaLockForm : Form
    {
        enum LockState
        {
            Unknown,
            Locked,
            Unlocked,
        }

        private bool m_stop = false;
        public string TargetEPC = String.Empty;

        public TagBlockPermaLockForm()
        {
            InitializeComponent();
        }

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderXP.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnAccessCompleted);
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
            else
            {
                Program.ReaderXP.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderXP_OnAccessCompleted);
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_StateChangedEvent);
            }
        }

        void ReaderXP_OnAccessCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            Trace.WriteLine(string.Format("Bank {0}, Access {1}, Result {2}, Data {3}", e.bank, e.access,e.success, e.data == null ? null : e.data.ToString()));
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
                            EnableButton(true);
                            EnableForm(true);
                        }
                        else
                        {
                            CloseForm();
                        }
                        break;
                    case RFState.BUSY:
                        EnableButton(false);
                        break;
                    case RFState.ABORT:
                        EnableForm(false);
                        break;
                }
            });
        }

        #endregion
        private void lb_epc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                    TargetEPC = lb_epc.Text = inv.epc;
                }
            }
            AttachCallback(true);
        }

        private void TagBlockPermaLockForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        private void TagBlockPermaLockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        private delegate void EnableButtonDeleg(bool en);
        private void EnableButton(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableButtonDeleg(EnableButton), new object[] { en });
                return;
            }
            btn_exit.Enabled = btn_lock.Enabled = btn_read.Enabled = en;
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskOffset = 0;
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            Program.ReaderXP.Options.TagBlockLock.accessPassword = tb_password.ToUInt32;
            Program.ReaderXP.Options.TagBlockLock.count = 1; // Read at least 64 block, only vaild for higgs 3 tag
            Program.ReaderXP.Options.TagBlockLock.offset = 2;
            Program.ReaderXP.Options.TagBlockLock.setPermalock = false;
            Program.ReaderXP.Options.TagBlockLock.retryCount = 7;
            Program.ReaderXP.Options.TagBlockLock.flags = SelectFlags.SELECT;
            if (Program.ReaderXP.StartOperation(Operation.TAG_BLOCK_PERMALOCK, true) == Result.OK)
            {
                //Read Permalock success
                SetPermalock(Program.ReaderXP.Options.TagBlockLock.mask);
            }
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderXP.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderXP.Options.TagSelected.epcMaskOffset = 0;
            Program.ReaderXP.StartOperation(Operation.TAG_SELECTED, true);

            Program.ReaderXP.Options.TagBlockLock.accessPassword = tb_password.ToUInt32;
            Program.ReaderXP.Options.TagBlockLock.count = 1;//Set at least 64 block, only vaild for higgs 3 tag
            Program.ReaderXP.Options.TagBlockLock.offset = 0;
            Program.ReaderXP.Options.TagBlockLock.setPermalock = true;
            Program.ReaderXP.Options.TagBlockLock.retryCount = 7;
            Program.ReaderXP.Options.TagBlockLock.mask = GetPermalock();
            Program.ReaderXP.Options.TagBlockLock.flags = SelectFlags.SELECT;
            Program.ReaderXP.StartOperation(Operation.TAG_BLOCK_PERMALOCK, false);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (nb_block.Value >= 0)
            {
                lv_lock.BeginUpdate();
                if (lv_lock.Items.Count == 0)
                {
                    for (int i = 0; i < nb_block.Value; i++)
                    {
                        ListViewItem item = new ListViewItem(i.ToString());
                        item.Tag = LockState.Unknown;
                        item.SubItems.Add("Unknown");
                        lv_lock.Items.Add(item);
                    }
                }
                else if(nb_block.Value > lv_lock.Items.Count)
                {
                    int index = lv_lock.Items.Count;
                    for (int i = 0; i < nb_block.Value - lv_lock.Items.Count; i++, index++)
                    {
                        ListViewItem item = new ListViewItem(index.ToString());
                        item.Tag = LockState.Unknown;
                        item.SubItems.Add("Unknown");
                        lv_lock.Items.Add(item);
                    }
                }
                else if (nb_block.Value < lv_lock.Items.Count)
                {
                    int count = (int)(lv_lock.Items.Count - nb_block.Value);
                    for (int i = 0; i < count; i++)
                    {
                        lv_lock.Items.RemoveAt(lv_lock.Items.Count - 1);
                    }
                }
                lv_lock.EndUpdate();
            }
        }*/

        private ushort[] GetPermalock()
        {
            List<ushort> tmpList = new List<ushort>();
            ushort utmp = 0x0;
            int countdown = 15;
            int left = lv_lock.Items.Count % 16;
            foreach (ListViewItem item in lv_lock.Items)
            {
                switch((LockState)item.Tag)
                {
                    case LockState.Locked:
                        utmp |= (ushort)(0x1 << countdown);
                        break;
                    case LockState.Unknown:
                    case LockState.Unlocked:
                        utmp |= (ushort)(0x0 << countdown);
                        break;
                }
                countdown--;
                if (countdown < 0)
                {
                    countdown = 15;
                    tmpList.Add(utmp);
                    utmp = 0;
                }
            }
            if (left != 0)
            {
                tmpList.Add(utmp);
            }
            return tmpList.ToArray();
        }
        /// <summary>
        /// We only care about first byte for Higgs 3
        /// </summary>
        /// <param name="locked"></param>
        private void SetPermalock(ushort[] locked)
        {
            int index = 0;
            lv_lock.BeginUpdate();
            lv_lock.Items.Clear();
            foreach (ushort s in locked)
            {
                for (int i = 15; i >= 8; i--)
                {
                    ListViewItem item = new ListViewItem(index.ToString());
                    if (((s >> i) & 0x1) == 1)
                    {
                        item.Tag = LockState.Locked;
                        item.SubItems.Add("Locked");
                    }
                    else
                    {
                        item.Tag = LockState.Unlocked;
                        item.SubItems.Add("Unlocked");
                    }
                    lv_lock.Items.Add(item);
                    index++;
                }
            }
            lv_lock.EndUpdate();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lv_lock.SelectedIndices.Count > 0 && lv_lock.SelectedIndices[0] >= 0)
            {
                lv_lock.Items[lv_lock.SelectedIndices[0]].Tag = LockState.Locked;
                lv_lock.Items[lv_lock.SelectedIndices[0]].SubItems[1].Text = "Locked";
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lv_lock.SelectedIndices.Count > 0 && lv_lock.SelectedIndices[0] >= 0)
            {
                lv_lock.Items[lv_lock.SelectedIndices[0]].Tag = LockState.Unknown;
                lv_lock.Items[lv_lock.SelectedIndices[0]].SubItems[1].Text = "Unknown";
            }
        }
    }
}