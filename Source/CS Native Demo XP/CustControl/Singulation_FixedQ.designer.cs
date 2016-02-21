namespace CS203_CALLBACK_API_DEMO
{
    partial class Singulation_FixedQ
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
            this.nb_qvalue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_retry = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_toggle = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_repeat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.Text = "QValue";
            // 
            // nb_qvalue
            // 
            this.nb_qvalue.Location = new System.Drawing.Point(90, 3);
            this.nb_qvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_qvalue.Name = "nb_qvalue";
            this.nb_qvalue.Size = new System.Drawing.Size(77, 24);
            this.nb_qvalue.TabIndex = 1;
            this.nb_qvalue.ValueChanged += new System.EventHandler(this.nb_qvalue_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.Text = "Retry";
            // 
            // nb_retry
            // 
            this.nb_retry.Location = new System.Drawing.Point(90, 31);
            this.nb_retry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_retry.Name = "nb_retry";
            this.nb_retry.Size = new System.Drawing.Size(77, 24);
            this.nb_retry.TabIndex = 1;
            this.nb_retry.ValueChanged += new System.EventHandler(this.nb_retry_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.Text = "Toggle";
            // 
            // cb_toggle
            // 
            this.cb_toggle.Checked = true;
            this.cb_toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_toggle.Location = new System.Drawing.Point(90, 64);
            this.cb_toggle.Name = "cb_toggle";
            this.cb_toggle.Size = new System.Drawing.Size(24, 18);
            this.cb_toggle.TabIndex = 2;
            this.cb_toggle.CheckStateChanged += new System.EventHandler(this.cb_toggle_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.Text = "Repeat";
            // 
            // cb_repeat
            // 
            this.cb_repeat.Checked = true;
            this.cb_repeat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_repeat.Location = new System.Drawing.Point(90, 102);
            this.cb_repeat.Name = "cb_repeat";
            this.cb_repeat.Size = new System.Drawing.Size(24, 24);
            this.cb_repeat.TabIndex = 2;
            this.cb_repeat.CheckStateChanged += new System.EventHandler(this.cb_repeat_CheckedChanged);
            // 
            // Singulation_FixedQ
            // 
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cb_repeat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_toggle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nb_retry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nb_qvalue);
            this.Controls.Add(this.label1);
            this.Name = "Singulation_FixedQ";
            this.Size = new System.Drawing.Size(310, 186);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nb_qvalue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nb_retry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_toggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_repeat;
    }
}
