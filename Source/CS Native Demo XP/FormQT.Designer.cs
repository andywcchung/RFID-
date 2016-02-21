namespace CS203_CALLBACK_API_DEMO
{
    partial class FormQT
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChangePublicMode = new System.Windows.Forms.Button();
            this.buttonChangePrivateMode = new System.Windows.Forms.Button();
            this.buttonReadPrivateData = new System.Windows.Forms.Button();
            this.textBoxPrivateAccessPassword = new System.Windows.Forms.TextBox();
            this.textBoxPrivatePC = new System.Windows.Forms.TextBox();
            this.textBoxPrivateEPC = new System.Windows.Forms.TextBox();
            this.textBoxPrivateTID = new System.Windows.Forms.TextBox();
            this.textBoxPrivateKillPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPublicEPC = new System.Windows.Forms.TextBox();
            this.groupBoxPrivate = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.checkBoxPrivateUser = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivateEPCPublic = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivateTID = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivateEPC = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivatePC = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivateAccessPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxPrivateKillPassword = new System.Windows.Forms.CheckBox();
            this.buttonReadData = new System.Windows.Forms.Button();
            this.textBoxPrivateUser = new System.Windows.Forms.TextBox();
            this.textBoxPrivateEPCPublic = new System.Windows.Forms.TextBox();
            this.buttonWriteData = new System.Windows.Forms.Button();
            this.groupBoxPublic = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonReadPublicData = new System.Windows.Forms.Button();
            this.checkBoxPublicPC = new System.Windows.Forms.CheckBox();
            this.checkBoxPublicTID = new System.Windows.Forms.CheckBox();
            this.textBoxPublicPC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPublicEPC = new System.Windows.Forms.CheckBox();
            this.textBoxPublicTID = new System.Windows.Forms.TextBox();
            this.buttonSlecetTag = new System.Windows.Forms.Button();
            this.textBoxTagID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxPrivate.SuspendLayout();
            this.groupBoxPublic.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(269, 80);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(168, 22);
            this.textBoxPassword.TabIndex = 28;
            this.textBoxPassword.Text = "00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Password";
            // 
            // buttonChangePublicMode
            // 
            this.buttonChangePublicMode.Location = new System.Drawing.Point(402, 117);
            this.buttonChangePublicMode.Name = "buttonChangePublicMode";
            this.buttonChangePublicMode.Size = new System.Drawing.Size(116, 55);
            this.buttonChangePublicMode.TabIndex = 30;
            this.buttonChangePublicMode.Text = "Change to Public Mode\r\n(Reduces Range)";
            this.buttonChangePublicMode.UseVisualStyleBackColor = true;
            this.buttonChangePublicMode.Click += new System.EventHandler(this.buttonChangePublicMode_Click);
            // 
            // buttonChangePrivateMode
            // 
            this.buttonChangePrivateMode.Location = new System.Drawing.Point(59, 117);
            this.buttonChangePrivateMode.Name = "buttonChangePrivateMode";
            this.buttonChangePrivateMode.Size = new System.Drawing.Size(116, 55);
            this.buttonChangePrivateMode.TabIndex = 31;
            this.buttonChangePrivateMode.Text = "Change to Private Mode\r\n(Reduces Range)";
            this.buttonChangePrivateMode.UseVisualStyleBackColor = true;
            this.buttonChangePrivateMode.Click += new System.EventHandler(this.buttonChangePrivateMode_Click);
            // 
            // buttonReadPrivateData
            // 
            this.buttonReadPrivateData.Location = new System.Drawing.Point(547, 40);
            this.buttonReadPrivateData.Name = "buttonReadPrivateData";
            this.buttonReadPrivateData.Size = new System.Drawing.Size(142, 55);
            this.buttonReadPrivateData.TabIndex = 32;
            this.buttonReadPrivateData.Text = "Peek Access Private Data (Private Mode Inventory)";
            this.buttonReadPrivateData.UseVisualStyleBackColor = true;
            this.buttonReadPrivateData.Click += new System.EventHandler(this.buttonReadPrivateData_Click);
            // 
            // textBoxPrivateAccessPassword
            // 
            this.textBoxPrivateAccessPassword.Location = new System.Drawing.Point(119, 52);
            this.textBoxPrivateAccessPassword.Name = "textBoxPrivateAccessPassword";
            this.textBoxPrivateAccessPassword.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateAccessPassword.TabIndex = 33;
            // 
            // textBoxPrivatePC
            // 
            this.textBoxPrivatePC.Location = new System.Drawing.Point(119, 80);
            this.textBoxPrivatePC.Name = "textBoxPrivatePC";
            this.textBoxPrivatePC.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivatePC.TabIndex = 36;
            // 
            // textBoxPrivateEPC
            // 
            this.textBoxPrivateEPC.Location = new System.Drawing.Point(119, 107);
            this.textBoxPrivateEPC.Name = "textBoxPrivateEPC";
            this.textBoxPrivateEPC.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateEPC.TabIndex = 38;
            // 
            // textBoxPrivateTID
            // 
            this.textBoxPrivateTID.Location = new System.Drawing.Point(119, 135);
            this.textBoxPrivateTID.Name = "textBoxPrivateTID";
            this.textBoxPrivateTID.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateTID.TabIndex = 39;
            // 
            // textBoxPrivateKillPassword
            // 
            this.textBoxPrivateKillPassword.Location = new System.Drawing.Point(119, 24);
            this.textBoxPrivateKillPassword.Name = "textBoxPrivateKillPassword";
            this.textBoxPrivateKillPassword.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateKillPassword.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 44;
            this.label8.Text = "32 bits";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(278, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "96 bits";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // textBoxPublicEPC
            // 
            this.textBoxPublicEPC.Location = new System.Drawing.Point(119, 52);
            this.textBoxPublicEPC.Name = "textBoxPublicEPC";
            this.textBoxPublicEPC.Size = new System.Drawing.Size(153, 22);
            this.textBoxPublicEPC.TabIndex = 48;
            // 
            // groupBoxPrivate
            // 
            this.groupBoxPrivate.Controls.Add(this.label25);
            this.groupBoxPrivate.Controls.Add(this.label24);
            this.groupBoxPrivate.Controls.Add(this.label23);
            this.groupBoxPrivate.Controls.Add(this.label22);
            this.groupBoxPrivate.Controls.Add(this.label21);
            this.groupBoxPrivate.Controls.Add(this.label20);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateUser);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateEPCPublic);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateTID);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateEPC);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivatePC);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateAccessPassword);
            this.groupBoxPrivate.Controls.Add(this.checkBoxPrivateKillPassword);
            this.groupBoxPrivate.Controls.Add(this.buttonReadData);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateUser);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateEPCPublic);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateKillPassword);
            this.groupBoxPrivate.Controls.Add(this.buttonWriteData);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateAccessPassword);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivatePC);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateTID);
            this.groupBoxPrivate.Controls.Add(this.textBoxPrivateEPC);
            this.groupBoxPrivate.Controls.Add(this.label8);
            this.groupBoxPrivate.Enabled = false;
            this.groupBoxPrivate.Location = new System.Drawing.Point(28, 197);
            this.groupBoxPrivate.Name = "groupBoxPrivate";
            this.groupBoxPrivate.Size = new System.Drawing.Size(326, 273);
            this.groupBoxPrivate.TabIndex = 52;
            this.groupBoxPrivate.TabStop = false;
            this.groupBoxPrivate.Text = "Private Mode Data";
            this.groupBoxPrivate.Enter += new System.EventHandler(this.groupBoxPrivate_Enter);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(278, 194);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 12);
            this.label25.TabIndex = 61;
            this.label25.Text = "512 bits";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(278, 166);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 12);
            this.label24.TabIndex = 71;
            this.label24.Text = "96 bits";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(278, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 12);
            this.label23.TabIndex = 61;
            this.label23.Text = "96 bits";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(278, 110);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 12);
            this.label22.TabIndex = 61;
            this.label22.Text = "128 bits";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(278, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 12);
            this.label21.TabIndex = 70;
            this.label21.Text = "16 bits";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(278, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 12);
            this.label20.TabIndex = 69;
            this.label20.Text = "32 bits";
            // 
            // checkBoxPrivateUser
            // 
            this.checkBoxPrivateUser.AutoSize = true;
            this.checkBoxPrivateUser.Checked = true;
            this.checkBoxPrivateUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateUser.Location = new System.Drawing.Point(6, 193);
            this.checkBoxPrivateUser.Name = "checkBoxPrivateUser";
            this.checkBoxPrivateUser.Size = new System.Drawing.Size(45, 16);
            this.checkBoxPrivateUser.TabIndex = 68;
            this.checkBoxPrivateUser.Text = "User";
            this.checkBoxPrivateUser.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivateEPCPublic
            // 
            this.checkBoxPrivateEPCPublic.AutoSize = true;
            this.checkBoxPrivateEPCPublic.Checked = true;
            this.checkBoxPrivateEPCPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateEPCPublic.Location = new System.Drawing.Point(6, 165);
            this.checkBoxPrivateEPCPublic.Name = "checkBoxPrivateEPCPublic";
            this.checkBoxPrivateEPCPublic.Size = new System.Drawing.Size(77, 16);
            this.checkBoxPrivateEPCPublic.TabIndex = 67;
            this.checkBoxPrivateEPCPublic.Text = "EPC Public";
            this.checkBoxPrivateEPCPublic.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivateTID
            // 
            this.checkBoxPrivateTID.AutoSize = true;
            this.checkBoxPrivateTID.Checked = true;
            this.checkBoxPrivateTID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateTID.Location = new System.Drawing.Point(6, 137);
            this.checkBoxPrivateTID.Name = "checkBoxPrivateTID";
            this.checkBoxPrivateTID.Size = new System.Drawing.Size(43, 16);
            this.checkBoxPrivateTID.TabIndex = 66;
            this.checkBoxPrivateTID.Text = "TID";
            this.checkBoxPrivateTID.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivateEPC
            // 
            this.checkBoxPrivateEPC.AutoSize = true;
            this.checkBoxPrivateEPC.Checked = true;
            this.checkBoxPrivateEPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateEPC.Location = new System.Drawing.Point(6, 109);
            this.checkBoxPrivateEPC.Name = "checkBoxPrivateEPC";
            this.checkBoxPrivateEPC.Size = new System.Drawing.Size(80, 16);
            this.checkBoxPrivateEPC.TabIndex = 65;
            this.checkBoxPrivateEPC.Text = "EPC Private";
            this.checkBoxPrivateEPC.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivatePC
            // 
            this.checkBoxPrivatePC.AutoSize = true;
            this.checkBoxPrivatePC.Checked = true;
            this.checkBoxPrivatePC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivatePC.Location = new System.Drawing.Point(6, 82);
            this.checkBoxPrivatePC.Name = "checkBoxPrivatePC";
            this.checkBoxPrivatePC.Size = new System.Drawing.Size(38, 16);
            this.checkBoxPrivatePC.TabIndex = 64;
            this.checkBoxPrivatePC.Text = "PC";
            this.checkBoxPrivatePC.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivateAccessPassword
            // 
            this.checkBoxPrivateAccessPassword.AutoSize = true;
            this.checkBoxPrivateAccessPassword.Checked = true;
            this.checkBoxPrivateAccessPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateAccessPassword.Location = new System.Drawing.Point(6, 54);
            this.checkBoxPrivateAccessPassword.Name = "checkBoxPrivateAccessPassword";
            this.checkBoxPrivateAccessPassword.Size = new System.Drawing.Size(101, 16);
            this.checkBoxPrivateAccessPassword.TabIndex = 63;
            this.checkBoxPrivateAccessPassword.Text = "Access Password";
            this.checkBoxPrivateAccessPassword.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrivateKillPassword
            // 
            this.checkBoxPrivateKillPassword.AutoSize = true;
            this.checkBoxPrivateKillPassword.Checked = true;
            this.checkBoxPrivateKillPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrivateKillPassword.Location = new System.Drawing.Point(6, 26);
            this.checkBoxPrivateKillPassword.Name = "checkBoxPrivateKillPassword";
            this.checkBoxPrivateKillPassword.Size = new System.Drawing.Size(87, 16);
            this.checkBoxPrivateKillPassword.TabIndex = 62;
            this.checkBoxPrivateKillPassword.Text = "Kill Password";
            this.checkBoxPrivateKillPassword.UseVisualStyleBackColor = true;
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(21, 219);
            this.buttonReadData.Name = "buttonReadData";
            this.buttonReadData.Size = new System.Drawing.Size(116, 34);
            this.buttonReadData.TabIndex = 61;
            this.buttonReadData.Text = "Read Data";
            this.buttonReadData.UseVisualStyleBackColor = true;
            this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
            // 
            // textBoxPrivateUser
            // 
            this.textBoxPrivateUser.Location = new System.Drawing.Point(119, 191);
            this.textBoxPrivateUser.Name = "textBoxPrivateUser";
            this.textBoxPrivateUser.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateUser.TabIndex = 56;
            // 
            // textBoxPrivateEPCPublic
            // 
            this.textBoxPrivateEPCPublic.Location = new System.Drawing.Point(119, 163);
            this.textBoxPrivateEPCPublic.Name = "textBoxPrivateEPCPublic";
            this.textBoxPrivateEPCPublic.Size = new System.Drawing.Size(153, 22);
            this.textBoxPrivateEPCPublic.TabIndex = 55;
            // 
            // buttonWriteData
            // 
            this.buttonWriteData.Location = new System.Drawing.Point(183, 219);
            this.buttonWriteData.Name = "buttonWriteData";
            this.buttonWriteData.Size = new System.Drawing.Size(116, 34);
            this.buttonWriteData.TabIndex = 54;
            this.buttonWriteData.Text = "Write Data";
            this.buttonWriteData.UseVisualStyleBackColor = true;
            this.buttonWriteData.Click += new System.EventHandler(this.buttonWriteData_Click);
            // 
            // groupBoxPublic
            // 
            this.groupBoxPublic.Controls.Add(this.label3);
            this.groupBoxPublic.Controls.Add(this.buttonReadPublicData);
            this.groupBoxPublic.Controls.Add(this.checkBoxPublicPC);
            this.groupBoxPublic.Controls.Add(this.checkBoxPublicTID);
            this.groupBoxPublic.Controls.Add(this.textBoxPublicPC);
            this.groupBoxPublic.Controls.Add(this.label2);
            this.groupBoxPublic.Controls.Add(this.checkBoxPublicEPC);
            this.groupBoxPublic.Controls.Add(this.textBoxPublicTID);
            this.groupBoxPublic.Controls.Add(this.label12);
            this.groupBoxPublic.Controls.Add(this.textBoxPublicEPC);
            this.groupBoxPublic.Enabled = false;
            this.groupBoxPublic.Location = new System.Drawing.Point(360, 197);
            this.groupBoxPublic.Name = "groupBoxPublic";
            this.groupBoxPublic.Size = new System.Drawing.Size(326, 273);
            this.groupBoxPublic.TabIndex = 53;
            this.groupBoxPublic.TabStop = false;
            this.groupBoxPublic.Text = "Public Mode Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "16 bits";
            // 
            // buttonReadPublicData
            // 
            this.buttonReadPublicData.Location = new System.Drawing.Point(119, 219);
            this.buttonReadPublicData.Name = "buttonReadPublicData";
            this.buttonReadPublicData.Size = new System.Drawing.Size(116, 34);
            this.buttonReadPublicData.TabIndex = 72;
            this.buttonReadPublicData.Text = "Read Data";
            this.buttonReadPublicData.UseVisualStyleBackColor = true;
            this.buttonReadPublicData.Click += new System.EventHandler(this.buttonReadPublicData_Click);
            // 
            // checkBoxPublicPC
            // 
            this.checkBoxPublicPC.AutoSize = true;
            this.checkBoxPublicPC.Checked = true;
            this.checkBoxPublicPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPublicPC.Location = new System.Drawing.Point(6, 26);
            this.checkBoxPublicPC.Name = "checkBoxPublicPC";
            this.checkBoxPublicPC.Size = new System.Drawing.Size(38, 16);
            this.checkBoxPublicPC.TabIndex = 73;
            this.checkBoxPublicPC.Text = "PC";
            this.checkBoxPublicPC.UseVisualStyleBackColor = true;
            // 
            // checkBoxPublicTID
            // 
            this.checkBoxPublicTID.AutoSize = true;
            this.checkBoxPublicTID.Checked = true;
            this.checkBoxPublicTID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPublicTID.Location = new System.Drawing.Point(6, 81);
            this.checkBoxPublicTID.Name = "checkBoxPublicTID";
            this.checkBoxPublicTID.Size = new System.Drawing.Size(43, 16);
            this.checkBoxPublicTID.TabIndex = 72;
            this.checkBoxPublicTID.Text = "TID";
            this.checkBoxPublicTID.UseVisualStyleBackColor = true;
            // 
            // textBoxPublicPC
            // 
            this.textBoxPublicPC.Location = new System.Drawing.Point(119, 24);
            this.textBoxPublicPC.Name = "textBoxPublicPC";
            this.textBoxPublicPC.Size = new System.Drawing.Size(153, 22);
            this.textBoxPublicPC.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "32 bits";
            // 
            // checkBoxPublicEPC
            // 
            this.checkBoxPublicEPC.AutoSize = true;
            this.checkBoxPublicEPC.Checked = true;
            this.checkBoxPublicEPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPublicEPC.Location = new System.Drawing.Point(6, 55);
            this.checkBoxPublicEPC.Name = "checkBoxPublicEPC";
            this.checkBoxPublicEPC.Size = new System.Drawing.Size(77, 16);
            this.checkBoxPublicEPC.TabIndex = 72;
            this.checkBoxPublicEPC.Text = "EPC Public";
            this.checkBoxPublicEPC.UseVisualStyleBackColor = true;
            // 
            // textBoxPublicTID
            // 
            this.textBoxPublicTID.Location = new System.Drawing.Point(119, 80);
            this.textBoxPublicTID.Name = "textBoxPublicTID";
            this.textBoxPublicTID.Size = new System.Drawing.Size(153, 22);
            this.textBoxPublicTID.TabIndex = 48;
            // 
            // buttonSlecetTag
            // 
            this.buttonSlecetTag.Location = new System.Drawing.Point(137, 42);
            this.buttonSlecetTag.Name = "buttonSlecetTag";
            this.buttonSlecetTag.Size = new System.Drawing.Size(126, 23);
            this.buttonSlecetTag.TabIndex = 54;
            this.buttonSlecetTag.Text = "Select Tag";
            this.buttonSlecetTag.UseVisualStyleBackColor = true;
            this.buttonSlecetTag.Click += new System.EventHandler(this.buttonSlecetTag_Click);
            // 
            // textBoxTagID
            // 
            this.textBoxTagID.Location = new System.Drawing.Point(269, 43);
            this.textBoxTagID.Name = "textBoxTagID";
            this.textBoxTagID.Size = new System.Drawing.Size(221, 22);
            this.textBoxTagID.TabIndex = 55;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 55);
            this.button1.TabIndex = 56;
            this.button1.Text = "Change to Private Mode\r\n(Normal Range)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(544, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 55);
            this.button2.TabIndex = 57;
            this.button2.Text = "Change to Public Mode\r\n(Normal Range)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormQT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTagID);
            this.Controls.Add(this.buttonSlecetTag);
            this.Controls.Add(this.groupBoxPublic);
            this.Controls.Add(this.groupBoxPrivate);
            this.Controls.Add(this.buttonReadPrivateData);
            this.Controls.Add(this.buttonChangePrivateMode);
            this.Controls.Add(this.buttonChangePublicMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "FormQT";
            this.Text = "QT Demo";
            this.Load += new System.EventHandler(this.FormQT_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQT_FormClosing);
            this.groupBoxPrivate.ResumeLayout(false);
            this.groupBoxPrivate.PerformLayout();
            this.groupBoxPublic.ResumeLayout(false);
            this.groupBoxPublic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangePublicMode;
        private System.Windows.Forms.Button buttonChangePrivateMode;
        private System.Windows.Forms.Button buttonReadPrivateData;
        private System.Windows.Forms.TextBox textBoxPrivateAccessPassword;
        private System.Windows.Forms.TextBox textBoxPrivatePC;
        private System.Windows.Forms.TextBox textBoxPrivateEPC;
        private System.Windows.Forms.TextBox textBoxPrivateTID;
        private System.Windows.Forms.TextBox textBoxPrivateKillPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPublicEPC;
        private System.Windows.Forms.GroupBox groupBoxPrivate;
        private System.Windows.Forms.GroupBox groupBoxPublic;
        private System.Windows.Forms.TextBox textBoxPublicTID;
        private System.Windows.Forms.Button buttonWriteData;
        private System.Windows.Forms.TextBox textBoxPrivateUser;
        private System.Windows.Forms.TextBox textBoxPrivateEPCPublic;
        private System.Windows.Forms.CheckBox checkBoxPrivateKillPassword;
        private System.Windows.Forms.Button buttonReadData;
        private System.Windows.Forms.CheckBox checkBoxPrivateUser;
        private System.Windows.Forms.CheckBox checkBoxPrivateEPCPublic;
        private System.Windows.Forms.CheckBox checkBoxPrivateTID;
        private System.Windows.Forms.CheckBox checkBoxPrivateEPC;
        private System.Windows.Forms.CheckBox checkBoxPrivatePC;
        private System.Windows.Forms.CheckBox checkBoxPrivateAccessPassword;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox checkBoxPublicEPC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReadPublicData;
        private System.Windows.Forms.CheckBox checkBoxPublicPC;
        private System.Windows.Forms.CheckBox checkBoxPublicTID;
        private System.Windows.Forms.TextBox textBoxPublicPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSlecetTag;
        private System.Windows.Forms.TextBox textBoxTagID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}