namespace CS203_CALLBACK_API_DEMO
{
    partial class ProfileForm
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
            this.lb_profile = new System.Windows.Forms.Label();
            this.tmr_autohide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link Profile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_profile
            // 
            this.lb_profile.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lb_profile.ForeColor = System.Drawing.Color.Green;
            this.lb_profile.Location = new System.Drawing.Point(0, 20);
            this.lb_profile.Name = "lb_profile";
            this.lb_profile.Size = new System.Drawing.Size(140, 25);
            this.lb_profile.TabIndex = 0;
            this.lb_profile.Text = "1";
            this.lb_profile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmr_autohide
            // 
            this.tmr_autohide.Interval = 1000;
            this.tmr_autohide.Tick += new System.EventHandler(this.tmr_autoclose_Tick);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(140, 45);
            this.ControlBox = false;
            this.Controls.Add(this.lb_profile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.LostFocus += new System.EventHandler(this.ProfileForm_LostFocus);
            this.GotFocus += new System.EventHandler(this.ProfileForm_GotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ProfileForm_Closing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProfileForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_profile;
        private System.Windows.Forms.Timer tmr_autohide;
    }
}