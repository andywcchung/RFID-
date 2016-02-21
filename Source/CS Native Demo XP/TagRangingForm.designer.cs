namespace CS203_CALLBACK_API_DEMO
{
    partial class TagRangingForm
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
            this.components = new System.ComponentModel.Container();
            this.tmr_readrate = new System.Windows.Forms.Timer(this.components);
            this.nTable = new CSLibrary.Windows.UI.NTable();
            this.startMenu1 = new CS203_CALLBACK_API_DEMO.StartMenu();
            this.SuspendLayout();
            // 
            // tmr_readrate
            // 
            this.tmr_readrate.Interval = 1000;
            this.tmr_readrate.Tick += new System.EventHandler(this.tmr_readrate_Tick);
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
            this.nTable.FocusCellBackColor = System.Drawing.Color.Black;
            this.nTable.FocusCellForeColor = System.Drawing.Color.White;
            this.nTable.LeftHeader = false;
            this.nTable.Location = new System.Drawing.Point(0, 0);
            this.nTable.MultipleSelection = false;
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
            // 
            // startMenu1
            // 
            this.startMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.startMenu1.IsSelectable = false;
            this.startMenu1.Location = new System.Drawing.Point(0, 180);
            this.startMenu1.Name = "startMenu1";
            this.startMenu1.Size = new System.Drawing.Size(320, 60);
            this.startMenu1.TabIndex = 5;
            this.startMenu1.OnButtonClick +=new StartMenu.ButtonClickArgs(startMenu1_OnButtonClick);
            // 
            // TagRangingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.startMenu1);
            this.Controls.Add(this.nTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagRangingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SearchForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_readrate;
        private CSLibrary.Windows.UI.NTable nTable;
        private StartMenu startMenu1;
    }
}

