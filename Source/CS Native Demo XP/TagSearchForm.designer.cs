namespace CS203_CALLBACK_API_DEMO
{
    partial class TagSearchForm
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.lb_tagCount = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.nTable1 = new CSLibrary.Windows.UI.NTable();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(245, 211);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(72, 26);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_select
            // 
            this.btn_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_select.Enabled = false;
            this.btn_select.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_select.ForeColor = System.Drawing.Color.White;
            this.btn_select.Location = new System.Drawing.Point(81, 211);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(72, 26);
            this.btn_select.TabIndex = 2;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = false;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_search.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(3, 211);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(72, 26);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lb_tagCount
            // 
            this.lb_tagCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_tagCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb_tagCount.Location = new System.Drawing.Point(159, 211);
            this.lb_tagCount.Name = "lb_tagCount";
            this.lb_tagCount.Size = new System.Drawing.Size(50, 26);
            this.lb_tagCount.TabIndex = 7;
            this.lb_tagCount.Text = "0000";
            this.lb_tagCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.linkLabel1.Location = new System.Drawing.Point(206, 217);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 20);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Tags";
            // 
            // nTable1
            // 
            this.nTable1.AllowColumnResize = false;
            this.nTable1.AltBackColor = System.Drawing.Color.Khaki;
            this.nTable1.AltForeColor = System.Drawing.Color.Black;
            this.nTable1.AutoColumnSize = true;
            this.nTable1.AutoMoveRow = true;
            this.nTable1.BackColor = System.Drawing.Color.White;
            this.nTable1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nTable1.ColumnBackColor = System.Drawing.Color.Chocolate;
            this.nTable1.ColumnFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.nTable1.ColumnForeColor = System.Drawing.Color.White;
            this.nTable1.DefaultLineAligment = System.Drawing.StringAlignment.Center;
            this.nTable1.DefaultRowHeight = 20;
            this.nTable1.DefaultTextAligment = System.Drawing.StringAlignment.Center;
            this.nTable1.DrawGridBorder = true;
            this.nTable1.FocusCellBackColor = System.Drawing.Color.Black;
            this.nTable1.FocusCellForeColor = System.Drawing.Color.White;
            this.nTable1.LeftHeader = false;
            this.nTable1.Location = new System.Drawing.Point(0, 0);
            this.nTable1.MultipleSelection = false;
            this.nTable1.Name = "nTable1";
            this.nTable1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.nTable1.SelectionForeColor = System.Drawing.Color.Black;
            this.nTable1.ShowSplitterValue = true;
            this.nTable1.ShowStartSplitter = true;
            this.nTable1.Size = new System.Drawing.Size(318, 205);
            this.nTable1.SplitterColor = System.Drawing.Color.Red;
            this.nTable1.SplitterMode = CSLibrary.Windows.UI.NTableSplitterMode.Default;
            this.nTable1.SplitterStartColor = System.Drawing.Color.Brown;
            this.nTable1.SplitterWidth = 1;
            this.nTable1.TabIndex = 4;
            this.nTable1.Text = "nTable1";
            this.nTable1.RowChanged += new CSLibrary.Windows.UI.NTableRowHandler(this.nTable1_RowChanged);
            // 
            // TagSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lb_tagCount);
            this.Controls.Add(this.nTable1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TagSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagSearchForm";
            this.Load += new System.EventHandler(this.TagSearchForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TagSearchForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_search;
        private CSLibrary.Windows.UI.NTable nTable1;
        private System.Windows.Forms.Label lb_tagCount;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}