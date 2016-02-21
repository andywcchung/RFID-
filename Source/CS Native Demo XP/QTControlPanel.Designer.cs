namespace CS203_CALLBACK_API_DEMO
{
    partial class QTControlPanelForm
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
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.cb_sql = new System.Windows.Forms.CheckBox();
            this.textBoxAccessPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(111, 369);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(111, 394);
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
            this.toolStrip1.Size = new System.Drawing.Size(111, 394);
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
            this.btn_run.Size = new System.Drawing.Size(109, 23);
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
            this.btn_once.Size = new System.Drawing.Size(109, 23);
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
            this.btn_stop.Size = new System.Drawing.Size(109, 23);
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
            this.btn_select.Size = new System.Drawing.Size(109, 23);
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
            this.btn_save.Size = new System.Drawing.Size(109, 23);
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
            this.btn_clear.Size = new System.Drawing.Size(109, 23);
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
            this.btn_exit.Size = new System.Drawing.Size(109, 23);
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
            this.toolStripContainer2.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.textBoxAccessPassword);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.checkBoxLog);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.cb_sql);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(111, 394);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(111, 394);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            this.toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Location = new System.Drawing.Point(12, 195);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(68, 16);
            this.checkBoxLog.TabIndex = 8;
            this.checkBoxLog.Text = "Save Log";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            // 
            // cb_sql
            // 
            this.cb_sql.AutoSize = true;
            this.cb_sql.Location = new System.Drawing.Point(12, 217);
            this.cb_sql.Name = "cb_sql";
            this.cb_sql.Size = new System.Drawing.Size(82, 16);
            this.cb_sql.TabIndex = 1;
            this.cb_sql.Text = "Save to SQL";
            this.cb_sql.UseVisualStyleBackColor = true;
            this.cb_sql.Visible = false;
            this.cb_sql.CheckedChanged += new System.EventHandler(this.cb_sql_CheckedChanged);
            // 
            // textBoxAccessPassword
            // 
            this.textBoxAccessPassword.Location = new System.Drawing.Point(6, 264);
            this.textBoxAccessPassword.Name = "textBoxAccessPassword";
            this.textBoxAccessPassword.Size = new System.Drawing.Size(86, 22);
            this.textBoxAccessPassword.TabIndex = 9;
            this.textBoxAccessPassword.Text = "11111111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Access Password";
            // 
            // QTControlPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(111, 394);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripContainer2);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QTControlPanelForm";
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
        public System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxAccessPassword;


    }
}