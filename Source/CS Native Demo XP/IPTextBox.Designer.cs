namespace CS203_CALLBACK_API_DEMO
{
    partial class IPTextBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numBox1 = new NumBox();
            this.numBox2 = new NumBox();
            this.numBox3 = new NumBox();
            this.numBox4 = new NumBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = ".";
            // 
            // numBox1
            // 
            this.numBox1.BackColor = System.Drawing.SystemColors.Info;
            this.numBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBox1.Location = new System.Drawing.Point(3, 3);
            this.numBox1.MaxLength = 3;
            this.numBox1.Name = "numBox1";
            this.numBox1.Size = new System.Drawing.Size(36, 19);
            this.numBox1.TabIndex = 1;
            this.numBox1.Text = "192";
            this.numBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numBox2
            // 
            this.numBox2.BackColor = System.Drawing.SystemColors.Info;
            this.numBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBox2.Location = new System.Drawing.Point(64, 3);
            this.numBox2.MaxLength = 3;
            this.numBox2.Name = "numBox2";
            this.numBox2.Size = new System.Drawing.Size(36, 19);
            this.numBox2.TabIndex = 2;
            this.numBox2.Text = "168";
            this.numBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numBox3
            // 
            this.numBox3.BackColor = System.Drawing.SystemColors.Info;
            this.numBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBox3.Location = new System.Drawing.Point(125, 3);
            this.numBox3.MaxLength = 3;
            this.numBox3.Name = "numBox3";
            this.numBox3.Size = new System.Drawing.Size(36, 19);
            this.numBox3.TabIndex = 3;
            this.numBox3.Text = "25";
            this.numBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numBox4
            // 
            this.numBox4.BackColor = System.Drawing.SystemColors.Info;
            this.numBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBox4.Location = new System.Drawing.Point(186, 3);
            this.numBox4.MaxLength = 3;
            this.numBox4.Name = "numBox4";
            this.numBox4.Size = new System.Drawing.Size(36, 19);
            this.numBox4.TabIndex = 4;
            this.numBox4.Text = "203";
            this.numBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.numBox4);
            this.Controls.Add(this.numBox3);
            this.Controls.Add(this.numBox2);
            this.Controls.Add(this.numBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IPTextBox";
            this.Size = new System.Drawing.Size(226, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private NumBox numBox1;
        private NumBox numBox2;
        private NumBox numBox3;
        private NumBox numBox4;
    }
}
