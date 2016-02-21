namespace CS203_CALLBACK_API_DEMO
{
    partial class PowerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_pwr = new System.Windows.Forms.Label();
            this.tmr_autohide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Power";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_pwr
            // 
            this.lb_pwr.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lb_pwr.ForeColor = System.Drawing.Color.Green;
            this.lb_pwr.Location = new System.Drawing.Point(3, 21);
            this.lb_pwr.Name = "lb_pwr";
            this.lb_pwr.Size = new System.Drawing.Size(133, 21);
            this.lb_pwr.TabIndex = 0;
            this.lb_pwr.Text = "30 dBm";
            this.lb_pwr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmr_autohide
            // 
            this.tmr_autohide.Interval = 1000;
            this.tmr_autohide.Tick += new System.EventHandler(this.tmr_autohide_Tick);
            // 
            // PowerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(135, 41);
            this.ControlBox = false;
            this.Controls.Add(this.lb_pwr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PowerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PowerForm_Load);
            this.LostFocus += new System.EventHandler(this.PowerForm_LostFocus);
            this.GotFocus += new System.EventHandler(this.PowerForm_GotFocus);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PowerForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_pwr;
        private System.Windows.Forms.Timer tmr_autohide;
    }
}