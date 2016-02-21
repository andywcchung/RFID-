namespace CS203_CALLBACK_API_DEMO
{
    partial class FormG2iLFuncTest
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
            this.textBoxTagID = new System.Windows.Forms.TextBox();
            this.buttonSlecetTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTagID
            // 
            this.textBoxTagID.Location = new System.Drawing.Point(195, 13);
            this.textBoxTagID.Name = "textBoxTagID";
            this.textBoxTagID.Size = new System.Drawing.Size(221, 22);
            this.textBoxTagID.TabIndex = 57;
            // 
            // buttonSlecetTag
            // 
            this.buttonSlecetTag.Location = new System.Drawing.Point(63, 12);
            this.buttonSlecetTag.Name = "buttonSlecetTag";
            this.buttonSlecetTag.Size = new System.Drawing.Size(126, 23);
            this.buttonSlecetTag.TabIndex = 56;
            this.buttonSlecetTag.Text = "Select Tag";
            this.buttonSlecetTag.UseVisualStyleBackColor = true;
            this.buttonSlecetTag.Click += new System.EventHandler(this.buttonSlecetTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(195, 41);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(125, 22);
            this.textBoxPassword.TabIndex = 58;
            this.textBoxPassword.Text = "00000000";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 31);
            this.button2.TabIndex = 62;
            this.button2.Text = "Read Status";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(534, 47);
            this.label2.TabIndex = 83;
            this.label2.Text = "Please select tag";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 84;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormG2iLFuncTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 204);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxTagID);
            this.Controls.Add(this.buttonSlecetTag);
            this.Name = "FormG2iLFuncTest";
            this.Text = "G2iL/M demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormG2iLM_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTagID;
        private System.Windows.Forms.Button buttonSlecetTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}