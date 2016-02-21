namespace CS203_CALLBACK_API_DEMO
{
    partial class FormColdChainViewLog
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
            this.label17 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.listView5 = new System.Windows.Forms.ListView();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(19, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(274, 20);
            this.label17.Text = "Total :";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(110, 187);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(87, 24);
            this.button12.TabIndex = 14;
            this.button12.Text = "OK";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(19, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 23);
            this.label16.Text = "EPC";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(74, 6);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(207, 23);
            this.textBox14.TabIndex = 13;
            // 
            // listView5
            // 
            this.listView5.Columns.Add(this.columnHeader26);
            this.listView5.Columns.Add(this.columnHeader24);
            this.listView5.Columns.Add(this.columnHeader25);
            this.listView5.Location = new System.Drawing.Point(9, 35);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(300, 121);
            this.listView5.TabIndex = 11;
            this.listView5.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Index";
            this.columnHeader26.Width = 40;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Date Time";
            this.columnHeader24.Width = 170;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Temp";
            this.columnHeader25.Width = 88;
            // 
            // FormColdChainViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 215);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.listView5);
            this.Name = "FormColdChainViewLog";
            this.Text = "FormColdChainViewLog";
            this.Load += new System.EventHandler(this.FormColdChainViewLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        public System.Windows.Forms.TextBox textBox14;
    }
}