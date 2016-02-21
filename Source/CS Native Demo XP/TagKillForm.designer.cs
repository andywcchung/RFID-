namespace CS203_CALLBACK_API_DEMO
{
    partial class TagKillForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lk_epc = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_kill = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.resultForm1 = new CS203_CALLBACK_API_DEMO.ResultForm();
            this.tb_kill_password = new Custom.Control.HexOnlyTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_extCmd = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 65);
            this.panel1.TabIndex = 13;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(7, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(304, 20);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Tag will be destoryed permanently. ";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Warning :";
            // 
            // lk_epc
            // 
            this.lk_epc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.lk_epc.Location = new System.Drawing.Point(10, 11);
            this.lk_epc.Name = "lk_epc";
            this.lk_epc.Size = new System.Drawing.Size(304, 20);
            this.lk_epc.TabIndex = 1;
            this.lk_epc.TabStop = true;
            this.lk_epc.Text = "Click here to select a tag to destroy.";
            this.lk_epc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lk_epc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_epc_LinkClicked);
            this.lk_epc.Click += new System.EventHandler(this.lk_epc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kill password :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_kill
            // 
            this.btn_kill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_kill.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_kill.Location = new System.Drawing.Point(10, 198);
            this.btn_kill.Name = "btn_kill";
            this.btn_kill.Size = new System.Drawing.Size(107, 39);
            this.btn_kill.TabIndex = 5;
            this.btn_kill.Text = "Kill Tag";
            this.btn_kill.UseVisualStyleBackColor = false;
            this.btn_kill.Click += new System.EventHandler(this.btn_kill_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_exit.Location = new System.Drawing.Point(245, 207);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(72, 20);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // resultForm1
            // 
            this.resultForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.resultForm1.Location = new System.Drawing.Point(82, 70);
            this.resultForm1.Name = "resultForm1";
            this.resultForm1.Size = new System.Drawing.Size(150, 66);
            this.resultForm1.TabIndex = 10;
            this.resultForm1.Visible = false;
            // 
            // tb_kill_password
            // 
            this.tb_kill_password.BackColor = System.Drawing.Color.LightPink;
            this.tb_kill_password.BackgroundText = null;
            this.tb_kill_password.FontColor = System.Drawing.Color.Black;
            this.tb_kill_password.ForeColor = System.Drawing.Color.Black;
            this.tb_kill_password.Location = new System.Drawing.Point(145, 150);
            this.tb_kill_password.MaxLength = 8;
            this.tb_kill_password.Name = "tb_kill_password";
            this.tb_kill_password.PaddingZero = true;
            this.tb_kill_password.Size = new System.Drawing.Size(100, 22);
            this.tb_kill_password.TabIndex = 4;
            this.tb_kill_password.Text = "00000000";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(56, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "ExtCommand";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_extCmd
            // 
            this.cb_extCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_extCmd.FormattingEnabled = true;
            this.cb_extCmd.Items.AddRange(new object[] {
            "Tag Kill",
            "Disable Permalock",
            "Disable User Memory",
            "Unlock all banks"});
            this.cb_extCmd.Location = new System.Drawing.Point(145, 181);
            this.cb_extCmd.Name = "cb_extCmd";
            this.cb_extCmd.Size = new System.Drawing.Size(100, 20);
            this.cb_extCmd.TabIndex = 15;
            // 
            // TagKillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.btn_kill);
            this.Controls.Add(this.cb_extCmd);
            this.Controls.Add(this.resultForm1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.tb_kill_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lk_epc);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TagKillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagKillForm";
            this.Load += new System.EventHandler(this.TagKillForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TagKillForm_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lk_epc;
        private System.Windows.Forms.Label label3;
        private Custom.Control.HexOnlyTextbox tb_kill_password;
        private System.Windows.Forms.Button btn_kill;
        private System.Windows.Forms.Button btn_exit;
        private ResultForm resultForm1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_extCmd;

    }
}