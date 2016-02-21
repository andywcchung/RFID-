namespace CS203_CALLBACK_API_DEMO
{
    partial class ConfigOffset
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.word = new System.Windows.Forms.NumericUpDown();
            this.offset = new System.Windows.Forms.NumericUpDown();
            this.wordLabel = new System.Windows.Forms.Label();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.word)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offset)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cancel.Location = new System.Drawing.Point(115, 89);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(60, 20);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ok.Location = new System.Drawing.Point(12, 89);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(60, 20);
            this.ok.TabIndex = 9;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // word
            // 
            this.word.Location = new System.Drawing.Point(75, 59);
            this.word.Maximum = new decimal(new int[] {
            2046,
            0,
            0,
            0});
            this.word.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(100, 22);
            this.word.TabIndex = 7;
            this.word.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(75, 28);
            this.offset.Maximum = new decimal(new int[] {
            2046,
            0,
            0,
            0});
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(100, 22);
            this.offset.TabIndex = 6;
            // 
            // wordLabel
            // 
            this.wordLabel.Location = new System.Drawing.Point(3, 63);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(69, 20);
            this.wordLabel.TabIndex = 10;
            this.wordLabel.Text = "Word";
            // 
            // offsetLabel
            // 
            this.offsetLabel.Location = new System.Drawing.Point(3, 32);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(69, 20);
            this.offsetLabel.TabIndex = 11;
            this.offsetLabel.Text = "Offset";
            // 
            // header
            // 
            this.header.Location = new System.Drawing.Point(3, 5);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(182, 20);
            this.header.TabIndex = 0;
            this.header.Text = "Configuration";
            this.header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConfigOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(186, 119);
            this.ControlBox = false;
            this.Controls.Add(this.header);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.word);
            this.Controls.Add(this.offset);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.offsetLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigOffset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.word)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.NumericUpDown word;
        private System.Windows.Forms.NumericUpDown offset;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.Label header;
    }
}
