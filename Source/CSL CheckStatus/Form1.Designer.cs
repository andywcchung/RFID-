namespace CS203_CheckStatus
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbPower = new System.Windows.Forms.Label();
            this.lbReset = new System.Windows.Forms.Label();
            this.lbKeepAlive = new System.Windows.Forms.Label();
            this.lbConnect = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbElapsed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_5VOutStatus = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbGPI1Interrupt = new System.Windows.Forms.Label();
            this.lbGPI0Interrupt = new System.Windows.Forms.Label();
            this.lbGPO1 = new System.Windows.Forms.Label();
            this.lbGPI1 = new System.Windows.Forms.Label();
            this.lbGPO0 = new System.Windows.Forms.Label();
            this.lbGPI0 = new System.Windows.Forms.Label();
            this.lbCrcFilter = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Get5VStatus = new System.Windows.Forms.Button();
            this.button_Set5VOff = new System.Windows.Forms.Button();
            this.btnForceReset = new System.Windows.Forms.Button();
            this.button_Set5VOn = new System.Windows.Forms.Button();
            this.btnKeepAliveOff = new System.Windows.Forms.Button();
            this.btnKeepAliveOn = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCrcFilterOff = new System.Windows.Forms.Button();
            this.btnCrcFilterOn = new System.Windows.Forms.Button();
            this.btnErrRstOff = new System.Windows.Forms.Button();
            this.btnErrRstOn = new System.Windows.Forms.Button();
            this.btnPowerOff = new System.Windows.Forms.Button();
            this.btnPowerOn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_GetGPI1 = new System.Windows.Forms.Button();
            this.button_GetGPI0 = new System.Windows.Forms.Button();
            this.btnGPO1Off = new System.Windows.Forms.Button();
            this.btnGPO1On = new System.Windows.Forms.Button();
            this.btnGPO0Off = new System.Windows.Forms.Button();
            this.btnGPO0On = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnStopPoll = new System.Windows.Forms.Button();
            this.btnStartPoll = new System.Windows.Forms.Button();
            this.cbGPI1Interrupt = new System.Windows.Forms.ComboBox();
            this.cbGPI0Interrupt = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGPI1Interrupt = new System.Windows.Forms.Button();
            this.btnGPI0Interrupt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Power:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Error Reset:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "UDP KeepAlive:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Connection:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.label5, "Device Connection Status");
            // 
            // lbPower
            // 
            this.lbPower.ForeColor = System.Drawing.Color.Blue;
            this.lbPower.Location = new System.Drawing.Point(134, 18);
            this.lbPower.Name = "lbPower";
            this.lbPower.Size = new System.Drawing.Size(100, 23);
            this.lbPower.TabIndex = 2;
            this.lbPower.Text = "UNKNOWN";
            this.lbPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPower.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbReset
            // 
            this.lbReset.ForeColor = System.Drawing.Color.Blue;
            this.lbReset.Location = new System.Drawing.Point(134, 41);
            this.lbReset.Name = "lbReset";
            this.lbReset.Size = new System.Drawing.Size(100, 23);
            this.lbReset.TabIndex = 2;
            this.lbReset.Text = "UNKNOWN";
            this.lbReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbReset.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbKeepAlive
            // 
            this.lbKeepAlive.ForeColor = System.Drawing.Color.Blue;
            this.lbKeepAlive.Location = new System.Drawing.Point(134, 64);
            this.lbKeepAlive.Name = "lbKeepAlive";
            this.lbKeepAlive.Size = new System.Drawing.Size(100, 23);
            this.lbKeepAlive.TabIndex = 2;
            this.lbKeepAlive.Text = "UNKNOWN";
            this.lbKeepAlive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKeepAlive.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbConnect
            // 
            this.lbConnect.ForeColor = System.Drawing.Color.Blue;
            this.lbConnect.Location = new System.Drawing.Point(134, 110);
            this.lbConnect.Name = "lbConnect";
            this.lbConnect.Size = new System.Drawing.Size(100, 23);
            this.lbConnect.TabIndex = 2;
            this.lbConnect.Text = "UNKNOWN";
            this.lbConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbConnect.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Elapsed Time:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.label9, "last received RFID packet time\r\n(days:hours:minutes:seconds)");
            // 
            // lbElapsed
            // 
            this.lbElapsed.ForeColor = System.Drawing.Color.Blue;
            this.lbElapsed.Location = new System.Drawing.Point(134, 133);
            this.lbElapsed.Name = "lbElapsed";
            this.lbElapsed.Size = new System.Drawing.Size(118, 23);
            this.lbElapsed.TabIndex = 2;
            this.lbElapsed.Text = "UNKNOWN";
            this.lbElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbElapsed.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_5VOutStatus);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbGPI1Interrupt);
            this.groupBox1.Controls.Add(this.lbGPI0Interrupt);
            this.groupBox1.Controls.Add(this.lbGPO1);
            this.groupBox1.Controls.Add(this.lbGPI1);
            this.groupBox1.Controls.Add(this.lbGPO0);
            this.groupBox1.Controls.Add(this.lbGPI0);
            this.groupBox1.Controls.Add(this.lbElapsed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbCrcFilter);
            this.groupBox1.Controls.Add(this.lbConnect);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lbKeepAlive);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbReset);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbPower);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 326);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Status";
            // 
            // label_5VOutStatus
            // 
            this.label_5VOutStatus.ForeColor = System.Drawing.Color.Blue;
            this.label_5VOutStatus.Location = new System.Drawing.Point(134, 156);
            this.label_5VOutStatus.Name = "label_5VOutStatus";
            this.label_5VOutStatus.Size = new System.Drawing.Size(118, 23);
            this.label_5VOutStatus.TabIndex = 4;
            this.label_5VOutStatus.Text = "UNKNOWN";
            this.label_5VOutStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_5VOutStatus.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "5V Out:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "CRC Filter:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGPI1Interrupt
            // 
            this.lbGPI1Interrupt.ForeColor = System.Drawing.Color.Blue;
            this.lbGPI1Interrupt.Location = new System.Drawing.Point(134, 294);
            this.lbGPI1Interrupt.Name = "lbGPI1Interrupt";
            this.lbGPI1Interrupt.Size = new System.Drawing.Size(118, 23);
            this.lbGPI1Interrupt.TabIndex = 2;
            this.lbGPI1Interrupt.Text = "UNKNOWN";
            this.lbGPI1Interrupt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPI1Interrupt.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbGPI0Interrupt
            // 
            this.lbGPI0Interrupt.ForeColor = System.Drawing.Color.Blue;
            this.lbGPI0Interrupt.Location = new System.Drawing.Point(134, 271);
            this.lbGPI0Interrupt.Name = "lbGPI0Interrupt";
            this.lbGPI0Interrupt.Size = new System.Drawing.Size(118, 23);
            this.lbGPI0Interrupt.TabIndex = 2;
            this.lbGPI0Interrupt.Text = "UNKNOWN";
            this.lbGPI0Interrupt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPI0Interrupt.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbGPO1
            // 
            this.lbGPO1.ForeColor = System.Drawing.Color.Blue;
            this.lbGPO1.Location = new System.Drawing.Point(134, 248);
            this.lbGPO1.Name = "lbGPO1";
            this.lbGPO1.Size = new System.Drawing.Size(118, 23);
            this.lbGPO1.TabIndex = 2;
            this.lbGPO1.Text = "UNKNOWN";
            this.lbGPO1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPO1.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbGPI1
            // 
            this.lbGPI1.ForeColor = System.Drawing.Color.Blue;
            this.lbGPI1.Location = new System.Drawing.Point(134, 202);
            this.lbGPI1.Name = "lbGPI1";
            this.lbGPI1.Size = new System.Drawing.Size(118, 23);
            this.lbGPI1.TabIndex = 2;
            this.lbGPI1.Text = "UNKNOWN";
            this.lbGPI1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPI1.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbGPO0
            // 
            this.lbGPO0.ForeColor = System.Drawing.Color.Blue;
            this.lbGPO0.Location = new System.Drawing.Point(134, 225);
            this.lbGPO0.Name = "lbGPO0";
            this.lbGPO0.Size = new System.Drawing.Size(118, 23);
            this.lbGPO0.TabIndex = 2;
            this.lbGPO0.Text = "UNKNOWN";
            this.lbGPO0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPO0.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbGPI0
            // 
            this.lbGPI0.ForeColor = System.Drawing.Color.Blue;
            this.lbGPI0.Location = new System.Drawing.Point(134, 179);
            this.lbGPI0.Name = "lbGPI0";
            this.lbGPI0.Size = new System.Drawing.Size(118, 23);
            this.lbGPI0.TabIndex = 2;
            this.lbGPI0.Text = "UNKNOWN";
            this.lbGPI0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGPI0.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lbCrcFilter
            // 
            this.lbCrcFilter.ForeColor = System.Drawing.Color.Blue;
            this.lbCrcFilter.Location = new System.Drawing.Point(134, 87);
            this.lbCrcFilter.Name = "lbCrcFilter";
            this.lbCrcFilter.Size = new System.Drawing.Size(100, 23);
            this.lbCrcFilter.TabIndex = 2;
            this.lbCrcFilter.Text = "UNKNOWN";
            this.lbCrcFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCrcFilter.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 294);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "GPI1 Interrupt:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 1;
            this.label13.Text = "GPI0 Interrupt:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 1;
            this.label10.Text = "GPO1:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "GPI1:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "GPO0:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "GPI0:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbIpAddress);
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Device";
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbIpAddress.Location = new System.Drawing.Point(21, 21);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(231, 31);
            this.tbIpAddress.TabIndex = 0;
            this.tbIpAddress.Text = "192.168.25.205";
            this.tbIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Get5VStatus);
            this.groupBox3.Controls.Add(this.button_Set5VOff);
            this.groupBox3.Controls.Add(this.btnForceReset);
            this.groupBox3.Controls.Add(this.button_Set5VOn);
            this.groupBox3.Controls.Add(this.btnKeepAliveOff);
            this.groupBox3.Controls.Add(this.btnKeepAliveOn);
            this.groupBox3.Controls.Add(this.btnCheck);
            this.groupBox3.Location = new System.Drawing.Point(297, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 139);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ControlBox";
            // 
            // button_Get5VStatus
            // 
            this.button_Get5VStatus.Location = new System.Drawing.Point(8, 108);
            this.button_Get5VStatus.Name = "button_Get5VStatus";
            this.button_Get5VStatus.Size = new System.Drawing.Size(113, 23);
            this.button_Get5VStatus.TabIndex = 11;
            this.button_Get5VStatus.Text = "Get 5V Out Status";
            this.button_Get5VStatus.UseVisualStyleBackColor = true;
            this.button_Get5VStatus.Click += new System.EventHandler(this.button_Get5VStatus_Click);
            // 
            // button_Set5VOff
            // 
            this.button_Set5VOff.Location = new System.Drawing.Point(149, 79);
            this.button_Set5VOff.Name = "button_Set5VOff";
            this.button_Set5VOff.Size = new System.Drawing.Size(113, 23);
            this.button_Set5VOff.TabIndex = 10;
            this.button_Set5VOff.Text = "5V Off";
            this.button_Set5VOff.UseVisualStyleBackColor = true;
            this.button_Set5VOff.Click += new System.EventHandler(this.button_Set5VOff_Click);
            // 
            // btnForceReset
            // 
            this.btnForceReset.Location = new System.Drawing.Point(149, 21);
            this.btnForceReset.Name = "btnForceReset";
            this.btnForceReset.Size = new System.Drawing.Size(113, 23);
            this.btnForceReset.TabIndex = 6;
            this.btnForceReset.Text = "Force Reset";
            this.toolTip1.SetToolTip(this.btnForceReset, "Reset Device");
            this.btnForceReset.UseVisualStyleBackColor = true;
            this.btnForceReset.Click += new System.EventHandler(this.btnForceReset_Click);
            // 
            // button_Set5VOn
            // 
            this.button_Set5VOn.Location = new System.Drawing.Point(8, 79);
            this.button_Set5VOn.Name = "button_Set5VOn";
            this.button_Set5VOn.Size = new System.Drawing.Size(113, 23);
            this.button_Set5VOn.TabIndex = 9;
            this.button_Set5VOn.Text = "5V On";
            this.button_Set5VOn.UseVisualStyleBackColor = true;
            this.button_Set5VOn.Click += new System.EventHandler(this.button_Set5VOn_Click);
            // 
            // btnKeepAliveOff
            // 
            this.btnKeepAliveOff.Location = new System.Drawing.Point(149, 50);
            this.btnKeepAliveOff.Name = "btnKeepAliveOff";
            this.btnKeepAliveOff.Size = new System.Drawing.Size(113, 23);
            this.btnKeepAliveOff.TabIndex = 6;
            this.btnKeepAliveOff.Text = "KeepAlive Off";
            this.toolTip1.SetToolTip(this.btnKeepAliveOff, "TurnOff UDP KeepAlive");
            this.btnKeepAliveOff.UseVisualStyleBackColor = true;
            this.btnKeepAliveOff.Click += new System.EventHandler(this.btnKeepAliveOff_Click);
            // 
            // btnKeepAliveOn
            // 
            this.btnKeepAliveOn.Location = new System.Drawing.Point(8, 50);
            this.btnKeepAliveOn.Name = "btnKeepAliveOn";
            this.btnKeepAliveOn.Size = new System.Drawing.Size(113, 23);
            this.btnKeepAliveOn.TabIndex = 6;
            this.btnKeepAliveOn.Text = "KeepAlive On";
            this.toolTip1.SetToolTip(this.btnKeepAliveOn, "TurnOn UDP KeepAlive");
            this.btnKeepAliveOn.UseVisualStyleBackColor = true;
            this.btnKeepAliveOn.Click += new System.EventHandler(this.btnKeepAliveOn_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(8, 21);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(113, 23);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Check Status";
            this.toolTip1.SetToolTip(this.btnCheck, "Check current device status");
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCrcFilterOff
            // 
            this.btnCrcFilterOff.Location = new System.Drawing.Point(873, 139);
            this.btnCrcFilterOff.Name = "btnCrcFilterOff";
            this.btnCrcFilterOff.Size = new System.Drawing.Size(113, 23);
            this.btnCrcFilterOff.TabIndex = 6;
            this.btnCrcFilterOff.Text = "CRC Filter Off";
            this.btnCrcFilterOff.UseVisualStyleBackColor = true;
            this.btnCrcFilterOff.Click += new System.EventHandler(this.btnCrcFilterOff_Click);
            // 
            // btnCrcFilterOn
            // 
            this.btnCrcFilterOn.Location = new System.Drawing.Point(732, 139);
            this.btnCrcFilterOn.Name = "btnCrcFilterOn";
            this.btnCrcFilterOn.Size = new System.Drawing.Size(113, 23);
            this.btnCrcFilterOn.TabIndex = 6;
            this.btnCrcFilterOn.Text = "CRC Filter On";
            this.btnCrcFilterOn.UseVisualStyleBackColor = true;
            this.btnCrcFilterOn.Click += new System.EventHandler(this.btnCrcFilterOn_Click);
            // 
            // btnErrRstOff
            // 
            this.btnErrRstOff.Location = new System.Drawing.Point(873, 110);
            this.btnErrRstOff.Name = "btnErrRstOff";
            this.btnErrRstOff.Size = new System.Drawing.Size(113, 23);
            this.btnErrRstOff.TabIndex = 6;
            this.btnErrRstOff.Text = "Error Reset Off";
            this.btnErrRstOff.UseVisualStyleBackColor = true;
            this.btnErrRstOff.Click += new System.EventHandler(this.btnErrRstOff_Click);
            // 
            // btnErrRstOn
            // 
            this.btnErrRstOn.Location = new System.Drawing.Point(732, 110);
            this.btnErrRstOn.Name = "btnErrRstOn";
            this.btnErrRstOn.Size = new System.Drawing.Size(113, 23);
            this.btnErrRstOn.TabIndex = 6;
            this.btnErrRstOn.Text = "Error Reset On";
            this.btnErrRstOn.UseVisualStyleBackColor = true;
            this.btnErrRstOn.Click += new System.EventHandler(this.btnErrRstOn_Click);
            // 
            // btnPowerOff
            // 
            this.btnPowerOff.Location = new System.Drawing.Point(873, 81);
            this.btnPowerOff.Name = "btnPowerOff";
            this.btnPowerOff.Size = new System.Drawing.Size(113, 23);
            this.btnPowerOff.TabIndex = 6;
            this.btnPowerOff.Text = "RFID Power Off";
            this.btnPowerOff.UseVisualStyleBackColor = true;
            this.btnPowerOff.Click += new System.EventHandler(this.btnPowerOff_Click);
            // 
            // btnPowerOn
            // 
            this.btnPowerOn.Location = new System.Drawing.Point(732, 81);
            this.btnPowerOn.Name = "btnPowerOn";
            this.btnPowerOn.Size = new System.Drawing.Size(113, 23);
            this.btnPowerOn.TabIndex = 6;
            this.btnPowerOn.Text = "RFID Power On";
            this.btnPowerOn.UseVisualStyleBackColor = true;
            this.btnPowerOn.Click += new System.EventHandler(this.btnPowerOn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(577, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_GetGPI1);
            this.groupBox4.Controls.Add(this.button_GetGPI0);
            this.groupBox4.Controls.Add(this.btnGPO1Off);
            this.groupBox4.Controls.Add(this.btnGPO1On);
            this.groupBox4.Controls.Add(this.btnGPO0Off);
            this.groupBox4.Controls.Add(this.btnGPO0On);
            this.groupBox4.Location = new System.Drawing.Point(297, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 120);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GPIO";
            // 
            // button_GetGPI1
            // 
            this.button_GetGPI1.Location = new System.Drawing.Point(149, 79);
            this.button_GetGPI1.Name = "button_GetGPI1";
            this.button_GetGPI1.Size = new System.Drawing.Size(113, 23);
            this.button_GetGPI1.TabIndex = 2;
            this.button_GetGPI1.Text = "Get GPI1";
            this.button_GetGPI1.UseVisualStyleBackColor = true;
            this.button_GetGPI1.Click += new System.EventHandler(this.button_GetGPI1_Click);
            // 
            // button_GetGPI0
            // 
            this.button_GetGPI0.Location = new System.Drawing.Point(8, 79);
            this.button_GetGPI0.Name = "button_GetGPI0";
            this.button_GetGPI0.Size = new System.Drawing.Size(113, 23);
            this.button_GetGPI0.TabIndex = 1;
            this.button_GetGPI0.Text = "Get GPI0";
            this.button_GetGPI0.UseVisualStyleBackColor = true;
            this.button_GetGPI0.Click += new System.EventHandler(this.button_GetGPI0_Click);
            // 
            // btnGPO1Off
            // 
            this.btnGPO1Off.Location = new System.Drawing.Point(149, 50);
            this.btnGPO1Off.Name = "btnGPO1Off";
            this.btnGPO1Off.Size = new System.Drawing.Size(113, 23);
            this.btnGPO1Off.TabIndex = 0;
            this.btnGPO1Off.Text = "GPO1 Off";
            this.btnGPO1Off.UseVisualStyleBackColor = true;
            this.btnGPO1Off.Click += new System.EventHandler(this.btnGPO1Off_Click);
            // 
            // btnGPO1On
            // 
            this.btnGPO1On.Location = new System.Drawing.Point(8, 50);
            this.btnGPO1On.Name = "btnGPO1On";
            this.btnGPO1On.Size = new System.Drawing.Size(113, 23);
            this.btnGPO1On.TabIndex = 0;
            this.btnGPO1On.Text = "GPO1 On";
            this.btnGPO1On.UseVisualStyleBackColor = true;
            this.btnGPO1On.Click += new System.EventHandler(this.btnGPO1On_Click);
            // 
            // btnGPO0Off
            // 
            this.btnGPO0Off.Location = new System.Drawing.Point(149, 21);
            this.btnGPO0Off.Name = "btnGPO0Off";
            this.btnGPO0Off.Size = new System.Drawing.Size(113, 23);
            this.btnGPO0Off.TabIndex = 0;
            this.btnGPO0Off.Text = "GPO0 Off";
            this.btnGPO0Off.UseVisualStyleBackColor = true;
            this.btnGPO0Off.Click += new System.EventHandler(this.btnGPO0Off_Click);
            // 
            // btnGPO0On
            // 
            this.btnGPO0On.Location = new System.Drawing.Point(8, 21);
            this.btnGPO0On.Name = "btnGPO0On";
            this.btnGPO0On.Size = new System.Drawing.Size(113, 23);
            this.btnGPO0On.TabIndex = 0;
            this.btnGPO0On.Text = "GPO0 On";
            this.btnGPO0On.UseVisualStyleBackColor = true;
            this.btnGPO0On.Click += new System.EventHandler(this.btnGPO0On_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnStopPoll);
            this.groupBox5.Controls.Add(this.btnStartPoll);
            this.groupBox5.Controls.Add(this.cbGPI1Interrupt);
            this.groupBox5.Controls.Add(this.cbGPI0Interrupt);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.btnGPI1Interrupt);
            this.groupBox5.Controls.Add(this.btnGPI0Interrupt);
            this.groupBox5.Location = new System.Drawing.Point(297, 283);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 124);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPI Interrupt";
            // 
            // btnStopPoll
            // 
            this.btnStopPoll.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStopPoll.Location = new System.Drawing.Point(140, 76);
            this.btnStopPoll.Name = "btnStopPoll";
            this.btnStopPoll.Size = new System.Drawing.Size(122, 42);
            this.btnStopPoll.TabIndex = 3;
            this.btnStopPoll.Text = "Stop Receiving GPI Status";
            this.btnStopPoll.UseVisualStyleBackColor = true;
            this.btnStopPoll.Click += new System.EventHandler(this.btnStopPoll_Click);
            // 
            // btnStartPoll
            // 
            this.btnStartPoll.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStartPoll.Location = new System.Drawing.Point(8, 76);
            this.btnStartPoll.Name = "btnStartPoll";
            this.btnStartPoll.Size = new System.Drawing.Size(126, 42);
            this.btnStartPoll.TabIndex = 3;
            this.btnStartPoll.Text = "Start Receiving GPI Status";
            this.btnStartPoll.UseVisualStyleBackColor = true;
            this.btnStartPoll.Click += new System.EventHandler(this.btnStartPoll_Click);
            // 
            // cbGPI1Interrupt
            // 
            this.cbGPI1Interrupt.FormattingEnabled = true;
            this.cbGPI1Interrupt.Items.AddRange(new object[] {
            "OFF",
            "Raising edge",
            "Falling edge",
            "Any Trigger"});
            this.cbGPI1Interrupt.Location = new System.Drawing.Point(61, 50);
            this.cbGPI1Interrupt.Name = "cbGPI1Interrupt";
            this.cbGPI1Interrupt.Size = new System.Drawing.Size(121, 20);
            this.cbGPI1Interrupt.TabIndex = 2;
            // 
            // cbGPI0Interrupt
            // 
            this.cbGPI0Interrupt.FormattingEnabled = true;
            this.cbGPI0Interrupt.Items.AddRange(new object[] {
            "OFF",
            "Raising edge",
            "Falling edge",
            "Any Trigger"});
            this.cbGPI0Interrupt.Location = new System.Drawing.Point(61, 21);
            this.cbGPI0Interrupt.Name = "cbGPI0Interrupt";
            this.cbGPI0Interrupt.Size = new System.Drawing.Size(121, 20);
            this.cbGPI0Interrupt.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "GPI1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "GPI0";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGPI1Interrupt
            // 
            this.btnGPI1Interrupt.Location = new System.Drawing.Point(187, 50);
            this.btnGPI1Interrupt.Name = "btnGPI1Interrupt";
            this.btnGPI1Interrupt.Size = new System.Drawing.Size(75, 23);
            this.btnGPI1Interrupt.TabIndex = 0;
            this.btnGPI1Interrupt.Text = "Set";
            this.btnGPI1Interrupt.UseVisualStyleBackColor = true;
            this.btnGPI1Interrupt.Click += new System.EventHandler(this.btnGPI1Interrupt_Click);
            // 
            // btnGPI0Interrupt
            // 
            this.btnGPI0Interrupt.Location = new System.Drawing.Point(187, 21);
            this.btnGPI0Interrupt.Name = "btnGPI0Interrupt";
            this.btnGPI0Interrupt.Size = new System.Drawing.Size(75, 23);
            this.btnGPI0Interrupt.TabIndex = 0;
            this.btnGPI0Interrupt.Text = "Set";
            this.btnGPI0Interrupt.UseVisualStyleBackColor = true;
            this.btnGPI0Interrupt.Click += new System.EventHandler(this.btnGPI0Interrupt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 442);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnCrcFilterOff);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCrcFilterOn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnErrRstOff);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnErrRstOn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPowerOff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPowerOn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS203 Check Status";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbPower;
        private System.Windows.Forms.Label lbReset;
        private System.Windows.Forms.Label lbKeepAlive;
        private System.Windows.Forms.Label lbConnect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbElapsed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnForceReset;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnKeepAliveOff;
        private System.Windows.Forms.Button btnKeepAliveOn;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Button btnErrRstOff;
        private System.Windows.Forms.Button btnErrRstOn;
        private System.Windows.Forms.Button btnPowerOff;
        private System.Windows.Forms.Button btnPowerOn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbCrcFilter;
        private System.Windows.Forms.Button btnCrcFilterOff;
        private System.Windows.Forms.Button btnCrcFilterOn;
        private System.Windows.Forms.Label lbGPI0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbGPI1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbGPO1;
        private System.Windows.Forms.Label lbGPO0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGPO1Off;
        private System.Windows.Forms.Button btnGPO1On;
        private System.Windows.Forms.Button btnGPO0Off;
        private System.Windows.Forms.Button btnGPO0On;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnGPI0Interrupt;
        private System.Windows.Forms.ComboBox cbGPI1Interrupt;
        private System.Windows.Forms.ComboBox cbGPI0Interrupt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGPI1Interrupt;
        private System.Windows.Forms.Label lbGPI1Interrupt;
        private System.Windows.Forms.Label lbGPI0Interrupt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStopPoll;
        private System.Windows.Forms.Button btnStartPoll;
        private System.Windows.Forms.Button button_Set5VOff;
        private System.Windows.Forms.Button button_Set5VOn;
        private System.Windows.Forms.Button button_GetGPI1;
        private System.Windows.Forms.Button button_GetGPI0;
        private System.Windows.Forms.Label label_5VOutStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_Get5VStatus;
    }
}

