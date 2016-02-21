namespace CS203DEMO
{
    partial class CustomReadForm
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
            this.tb_log = new System.Windows.Forms.TextBox();
            this.pn_tg = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_tg_target = new System.Windows.Forms.ComboBox();
            this.cb_tg_session = new System.Windows.Forms.ComboBox();
            this.cb_tg_select = new System.Windows.Forms.ComboBox();
            this.nb_alg_qsize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_alg_toggle = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nb_alg_retry = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_alg = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_sel_target = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_sel_action = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pn_tg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_log
            // 
            this.tb_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tb_log.Location = new System.Drawing.Point(3, 3);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(314, 80);
            this.tb_log.TabIndex = 0;
            // 
            // pn_tg
            // 
            this.pn_tg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pn_tg.Controls.Add(this.btn_exit);
            this.pn_tg.Controls.Add(this.btn_read);
            this.pn_tg.Controls.Add(this.label3);
            this.pn_tg.Controls.Add(this.label2);
            this.pn_tg.Controls.Add(this.label1);
            this.pn_tg.Controls.Add(this.cb_tg_target);
            this.pn_tg.Controls.Add(this.cb_tg_session);
            this.pn_tg.Controls.Add(this.cb_tg_select);
            this.pn_tg.Location = new System.Drawing.Point(4, 118);
            this.pn_tg.Name = "pn_tg";
            this.pn_tg.Size = new System.Drawing.Size(158, 119);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_exit.Location = new System.Drawing.Point(103, 94);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(50, 20);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_read
            // 
            this.btn_read.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_read.Location = new System.Drawing.Point(3, 94);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(50, 20);
            this.btn_read.TabIndex = 4;
            this.btn_read.Text = "Read";
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.Text = "Target";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.Text = "Session";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.Text = "Select";
            // 
            // cb_tg_target
            // 
            this.cb_tg_target.Items.Add("A");
            this.cb_tg_target.Items.Add("B");
            this.cb_tg_target.Location = new System.Drawing.Point(89, 61);
            this.cb_tg_target.Name = "cb_tg_target";
            this.cb_tg_target.Size = new System.Drawing.Size(66, 23);
            this.cb_tg_target.TabIndex = 0;
            // 
            // cb_tg_session
            // 
            this.cb_tg_session.Items.Add("S0");
            this.cb_tg_session.Items.Add("S1");
            this.cb_tg_session.Items.Add("S2");
            this.cb_tg_session.Items.Add("S3");
            this.cb_tg_session.Location = new System.Drawing.Point(89, 32);
            this.cb_tg_session.Name = "cb_tg_session";
            this.cb_tg_session.Size = new System.Drawing.Size(66, 23);
            this.cb_tg_session.TabIndex = 0;
            // 
            // cb_tg_select
            // 
            this.cb_tg_select.Items.Add("ALL");
            this.cb_tg_select.Items.Add("ON");
            this.cb_tg_select.Items.Add("OFF");
            this.cb_tg_select.Location = new System.Drawing.Point(89, 3);
            this.cb_tg_select.Name = "cb_tg_select";
            this.cb_tg_select.Size = new System.Drawing.Size(66, 23);
            this.cb_tg_select.TabIndex = 0;
            // 
            // nb_alg_qsize
            // 
            this.nb_alg_qsize.Location = new System.Drawing.Point(85, 2);
            this.nb_alg_qsize.Name = "nb_alg_qsize";
            this.nb_alg_qsize.Size = new System.Drawing.Size(66, 24);
            this.nb_alg_qsize.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.Text = "QSize";
            // 
            // cb_alg_toggle
            // 
            this.cb_alg_toggle.Location = new System.Drawing.Point(85, 94);
            this.cb_alg_toggle.Name = "cb_alg_toggle";
            this.cb_alg_toggle.Size = new System.Drawing.Size(34, 20);
            this.cb_alg_toggle.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.Text = "Toggle";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.Text = "Retry";
            // 
            // nb_alg_retry
            // 
            this.nb_alg_retry.Location = new System.Drawing.Point(85, 31);
            this.nb_alg_retry.Name = "nb_alg_retry";
            this.nb_alg_retry.Size = new System.Drawing.Size(66, 24);
            this.nb_alg_retry.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.cb_alg_toggle);
            this.panel1.Controls.Add(this.nb_alg_qsize);
            this.panel1.Controls.Add(this.nb_alg_retry);
            this.panel1.Controls.Add(this.cb_alg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(163, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 119);
            // 
            // cb_alg
            // 
            this.cb_alg.Items.Add("FixedQ,");
            this.cb_alg.Items.Add("DynQ,");
            this.cb_alg.Items.Add("DynAdjQ,");
            this.cb_alg.Items.Add("DynThrQ");
            this.cb_alg.Location = new System.Drawing.Point(85, 61);
            this.cb_alg.Name = "cb_alg";
            this.cb_alg.Size = new System.Drawing.Size(66, 23);
            this.cb_alg.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.Text = "Algorithm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cb_sel_target);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cb_sel_action);
            this.panel2.Location = new System.Drawing.Point(4, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 29);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(161, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.Text = "Target";
            // 
            // cb_sel_target
            // 
            this.cb_sel_target.Items.Add("S0");
            this.cb_sel_target.Items.Add("S1");
            this.cb_sel_target.Items.Add("S2");
            this.cb_sel_target.Items.Add("S3");
            this.cb_sel_target.Items.Add("SELECTED");
            this.cb_sel_target.Location = new System.Drawing.Point(244, 3);
            this.cb_sel_target.Name = "cb_sel_target";
            this.cb_sel_target.Size = new System.Drawing.Size(66, 23);
            this.cb_sel_target.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.Text = "Action";
            // 
            // cb_sel_action
            // 
            this.cb_sel_action.Items.Add("ASLINVA_DSLINVB");
            this.cb_sel_action.Items.Add("ASLINVA_NOTHING");
            this.cb_sel_action.Items.Add("NOTHING_DSLINVB");
            this.cb_sel_action.Items.Add("NSLINVS_NOTHING");
            this.cb_sel_action.Items.Add("DSLINVB_ASLINVA");
            this.cb_sel_action.Items.Add("DSLINVB_NOTHING");
            this.cb_sel_action.Items.Add("NOTHING_ASLINVA");
            this.cb_sel_action.Items.Add("NOTHING_NSLINVS");
            this.cb_sel_action.Location = new System.Drawing.Point(51, 3);
            this.cb_sel_action.Name = "cb_sel_action";
            this.cb_sel_action.Size = new System.Drawing.Size(104, 23);
            this.cb_sel_action.TabIndex = 1;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Red;
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(248, 64);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(49, 19);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // CustomReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_tg);
            this.Controls.Add(this.tb_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomReadForm";
            this.Text = "CustomReadForm";
            this.Load += new System.EventHandler(this.CustomReadForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CustomReadForm_Closing);
            this.pn_tg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Panel pn_tg;
        private System.Windows.Forms.ComboBox cb_tg_target;
        private System.Windows.Forms.ComboBox cb_tg_session;
        private System.Windows.Forms.ComboBox cb_tg_select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_alg_toggle;
        private System.Windows.Forms.NumericUpDown nb_alg_retry;
        private System.Windows.Forms.NumericUpDown nb_alg_qsize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_alg;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_sel_action;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_sel_target;
        private System.Windows.Forms.Button btn_clear;
    }
}