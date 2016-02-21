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
    public partial class WriteAllBank : UserControl
    {
        public enum WriteState
        {
            OK,
            FAILED,
            UNKNOWN
        }

        private WriteState m_pc = WriteState.UNKNOWN;
        private WriteState m_epc = WriteState.UNKNOWN;
        private WriteState m_acc = WriteState.UNKNOWN;
        private WriteState m_kill = WriteState.UNKNOWN;
        private WriteState m_user = WriteState.UNKNOWN;

        private ushort m_offsetUser = 0;

        private ushort m_wordUser = 1;
       
        private ImageAttributes imgAtt = new ImageAttributes();
        private Bitmap m_bmpBuffer = null;
        private Graphics m_gxGraphic = null;
        private Bitmap m_accept_image = null;
        private Bitmap m_cancel_image = null;
        private Bitmap m_refresh_image = null;

        #region Extern variable

        #region Update Icon
        public WriteState IconPc
        {
            get { return m_pc; }
            set
            {
                m_pc = value;
                switch (value)
                {
                    case WriteState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                    case WriteState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                    case WriteState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_pc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public WriteState IconEpc
        {
            get { return m_epc; }
            set
            {
                m_epc = value;
                switch (value)
                {
                    case WriteState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                    case WriteState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                    case WriteState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_epc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public WriteState IconAcc
        {
            get { return m_acc; }
            set
            {
                m_acc = value;
                switch (value)
                {
                    case WriteState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                    case WriteState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                    case WriteState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_acc.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        public WriteState IconKill
        {
            get { return m_kill; }
            set
            {
                m_kill = value;
                switch (value)
                {
                    case WriteState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                    case WriteState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                    case WriteState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_kill.Image = m_bmpBuffer;
                        break;
                }
            }
        }

        public WriteState IconUser
        {
            get { return m_user; }
            set
            {
                m_user = value;
                switch (value)
                {
                    case WriteState.FAILED:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_cancel_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                    case WriteState.OK:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_accept_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                    case WriteState.UNKNOWN:
                        m_gxGraphic.Clear(Color.FromArgb(192, 255, 192));
                        m_gxGraphic.DrawImage(m_refresh_image, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, imgAtt);
                        pic_user.Image = m_bmpBuffer;
                        break;
                }
            }
        }
        #endregion

        public uint AccessPwd
        {
            get { return hexOnlyTextbox1.ToUInt32; }
        }

        public bool WritePC
        {
            get { return cb_pc.Checked; }
            set { cb_pc.Checked = value; }
        }

        public bool WriteEPC
        {
            get { return cb_epc.Checked; }
            set { cb_epc.Checked = value; }
        }

        public bool WriteAccPwd
        {
            get { return cb_accpwd.Checked; }
            set { cb_accpwd.Checked = value; }
        }

        public bool WriteKillPwd
        {
            get { return cb_killpwd.Checked; }
            set { cb_killpwd.Checked = value; }
        }

        public bool WriteUser
        {
            get { return cb_userbank.Checked; }
            set { cb_userbank.Checked = value; }
        }

        public ushort OffsetUser
        {
            get { return m_offsetUser; }
            set 
            { 
                m_offsetUser = value;
                cfg_user.Text = string.Format("Offset={0}, Word={1}", OffsetUser, WordUser);
            }
        }

        public ushort WordUser
        {
            get { return m_wordUser; }
            set 
            { 
                m_wordUser = value;
                cfg_user.Text = string.Format("Offset={0}, Word={1}", OffsetUser, WordUser);
                tb_user.MaxLength = WordUser * 4;
            }
        }
        public string pc
        {
            get { return tb_pc.Text; }
            set { tb_pc.Text = value; }
        }
        public string epc
        {
            get { return tb_epc.Text; }
            set 
            {
                tb_epc.MaxLength = value.Length;
                tb_epc.Text = value;
            }
        }
        public UInt32 AccPwd
        {
            get { return UInt32.Parse(tb_accpwd.Text, System.Globalization.NumberStyles.HexNumber); }
        }

        public UInt32 KillPwd
        {
            get { return UInt32.Parse(tb_killpwd.Text, System.Globalization.NumberStyles.HexNumber); }
        }

        public string User
        {
            get { return tb_user.Text; }
        }

        #endregion

        public WriteAllBank()
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
        }


        private delegate void UpdateAccPwdDelegate(string pwd);
        public void UpdateAccPwd(string pwd)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateAccPwdDelegate(UpdateAccPwd), new object[] { pwd });
                return;
            }
            tb_accpwd.Text = pwd;
        }

        private delegate void UpdateKillPwdDelegate(string pwd);
        public void UpdateKillPwd(string pwd)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateKillPwdDelegate(UpdateKillPwd), new object[] { pwd });
                return;
            }
            tb_killpwd.Text = pwd;
        }

        private delegate void UpdateUserBankDelegate(string user);
        public void UpdateUserBank(string user)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateUserBankDelegate(UpdateUserBank), new object[] { user });
                return;
            }
            tb_user.Text = user;
        }
        #endregion

        #region Button handle
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
                    tb_user.MaxLength = WordUser * 4;
                    //UpdateUI
                    cfg_user.Text = string.Format("Offset={0}, Word={1}", OffsetUser, WordUser);
                }
                this.Enabled = true;
            }
        }
        #endregion
       
    }
}
