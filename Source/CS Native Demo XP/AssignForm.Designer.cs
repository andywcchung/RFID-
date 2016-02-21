namespace CS203_CALLBACK_API_DEMO
{
    partial class AssignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_assign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_timeout = new System.Windows.Forms.NumericUpDown();
            this.ipTextBox1 = new CS203_CALLBACK_API_DEMO.IPTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_devicename = new System.Windows.Forms.TextBox();
            this.cb_dhcp = new System.Windows.Forms.CheckBox();
            this.tbTrustedServer = new CS203_CALLBACK_API_DEMO.IPTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTrustedEnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ipTxtSubnet = new CS203_CALLBACK_API_DEMO.IPTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ipTxtGateway = new CS203_CALLBACK_API_DEMO.IPTextBox();
            this.checkBox_GatewayCheckResetMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nb_timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = " IP";
            // 
            // btn_assign
            // 
            this.btn_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_assign.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_assign.Location = new System.Drawing.Point(0, 232);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(310, 28);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assign";
            this.btn_assign.UseVisualStyleBackColor = false;
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "DHCP Retry";
            // 
            // nb_timeout
            // 
            this.nb_timeout.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_timeout.Location = new System.Drawing.Point(107, 177);
            this.nb_timeout.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_timeout.Name = "nb_timeout";
            this.nb_timeout.Size = new System.Drawing.Size(52, 25);
            this.nb_timeout.TabIndex = 3;
            this.nb_timeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ipTextBox1.IP = "192.168.25.203";
            this.ipTextBox1.Location = new System.Drawing.Point(80, 30);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(226, 25);
            this.ipTextBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device Name";
            // 
            // tb_devicename
            // 
            this.tb_devicename.Location = new System.Drawing.Point(107, 6);
            this.tb_devicename.MaxLength = 31;
            this.tb_devicename.Name = "tb_devicename";
            this.tb_devicename.Size = new System.Drawing.Size(199, 22);
            this.tb_devicename.TabIndex = 4;
            // 
            // cb_dhcp
            // 
            this.cb_dhcp.AutoSize = true;
            this.cb_dhcp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dhcp.Location = new System.Drawing.Point(172, 179);
            this.cb_dhcp.Name = "cb_dhcp";
            this.cb_dhcp.Size = new System.Drawing.Size(126, 22);
            this.cb_dhcp.TabIndex = 5;
            this.cb_dhcp.Text = "DHCP Enable";
            this.cb_dhcp.UseVisualStyleBackColor = true;
            this.cb_dhcp.CheckedChanged += new System.EventHandler(this.cb_dhcp_CheckedChanged);
            // 
            // tbTrustedServer
            // 
            this.tbTrustedServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbTrustedServer.IP = "192.168.25.203";
            this.tbTrustedServer.Location = new System.Drawing.Point(80, 123);
            this.tbTrustedServer.Name = "tbTrustedServer";
            this.tbTrustedServer.Size = new System.Drawing.Size(226, 25);
            this.tbTrustedServer.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "TrustedIP";
            // 
            // cbTrustedEnable
            // 
            this.cbTrustedEnable.AutoSize = true;
            this.cbTrustedEnable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrustedEnable.Location = new System.Drawing.Point(172, 154);
            this.cbTrustedEnable.Name = "cbTrustedEnable";
            this.cbTrustedEnable.Size = new System.Drawing.Size(131, 22);
            this.cbTrustedEnable.TabIndex = 5;
            this.cbTrustedEnable.Text = "Trusted Enable";
            this.cbTrustedEnable.UseVisualStyleBackColor = true;
            this.cbTrustedEnable.CheckedChanged += new System.EventHandler(this.cb_dhcp_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-2, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Subnet";
            // 
            // ipTxtSubnet
            // 
            this.ipTxtSubnet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ipTxtSubnet.IP = "192.168.25.203";
            this.ipTxtSubnet.Location = new System.Drawing.Point(80, 61);
            this.ipTxtSubnet.Name = "ipTxtSubnet";
            this.ipTxtSubnet.Size = new System.Drawing.Size(226, 25);
            this.ipTxtSubnet.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-2, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gateway";
            // 
            // ipTxtGateway
            // 
            this.ipTxtGateway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ipTxtGateway.IP = "192.168.25.203";
            this.ipTxtGateway.Location = new System.Drawing.Point(80, 92);
            this.ipTxtGateway.Name = "ipTxtGateway";
            this.ipTxtGateway.Size = new System.Drawing.Size(226, 25);
            this.ipTxtGateway.TabIndex = 8;
            // 
            // checkBox_GatewayCheckResetMode
            // 
            this.checkBox_GatewayCheckResetMode.AutoSize = true;
            this.checkBox_GatewayCheckResetMode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_GatewayCheckResetMode.Location = new System.Drawing.Point(28, 207);
            this.checkBox_GatewayCheckResetMode.Name = "checkBox_GatewayCheckResetMode";
            this.checkBox_GatewayCheckResetMode.Size = new System.Drawing.Size(256, 22);
            this.checkBox_GatewayCheckResetMode.TabIndex = 10;
            this.checkBox_GatewayCheckResetMode.Text = "Reset if gateway cannot be found";
            this.checkBox_GatewayCheckResetMode.UseVisualStyleBackColor = true;
            // 
            // AssignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(310, 260);
            this.Controls.Add(this.checkBox_GatewayCheckResetMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ipTxtGateway);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ipTxtSubnet);
            this.Controls.Add(this.cbTrustedEnable);
            this.Controls.Add(this.cb_dhcp);
            this.Controls.Add(this.tb_devicename);
            this.Controls.Add(this.nb_timeout);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTrustedServer);
            this.Controls.Add(this.ipTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.nb_timeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IPTextBox ipTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_assign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nb_timeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_devicename;
        private System.Windows.Forms.CheckBox cb_dhcp;
        private IPTextBox tbTrustedServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbTrustedEnable;
        private System.Windows.Forms.Label label5;
        private IPTextBox ipTxtSubnet;
        private System.Windows.Forms.Label label6;
        private IPTextBox ipTxtGateway;
        public System.Windows.Forms.CheckBox checkBox_GatewayCheckResetMode;
    }
}