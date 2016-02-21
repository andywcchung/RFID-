#if NET_BUILD
namespace CS203_CALLBACK_API_DEMO
{
    partial class NetFinderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetFinderForm));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_assign = new System.Windows.Forms.Button();
            this.btn_image = new System.Windows.Forms.Button();
            this.btn_bootloader = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.Label();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.cbDirectSearch = new System.Windows.Forms.CheckBox();
            this.lv_device = new CS203_CALLBACK_API_DEMO.ListBoxEx.ListBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Mask3 = new System.Windows.Forms.TextBox();
            this.textBox_Mask2 = new System.Windows.Forms.TextBox();
            this.textBox_Mask1 = new System.Windows.Forms.TextBox();
            this.textBox_IP3 = new System.Windows.Forms.TextBox();
            this.textBox_IP2 = new System.Windows.Forms.TextBox();
            this.textBox_IP1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.AccessibleDescription = "Start Button";
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(15, 429);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(98, 30);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Search";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.Cyan;
            this.btn_connect.Enabled = false;
            this.btn_connect.Location = new System.Drawing.Point(15, 469);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(98, 30);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_clear.Location = new System.Drawing.Point(619, 465);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(97, 30);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_assign
            // 
            this.btn_assign.BackColor = System.Drawing.Color.Blue;
            this.btn_assign.Enabled = false;
            this.btn_assign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_assign.ForeColor = System.Drawing.Color.White;
            this.btn_assign.Location = new System.Drawing.Point(619, 429);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(97, 30);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assignment";
            this.btn_assign.UseVisualStyleBackColor = false;
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // btn_image
            // 
            this.btn_image.BackColor = System.Drawing.Color.Blue;
            this.btn_image.Enabled = false;
            this.btn_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_image.ForeColor = System.Drawing.Color.White;
            this.btn_image.Location = new System.Drawing.Point(8, 21);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(211, 30);
            this.btn_image.TabIndex = 3;
            this.btn_image.Text = "Network Processor Application";
            this.btn_image.UseVisualStyleBackColor = false;
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // btn_bootloader
            // 
            this.btn_bootloader.BackColor = System.Drawing.Color.Blue;
            this.btn_bootloader.Enabled = false;
            this.btn_bootloader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_bootloader.ForeColor = System.Drawing.Color.White;
            this.btn_bootloader.Location = new System.Drawing.Point(8, 57);
            this.btn_bootloader.Name = "btn_bootloader";
            this.btn_bootloader.Size = new System.Drawing.Size(211, 30);
            this.btn_bootloader.TabIndex = 4;
            this.btn_bootloader.Text = "Network Processor Bootloader";
            this.btn_bootloader.UseVisualStyleBackColor = false;
            this.btn_bootloader.Click += new System.EventHandler(this.btn_bootloader_Click);
            // 
            // lb_info
            // 
            this.lb_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lb_info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_info.ForeColor = System.Drawing.Color.Blue;
            this.lb_info.Location = new System.Drawing.Point(12, 382);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(939, 23);
            this.lb_info.TabIndex = 5;
            this.lb_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbIpAddress.Location = new System.Drawing.Point(119, 429);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(172, 31);
            this.tbIpAddress.TabIndex = 6;
            this.tbIpAddress.Text = "192.168.25.203";
            this.tbIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbDirectSearch
            // 
            this.cbDirectSearch.AutoSize = true;
            this.cbDirectSearch.Location = new System.Drawing.Point(119, 477);
            this.cbDirectSearch.Name = "cbDirectSearch";
            this.cbDirectSearch.Size = new System.Drawing.Size(86, 16);
            this.cbDirectSearch.TabIndex = 7;
            this.cbDirectSearch.Text = "Direct Search";
            this.cbDirectSearch.UseVisualStyleBackColor = true;
            // 
            // lv_device
            // 
            this.lv_device.BackColor = System.Drawing.SystemColors.Info;
            this.lv_device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_device.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lv_device.FormattingEnabled = true;
            this.lv_device.ItemHeight = 65;
            this.lv_device.Location = new System.Drawing.Point(12, 12);
            this.lv_device.Name = "lv_device";
            this.lv_device.Size = new System.Drawing.Size(939, 367);
            this.lv_device.TabIndex = 4;
            this.lv_device.SelectedIndexChanged += new System.EventHandler(this.lv_device_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_image);
            this.groupBox1.Controls.Add(this.btn_bootloader);
            this.groupBox1.Location = new System.Drawing.Point(732, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 93);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upgrade";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Mask3);
            this.groupBox2.Controls.Add(this.textBox_Mask2);
            this.groupBox2.Controls.Add(this.textBox_Mask1);
            this.groupBox2.Controls.Add(this.textBox_IP3);
            this.groupBox2.Controls.Add(this.textBox_IP2);
            this.groupBox2.Controls.Add(this.textBox_IP1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(297, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 90);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PC Info";
            // 
            // textBox_Mask3
            // 
            this.textBox_Mask3.Location = new System.Drawing.Point(205, 63);
            this.textBox_Mask3.Name = "textBox_Mask3";
            this.textBox_Mask3.Size = new System.Drawing.Size(94, 22);
            this.textBox_Mask3.TabIndex = 26;
            // 
            // textBox_Mask2
            // 
            this.textBox_Mask2.Location = new System.Drawing.Point(205, 39);
            this.textBox_Mask2.Name = "textBox_Mask2";
            this.textBox_Mask2.Size = new System.Drawing.Size(94, 22);
            this.textBox_Mask2.TabIndex = 25;
            // 
            // textBox_Mask1
            // 
            this.textBox_Mask1.Location = new System.Drawing.Point(205, 15);
            this.textBox_Mask1.Name = "textBox_Mask1";
            this.textBox_Mask1.Size = new System.Drawing.Size(94, 22);
            this.textBox_Mask1.TabIndex = 24;
            // 
            // textBox_IP3
            // 
            this.textBox_IP3.Location = new System.Drawing.Point(48, 63);
            this.textBox_IP3.Name = "textBox_IP3";
            this.textBox_IP3.Size = new System.Drawing.Size(94, 22);
            this.textBox_IP3.TabIndex = 23;
            // 
            // textBox_IP2
            // 
            this.textBox_IP2.Location = new System.Drawing.Point(48, 39);
            this.textBox_IP2.Name = "textBox_IP2";
            this.textBox_IP2.Size = new System.Drawing.Size(94, 22);
            this.textBox_IP2.TabIndex = 22;
            // 
            // textBox_IP1
            // 
            this.textBox_IP1.Location = new System.Drawing.Point(48, 15);
            this.textBox_IP1.Name = "textBox_IP1";
            this.textBox_IP1.Size = new System.Drawing.Size(94, 22);
            this.textBox_IP1.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Mask";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "Mask";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mask";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "IP3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "IP2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "IP1";
            // 
            // NetFinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(968, 512);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbDirectSearch);
            this.Controls.Add(this.tbIpAddress);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.lv_device);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NetFinderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Device";
            this.Load += new System.EventHandler(this.NetFinderForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetFinderForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_assign;
        private CS203_CALLBACK_API_DEMO.ListBoxEx.ListBoxEx lv_device;
        private System.Windows.Forms.Button btn_image;
        private System.Windows.Forms.Button btn_bootloader;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.CheckBox cbDirectSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Mask3;
        private System.Windows.Forms.TextBox textBox_Mask2;
        private System.Windows.Forms.TextBox textBox_Mask1;
        private System.Windows.Forms.TextBox textBox_IP3;
        private System.Windows.Forms.TextBox textBox_IP2;
        private System.Windows.Forms.TextBox textBox_IP1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
#endif