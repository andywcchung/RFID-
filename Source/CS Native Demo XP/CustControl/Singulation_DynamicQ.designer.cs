namespace CS203_CALLBACK_API_DEMO
{
    partial class Singulation_DynamicQ
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
            this.cb_toggle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nb_retry = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_startqvalue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nb_minqvalue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nb_maxqvalue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_thresholdMultiplier = new System.Windows.Forms.NumericUpDown();
            this.SuspendLayout();
            // 
            // cb_toggle
            // 
            this.cb_toggle.Checked = true;
            this.cb_toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_toggle.Location = new System.Drawing.Point(157, 145);
            this.cb_toggle.Name = "cb_toggle";
            this.cb_toggle.Size = new System.Drawing.Size(27, 18);
            this.cb_toggle.TabIndex = 10;
            this.cb_toggle.CheckStateChanged += new System.EventHandler(this.cb_toggle_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.Text = "Toggle";
            this.label3.ParentChanged += new System.EventHandler(this.label3_ParentChanged);
            // 
            // nb_retry
            // 
            this.nb_retry.Location = new System.Drawing.Point(140, 87);
            this.nb_retry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_retry.Name = "nb_retry";
            this.nb_retry.Size = new System.Drawing.Size(77, 24);
            this.nb_retry.TabIndex = 8;
            this.nb_retry.ValueChanged += new System.EventHandler(this.nb_retry_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 23);
            this.label2.Text = "Retry";
            // 
            // nb_startqvalue
            // 
            this.nb_startqvalue.Location = new System.Drawing.Point(140, 3);
            this.nb_startqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_startqvalue.Name = "nb_startqvalue";
            this.nb_startqvalue.Size = new System.Drawing.Size(77, 24);
            this.nb_startqvalue.TabIndex = 7;
            this.nb_startqvalue.ValueChanged += new System.EventHandler(this.nb_startqvalue_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.Text = "StartQValue";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.Text = "MinQValue";
            // 
            // nb_minqvalue
            // 
            this.nb_minqvalue.Location = new System.Drawing.Point(140, 31);
            this.nb_minqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_minqvalue.Name = "nb_minqvalue";
            this.nb_minqvalue.Size = new System.Drawing.Size(77, 24);
            this.nb_minqvalue.TabIndex = 7;
            this.nb_minqvalue.ValueChanged += new System.EventHandler(this.nb_minqvalue_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 23);
            this.label6.Text = "MaxQValue";
            // 
            // nb_maxqvalue
            // 
            this.nb_maxqvalue.Location = new System.Drawing.Point(140, 115);
            this.nb_maxqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_maxqvalue.Name = "nb_maxqvalue";
            this.nb_maxqvalue.Size = new System.Drawing.Size(77, 24);
            this.nb_maxqvalue.TabIndex = 7;
            this.nb_maxqvalue.ValueChanged += new System.EventHandler(this.nb_maxqvalue_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.Text = "ThresholdMultiplier";
            // 
            // nb_MaxQueryRep
            // 
            this.nb_thresholdMultiplier.Location = new System.Drawing.Point(140, 59);
            this.nb_thresholdMultiplier.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_thresholdMultiplier.Name = "nb_MaxQueryRep";
            this.nb_thresholdMultiplier.Size = new System.Drawing.Size(77, 24);
            this.nb_thresholdMultiplier.TabIndex = 7;
            this.nb_thresholdMultiplier.ValueChanged += new System.EventHandler(this.nb_MaxQueryRep_ValueChanged);
            // 
            // Singulation_DynamicQ
            // 
            this.Controls.Add(this.cb_toggle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nb_retry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nb_maxqvalue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nb_thresholdMultiplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nb_minqvalue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nb_startqvalue);
            this.Controls.Add(this.label1);
            this.Name = "Singulation_DynamicQ";
            this.Size = new System.Drawing.Size(310, 186);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_toggle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nb_retry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nb_startqvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nb_minqvalue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nb_maxqvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nb_thresholdMultiplier;
    }
}
