namespace CS203_CALLBACK_API_DEMO
{
    partial class TagWriteAnyEPCForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbCount = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new CSLibrary.Windows.RoundButton();
            this.btnStop = new CSLibrary.Windows.RoundButton();
            this.btnStart = new CSLibrary.Windows.RoundButton();
            this.txtMask = new CSLibrary.Windows.HexOnlyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuccessTag = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nbInitialValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownQvalue = new System.Windows.Forms.NumericUpDown();
            this.radioButton_MatchMask = new System.Windows.Forms.RadioButton();
            this.label_InputMask = new System.Windows.Forms.Label();
            this.hexOnlyTextBox_InputMask = new CSLibrary.Windows.HexOnlyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonNonMatchMask = new System.Windows.Forms.RadioButton();
            this.checkBox_Toggle = new System.Windows.Forms.CheckBox();
            this.numericUpDown_ProcessRetry = new System.Windows.Forms.NumericUpDown();
            this.label_ProcessRetry = new System.Windows.Forms.Label();
            this.label_WriteRetry = new System.Windows.Forms.Label();
            this.numericUpDown_WriteRetry = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nbCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbInitialValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ProcessRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WriteRetry)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Output Mask";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "num of Tags";
            // 
            // nbCount
            // 
            this.nbCount.Location = new System.Drawing.Point(120, 33);
            this.nbCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nbCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbCount.Name = "nbCount";
            this.nbCount.Size = new System.Drawing.Size(195, 22);
            this.nbCount.TabIndex = 3;
            this.nbCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbCount.ValueChanged += new System.EventHandler(this.nbCount_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.BorderLineColor = System.Drawing.Color.Black;
            this.btnExit.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnExit.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnExit.DrawBorderLine = false;
            this.btnExit.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(241, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 35);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.TextMargin = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStop.BorderLineColor = System.Drawing.Color.Black;
            this.btnStop.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnStop.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnStop.DrawBorderLine = false;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(89, 256);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 35);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStop.TextMargin = 0;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.ActiveBackColor = System.Drawing.Color.LightGreen;
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.BorderLineColor = System.Drawing.Color.Black;
            this.btnStart.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnStart.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnStart.DrawBorderLine = false;
            this.btnStart.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(6, 256);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 35);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStart.TextMargin = 0;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtMask
            // 
            this.txtMask.BackgroundText = null;
            this.txtMask.FontColor = System.Drawing.Color.Black;
            this.txtMask.ForeColor = System.Drawing.Color.Gray;
            this.txtMask.Location = new System.Drawing.Point(120, 97);
            this.txtMask.MaxLength = 23;
            this.txtMask.Name = "txtMask";
            this.txtMask.PaddingZero = true;
            this.txtMask.Size = new System.Drawing.Size(195, 22);
            this.txtMask.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(7, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Successful Written Tag";
            // 
            // txtSuccessTag
            // 
            this.txtSuccessTag.Font = new System.Drawing.Font("Tahoma", 24F);
            this.txtSuccessTag.ForeColor = System.Drawing.Color.Red;
            this.txtSuccessTag.Location = new System.Drawing.Point(147, 211);
            this.txtSuccessTag.Name = "txtSuccessTag";
            this.txtSuccessTag.Size = new System.Drawing.Size(53, 39);
            this.txtSuccessTag.TabIndex = 0;
            this.txtSuccessTag.Text = "0";
            this.txtSuccessTag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtSuccessTag.Click += new System.EventHandler(this.txtSuccessTag_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Initial Value(decimal)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nbInitialValue
            // 
            this.nbInitialValue.Location = new System.Drawing.Point(120, 53);
            this.nbInitialValue.Maximum = new decimal(new int[] {
            6553500,
            0,
            0,
            0});
            this.nbInitialValue.Name = "nbInitialValue";
            this.nbInitialValue.Size = new System.Drawing.Size(195, 22);
            this.nbInitialValue.TabIndex = 3;
            this.nbInitialValue.ValueChanged += new System.EventHandler(this.nbCount_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fix Q Value";
            // 
            // numericUpDownQvalue
            // 
            this.numericUpDownQvalue.Location = new System.Drawing.Point(120, 119);
            this.numericUpDownQvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownQvalue.Name = "numericUpDownQvalue";
            this.numericUpDownQvalue.Size = new System.Drawing.Size(195, 22);
            this.numericUpDownQvalue.TabIndex = 12;
            // 
            // radioButton_MatchMask
            // 
            this.radioButton_MatchMask.AutoSize = true;
            this.radioButton_MatchMask.Location = new System.Drawing.Point(179, 171);
            this.radioButton_MatchMask.Name = "radioButton_MatchMask";
            this.radioButton_MatchMask.Size = new System.Drawing.Size(80, 16);
            this.radioButton_MatchMask.TabIndex = 13;
            this.radioButton_MatchMask.TabStop = true;
            this.radioButton_MatchMask.Text = "Match Mask";
            this.radioButton_MatchMask.UseVisualStyleBackColor = true;
            this.radioButton_MatchMask.CheckedChanged += new System.EventHandler(this.radioButton_MatchMask_CheckedChanged);
            // 
            // label_InputMask
            // 
            this.label_InputMask.Enabled = false;
            this.label_InputMask.Location = new System.Drawing.Point(5, 78);
            this.label_InputMask.Name = "label_InputMask";
            this.label_InputMask.Size = new System.Drawing.Size(77, 13);
            this.label_InputMask.TabIndex = 16;
            this.label_InputMask.Text = "Input Mask";
            // 
            // hexOnlyTextBox_InputMask
            // 
            this.hexOnlyTextBox_InputMask.BackgroundText = null;
            this.hexOnlyTextBox_InputMask.Enabled = false;
            this.hexOnlyTextBox_InputMask.FontColor = System.Drawing.Color.Black;
            this.hexOnlyTextBox_InputMask.ForeColor = System.Drawing.Color.Gray;
            this.hexOnlyTextBox_InputMask.Location = new System.Drawing.Point(120, 75);
            this.hexOnlyTextBox_InputMask.MaxLength = 23;
            this.hexOnlyTextBox_InputMask.Name = "hexOnlyTextBox_InputMask";
            this.hexOnlyTextBox_InputMask.PaddingZero = true;
            this.hexOnlyTextBox_InputMask.Size = new System.Drawing.Size(195, 22);
            this.hexOnlyTextBox_InputMask.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label6.Location = new System.Drawing.Point(5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(310, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Write EPC auto increment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radioButtonNonMatchMask
            // 
            this.radioButtonNonMatchMask.AutoSize = true;
            this.radioButtonNonMatchMask.Checked = true;
            this.radioButtonNonMatchMask.Location = new System.Drawing.Point(179, 189);
            this.radioButtonNonMatchMask.Name = "radioButtonNonMatchMask";
            this.radioButtonNonMatchMask.Size = new System.Drawing.Size(103, 16);
            this.radioButtonNonMatchMask.TabIndex = 14;
            this.radioButtonNonMatchMask.TabStop = true;
            this.radioButtonNonMatchMask.Text = "Non Match Mask";
            this.radioButtonNonMatchMask.UseVisualStyleBackColor = true;
            this.radioButtonNonMatchMask.CheckedChanged += new System.EventHandler(this.radioButtonNonMatchMask_CheckedChanged);
            // 
            // checkBox_Toggle
            // 
            this.checkBox_Toggle.AutoSize = true;
            this.checkBox_Toggle.Checked = true;
            this.checkBox_Toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Toggle.Location = new System.Drawing.Point(179, 147);
            this.checkBox_Toggle.Name = "checkBox_Toggle";
            this.checkBox_Toggle.Size = new System.Drawing.Size(79, 16);
            this.checkBox_Toggle.TabIndex = 20;
            this.checkBox_Toggle.Text = "Toggle A/B";
            this.checkBox_Toggle.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_ProcessRetry
            // 
            this.numericUpDown_ProcessRetry.Location = new System.Drawing.Point(89, 147);
            this.numericUpDown_ProcessRetry.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_ProcessRetry.Name = "numericUpDown_ProcessRetry";
            this.numericUpDown_ProcessRetry.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown_ProcessRetry.TabIndex = 21;
            // 
            // label_ProcessRetry
            // 
            this.label_ProcessRetry.AutoSize = true;
            this.label_ProcessRetry.Location = new System.Drawing.Point(5, 149);
            this.label_ProcessRetry.Name = "label_ProcessRetry";
            this.label_ProcessRetry.Size = new System.Drawing.Size(68, 12);
            this.label_ProcessRetry.TabIndex = 22;
            this.label_ProcessRetry.Text = "Process Retry";
            // 
            // label_WriteRetry
            // 
            this.label_WriteRetry.AutoSize = true;
            this.label_WriteRetry.Location = new System.Drawing.Point(5, 171);
            this.label_WriteRetry.Name = "label_WriteRetry";
            this.label_WriteRetry.Size = new System.Drawing.Size(60, 12);
            this.label_WriteRetry.TabIndex = 23;
            this.label_WriteRetry.Text = "Write Retry";
            // 
            // numericUpDown_WriteRetry
            // 
            this.numericUpDown_WriteRetry.Location = new System.Drawing.Point(89, 169);
            this.numericUpDown_WriteRetry.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_WriteRetry.Name = "numericUpDown_WriteRetry";
            this.numericUpDown_WriteRetry.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown_WriteRetry.TabIndex = 24;
            this.numericUpDown_WriteRetry.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TagWriteAnyEPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(329, 301);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDown_WriteRetry);
            this.Controls.Add(this.label_WriteRetry);
            this.Controls.Add(this.label_ProcessRetry);
            this.Controls.Add(this.numericUpDown_ProcessRetry);
            this.Controls.Add(this.checkBox_Toggle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_InputMask);
            this.Controls.Add(this.hexOnlyTextBox_InputMask);
            this.Controls.Add(this.radioButtonNonMatchMask);
            this.Controls.Add(this.radioButton_MatchMask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownQvalue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSuccessTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.nbInitialValue);
            this.Controls.Add(this.nbCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagWriteAnyEPCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS10 WriteAny Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagWriteAnyEPCForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nbCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbInitialValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ProcessRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WriteRetry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbCount;
        private CSLibrary.Windows.HexOnlyTextBox txtMask;
        private CSLibrary.Windows.RoundButton btnStart;
        private CSLibrary.Windows.RoundButton btnStop;
        private CSLibrary.Windows.RoundButton btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtSuccessTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nbInitialValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownQvalue;
        private System.Windows.Forms.RadioButton radioButton_MatchMask;
        private System.Windows.Forms.Label label_InputMask;
        private CSLibrary.Windows.HexOnlyTextBox hexOnlyTextBox_InputMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonNonMatchMask;
        private System.Windows.Forms.CheckBox checkBox_Toggle;
        private System.Windows.Forms.NumericUpDown numericUpDown_ProcessRetry;
        private System.Windows.Forms.Label label_ProcessRetry;
        private System.Windows.Forms.Label label_WriteRetry;
        private System.Windows.Forms.NumericUpDown numericUpDown_WriteRetry;
    }
}

