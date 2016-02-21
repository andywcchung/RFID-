namespace CS203_CALLBACK_API_DEMO
{
    partial class TagReadWriteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected new bool IsDisposed = false;
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
            base.Dispose(IsDisposed = disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_readAndWrite = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxEPCOffset = new System.Windows.Forms.TextBox();
            this.labelEPCOffset = new System.Windows.Forms.Label();
            this.nTable1 = new CSLibrary.Windows.UI.NTable();
            this.btn_search = new System.Windows.Forms.Button();
            this.lb_clear = new System.Windows.Forms.LinkLabel();
            this.tb_entertag = new Custom.Control.HexOnlyTextbox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lb_ReadInfo = new System.Windows.Forms.Label();
            this.btn_readallbank = new System.Windows.Forms.Button();
            this.m_readAllBank = new CS203_CALLBACK_API_DEMO.ReadAllBank();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lb_WriteInfo = new System.Windows.Forms.Label();
            this.btn_writeallbank = new System.Windows.Forms.Button();
            this.m_writeAllBank = new CS203_CALLBACK_API_DEMO.WriteAllBank();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tc_readAndWrite.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_readAndWrite
            // 
            this.tc_readAndWrite.Controls.Add(this.tabPage1);
            this.tc_readAndWrite.Controls.Add(this.tabPage5);
            this.tc_readAndWrite.Controls.Add(this.tabPage6);
            this.tc_readAndWrite.Controls.Add(this.tabPage4);
            this.tc_readAndWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_readAndWrite.Location = new System.Drawing.Point(0, 0);
            this.tc_readAndWrite.Name = "tc_readAndWrite";
            this.tc_readAndWrite.SelectedIndex = 0;
            this.tc_readAndWrite.Size = new System.Drawing.Size(320, 240);
            this.tc_readAndWrite.TabIndex = 0;
            this.tc_readAndWrite.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPage1.Controls.Add(this.textBoxEPCOffset);
            this.tabPage1.Controls.Add(this.labelEPCOffset);
            this.tabPage1.Controls.Add(this.nTable1);
            this.tabPage1.Controls.Add(this.btn_search);
            this.tabPage1.Controls.Add(this.lb_clear);
            this.tabPage1.Controls.Add(this.tb_entertag);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(312, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1.Select Tag";
            // 
            // textBoxEPCOffset
            // 
            this.textBoxEPCOffset.BackColor = System.Drawing.Color.LightGreen;
            this.textBoxEPCOffset.Location = new System.Drawing.Point(147, 189);
            this.textBoxEPCOffset.Name = "textBoxEPCOffset";
            this.textBoxEPCOffset.Size = new System.Drawing.Size(36, 22);
            this.textBoxEPCOffset.TabIndex = 6;
            this.textBoxEPCOffset.Text = "0";
            // 
            // labelEPCOffset
            // 
            this.labelEPCOffset.AutoSize = true;
            this.labelEPCOffset.Location = new System.Drawing.Point(84, 194);
            this.labelEPCOffset.Name = "labelEPCOffset";
            this.labelEPCOffset.Size = new System.Drawing.Size(57, 12);
            this.labelEPCOffset.TabIndex = 5;
            this.labelEPCOffset.Text = "EPC Offset";
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
            this.nTable1.Location = new System.Drawing.Point(3, 3);
            this.nTable1.MultipleSelection = false;
            this.nTable1.Name = "nTable1";
            this.nTable1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.nTable1.SelectionForeColor = System.Drawing.Color.Black;
            this.nTable1.ShowSplitterValue = true;
            this.nTable1.ShowStartSplitter = true;
            this.nTable1.Size = new System.Drawing.Size(306, 156);
            this.nTable1.SplitterColor = System.Drawing.Color.Red;
            this.nTable1.SplitterMode = CSLibrary.Windows.UI.NTableSplitterMode.Default;
            this.nTable1.SplitterStartColor = System.Drawing.Color.Brown;
            this.nTable1.SplitterWidth = 1;
            this.nTable1.TabIndex = 4;
            this.nTable1.Text = "nTable1";
            this.nTable1.RowChanged += new CSLibrary.Windows.UI.NTableRowHandler(this.nTable1_RowChanged);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_search.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(3, 165);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(72, 43);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lb_clear
            // 
            this.lb_clear.Location = new System.Drawing.Point(276, 176);
            this.lb_clear.Name = "lb_clear";
            this.lb_clear.Size = new System.Drawing.Size(33, 20);
            this.lb_clear.TabIndex = 2;
            this.lb_clear.TabStop = true;
            this.lb_clear.Text = "CLR";
            this.lb_clear.Click += new System.EventHandler(this.lb_clear_Click);
            // 
            // tb_entertag
            // 
            this.tb_entertag.BackColor = System.Drawing.Color.LightGreen;
            this.tb_entertag.BackgroundText = "Please type your EPC here!";
            this.tb_entertag.FontColor = System.Drawing.Color.Black;
            this.tb_entertag.ForeColor = System.Drawing.Color.Gray;
            this.tb_entertag.Location = new System.Drawing.Point(81, 165);
            this.tb_entertag.MaxLength = 24;
            this.tb_entertag.Name = "tb_entertag";
            this.tb_entertag.PaddingZero = true;
            this.tb_entertag.Size = new System.Drawing.Size(189, 22);
            this.tb_entertag.TabIndex = 0;
            this.tb_entertag.TextChanged += new System.EventHandler(this.tb_entertag_TextChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage5.Controls.Add(this.lb_ReadInfo);
            this.tabPage5.Controls.Add(this.btn_readallbank);
            this.tabPage5.Controls.Add(this.m_readAllBank);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(312, 214);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "2.Read Tag";
            // 
            // lb_ReadInfo
            // 
            this.lb_ReadInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lb_ReadInfo.Location = new System.Drawing.Point(81, 186);
            this.lb_ReadInfo.Name = "lb_ReadInfo";
            this.lb_ReadInfo.Size = new System.Drawing.Size(228, 20);
            this.lb_ReadInfo.TabIndex = 0;
            this.lb_ReadInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_readallbank
            // 
            this.btn_readallbank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_readallbank.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_readallbank.Location = new System.Drawing.Point(3, 186);
            this.btn_readallbank.Name = "btn_readallbank";
            this.btn_readallbank.Size = new System.Drawing.Size(72, 20);
            this.btn_readallbank.TabIndex = 1;
            this.btn_readallbank.Text = "Read";
            this.btn_readallbank.UseVisualStyleBackColor = false;
            this.btn_readallbank.Click += new System.EventHandler(this.btn_readallbank_Click);
            // 
            // m_readAllBank
            // 
            this.m_readAllBank.AccPwd = "FFFFFFFF";
            this.m_readAllBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_readAllBank.epc = "FFFF-FFFF-FFFF-FFFF-FFFF-FFFF";
            this.m_readAllBank.IconAcc = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.IconEpc = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.IconKill = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.IconPc = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.IconTid = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.IconUser = CS203_CALLBACK_API_DEMO.ReadAllBank.ReadState.UNKNOWN;
            this.m_readAllBank.KillPwd = "FFFFFFFF";
            this.m_readAllBank.Location = new System.Drawing.Point(0, 0);
            this.m_readAllBank.Name = "m_readAllBank";
            this.m_readAllBank.pc = "FFFF";
            this.m_readAllBank.ReadAccPwd = true;
            this.m_readAllBank.ReadEpc = true;
            this.m_readAllBank.ReadKillPwd = true;
            this.m_readAllBank.ReadPc = true;
            this.m_readAllBank.ReadTid = true;
            this.m_readAllBank.ReadUserBank = true;
            this.m_readAllBank.Size = new System.Drawing.Size(312, 183);
            this.m_readAllBank.TabIndex = 0;
            this.m_readAllBank.Tid = "FFFFFFFF";
            this.m_readAllBank.UserMem = "FFFFFFFF";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage6.Controls.Add(this.lb_WriteInfo);
            this.tabPage6.Controls.Add(this.btn_writeallbank);
            this.tabPage6.Controls.Add(this.m_writeAllBank);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(312, 214);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "3.Write Tag";
            // 
            // lb_WriteInfo
            // 
            this.lb_WriteInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lb_WriteInfo.Location = new System.Drawing.Point(81, 186);
            this.lb_WriteInfo.Name = "lb_WriteInfo";
            this.lb_WriteInfo.Size = new System.Drawing.Size(228, 20);
            this.lb_WriteInfo.TabIndex = 0;
            this.lb_WriteInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_writeallbank
            // 
            this.btn_writeallbank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_writeallbank.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_writeallbank.Location = new System.Drawing.Point(3, 186);
            this.btn_writeallbank.Name = "btn_writeallbank";
            this.btn_writeallbank.Size = new System.Drawing.Size(72, 20);
            this.btn_writeallbank.TabIndex = 2;
            this.btn_writeallbank.Text = "Write";
            this.btn_writeallbank.UseVisualStyleBackColor = false;
            this.btn_writeallbank.Click += new System.EventHandler(this.btn_writeAllbank_Click);
            // 
            // m_writeAllBank
            // 
            this.m_writeAllBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_writeAllBank.epc = "";
            this.m_writeAllBank.IconAcc = CS203_CALLBACK_API_DEMO.WriteAllBank.WriteState.UNKNOWN;
            this.m_writeAllBank.IconEpc = CS203_CALLBACK_API_DEMO.WriteAllBank.WriteState.UNKNOWN;
            this.m_writeAllBank.IconKill = CS203_CALLBACK_API_DEMO.WriteAllBank.WriteState.UNKNOWN;
            this.m_writeAllBank.IconPc = CS203_CALLBACK_API_DEMO.WriteAllBank.WriteState.UNKNOWN;
            this.m_writeAllBank.IconUser = CS203_CALLBACK_API_DEMO.WriteAllBank.WriteState.UNKNOWN;
            this.m_writeAllBank.Location = new System.Drawing.Point(0, 0);
            this.m_writeAllBank.Name = "m_writeAllBank";
            this.m_writeAllBank.OffsetUser = ((ushort)(0));
            this.m_writeAllBank.pc = "";
            this.m_writeAllBank.Size = new System.Drawing.Size(312, 183);
            this.m_writeAllBank.TabIndex = 0;
            this.m_writeAllBank.WordUser = ((ushort)(1));
            this.m_writeAllBank.WriteAccPwd = false;
            this.m_writeAllBank.WriteEPC = false;
            this.m_writeAllBank.WriteKillPwd = false;
            this.m_writeAllBank.WritePC = false;
            this.m_writeAllBank.WriteUser = false;
            this.m_writeAllBank.Load += new System.EventHandler(this.m_writeAllBank_Load);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(312, 214);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Exit";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 146);
            this.label1.TabIndex = 0;
            this.label1.Text = "TODO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(4, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "USER";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(4, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 24);
            this.button2.TabIndex = 0;
            this.button2.Text = "TID";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(4, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 24);
            this.button3.TabIndex = 0;
            this.button3.Text = "EPC";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(4, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 24);
            this.button4.TabIndex = 0;
            this.button4.Text = "PC";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(4, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 24);
            this.button5.TabIndex = 0;
            this.button5.Text = "ACC";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 24);
            this.button6.TabIndex = 0;
            this.button6.Text = "KILL";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // TagReadWriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.tc_readAndWrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TagReadWriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewReadWriteForm";
            this.Load += new System.EventHandler(this.NewReadWriteForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NewReadWriteForm_Closing);
            this.tc_readAndWrite.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_readAndWrite;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.LinkLabel lb_clear;
        private Custom.Control.HexOnlyTextbox tb_entertag;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private ReadAllBank m_readAllBank;
        private System.Windows.Forms.Button btn_readallbank;
        private System.Windows.Forms.Label lb_ReadInfo;
        private WriteAllBank m_writeAllBank;
        private System.Windows.Forms.Label lb_WriteInfo;
        private System.Windows.Forms.Button btn_writeallbank;
        private CSLibrary.Windows.UI.NTable nTable1;
        private System.Windows.Forms.Label labelEPCOffset;
        private System.Windows.Forms.TextBox textBoxEPCOffset;
    }
}