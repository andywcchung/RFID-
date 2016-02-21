using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class ReadAllBank : UserControl
    {
        public enum ReadState
        {
            OK,
            FAILED,
            UNKNOWN
        }

        private ReadState m_pc = ReadState.UNKNOWN;
        private ReadState m_epc = ReadState.UNKNOWN;
        private ReadState m_acc = ReadState.UNKNOWN;
        private ReadState m_kill = ReadState.UNKNOWN;
        private ReadState m_tid = ReadState.UNKNOWN;
        private ReadState m_user = ReadState.UNKNOWN;

        private ImageAttributes imgAtt = new ImageAttributes();
        private Bitmap m_bmpBuffer = null;
        private Graphics m_gxGraphic = null;
        private Bitmap m_accept_image = null;
        private Bitmap m_cancel_image = null;
        private Bitmap m_refresh_image = null;

        #region Extern variable

        #region Update Icon
        public ReadState IconPc
        {
            get { return m_pc; }
            set
            {
                m_pc = value; 
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public ReadState IconEpc
        {
            get { return m_epc; }
            set
            {
                m_epc = value; 
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public ReadState IconAcc
        {
            get { return m_acc; }
            set
            {
                m_acc = value;
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public ReadState IconKill
        {
            get { return m_kill; }
            set
            {
                m_kill = value;
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public ReadState IconTid
        {
            get { return m_tid; }
            set
            {
                m_tid = value;
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_tid.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_tid.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_tid.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public ReadState IconUser
        {
            get { return m_user; }
            set
            {
                m_user = value;
                switch (value)
                {
                    case ReadState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                    case ReadState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                    case ReadState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        #endregion
        
        #region Enable Checkbox
        public bool ReadPc
        {
            get { return cb_pc.Checked; }
            set { cb_pc.Checked = value; }
        }

        public bool ReadEpc
        {
            get { return cb_epc.Checked; }
            set { cb_epc.Checked = value; }
        }

        public bool ReadAccPwd
        {
            get { return cb_accpwd.Checked; }
            set { cb_accpwd.Checked = value; }
        }

        public bool ReadKillPwd
        {
            get { return cb_killpwd.Checked; }
            set { cb_killpwd.Checked = value; }
        }

        public bool ReadTid
        {
            get { return cb_tid.Checked; }
            set { cb_tid.Checked = value; }
        }

        public bool ReadUserBank
        {
            get { return cb_userbank.Checked; }
            set { cb_userbank.Checked = value; }
        }
        #endregion

        public uint AccessPwd
        {
            get { return hexOnlyTextbox1.ToUInt32; }
        }

        public ushort OffsetTid = 0;

        public ushort WordTid = 2;

        public ushort OffsetUser = 0;

        public ushort WordUser = 1;

        public string pc
        {
            get { return lb_pc.Text; }
            set { lb_pc.Text = value; }
        }

        public string epc
        {
            get { return lb_epc.Text; }
            set { lb_epc.Text = value; }
        }

        public string AccPwd
        {
            get { return lb_accpwd.Text; }
            set { lb_accpwd.Text = value; }
        }
        public string KillPwd
        {
            get { return lb_killpwd.Text; }
            set { lb_killpwd.Text = value; }
        }
        public string Tid
        {
            get { return lb_tid.Text; }
            set { lb_tid.Text = value; }
        }
        public string UserMem
        {
            get { return lb_user.Text; }
            set { lb_user.Text = value; }
        }

        #endregion

        public ReadAllBank()
        {
            InitializeComponent();

            this.Size = new Size(306, 160);

            try
            {
                m_accept_image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("CS203_CALLBACK_API_DEMO.Resources.accept.png"));
                m_cancel_image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("CS203_CALLBACK_API_DEMO.Resources.cancel.png"));
                m_refresh_image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("CS203_CALLBACK_API_DEMO.Resources.refresh.png"));
            }
            catch
            {
                MessageBox.Show("Error accessing resources!");
            }

            try
            {
                if (m_bmpBuffer == null)
                {
                    m_bmpBuffer = new Bitmap(16, 16);
                    m_gxGraphic = Graphics.FromImage(m_bmpBuffer);
                    m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                }

                imgAtt.SetColorKey(Color.FromArgb(0, 0, 255), Color.FromArgb(0, 0, 255));

                m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);

                pic_acc.Image = m_bmpBuffer;
                pic_epc.Image = m_bmpBuffer;
                pic_kill.Image = m_bmpBuffer;
                pic_pc.Image = m_bmpBuffer;
                pic_tid.Image = m_bmpBuffer;
                pic_user.Image = m_bmpBuffer;
            }
            catch
            {
                MessageBox.Show("Error creating image!");
            }
        }

        #region UI Update
        private delegate void ClearDeleg();
        public void Clear()
        {
            if (this.InvokeRequired)
            {
                Invoke(new ClearDeleg(Clear), new object[] { });
                return;
            }
            lb_pc.Text = "Unread";
            lb_epc.Text = "Unread";
            lb_accpwd.Text = "Unread";
            lb_killpwd.Text = "Unread";
            lb_tid.Text = "Unread";
            lb_user.Text = "Unread";
            tb_showall.Text = "";
            m_gxGraphic.Clear(Color.FromArgb(192, 255, 192)); 
            m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
            if (cb_accpwd.Checked)
                pic_acc.Image = m_bmpBuffer;
            if (cb_epc.Checked)
                pic_epc.Image = m_bmpBuffer;
            if (cb_killpwd.Checked)
                pic_kill.Image = m_bmpBuffer;
            if (cb_pc.Checked)
                pic_pc.Image = m_bmpBuffer;
            if (cb_userbank.Checked)
                pic_user.Image = m_bmpBuffer;
            if (cb_tid.Checked)
                pic_tid.Image = m_bmpBuffer;
        }

        private delegate void UpdatePCDelegate(string pc);
        public void UpdatePC(string pc)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdatePCDelegate(UpdatePC), new object[] { pc });
                return;
            }
            lb_pc.Text = pc;
        }

        private delegate void UpdateEPCDelegate(string epc);
        public void UpdateEPC(string epc)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateEPCDelegate(UpdateEPC), new object[] { epc });
                return;
            }
            lb_epc.Text = epc;
        }

        private delegate void UpdateAccPwdDelegate(string pwd);
        public void UpdateAccPwd(string pwd)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateAccPwdDelegate(UpdateAccPwd), new object[] { pwd });
                return;
            }
            lb_accpwd.Text = pwd;
        }

        private delegate void UpdateKillPwdDelegate(string pwd);
        public void UpdateKillPwd(string pwd)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateKillPwdDelegate(UpdateKillPwd), new object[] { pwd });
                return;
            }
            lb_killpwd.Text = pwd;
        }

        private delegate void UpdateTidDelegate(string tid);
        public void UpdateTid(string tid)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateTidDelegate(UpdateTid), new object[] { tid });
                return;
            }
            lb_tid.Text = tid;
        }

        private delegate void UpdateUserBankDelegate(string user);
        public void UpdateUserBank(string user)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateUserBankDelegate(UpdateUserBank), new object[] { user });
                return;
            }
            lb_user.Text = user;
        }
        #endregion

        #region Button handle
        private void lb_viewall_Click(object sender, EventArgs e)
        {
            tb_showall.Visible = false;
            lb_hide.Visible = false;
        }
        private void cfg_tid_Click(object sender, EventArgs e)
        {
            using (ConfigOffset off = new ConfigOffset())
            {
                this.Enabled = false;
                off.Offset = OffsetTid;
                off.Word = WordTid;
                if (off.ShowDialog() == DialogResult.OK)
                {
                    OffsetTid = off.Offset;
                    WordTid = off.Word;
                    //UpdateUI
                    cfg_tid.Text = string.Format("Offset={0}, Word={1}", OffsetTid, WordTid);
                }
                this.Enabled = true;
            }
        }

        private void cfg_user_Click(object sender, EventArgs e)
        {
            using (ConfigOffset off = new ConfigOffset())
            {
                this.Enabled = false;
                off.Offset = OffsetUser;
                off.Word = WordUser;
                if (off.ShowDialog() == DialogResult.OK)
                {
                    OffsetUser = off.Offset;
                    WordUser = off.Word;
                    //UpdateUI
                    cfg_user.Text = string.Format("Offset={0}, Word={1}", OffsetUser, WordUser);
                }
                this.Enabled = true;
            }
        }

        private void lb_tid_Click(object sender, EventArgs e)
        {
            tb_showall.Visible = true;
            lb_hide.Visible = true;
            tb_showall.Text = lb_tid.Text;
        }

        private void lb_user_Click(object sender, EventArgs e)
        {
            tb_showall.Visible = true;
            lb_hide.Visible = true;
            tb_showall.Text = lb_user.Text;
        }
        #endregion

        private void hexOnlyTextbox1_Validating(object sender, CancelEventArgs e)
        {
            if (hexOnlyTextbox1.Text.Length < 8)
                hexOnlyTextbox1.Text += new string ('0', 8 - hexOnlyTextbox1.Text.Length);
        }
    }
}
