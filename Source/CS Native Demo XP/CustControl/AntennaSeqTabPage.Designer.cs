namespace CS203_CALLBACK_API_DEMO
{
    partial class AntennaSeqTabPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbSequenceSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.view = new System.Windows.Forms.DataGridView();


            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSequenceSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nbSequenceSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            //this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            //this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Antenna";
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Normal",
            "Sequence",
            "SmartCheck",
            "Sequence and SmartCheck"});
            this.cbMode.Location = new System.Drawing.Point(130, 73);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 20);
            this.cbMode.TabIndex = 2;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mode :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "SeqSize :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nbSequenceSize
            // 
            this.nbSequenceSize.Enabled = true;
            this.nbSequenceSize.Location = new System.Drawing.Point(131, 108);
            this.nbSequenceSize.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nbSequenceSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbSequenceSize.Name = "nbSequenceSize";
            this.nbSequenceSize.Size = new System.Drawing.Size(120, 22);
            this.nbSequenceSize.TabIndex = 1;
            this.nbSequenceSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbSequenceSize.ValueChanged += new System.EventHandler(this.nbSequenceSize_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.view);
            //this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            //this.groupBox2.Location = new System.Drawing.Point(0, 110);
            this.groupBox2.Location = new System.Drawing.Point(312, 12);
            this.groupBox2.Name = "groupBox2";
            //this.groupBox2.Size = new System.Drawing.Size(284, 132);
            this.groupBox2.Size = new System.Drawing.Size(287, 220);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Antenna Sequence";
            // 
            // view
            // 
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.view.Location = new System.Drawing.Point(15, 18);
            this.view.Location = new System.Drawing.Point(15, 21);
            this.view.Name = "view";
            //this.view.Size = new System.Drawing.Size(257, 109);
            this.view.RowTemplate.Height = 24;
            this.view.Size = new System.Drawing.Size(257, 182);
            this.view.TabIndex = 0;
            // 
            // btnApply
            // 
            //this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.btnApply.Location = new System.Drawing.Point(0, 242);
            //this.btnApply.Name = "btnApply";
            //this.btnApply.Size = new System.Drawing.Size(284, 36);
            //this.btnApply.TabIndex = 4;
            //this.btnApply.Text = "Apply";
            //this.btnApply.UseVisualStyleBackColor = true;
            //this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // AntennaSeqTabPage
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 278);
            //this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.Name = "ConfigureOperation";
            //this.ShowIcon = false;
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.Load += new System.EventHandler(this.ConfigureOperation_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbSequenceSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbSequenceSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView view;

    }
}