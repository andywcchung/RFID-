namespace CS203_CALLBACK_API_DEMO
{
    partial class TagSecurityForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_kill = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_acc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_epc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_tid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_user = new System.Windows.Forms.ComboBox();
            this.btn_applysec = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lk_epc = new System.Windows.Forms.LinkLabel();
            this.resultForm1 = new CS203_CALLBACK_API_DEMO.ResultForm();
            this.tb_pwd = new Custom.Control.HexOnlyTextbox();
            this.btn_permlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Kill Pwd";
            // 
            // cb_kill
            // 
            this.cb_kill.Items.AddRange(new object[] {
            "UNLOCK",
            "PERM_UNLOCK",
            "LOCK",
            "PERM_LOCK",
            "UNCHANGED"});
            this.cb_kill.Location = new System.Drawing.Point(66, 40);
            this.cb_kill.Name = "cb_kill";
            this.cb_kill.Size = new System.Drawing.Size(205, 20);
            this.cb_kill.TabIndex = 3;
            this.cb_kill.SelectedIndexChanged += new System.EventHandler(this.cb_kill_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Acc Pwd";
            // 
            // cb_acc
            // 
            this.cb_acc.Items.AddRange(new object[] {
            "UNLOCK",
            "PERM_UNLOCK",
            "LOCK",
            "PERM_LOCK",
            "UNCHANGED"});
            this.cb_acc.Location = new System.Drawing.Point(66, 69);
            this.cb_acc.Name = "cb_acc";
            this.cb_acc.Size = new System.Drawing.Size(205, 20);
            this.cb_acc.TabIndex = 3;
            this.cb_acc.SelectedIndexChanged += new System.EventHandler(this.cb_acc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "EPC";
            // 
            // cb_epc
            // 
            this.cb_epc.Items.AddRange(new object[] {
            "UNLOCK",
            "PERM_UNLOCK",
            "LOCK",
            "PERM_LOCK",
            "UNCHANGED"});
            this.cb_epc.Location = new System.Drawing.Point(66, 98);
            this.cb_epc.Name = "cb_epc";
            this.cb_epc.Size = new System.Drawing.Size(205, 20);
            this.cb_epc.TabIndex = 3;
            this.cb_epc.SelectedIndexChanged += new System.EventHandler(this.cb_epc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "TID";
            // 
            // cb_tid
            // 
            this.cb_tid.Items.AddRange(new object[] {
            "UNLOCK",
            "PERM_UNLOCK",
            "LOCK",
            "PERM_LOCK",
            "UNCHANGED"});
            this.cb_tid.Location = new System.Drawing.Point(66, 127);
            this.cb_tid.Name = "cb_tid";
            this.cb_tid.Size = new System.Drawing.Size(205, 20);
            this.cb_tid.TabIndex = 3;
            this.cb_tid.SelectedIndexChanged += new System.EventHandler(this.cb_tid_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "USER";
            // 
            // cb_user
            // 
            this.cb_user.Items.AddRange(new object[] {
            "UNLOCK",
            "PERM_UNLOCK",
            "LOCK",
            "PERM_LOCK",
            "UNCHANGED"});
            this.cb_user.Location = new System.Drawing.Point(66, 156);
            this.cb_user.Name = "cb_user";
            this.cb_user.Size = new System.Drawing.Size(205, 20);
            this.cb_user.TabIndex = 3;
            this.cb_user.SelectedIndexChanged += new System.EventHandler(this.cb_user_SelectedIndexChanged);
            // 
            // btn_applysec
            // 
            this.btn_applysec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_applysec.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_applysec.Location = new System.Drawing.Point(3, 208);
            this.btn_applysec.Name = "btn_applysec";
            this.btn_applysec.Size = new System.Drawing.Size(120, 25);
            this.btn_applysec.TabIndex = 9;
            this.btn_applysec.Text = "Apply Security";
            this.btn_applysec.UseVisualStyleBackColor = false;
            this.btn_applysec.Click += new System.EventHandler(this.btn_applysec_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(267, 212);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(50, 20);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Access password";
            // 
            // lk_epc
            // 
            this.lk_epc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Underline);
            this.lk_epc.Location = new System.Drawing.Point(3, 0);
            this.lk_epc.Name = "lk_epc";
            this.lk_epc.Size = new System.Drawing.Size(314, 32);
            this.lk_epc.TabIndex = 24;
            this.lk_epc.TabStop = true;
            this.lk_epc.Text = "Please Click Here To Select A Tag";
            this.lk_epc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lk_epc.Click += new System.EventHandler(this.lk_epc_Click);
            // 
            // resultForm1
            // 
            this.resultForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.resultForm1.Location = new System.Drawing.Point(80, 55);
            this.resultForm1.Name = "resultForm1";
            this.resultForm1.Size = new System.Drawing.Size(150, 66);
            this.resultForm1.TabIndex = 31;
            this.resultForm1.Visible = false;
            // 
            // tb_pwd
            // 
            this.tb_pwd.BackColor = System.Drawing.Color.LightPink;
            this.tb_pwd.BackgroundText = null;
            this.tb_pwd.FontColor = System.Drawing.Color.Black;
            this.tb_pwd.ForeColor = System.Drawing.Color.Black;
            this.tb_pwd.Location = new System.Drawing.Point(171, 186);
            this.tb_pwd.MaxLength = 8;
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PaddingZero = true;
            this.tb_pwd.Size = new System.Drawing.Size(100, 22);
            this.tb_pwd.TabIndex = 18;
            this.tb_pwd.Text = "00000000";
            // 
            // btn_permlock
            // 
            this.btn_permlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_permlock.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_permlock.Location = new System.Drawing.Point(129, 208);
            this.btn_permlock.Name = "btn_permlock";
            this.btn_permlock.Size = new System.Drawing.Size(132, 25);
            this.btn_permlock.TabIndex = 9;
            this.btn_permlock.Text = "User Perm-lock";
            this.btn_permlock.UseVisualStyleBackColor = false;
            this.btn_permlock.Click += new System.EventHandler(this.btn_permlock_Click);
            // 
            // TagSecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.resultForm1);
            this.Controls.Add(this.lk_epc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_permlock);
            this.Controls.Add(this.btn_applysec);
            this.Controls.Add(this.cb_user);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_tid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_epc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_acc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_kill);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TagSecurityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagSecurityForm";
            this.Load += new System.EventHandler(this.TagSecurityForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TagSecurityForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_kill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_acc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_epc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_tid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_user;
        private System.Windows.Forms.Button btn_applysec;
        private System.Windows.Forms.Button btn_exit;
        private Custom.Control.HexOnlyTextbox tb_pwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lk_epc;
        private ResultForm resultForm1;
        private System.Windows.Forms.Button btn_permlock;
    }
}