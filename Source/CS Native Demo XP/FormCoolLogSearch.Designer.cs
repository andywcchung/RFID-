namespace CS203_CALLBACK_API_DEMO
{
    partial class FormCoolLogSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#if WINCE
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
#endif

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nTable = new CSLibrary.Windows.UI.NTable();
            this.tmr_readrate = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nTable
            // 
            this.nTable.AllowColumnResize = true;
            this.nTable.AltBackColor = System.Drawing.Color.Khaki;
            this.nTable.AltForeColor = System.Drawing.Color.Black;
            this.nTable.AutoColumnSize = true;
            this.nTable.AutoMoveRow = false;
            this.nTable.BackColor = System.Drawing.Color.White;
            this.nTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nTable.ColumnBackColor = System.Drawing.Color.Chocolate;
            this.nTable.ColumnFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.nTable.ColumnForeColor = System.Drawing.Color.White;
            this.nTable.DefaultLineAligment = System.Drawing.StringAlignment.Center;
            this.nTable.DefaultRowHeight = 20;
            this.nTable.DefaultTextAligment = System.Drawing.StringAlignment.Center;
            this.nTable.DrawGridBorder = true;
            this.nTable.FocusCellBackColor = System.Drawing.Color.DarkOrange;
            this.nTable.FocusCellForeColor = System.Drawing.Color.Black;
            this.nTable.LeftHeader = false;
            this.nTable.Location = new System.Drawing.Point(0, 0);
            this.nTable.MultipleSelection = true;
            this.nTable.Name = "nTable";
            this.nTable.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.nTable.SelectionForeColor = System.Drawing.Color.Black;
            this.nTable.ShowSplitterValue = true;
            this.nTable.ShowStartSplitter = true;
            this.nTable.Size = new System.Drawing.Size(320, 180);
            this.nTable.SplitterColor = System.Drawing.Color.Red;
            this.nTable.SplitterMode = CSLibrary.Windows.UI.NTableSplitterMode.Default;
            this.nTable.SplitterStartColor = System.Drawing.Color.Brown;
            this.nTable.SplitterWidth = 1;
            this.nTable.TabIndex = 4;
            this.nTable.Text = "nTable1";
            this.nTable.RowChanged += new CSLibrary.Windows.UI.NTableRowHandler(this.nTable_RowChanged);
            // 
            // tmr_readrate
            // 
            this.tmr_readrate.Interval = 1000;
            this.tmr_readrate.Tick += new System.EventHandler(this.tmr_readrate_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(82, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 25);
            this.button4.TabIndex = 8;
            this.button4.Text = "Start Log";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(82, 212);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(73, 25);
            this.button5.TabIndex = 9;
            this.button5.Text = "Stop Log";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(161, 212);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(73, 25);
            this.button6.TabIndex = 10;
            this.button6.Text = "Get Log";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(240, 212);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(73, 25);
            this.button7.TabIndex = 11;
            this.button7.Text = "Exit";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(161, 186);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(73, 25);
            this.button8.TabIndex = 12;
            this.button8.Text = "Log Files";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // FormCoolLogSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCoolLogSearch";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SearchForm_Closing);
            this.ResumeLayout(false);

        }
        #endregion

        private CSLibrary.Windows.UI.NTable nTable;
        private System.Windows.Forms.Timer tmr_readrate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

