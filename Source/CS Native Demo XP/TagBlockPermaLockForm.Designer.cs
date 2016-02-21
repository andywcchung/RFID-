namespace CS203_CALLBACK_API_DEMO
{
    partial class TagBlockPermaLockForm
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
            this.components = new System.ComponentModel.Container();
            this.lb_epc = new System.Windows.Forms.LinkLabel();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_lock = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_lock = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_lock = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_unchanged = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_password = new Custom.Control.HexOnlyTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_epc
            // 
            this.lb_epc.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lb_epc.Location = new System.Drawing.Point(12, 9);
            this.lb_epc.Name = "lb_epc";
            this.lb_epc.Size = new System.Drawing.Size(294, 23);
            this.lb_epc.TabIndex = 0;
            this.lb_epc.TabStop = true;
            this.lb_epc.Text = "Please click here to select a tag";
            this.lb_epc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_epc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_epc_LinkClicked);
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(12, 160);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 4;
            this.btn_read.Text = "Read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_lock
            // 
            this.btn_lock.Location = new System.Drawing.Point(12, 203);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(75, 23);
            this.btn_lock.TabIndex = 4;
            this.btn_lock.Text = "Lock";
            this.btn_lock.UseVisualStyleBackColor = true;
            this.btn_lock.Click += new System.EventHandler(this.btn_lock_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(93, 203);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Access Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_lock
            // 
            this.lv_lock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_lock.ContextMenuStrip = this.contextMenuStrip1;
            this.lv_lock.FullRowSelect = true;
            this.lv_lock.GridLines = true;
            this.lv_lock.Location = new System.Drawing.Point(174, 35);
            this.lv_lock.Name = "lv_lock";
            this.lv_lock.Size = new System.Drawing.Size(143, 191);
            this.lv_lock.TabIndex = 9;
            this.lv_lock.UseCompatibleStateImageBehavior = false;
            this.lv_lock.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Block";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Locked";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_lock,
            this.menu_unchanged});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // menu_lock
            // 
            this.menu_lock.AutoToolTip = true;
            this.menu_lock.Name = "menu_lock";
            this.menu_lock.Size = new System.Drawing.Size(98, 22);
            this.menu_lock.Text = "PermLock";
            this.menu_lock.ToolTipText = "lock this block permanently";
            this.menu_lock.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menu_unchanged
            // 
            this.menu_unchanged.Name = "menu_unchanged";
            this.menu_unchanged.Size = new System.Drawing.Size(98, 22);
            this.menu_unchanged.Text = "Unchanged";
            this.menu_unchanged.ToolTipText = "unchange";
            this.menu_unchanged.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.LightPink;
            this.tb_password.BackgroundText = null;
            this.tb_password.FontColor = System.Drawing.Color.Black;
            this.tb_password.ForeColor = System.Drawing.Color.Black;
            this.tb_password.Location = new System.Drawing.Point(12, 123);
            this.tb_password.MaxLength = 8;
            this.tb_password.Name = "tb_password";
            this.tb_password.PaddingZero = true;
            this.tb_password.Size = new System.Drawing.Size(141, 22);
            this.tb_password.TabIndex = 6;
            this.tb_password.Text = "00000000";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 62);
            this.label1.TabIndex = 10;
            this.label1.Text = "512 bit User memory Permalock, with 64 bit block-size";
            // 
            // TagBlockPermaLockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(318, 234);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_lock);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_lock);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.lb_epc);
            this.Name = "TagBlockPermaLockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagBlockPermaLockForm";
            this.Load += new System.EventHandler(this.TagBlockPermaLockForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagBlockPermaLockForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lb_epc;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_lock;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label4;
        private Custom.Control.HexOnlyTextbox tb_password;
        private System.Windows.Forms.ListView lv_lock;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_lock;
        private System.Windows.Forms.ToolStripMenuItem menu_unchanged;
        private System.Windows.Forms.Label label1;
    }
}