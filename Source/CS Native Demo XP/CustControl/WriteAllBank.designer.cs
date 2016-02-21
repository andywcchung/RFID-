namespace CS203_CALLBACK_API_DEMO
{
    partial class WriteAllBank
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_accpwd = new System.Windows.Forms.CheckBox();
            this.cb_killpwd = new System.Windows.Forms.CheckBox();
            this.cb_userbank = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_pc = new System.Windows.Forms.CheckBox();
            this.cb_epc = new System.Windows.Forms.CheckBox();
            this.pic_pc = new System.Windows.Forms.PictureBox();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.pic_kill = new System.Windows.Forms.PictureBox();
            this.pic_acc = new System.Windows.Forms.PictureBox();
            this.pic_epc = new System.Windows.Forms.PictureBox();
            this.cfg_user = new System.Windows.Forms.LinkLabel();
            this.hexOnlyTextbox1 = new Custom.Control.HexOnlyTextbox();
            this.tb_epc = new Custom.Control.HexOnlyTextbox();
            this.tb_user = new Custom.Control.HexOnlyTextbox();
            this.tb_killpwd = new Custom.Control.HexOnlyTextbox();
            this.tb_accpwd = new Custom.Control.HexOnlyTextbox();
            this.tb_pc = new Custom.Control.HexOnlyTextbox();
            this.SuspendLayout();
            // 
            // cb_accpwd
            // 
            this.cb_accpwd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cb_accpwd.Location = new System.Drawing.Point(3, 50);
            this.cb_accpwd.Name = "cb_accpwd";
            this.cb_accpwd.Size = new System.Drawing.Size(81, 16);
            this.cb_accpwd.TabIndex = 0;
            this.cb_accpwd.Text = "ACC PWD";
            // 
            // cb_killpwd
            // 
            this.cb_killpwd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cb_killpwd.Location = new System.Drawing.Point(3, 71);
            this.cb_killpwd.Name = "cb_killpwd";
            this.cb_killpwd.Size = new System.Drawing.Size(81, 16);
            this.cb_killpwd.TabIndex = 0;
            this.cb_killpwd.Text = "KILL PWD";
            // 
            // cb_userbank
            // 
            this.cb_userbank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cb_userbank.Location = new System.Drawing.Point(3, 93);
            this.cb_userbank.Name = "cb_userbank";
            this.cb_userbank.Size = new System.Drawing.Size(81, 16);
            this.cb_userbank.TabIndex = 0;
            this.cb_userbank.Text = "USER";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.Text = "Access Password";
            // 
            // cb_pc
            // 
            this.cb_pc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cb_pc.Location = new System.Drawing.Point(3, 6);
            this.cb_pc.Name = "cb_pc";
            this.cb_pc.Size = new System.Drawing.Size(81, 16);
            this.cb_pc.TabIndex = 18;
            this.cb_pc.Text = "PC";
            // 
            // cb_epc
            // 
            this.cb_epc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cb_epc.Location = new System.Drawing.Point(3, 28);
            this.cb_epc.Name = "cb_epc";
            this.cb_epc.Size = new System.Drawing.Size(81, 16);
            this.cb_epc.TabIndex = 19;
            this.cb_epc.Text = "EPC";
            // 
            // pic_pc
            // 
            this.pic_pc.Location = new System.Drawing.Point(287, 6);
            this.pic_pc.Name = "pic_pc";
            this.pic_pc.Size = new System.Drawing.Size(16, 16);
            // 
            // pic_user
            // 
            this.pic_user.Location = new System.Drawing.Point(287, 93);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(16, 16);
            // 
            // pic_kill
            // 
            this.pic_kill.Location = new System.Drawing.Point(287, 71);
            this.pic_kill.Name = "pic_kill";
            this.pic_kill.Size = new System.Drawing.Size(16, 16);
            // 
            // pic_acc
            // 
            this.pic_acc.Location = new System.Drawing.Point(287, 50);
            this.pic_acc.Name = "pic_acc";
            this.pic_acc.Size = new System.Drawing.Size(16, 16);
            // 
            // pic_epc
            // 
            this.pic_epc.Location = new System.Drawing.Point(287, 28);
            this.pic_epc.Name = "pic_epc";
            this.pic_epc.Size = new System.Drawing.Size(16, 16);
            // 
            // cfg_user
            // 
            this.cfg_user.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.cfg_user.ForeColor = System.Drawing.Color.Red;
            this.cfg_user.Location = new System.Drawing.Point(90, 93);
            this.cfg_user.Name = "cfg_user";
            this.cfg_user.Size = new System.Drawing.Size(123, 16);
            this.cfg_user.TabIndex = 34;
            this.cfg_user.Text = "Offset=0, Word=1";
            this.cfg_user.Click += new System.EventHandler(this.cfg_user_Click);
            // 
            // hexOnlyTextbox1
            // 
            this.hexOnlyTextbox1.BackgroundText = "";
            this.hexOnlyTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hexOnlyTextbox1.FontColor = System.Drawing.Color.Black;
            this.hexOnlyTextbox1.Location = new System.Drawing.Point(106, 154);
            this.hexOnlyTextbox1.MaxLength = 8;
            this.hexOnlyTextbox1.Name = "hexOnlyTextbox1";
            this.hexOnlyTextbox1.PaddingZero = true;
            this.hexOnlyTextbox1.Size = new System.Drawing.Size(107, 23);
            this.hexOnlyTextbox1.TabIndex = 35;
            this.hexOnlyTextbox1.Text = "00000000";
            // 
            // tb_epc
            // 
            this.tb_epc.BackColor = System.Drawing.Color.LightGreen;
            this.tb_epc.BackgroundText = "EPC";
            this.tb_epc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tb_epc.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tb_epc.FontColor = System.Drawing.Color.Red;
            this.tb_epc.ForeColor = System.Drawing.Color.Red;
            this.tb_epc.Location = new System.Drawing.Point(90, 25);
            this.tb_epc.MaxLength = 24;
            this.tb_epc.Name = "tb_epc";
            this.tb_epc.PaddingZero = true;
            this.tb_epc.Size = new System.Drawing.Size(191, 19);
            this.tb_epc.TabIndex = 16;
            // 
            // tb_user
            // 
            this.tb_user.BackColor = System.Drawing.Color.LightGreen;
            this.tb_user.BackgroundText = "USER";
            this.tb_user.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tb_user.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tb_user.FontColor = System.Drawing.Color.Red;
            this.tb_user.ForeColor = System.Drawing.Color.Red;
            this.tb_user.Location = new System.Drawing.Point(6, 112);
            this.tb_user.MaxLength = 4;
            this.tb_user.Multiline = true;
            this.tb_user.Name = "tb_user";
            this.tb_user.PaddingZero = true;
            this.tb_user.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_user.Size = new System.Drawing.Size(300, 36);
            this.tb_user.TabIndex = 17;
            // 
            // tb_killpwd
            // 
            this.tb_killpwd.BackColor = System.Drawing.Color.LightPink;
            this.tb_killpwd.BackgroundText = "KILL PWD";
            this.tb_killpwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tb_killpwd.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tb_killpwd.FontColor = System.Drawing.Color.Red;
            this.tb_killpwd.ForeColor = System.Drawing.Color.Red;
            this.tb_killpwd.Location = new System.Drawing.Point(90, 68);
            this.tb_killpwd.MaxLength = 8;
            this.tb_killpwd.Name = "tb_killpwd";
            this.tb_killpwd.PaddingZero = true;
            this.tb_killpwd.Size = new System.Drawing.Size(86, 19);
            this.tb_killpwd.TabIndex = 17;
            this.tb_killpwd.Text = "00000000";
            // 
            // tb_accpwd
            // 
            this.tb_accpwd.BackColor = System.Drawing.Color.LightPink;
            this.tb_accpwd.BackgroundText = "ACC PWD";
            this.tb_accpwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tb_accpwd.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tb_accpwd.FontColor = System.Drawing.Color.Red;
            this.tb_accpwd.ForeColor = System.Drawing.Color.Red;
            this.tb_accpwd.Location = new System.Drawing.Point(90, 47);
            this.tb_accpwd.MaxLength = 8;
            this.tb_accpwd.Name = "tb_accpwd";
            this.tb_accpwd.PaddingZero = true;
            this.tb_accpwd.Size = new System.Drawing.Size(86, 19);
            this.tb_accpwd.TabIndex = 17;
            this.tb_accpwd.Text = "00000000";
            // 
            // tb_pc
            // 
            this.tb_pc.BackColor = System.Drawing.Color.LightGreen;
            this.tb_pc.BackgroundText = "PC";
            this.tb_pc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tb_pc.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tb_pc.FontColor = System.Drawing.Color.Red;
            this.tb_pc.ForeColor = System.Drawing.Color.Red;
            this.tb_pc.Location = new System.Drawing.Point(90, 3);
            this.tb_pc.MaxLength = 4;
            this.tb_pc.Name = "tb_pc";
            this.tb_pc.PaddingZero = true;
            this.tb_pc.Size = new System.Drawing.Size(64, 19);
            this.tb_pc.TabIndex = 15;
            // 
            // WriteAllBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.hexOnlyTextbox1);
            this.Controls.Add(this.cfg_user);
            this.Controls.Add(this.pic_pc);
            this.Controls.Add(this.pic_user);
            this.Controls.Add(this.pic_kill);
            this.Controls.Add(this.pic_acc);
            this.Controls.Add(this.pic_epc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_epc);
            this.Controls.Add(this.cb_epc);
            this.Controls.Add(this.cb_pc);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_killpwd);
            this.Controls.Add(this.tb_accpwd);
            this.Controls.Add(this.tb_pc);
            this.Controls.Add(this.cb_userbank);
            this.Controls.Add(this.cb_killpwd);
            this.Controls.Add(this.cb_accpwd);
            this.Name = "WriteAllBank";
            this.Size = new System.Drawing.Size(306, 180);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_accpwd;
        private System.Windows.Forms.CheckBox cb_killpwd;
        private System.Windows.Forms.CheckBox cb_userbank;
        private System.Windows.Forms.Label label3;
        private Custom.Control.HexOnlyTextbox tb_pc;
        private Custom.Control.HexOnlyTextbox tb_epc;
        private Custom.Control.HexOnlyTextbox tb_accpwd;
        private Custom.Control.HexOnlyTextbox tb_killpwd;
        private System.Windows.Forms.CheckBox cb_pc;
        private System.Windows.Forms.CheckBox cb_epc;
        private System.Windows.Forms.PictureBox pic_pc;
        private System.Windows.Forms.PictureBox pic_user;
        private System.Windows.Forms.PictureBox pic_kill;
        private System.Windows.Forms.PictureBox pic_acc;
        private System.Windows.Forms.PictureBox pic_epc;
        private System.Windows.Forms.LinkLabel cfg_user;
        private Custom.Control.HexOnlyTextbox hexOnlyTextbox1;
        private Custom.Control.HexOnlyTextbox tb_user;
    }
}
