namespace CS203_CALLBACK_API_DEMO
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.btn_rw = new System.Windows.Forms.Button();
            this.btn_geiger = new System.Windows.Forms.Button();
            this.btn_security = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_setup = new System.Windows.Forms.Button();
            this.btn_inv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_software = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_firmware = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_cslib = new System.Windows.Forms.Label();
            this.lb_freqProfile = new System.Windows.Forms.Label();
            this.lb_freqtype = new System.Windows.Forms.Label();
            this.lb_profile = new System.Windows.Forms.Label();
            this.lb_power = new System.Windows.Forms.Label();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_c51bldr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_c51App = new System.Windows.Forms.Label();
            this.btn_kill = new System.Windows.Forms.Button();
            this.btn_writeany = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDeviceType = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.labelApiMode = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.labelInterface = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label_ConfigFilePath = new System.Windows.Forms.Label();
            this.label_BootloaderMode = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rw
            // 
            this.btn_rw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_rw.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_rw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_rw.Location = new System.Drawing.Point(3, 36);
            this.btn_rw.Name = "btn_rw";
            this.btn_rw.Size = new System.Drawing.Size(112, 27);
            this.btn_rw.TabIndex = 1;
            this.btn_rw.Text = "ReadWrite";
            this.btn_rw.UseVisualStyleBackColor = false;
            this.btn_rw.Click += new System.EventHandler(this.btn_rw_Click);
            // 
            // btn_geiger
            // 
            this.btn_geiger.BackColor = System.Drawing.Color.Lime;
            this.btn_geiger.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_geiger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_geiger.Location = new System.Drawing.Point(3, 101);
            this.btn_geiger.Name = "btn_geiger";
            this.btn_geiger.Size = new System.Drawing.Size(112, 27);
            this.btn_geiger.TabIndex = 2;
            this.btn_geiger.Text = "Geiger";
            this.btn_geiger.UseVisualStyleBackColor = false;
            this.btn_geiger.Click += new System.EventHandler(this.btn_geiger_Click);
            // 
            // btn_security
            // 
            this.btn_security.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_security.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_security.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_security.Location = new System.Drawing.Point(3, 134);
            this.btn_security.Name = "btn_security";
            this.btn_security.Size = new System.Drawing.Size(112, 27);
            this.btn_security.TabIndex = 3;
            this.btn_security.Text = "Security";
            this.btn_security.UseVisualStyleBackColor = false;
            this.btn_security.Click += new System.EventHandler(this.btn_security_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_back.Location = new System.Drawing.Point(3, 425);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(112, 27);
            this.btn_back.TabIndex = 6;
            this.btn_back.Text = "Exit";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_setup
            // 
            this.btn_setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_setup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_setup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_setup.Location = new System.Drawing.Point(3, 388);
            this.btn_setup.Name = "btn_setup";
            this.btn_setup.Size = new System.Drawing.Size(112, 27);
            this.btn_setup.TabIndex = 5;
            this.btn_setup.Text = "Setup";
            this.btn_setup.UseVisualStyleBackColor = false;
            this.btn_setup.Click += new System.EventHandler(this.btn_setup_Click);
            // 
            // btn_inv
            // 
            this.btn_inv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_inv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_inv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_inv.Location = new System.Drawing.Point(3, 3);
            this.btn_inv.Name = "btn_inv";
            this.btn_inv.Size = new System.Drawing.Size(112, 27);
            this.btn_inv.TabIndex = 0;
            this.btn_inv.Text = "Inventory";
            this.btn_inv.UseVisualStyleBackColor = false;
            this.btn_inv.Click += new System.EventHandler(this.btn_inv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Demo App Vers";
            // 
            // lb_software
            // 
            this.lb_software.AutoSize = true;
            this.lb_software.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_software.Location = new System.Drawing.Point(400, 54);
            this.lb_software.Name = "lb_software";
            this.lb_software.Size = new System.Drawing.Size(33, 13);
            this.lb_software.TabIndex = 10;
            this.lb_software.Text = "1.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "RFID Firmware Vers";
            // 
            // lb_firmware
            // 
            this.lb_firmware.AutoSize = true;
            this.lb_firmware.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_firmware.Location = new System.Drawing.Point(400, 132);
            this.lb_firmware.Name = "lb_firmware";
            this.lb_firmware.Size = new System.Drawing.Size(33, 13);
            this.lb_firmware.TabIndex = 6;
            this.lb_firmware.Text = "1.0.0";
            this.lb_firmware.Click += new System.EventHandler(this.lb_firmware_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(264, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "CSLib Vers";
            // 
            // lb_cslib
            // 
            this.lb_cslib.AutoSize = true;
            this.lb_cslib.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cslib.Location = new System.Drawing.Point(400, 78);
            this.lb_cslib.Name = "lb_cslib";
            this.lb_cslib.Size = new System.Drawing.Size(33, 13);
            this.lb_cslib.TabIndex = 0;
            this.lb_cslib.Text = "1.0.0";
            // 
            // lb_freqProfile
            // 
            this.lb_freqProfile.AutoSize = true;
            this.lb_freqProfile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_freqProfile.Location = new System.Drawing.Point(264, 207);
            this.lb_freqProfile.Name = "lb_freqProfile";
            this.lb_freqProfile.Size = new System.Drawing.Size(147, 13);
            this.lb_freqProfile.TabIndex = 4;
            this.lb_freqProfile.Text = "Frequency Band : Hong Kong";
            // 
            // lb_freqtype
            // 
            this.lb_freqtype.AutoSize = true;
            this.lb_freqtype.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_freqtype.Location = new System.Drawing.Point(264, 229);
            this.lb_freqtype.Name = "lb_freqtype";
            this.lb_freqtype.Size = new System.Drawing.Size(107, 13);
            this.lb_freqtype.TabIndex = 3;
            this.lb_freqtype.Text = "Frequency : Hopping";
            // 
            // lb_profile
            // 
            this.lb_profile.AutoSize = true;
            this.lb_profile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_profile.Location = new System.Drawing.Point(264, 251);
            this.lb_profile.Name = "lb_profile";
            this.lb_profile.Size = new System.Drawing.Size(53, 13);
            this.lb_profile.TabIndex = 2;
            this.lb_profile.Text = "Profile : 2";
            // 
            // lb_power
            // 
            this.lb_power.AutoSize = true;
            this.lb_power.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_power.Location = new System.Drawing.Point(264, 271);
            this.lb_power.Name = "lb_power";
            this.lb_power.Size = new System.Drawing.Size(82, 13);
            this.lb_power.TabIndex = 1;
            this.lb_power.Text = "Power : 30 dBm";
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(267, 388);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(209, 71);
            this.pb_logo.TabIndex = 12;
            this.pb_logo.TabStop = false;
            this.pb_logo.MouseLeave += new System.EventHandler(this.pb_logo_MouseLeave);
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            this.pb_logo.MouseEnter += new System.EventHandler(this.pb_logo_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Network Proc BootLoader";
            // 
            // lb_c51bldr
            // 
            this.lb_c51bldr.AutoSize = true;
            this.lb_c51bldr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_c51bldr.Location = new System.Drawing.Point(400, 154);
            this.lb_c51bldr.Name = "lb_c51bldr";
            this.lb_c51bldr.Size = new System.Drawing.Size(33, 13);
            this.lb_c51bldr.TabIndex = 0;
            this.lb_c51bldr.Text = "1.0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Network Proc  8051 App";
            // 
            // lb_c51App
            // 
            this.lb_c51App.AutoSize = true;
            this.lb_c51App.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_c51App.Location = new System.Drawing.Point(400, 176);
            this.lb_c51App.Name = "lb_c51App";
            this.lb_c51App.Size = new System.Drawing.Size(33, 13);
            this.lb_c51App.TabIndex = 0;
            this.lb_c51App.Text = "1.0.0";
            // 
            // btn_kill
            // 
            this.btn_kill.BackColor = System.Drawing.Color.Red;
            this.btn_kill.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_kill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_kill.Location = new System.Drawing.Point(3, 166);
            this.btn_kill.Name = "btn_kill";
            this.btn_kill.Size = new System.Drawing.Size(112, 27);
            this.btn_kill.TabIndex = 4;
            this.btn_kill.Text = "Kill";
            this.btn_kill.UseVisualStyleBackColor = false;
            this.btn_kill.Click += new System.EventHandler(this.btn_kill_Click);
            // 
            // btn_writeany
            // 
            this.btn_writeany.BackColor = System.Drawing.Color.Green;
            this.btn_writeany.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_writeany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_writeany.Location = new System.Drawing.Point(3, 68);
            this.btn_writeany.Name = "btn_writeany";
            this.btn_writeany.Size = new System.Drawing.Size(112, 27);
            this.btn_writeany.TabIndex = 1;
            this.btn_writeany.Text = "WriteAny";
            this.btn_writeany.UseVisualStyleBackColor = false;
            this.btn_writeany.Click += new System.EventHandler(this.btn_writeany_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(265, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Device Type :";
            // 
            // labelDeviceType
            // 
            this.labelDeviceType.AutoSize = true;
            this.labelDeviceType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceType.Location = new System.Drawing.Point(344, 291);
            this.labelDeviceType.Name = "labelDeviceType";
            this.labelDeviceType.Size = new System.Drawing.Size(35, 13);
            this.labelDeviceType.TabIndex = 16;
            this.labelDeviceType.Text = "label6";
            this.labelDeviceType.Click += new System.EventHandler(this.labelDeviceType_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkKhaki;
            this.button3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.Location = new System.Drawing.Point(3, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 27);
            this.button3.TabIndex = 18;
            this.button3.Text = "Monza4QT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkOrange;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button4.Location = new System.Drawing.Point(130, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 27);
            this.button4.TabIndex = 19;
            this.button4.Text = "G2iL/M";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Reader Side Version:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(264, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "PC Side Version:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(265, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "C# Native 3.0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(3, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "ColdChain";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FloralWhite;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(3, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 27);
            this.button2.TabIndex = 23;
            this.button2.Text = "CS9010";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button5.Location = new System.Drawing.Point(130, 168);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 27);
            this.button5.TabIndex = 25;
            this.button5.Text = "Temp Mon";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Lime;
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button6.Location = new System.Drawing.Point(130, 102);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 27);
            this.button6.TabIndex = 26;
            this.button6.Text = "Set Interface";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkKhaki;
            this.button7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button7.Location = new System.Drawing.Point(130, 201);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 27);
            this.button7.TabIndex = 27;
            this.button7.Text = "InvGPIOSyn";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.DarkOrange;
            this.button8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button8.Location = new System.Drawing.Point(130, 36);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 27);
            this.button8.TabIndex = 28;
            this.button8.Text = "G2iL Func";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DarkKhaki;
            this.button9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button9.Location = new System.Drawing.Point(130, 234);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 27);
            this.button9.TabIndex = 29;
            this.button9.Text = "InvGPIOAsyn";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // labelApiMode
            // 
            this.labelApiMode.AutoSize = true;
            this.labelApiMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApiMode.Location = new System.Drawing.Point(264, 312);
            this.labelApiMode.Name = "labelApiMode";
            this.labelApiMode.Size = new System.Drawing.Size(60, 13);
            this.labelApiMode.TabIndex = 30;
            this.labelApiMode.Text = "API Mode :";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.DarkKhaki;
            this.button10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button10.Location = new System.Drawing.Point(130, 135);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(112, 27);
            this.button10.TabIndex = 31;
            this.button10.Text = "Set API Mode";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // labelInterface
            // 
            this.labelInterface.AutoSize = true;
            this.labelInterface.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInterface.Location = new System.Drawing.Point(265, 331);
            this.labelInterface.Name = "labelInterface";
            this.labelInterface.Size = new System.Drawing.Size(59, 13);
            this.labelInterface.TabIndex = 32;
            this.labelInterface.Text = "Interface :";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Lime;
            this.button11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button11.Location = new System.Drawing.Point(130, 69);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(112, 27);
            this.button11.TabIndex = 33;
            this.button11.Text = "UCODE7";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label_ConfigFilePath
            // 
            this.label_ConfigFilePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigFilePath.Location = new System.Drawing.Point(265, 350);
            this.label_ConfigFilePath.Name = "label_ConfigFilePath";
            this.label_ConfigFilePath.Size = new System.Drawing.Size(229, 32);
            this.label_ConfigFilePath.TabIndex = 34;
            this.label_ConfigFilePath.Text = "Config File Path :";
            // 
            // label_BootloaderMode
            // 
            this.label_BootloaderMode.AutoSize = true;
            this.label_BootloaderMode.ForeColor = System.Drawing.Color.Red;
            this.label_BootloaderMode.Location = new System.Drawing.Point(439, 134);
            this.label_BootloaderMode.Name = "label_BootloaderMode";
            this.label_BootloaderMode.Size = new System.Drawing.Size(95, 12);
            this.label_BootloaderMode.TabIndex = 35;
            this.label_BootloaderMode.Text = "(Bootloader Mode)";
            this.label_BootloaderMode.Visible = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.DarkKhaki;
            this.button12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button12.Location = new System.Drawing.Point(130, 267);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(112, 27);
            this.button12.TabIndex = 36;
            this.button12.Text = "TID Demo";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(547, 471);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label_BootloaderMode);
            this.Controls.Add(this.label_ConfigFilePath);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.labelInterface);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.labelApiMode);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelDeviceType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_c51App);
            this.Controls.Add(this.lb_c51bldr);
            this.Controls.Add(this.lb_cslib);
            this.Controls.Add(this.lb_power);
            this.Controls.Add(this.lb_profile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_freqtype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_freqProfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_firmware);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_software);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_kill);
            this.Controls.Add(this.btn_setup);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_security);
            this.Controls.Add(this.btn_geiger);
            this.Controls.Add(this.btn_inv);
            this.Controls.Add(this.btn_writeany);
            this.Controls.Add(this.btn_rw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Application";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rw;
        private System.Windows.Forms.Button btn_geiger;
        private System.Windows.Forms.Button btn_security;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_setup;
        private System.Windows.Forms.Button btn_inv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_software;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_firmware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_cslib;
        private System.Windows.Forms.Label lb_freqProfile;
        private System.Windows.Forms.Label lb_freqtype;
        private System.Windows.Forms.Label lb_profile;
        private System.Windows.Forms.Label lb_power;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_c51bldr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_c51App;
        private System.Windows.Forms.Button btn_kill;
        private System.Windows.Forms.Button btn_writeany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDeviceType;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label labelApiMode;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label labelInterface;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label_ConfigFilePath;
        private System.Windows.Forms.Label label_BootloaderMode;
        private System.Windows.Forms.Button button12;
    }
}