namespace CS203_CALLBACK_API_DEMO
{
    partial class AntennaPortCfgForm
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
            this.rxPhysicalPort = new System.Windows.Forms.TextBox();
            this.senseThreshold = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.powerLevel = new System.Windows.Forms.NumericUpDown();
            this.inventoryCycles = new System.Windows.Forms.NumericUpDown();
            this.dwellTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.ComboBox();
            this.antennaNumberLabel = new System.Windows.Forms.Label();
            this.txPhysicalPort = new System.Windows.Forms.TextBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_enable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.senseThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwellTime)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rxPhysicalPort
            // 
            this.rxPhysicalPort.Location = new System.Drawing.Point(367, 21);
            this.rxPhysicalPort.Name = "rxPhysicalPort";
            this.rxPhysicalPort.ReadOnly = true;
            this.rxPhysicalPort.Size = new System.Drawing.Size(116, 22);
            this.rxPhysicalPort.TabIndex = 42;
            // 
            // senseThreshold
            // 
            this.senseThreshold.Location = new System.Drawing.Point(363, 147);
            this.senseThreshold.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.senseThreshold.Name = "senseThreshold";
            this.senseThreshold.Size = new System.Drawing.Size(120, 22);
            this.senseThreshold.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(363, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 12);
            this.label11.TabIndex = 39;
            this.label11.Text = "Antenna Sense";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(363, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "Threshold";
            // 
            // powerLevel
            // 
            this.powerLevel.Location = new System.Drawing.Point(191, 147);
            this.powerLevel.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.powerLevel.Name = "powerLevel";
            this.powerLevel.Size = new System.Drawing.Size(120, 22);
            this.powerLevel.TabIndex = 38;
            // 
            // inventoryCycles
            // 
            this.inventoryCycles.Location = new System.Drawing.Point(363, 86);
            this.inventoryCycles.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.inventoryCycles.Name = "inventoryCycles";
            this.inventoryCycles.Size = new System.Drawing.Size(120, 22);
            this.inventoryCycles.TabIndex = 37;
            // 
            // dwellTime
            // 
            this.dwellTime.Location = new System.Drawing.Point(191, 86);
            this.dwellTime.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.dwellTime.Name = "dwellTime";
            this.dwellTime.Size = new System.Drawing.Size(120, 22);
            this.dwellTime.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "Inventory Cycles";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "Rx Physical Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tx Physical Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "Maximum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "Maximum Dwell Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "Milliseconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "Power ( 1/10 dBm )";
            // 
            // state
            // 
            this.state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.state.FormattingEnabled = true;
            this.state.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.state.Location = new System.Drawing.Point(12, 21);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(120, 20);
            this.state.TabIndex = 27;
            this.state.SelectedIndexChanged += new System.EventHandler(this.state_SelectedIndexChanged);
            // 
            // antennaNumberLabel
            // 
            this.antennaNumberLabel.AutoSize = true;
            this.antennaNumberLabel.Location = new System.Drawing.Point(12, 6);
            this.antennaNumberLabel.Name = "antennaNumberLabel";
            this.antennaNumberLabel.Size = new System.Drawing.Size(47, 12);
            this.antennaNumberLabel.TabIndex = 26;
            this.antennaNumberLabel.Text = "Antenna ";
            // 
            // txPhysicalPort
            // 
            this.txPhysicalPort.Location = new System.Drawing.Point(191, 21);
            this.txPhysicalPort.Name = "txPhysicalPort";
            this.txPhysicalPort.ReadOnly = true;
            this.txPhysicalPort.Size = new System.Drawing.Size(116, 22);
            this.txPhysicalPort.TabIndex = 42;
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(12, 172);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(121, 40);
            this.btn_apply.TabIndex = 44;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 224);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(498, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // cb_enable
            // 
            this.cb_enable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_enable.FormattingEnabled = true;
            this.cb_enable.Items.AddRange(new object[] {
            "Disable",
            "Enable",
            "Unknown"});
            this.cb_enable.Location = new System.Drawing.Point(12, 63);
            this.cb_enable.Name = "cb_enable";
            this.cb_enable.Size = new System.Drawing.Size(120, 20);
            this.cb_enable.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Enable?";
            // 
            // AntennaPortCfgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 246);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.txPhysicalPort);
            this.Controls.Add(this.rxPhysicalPort);
            this.Controls.Add(this.senseThreshold);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.powerLevel);
            this.Controls.Add(this.inventoryCycles);
            this.Controls.Add(this.dwellTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_enable);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.antennaNumberLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AntennaPortCfgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AntennaPortCfgForm";
            this.Load += new System.EventHandler(this.AntennaPortCfgForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.senseThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwellTime)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rxPhysicalPort;
        private System.Windows.Forms.NumericUpDown senseThreshold;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown powerLevel;
        private System.Windows.Forms.NumericUpDown inventoryCycles;
        private System.Windows.Forms.NumericUpDown dwellTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox state;
        private System.Windows.Forms.Label antennaNumberLabel;
        private System.Windows.Forms.TextBox txPhysicalPort;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ComboBox cb_enable;
        private System.Windows.Forms.Label label3;

    }
}