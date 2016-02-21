namespace CS203_CALLBACK_API_DEMO
{
    partial class StartMenu
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
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.cb_sorting = new System.Windows.Forms.ComboBox();
            this.lb_tagFound = new System.Windows.Forms.Label();
            this.lk_hideMenu = new System.Windows.Forms.LinkLabel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lb_rate = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(3, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(72, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(3, 32);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(72, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(157, 32);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(72, 23);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "Exit";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // cb_sorting
            // 
            this.cb_sorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cb_sorting.ForeColor = System.Drawing.Color.Red;
            this.cb_sorting.Items.Add("EPC(Ascending)");
            this.cb_sorting.Items.Add("EPC(Descending)");
            this.cb_sorting.Items.Add("RSSI(Ascending)");
            this.cb_sorting.Items.Add("RSSI(Decending)");
            this.cb_sorting.Location = new System.Drawing.Point(235, 32);
            this.cb_sorting.Name = "cb_sorting";
            this.cb_sorting.Size = new System.Drawing.Size(82, 23);
            this.cb_sorting.TabIndex = 1;
            this.cb_sorting.SelectedIndexChanged += new System.EventHandler(this.cb_sorting_SelectedIndexChanged);
            // 
            // lb_tagFound
            // 
            this.lb_tagFound.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lb_tagFound.Location = new System.Drawing.Point(81, 3);
            this.lb_tagFound.Name = "lb_tagFound";
            this.lb_tagFound.Size = new System.Drawing.Size(70, 26);
            this.lb_tagFound.Text = "000";
            this.lb_tagFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lk_hideMenu
            // 
            this.lk_hideMenu.Location = new System.Drawing.Point(244, 3);
            this.lk_hideMenu.Name = "lk_hideMenu";
            this.lk_hideMenu.Size = new System.Drawing.Size(76, 23);
            this.lk_hideMenu.TabIndex = 3;
            this.lk_hideMenu.Text = "Hide Menu";
            this.lk_hideMenu.Click += new System.EventHandler(this.lk_hideMenu_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_clear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(79, 32);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(72, 23);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lb_rate
            // 
            this.lb_rate.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lb_rate.Location = new System.Drawing.Point(157, 3);
            this.lb_rate.Name = "lb_rate";
            this.lb_rate.Size = new System.Drawing.Size(72, 26);
            this.lb_rate.Text = "000";
            this.lb_rate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.linkLabel1.Location = new System.Drawing.Point(209, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(39, 20);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.Text = "Tag/s";
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lk_hideMenu);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.cb_sorting);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lb_tagFound);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lb_rate);
            this.Name = "StartMenu";
            this.Size = new System.Drawing.Size(320, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cb_sorting;
        private System.Windows.Forms.Label lb_tagFound;
        private System.Windows.Forms.LinkLabel lk_hideMenu;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lb_rate;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}
