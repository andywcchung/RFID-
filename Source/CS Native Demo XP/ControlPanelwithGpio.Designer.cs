namespace CS203_CALLBACK_API_DEMO
{
    partial class ControlPanelWithGpioForm
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_run = new System.Windows.Forms.ToolStripButton();
            this.btn_once = new System.Windows.Forms.ToolStripButton();
            this.btn_stop = new System.Windows.Forms.ToolStripButton();
            this.btn_select = new System.Windows.Forms.ToolStripButton();
            this.btn_save = new System.Windows.Forms.ToolStripButton();
            this.btn_clear = new System.Windows.Forms.ToolStripButton();
            this.btn_exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.textBoxUsercount = new System.Windows.Forms.TextBox();
            this.textBoxUseroffset = new System.Windows.Forms.TextBox();
            this.textBoxTIDcount = new System.Windows.Forms.TextBox();
            this.textBoxTIDoffset = new System.Windows.Forms.TextBox();
            this.checkBoxReadUser = new System.Windows.Forms.CheckBox();
            this.checkBoxReadTID = new System.Windows.Forms.CheckBox();
            this.cb_sql = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(153, 526);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(153, 551);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_run,
            this.btn_once,
            this.btn_stop,
            this.btn_select,
            this.btn_save,
            this.btn_clear,
            this.btn_exit});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(153, 551);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Run;
            this.btn_run.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(151, 23);
            this.btn_run.Text = "Run";
            this.btn_run.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_run.ToolTipText = "Run continuous inventory";
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_once
            // 
            this.btn_once.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_once.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Run;
            this.btn_once.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_once.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_once.Name = "btn_once";
            this.btn_once.Size = new System.Drawing.Size(151, 23);
            this.btn_once.Text = "Run Once";
            this.btn_once.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_once.ToolTipText = "Run noncontinuous inventory";
            this.btn_once.Click += new System.EventHandler(this.btn_once_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Delete;
            this.btn_stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(151, 23);
            this.btn_stop.Text = "Stop";
            this.btn_stop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_stop.ToolTipText = "Stop inventory";
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_select
            // 
            this.btn_select.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Add;
            this.btn_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(151, 23);
            this.btn_select.Text = "Select";
            this.btn_select.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_select.ToolTipText = "Select a tag";
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Save;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(151, 23);
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ToolTipText = "Save all tags to file";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Clear;
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(151, 23);
            this.btn_clear.Text = "Clear";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clear.ToolTipText = "Clear inventory session";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Image = global::CS203_CALLBACK_API_DEMO.Properties.Resources.Close;
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(151, 23);
            this.btn_exit.Text = "Exit";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button9);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button10);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button8);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button7);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button6);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button5);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button4);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button3);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button2);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.button1);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.checkBoxLog);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.textBoxUsercount);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.textBoxUseroffset);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.textBoxTIDcount);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.textBoxTIDoffset);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.checkBoxReadUser);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.checkBoxReadTID);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.cb_sql);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(153, 551);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(153, 551);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            this.toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(80, 459);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 28);
            this.button8.TabIndex = 16;
            this.button8.Text = "Flash Stop";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 459);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 28);
            this.button7.TabIndex = 15;
            this.button7.Text = "GPO Flash";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(79, 425);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 28);
            this.button6.TabIndex = 14;
            this.button6.Text = "Get GPI1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 425);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 28);
            this.button5.TabIndex = 13;
            this.button5.Text = "Get GPI0";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(79, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "GPO1 Off";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 391);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 28);
            this.button3.TabIndex = 11;
            this.button3.Text = "GPO1 On";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 28);
            this.button2.TabIndex = 10;
            this.button2.Text = "GPO0 Off";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "GPO0 On";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Location = new System.Drawing.Point(12, 179);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(68, 16);
            this.checkBoxLog.TabIndex = 8;
            this.checkBoxLog.Text = "Save Log";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.checkBoxLog_CheckedChanged);
            // 
            // textBoxUsercount
            // 
            this.textBoxUsercount.Location = new System.Drawing.Point(29, 329);
            this.textBoxUsercount.Name = "textBoxUsercount";
            this.textBoxUsercount.Size = new System.Drawing.Size(70, 22);
            this.textBoxUsercount.TabIndex = 7;
            this.textBoxUsercount.Text = "1";
            // 
            // textBoxUseroffset
            // 
            this.textBoxUseroffset.Location = new System.Drawing.Point(29, 301);
            this.textBoxUseroffset.Name = "textBoxUseroffset";
            this.textBoxUseroffset.Size = new System.Drawing.Size(70, 22);
            this.textBoxUseroffset.TabIndex = 6;
            this.textBoxUseroffset.Text = "0";
            // 
            // textBoxTIDcount
            // 
            this.textBoxTIDcount.Location = new System.Drawing.Point(29, 251);
            this.textBoxTIDcount.Name = "textBoxTIDcount";
            this.textBoxTIDcount.Size = new System.Drawing.Size(70, 22);
            this.textBoxTIDcount.TabIndex = 5;
            this.textBoxTIDcount.Text = "1";
            // 
            // textBoxTIDoffset
            // 
            this.textBoxTIDoffset.Location = new System.Drawing.Point(29, 223);
            this.textBoxTIDoffset.Name = "textBoxTIDoffset";
            this.textBoxTIDoffset.Size = new System.Drawing.Size(70, 22);
            this.textBoxTIDoffset.TabIndex = 4;
            this.textBoxTIDoffset.Text = "0";
            // 
            // checkBoxReadUser
            // 
            this.checkBoxReadUser.AutoSize = true;
            this.checkBoxReadUser.Location = new System.Drawing.Point(12, 279);
            this.checkBoxReadUser.Name = "checkBoxReadUser";
            this.checkBoxReadUser.Size = new System.Drawing.Size(72, 16);
            this.checkBoxReadUser.TabIndex = 3;
            this.checkBoxReadUser.Text = "Read User";
            this.checkBoxReadUser.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadTID
            // 
            this.checkBoxReadTID.AutoSize = true;
            this.checkBoxReadTID.Location = new System.Drawing.Point(12, 201);
            this.checkBoxReadTID.Name = "checkBoxReadTID";
            this.checkBoxReadTID.Size = new System.Drawing.Size(70, 16);
            this.checkBoxReadTID.TabIndex = 2;
            this.checkBoxReadTID.Text = "Read TID";
            this.checkBoxReadTID.UseVisualStyleBackColor = true;
            // 
            // cb_sql
            // 
            this.cb_sql.AutoSize = true;
            this.cb_sql.Location = new System.Drawing.Point(91, 220);
            this.cb_sql.Name = "cb_sql";
            this.cb_sql.Size = new System.Drawing.Size(82, 16);
            this.cb_sql.TabIndex = 1;
            this.cb_sql.Text = "Save to SQL";
            this.cb_sql.UseVisualStyleBackColor = true;
            this.cb_sql.Visible = false;
            this.cb_sql.CheckedChanged += new System.EventHandler(this.cb_sql_CheckedChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(80, 491);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 28);
            this.button9.TabIndex = 18;
            this.button9.Text = "5V Off";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(3, 491);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(70, 28);
            this.button10.TabIndex = 17;
            this.button10.Text = "5V On";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // ControlPanelWithGpioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 551);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripContainer2);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlPanelWithGpioForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Control";
            this.Load += new System.EventHandler(this.ControlPanelForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanelForm_FormClosing);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_run;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStripButton btn_once;
        private System.Windows.Forms.ToolStripButton btn_stop;
        private System.Windows.Forms.ToolStripButton btn_save;
        private System.Windows.Forms.ToolStripButton btn_clear;
        private System.Windows.Forms.ToolStripButton btn_select;
        private System.Windows.Forms.ToolStripButton btn_exit;
        private System.Windows.Forms.CheckBox cb_sql;
        public System.Windows.Forms.TextBox textBoxUsercount;
        public System.Windows.Forms.TextBox textBoxUseroffset;
        public System.Windows.Forms.TextBox textBoxTIDcount;
        public System.Windows.Forms.TextBox textBoxTIDoffset;
        public System.Windows.Forms.CheckBox checkBoxReadUser;
        public System.Windows.Forms.CheckBox checkBoxReadTID;
        public System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;


    }
}