namespace CS203_CALLBACK_API_DEMO
{
    partial class MenuBar
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
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.pnl_btn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_up
            // 
            this.btn_up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_up.Location = new System.Drawing.Point(0, 0);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(96, 24);
            this.btn_up.TabIndex = 0;
            this.btn_up.Text = "Up";
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_down
            // 
            this.btn_down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_down.Location = new System.Drawing.Point(0, 216);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(96, 24);
            this.btn_down.TabIndex = 0;
            this.btn_down.Text = "Down";
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // pnl_btn
            // 
            this.pnl_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnl_btn.Location = new System.Drawing.Point(0, 24);
            this.pnl_btn.Name = "pnl_btn";
            this.pnl_btn.Size = new System.Drawing.Size(96, 192);
            // 
            // MenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.pnl_btn);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.btn_down);
            this.Name = "MenuBar";
            this.Size = new System.Drawing.Size(96, 240);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Panel pnl_btn;
    }
}
