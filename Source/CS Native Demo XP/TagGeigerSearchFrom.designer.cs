namespace CS203_CALLBACK_API_DEMO
{
    partial class GeigerSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeigerSearchForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pg_rssi = new Custom.Control.ProgressBar();
            this.cb_averaging = new System.Windows.Forms.CheckBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tk_threshold = new System.Windows.Forms.TrackBar();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.tmr_ZeroDetector = new System.Windows.Forms.Timer(this.components);
            this.lb_rssi = new System.Windows.Forms.Label();
            this.tmr_tone = new System.Windows.Forms.Timer(this.components);
            this.btn_scan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_threshold = new System.Windows.Forms.Label();
            this.tb_epc = new Custom.Control.HexOnlyTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tk_threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(283, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "100";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(140, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "50";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pg_rssi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 74);
            this.panel1.TabIndex = 17;
            // 
            // pg_rssi
            // 
            this.pg_rssi.BackgroundDrawMethod = Custom.Control.ProgressBar.DrawMethod.Stretch;
            this.pg_rssi.BackgroundLeadingSize = 12;
            this.pg_rssi.BackgroundPicture = ((System.Drawing.Image)(resources.GetObject("pg_rssi.BackgroundPicture")));
            this.pg_rssi.BackgroundTrailingSize = 12;
            this.pg_rssi.ForegroundDrawMethod = Custom.Control.ProgressBar.DrawMethod.Stretch;
            this.pg_rssi.ForegroundLeadingSize = 0;
            this.pg_rssi.ForegroundPicture = ((System.Drawing.Image)(resources.GetObject("pg_rssi.ForegroundPicture")));
            this.pg_rssi.ForegroundTrailingSize = 0;
            this.pg_rssi.Location = new System.Drawing.Point(2, 32);
            this.pg_rssi.Marquee = Custom.Control.ProgressBar.MarqueeStyle.TileWrap;
            this.pg_rssi.MarqueeWidth = 10;
            this.pg_rssi.Maximum = 100;
            this.pg_rssi.Minimum = 0;
            this.pg_rssi.Name = "pg_rssi";
            this.pg_rssi.OverlayDrawMethod = Custom.Control.ProgressBar.DrawMethod.Stretch;
            this.pg_rssi.OverlayLeadingSize = 12;
            this.pg_rssi.OverlayPicture = ((System.Drawing.Image)(resources.GetObject("pg_rssi.OverlayPicture")));
            this.pg_rssi.OverlayTrailingSize = 12;
            this.pg_rssi.Size = new System.Drawing.Size(314, 37);
            this.pg_rssi.TabIndex = 1;
            this.pg_rssi.Type = Custom.Control.ProgressBar.BarType.Progress;
            this.pg_rssi.Value = 0;
            // 
            // cb_averaging
            // 
            this.cb_averaging.Checked = true;
            this.cb_averaging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_averaging.Location = new System.Drawing.Point(0, 120);
            this.cb_averaging.Name = "cb_averaging";
            this.cb_averaging.Size = new System.Drawing.Size(122, 20);
            this.cb_averaging.TabIndex = 11;
            this.cb_averaging.Text = "Averaging RSSI";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btn_start.Location = new System.Drawing.Point(3, 188);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(88, 73);
            this.btn_start.TabIndex = 14;
            this.btn_start.Text = "Geiger";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(226, 234);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(90, 27);
            this.btn_exit.TabIndex = 14;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tk_threshold
            // 
            this.tk_threshold.LargeChange = 1;
            this.tk_threshold.Location = new System.Drawing.Point(3, 143);
            this.tk_threshold.Maximum = 100;
            this.tk_threshold.Minimum = 61;
            this.tk_threshold.Name = "tk_threshold";
            this.tk_threshold.Size = new System.Drawing.Size(313, 45);
            this.tk_threshold.TabIndex = 15;
            this.tk_threshold.Value = 75;
            this.tk_threshold.ValueChanged += new System.EventHandler(this.tk_threshold_ValueChanged);
            // 
            // cb_sound
            // 
            this.cb_sound.Checked = true;
            this.cb_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sound.Location = new System.Drawing.Point(128, 120);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(66, 20);
            this.cb_sound.TabIndex = 16;
            this.cb_sound.Text = "Tone";
            this.cb_sound.CheckStateChanged += new System.EventHandler(this.cb_sound_CheckStateChanged);
            // 
            // tmr_ZeroDetector
            // 
            this.tmr_ZeroDetector.Interval = 500;
            this.tmr_ZeroDetector.Tick += new System.EventHandler(this.tmr_ZeroDetector_Tick);
            // 
            // lb_rssi
            // 
            this.lb_rssi.Font = new System.Drawing.Font("Arial", 36F);
            this.lb_rssi.ForeColor = System.Drawing.Color.Red;
            this.lb_rssi.Location = new System.Drawing.Point(106, 191);
            this.lb_rssi.Name = "lb_rssi";
            this.lb_rssi.Size = new System.Drawing.Size(114, 66);
            this.lb_rssi.TabIndex = 2;
            this.lb_rssi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmr_tone
            // 
            this.tmr_tone.Interval = 1000;
            this.tmr_tone.Tick += new System.EventHandler(this.tmr_tone_Tick);
            // 
            // btn_scan
            // 
            this.btn_scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_scan.Font = new System.Drawing.Font("Arial", 14F);
            this.btn_scan.Location = new System.Drawing.Point(226, 188);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(91, 40);
            this.btn_scan.TabIndex = 14;
            this.btn_scan.Text = "Select";
            this.btn_scan.UseVisualStyleBackColor = false;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(200, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Threshold";
            // 
            // lb_threshold
            // 
            this.lb_threshold.Location = new System.Drawing.Point(271, 122);
            this.lb_threshold.Name = "lb_threshold";
            this.lb_threshold.Size = new System.Drawing.Size(45, 20);
            this.lb_threshold.TabIndex = 0;
            // 
            // tb_epc
            // 
            this.tb_epc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_epc.BackgroundText = null;
            this.tb_epc.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_epc.FontColor = System.Drawing.Color.Black;
            this.tb_epc.ForeColor = System.Drawing.Color.Gray;
            this.tb_epc.Location = new System.Drawing.Point(0, 83);
            this.tb_epc.MaxLength = 24;
            this.tb_epc.Name = "tb_epc";
            this.tb_epc.PaddingZero = false;
            this.tb_epc.Size = new System.Drawing.Size(320, 26);
            this.tb_epc.TabIndex = 10;
            this.tb_epc.TextChanged += new System.EventHandler(this.tb_epc_TextChanged);
            // 
            // GeigerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 273);
            this.ControlBox = false;
            this.Controls.Add(this.lb_threshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_rssi);
            this.Controls.Add(this.cb_sound);
            this.Controls.Add(this.tk_threshold);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.cb_averaging);
            this.Controls.Add(this.tb_epc);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GeigerSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeigerSearchFrom";
            this.Load += new System.EventHandler(this.GeigerSearchForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GeigerSearchForm_Closing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tk_threshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.Control.ProgressBar pg_rssi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private Custom.Control.HexOnlyTextbox tb_epc;
        private System.Windows.Forms.CheckBox cb_averaging;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TrackBar tk_threshold;
        private System.Windows.Forms.CheckBox cb_sound;
        private System.Windows.Forms.Timer tmr_ZeroDetector;
        private System.Windows.Forms.Label lb_rssi;
        private System.Windows.Forms.Timer tmr_tone;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_threshold;
    }
}