namespace CS203_CALLBACK_API_DEMO
{
    partial class FormColdChainMonitorConfig
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxD8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxD9 = new System.Windows.Forms.TextBox();
            this.labelASI = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelASSD = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.Items.Add("1s");
            this.comboBox2.Items.Add("1m");
            this.comboBox2.Items.Add("1h");
            this.comboBox2.Items.Add("5m");
            this.comboBox2.Location = new System.Drawing.Point(256, 74);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 23);
            this.comboBox2.TabIndex = 41;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("1s");
            this.comboBox1.Items.Add("1m");
            this.comboBox1.Items.Add("1h");
            this.comboBox1.Items.Add("Follow SI");
            this.comboBox1.Location = new System.Drawing.Point(256, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(62, 23);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(169, 74);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(53, 23);
            this.textBox6.TabIndex = 39;
            this.textBox6.Text = "1";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.textBox6.Validating += new System.ComponentModel.CancelEventHandler(this.textBox6_Validating);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(169, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(53, 23);
            this.textBox5.TabIndex = 38;
            this.textBox5.Text = "1";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.Validating += new System.ComponentModel.CancelEventHandler(this.textBox5_Validating);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 21);
            this.label6.Text = "Sampling Start Delay (0-63)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 21);
            this.label5.Text = "Sampling Interval (0-63)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(237, 7);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(53, 23);
            this.textBox4.TabIndex = 37;
            this.textBox4.Text = "10";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(147, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(53, 23);
            this.textBox3.TabIndex = 36;
            this.textBox3.Text = "-10";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(206, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.Text = "Over";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 21);
            this.label3.Text = "Temp Threshold : Under";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(228, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.Text = "Unit";
            this.label8.ParentChanged += new System.EventHandler(this.label8_ParentChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 31);
            this.button1.TabIndex = 48;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 40);
            this.label1.Text = "# of count for alarm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.ParentChanged += new System.EventHandler(this.label1_ParentChanged);
            // 
            // textBoxD8
            // 
            this.textBoxD8.Location = new System.Drawing.Point(147, 33);
            this.textBoxD8.Name = "textBoxD8";
            this.textBoxD8.Size = new System.Drawing.Size(53, 23);
            this.textBoxD8.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(206, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 21);
            this.label9.Text = "Over";
            this.label9.ParentChanged += new System.EventHandler(this.label9_ParentChanged);
            // 
            // textBoxD9
            // 
            this.textBoxD9.Location = new System.Drawing.Point(237, 33);
            this.textBoxD9.Name = "textBoxD9";
            this.textBoxD9.Size = new System.Drawing.Size(53, 23);
            this.textBoxD9.TabIndex = 60;
            // 
            // labelASI
            // 
            this.labelASI.Location = new System.Drawing.Point(192, 97);
            this.labelASI.Name = "labelASI";
            this.labelASI.Size = new System.Drawing.Size(123, 19);
            this.labelASI.Text = "label";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(3, 97);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(200, 19);
            this.label20.Text = "Actual Sampling Interval (S.I.) : ";
            // 
            // labelASSD
            // 
            this.labelASSD.Location = new System.Drawing.Point(194, 146);
            this.labelASSD.Name = "labelASSD";
            this.labelASSD.Size = new System.Drawing.Size(121, 23);
            this.labelASSD.Text = "label";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(5, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(195, 23);
            this.label21.Text = "Actual Sampling Start Delay :";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(228, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.Text = "Unit";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(100, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.Text = ": Under";
            // 
            // FormColdChainMonitorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 215);
            this.Controls.Add(this.textBoxD8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.labelASSD);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.labelASI);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxD9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "FormColdChainMonitorConfig";
            this.Text = "FormColdChainMonitorConfig";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxD8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxD9;
        private System.Windows.Forms.Label labelASI;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelASSD;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}