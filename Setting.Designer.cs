namespace PingoMeter
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.delay = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.setBgColor = new System.Windows.Forms.Button();
            this.setGoodColor = new System.Windows.Forms.Button();
            this.setNormalColor = new System.Windows.Forms.Button();
            this.setBadColor = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.maxPing = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numbersModeCheckBox = new System.Windows.Forms.CheckBox();
            this.graphColorsGroupBox = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.connectionResumeSFXBtn = new System.Windows.Forms.Button();
            this.connectionLostSFXBtn = new System.Windows.Forms.Button();
            this.pingTimeoutSFXBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.alarmTimeOut = new System.Windows.Forms.CheckBox();
            this.alarmResumed = new System.Windows.Forms.CheckBox();
            this.alarmConnectionLost = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbStartupRun = new System.Windows.Forms.CheckBox();
            this.cbOfflineCounter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPing)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.graphColorsGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update time in milisec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Background color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Good ping color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Normal ping color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bad ping color:";
            // 
            // delay
            // 
            this.delay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.delay.Font = new System.Drawing.Font("Consolas", 9F);
            this.delay.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.delay.Location = new System.Drawing.Point(144, 7);
            this.delay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.delay.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(82, 22);
            this.delay.TabIndex = 1;
            this.delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delay.ThousandsSeparator = true;
            this.delay.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // setBgColor
            // 
            this.setBgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.setBgColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setBgColor.Location = new System.Drawing.Point(130, 25);
            this.setBgColor.Name = "setBgColor";
            this.setBgColor.Size = new System.Drawing.Size(23, 23);
            this.setBgColor.TabIndex = 3;
            this.setBgColor.UseVisualStyleBackColor = false;
            this.setBgColor.Click += new System.EventHandler(this.SetBgColor_Click);
            // 
            // setGoodColor
            // 
            this.setGoodColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.setGoodColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setGoodColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setGoodColor.Location = new System.Drawing.Point(130, 54);
            this.setGoodColor.Name = "setGoodColor";
            this.setGoodColor.Size = new System.Drawing.Size(23, 23);
            this.setGoodColor.TabIndex = 4;
            this.setGoodColor.UseVisualStyleBackColor = false;
            this.setGoodColor.Click += new System.EventHandler(this.SetGoodColor_Click);
            // 
            // setNormalColor
            // 
            this.setNormalColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.setNormalColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setNormalColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setNormalColor.Location = new System.Drawing.Point(130, 83);
            this.setNormalColor.Name = "setNormalColor";
            this.setNormalColor.Size = new System.Drawing.Size(23, 23);
            this.setNormalColor.TabIndex = 5;
            this.setNormalColor.UseVisualStyleBackColor = false;
            this.setNormalColor.Click += new System.EventHandler(this.SetNormalColor_Click);
            // 
            // setBadColor
            // 
            this.setBadColor.BackColor = System.Drawing.Color.Red;
            this.setBadColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBadColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setBadColor.Location = new System.Drawing.Point(130, 112);
            this.setBadColor.Name = "setBadColor";
            this.setBadColor.Size = new System.Drawing.Size(23, 23);
            this.setBadColor.TabIndex = 6;
            this.setBadColor.UseVisualStyleBackColor = false;
            this.setBadColor.Click += new System.EventHandler(this.SetBadColor_Click);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.apply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.apply.Location = new System.Drawing.Point(12, 353);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 26);
            this.apply.TabIndex = 9;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reset.Location = new System.Drawing.Point(276, 353);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 26);
            this.reset.TabIndex = 11;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.Location = new System.Drawing.Point(93, 353);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 26);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Max ping interval:";
            // 
            // maxPing
            // 
            this.maxPing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxPing.Font = new System.Drawing.Font("Consolas", 9F);
            this.maxPing.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxPing.Location = new System.Drawing.Point(144, 34);
            this.maxPing.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.maxPing.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxPing.Name = "maxPing";
            this.maxPing.Size = new System.Drawing.Size(82, 22);
            this.maxPing.TabIndex = 2;
            this.maxPing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxPing.ThousandsSeparator = true;
            this.maxPing.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ping IP addres:";
            // 
            // ipAddress
            // 
            this.ipAddress.Font = new System.Drawing.Font("Consolas", 9F);
            this.ipAddress.Location = new System.Drawing.Point(145, 6);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(172, 22);
            this.ipAddress.TabIndex = 7;
            this.ipAddress.Text = "8.8.8.8";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(30, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(339, 335);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbOfflineCounter);
            this.tabPage1.Controls.Add(this.numbersModeCheckBox);
            this.tabPage1.Controls.Add(this.graphColorsGroupBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.delay);
            this.tabPage1.Controls.Add(this.maxPing);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(331, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            // 
            // numbersModeCheckBox
            // 
            this.numbersModeCheckBox.AutoSize = true;
            this.numbersModeCheckBox.Location = new System.Drawing.Point(6, 65);
            this.numbersModeCheckBox.Name = "numbersModeCheckBox";
            this.numbersModeCheckBox.Size = new System.Drawing.Size(215, 19);
            this.numbersModeCheckBox.TabIndex = 8;
            this.numbersModeCheckBox.Text = "Numbers mode (ping from 0 to 99)";
            this.numbersModeCheckBox.UseVisualStyleBackColor = true;
            this.numbersModeCheckBox.CheckedChanged += new System.EventHandler(this.numbersModeCheckBox_CheckedChanged);
            // 
            // graphColorsGroupBox
            // 
            this.graphColorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphColorsGroupBox.Controls.Add(this.label2);
            this.graphColorsGroupBox.Controls.Add(this.setBgColor);
            this.graphColorsGroupBox.Controls.Add(this.setGoodColor);
            this.graphColorsGroupBox.Controls.Add(this.label3);
            this.graphColorsGroupBox.Controls.Add(this.setNormalColor);
            this.graphColorsGroupBox.Controls.Add(this.label4);
            this.graphColorsGroupBox.Controls.Add(this.setBadColor);
            this.graphColorsGroupBox.Controls.Add(this.label5);
            this.graphColorsGroupBox.Location = new System.Drawing.Point(9, 90);
            this.graphColorsGroupBox.Name = "graphColorsGroupBox";
            this.graphColorsGroupBox.Size = new System.Drawing.Size(316, 150);
            this.graphColorsGroupBox.TabIndex = 7;
            this.graphColorsGroupBox.TabStop = false;
            this.graphColorsGroupBox.Text = "Graph colors and Sound effect";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cbStartupRun);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ipAddress);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(331, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.connectionResumeSFXBtn);
            this.groupBox2.Controls.Add(this.connectionLostSFXBtn);
            this.groupBox2.Controls.Add(this.pingTimeoutSFXBtn);
            this.groupBox2.Location = new System.Drawing.Point(6, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 116);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alarm sound when (right click to clear):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Connection resume:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Connection lost:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ping timeout:";
            // 
            // connectionResumeSFXBtn
            // 
            this.connectionResumeSFXBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionResumeSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionResumeSFXBtn.Location = new System.Drawing.Point(128, 81);
            this.connectionResumeSFXBtn.Name = "connectionResumeSFXBtn";
            this.connectionResumeSFXBtn.Size = new System.Drawing.Size(177, 23);
            this.connectionResumeSFXBtn.TabIndex = 11;
            this.connectionResumeSFXBtn.Text = "none";
            this.connectionResumeSFXBtn.UseVisualStyleBackColor = true;
            // 
            // connectionLostSFXBtn
            // 
            this.connectionLostSFXBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionLostSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionLostSFXBtn.Location = new System.Drawing.Point(128, 52);
            this.connectionLostSFXBtn.Name = "connectionLostSFXBtn";
            this.connectionLostSFXBtn.Size = new System.Drawing.Size(177, 23);
            this.connectionLostSFXBtn.TabIndex = 11;
            this.connectionLostSFXBtn.Text = "none";
            this.connectionLostSFXBtn.UseVisualStyleBackColor = true;
            // 
            // pingTimeoutSFXBtn
            // 
            this.pingTimeoutSFXBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pingTimeoutSFXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pingTimeoutSFXBtn.Location = new System.Drawing.Point(128, 23);
            this.pingTimeoutSFXBtn.Name = "pingTimeoutSFXBtn";
            this.pingTimeoutSFXBtn.Size = new System.Drawing.Size(177, 23);
            this.pingTimeoutSFXBtn.TabIndex = 11;
            this.pingTimeoutSFXBtn.Text = "none";
            this.pingTimeoutSFXBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.alarmTimeOut);
            this.groupBox1.Controls.Add(this.alarmResumed);
            this.groupBox1.Controls.Add(this.alarmConnectionLost);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balloon tip alarm when:";
            // 
            // alarmTimeOut
            // 
            this.alarmTimeOut.AutoSize = true;
            this.alarmTimeOut.Location = new System.Drawing.Point(6, 20);
            this.alarmTimeOut.Name = "alarmTimeOut";
            this.alarmTimeOut.Size = new System.Drawing.Size(95, 19);
            this.alarmTimeOut.TabIndex = 9;
            this.alarmTimeOut.Text = "Ping timeout";
            this.alarmTimeOut.UseVisualStyleBackColor = true;
            // 
            // alarmResumed
            // 
            this.alarmResumed.AutoSize = true;
            this.alarmResumed.Location = new System.Drawing.Point(6, 70);
            this.alarmResumed.Name = "alarmResumed";
            this.alarmResumed.Size = new System.Drawing.Size(133, 19);
            this.alarmResumed.TabIndex = 8;
            this.alarmResumed.Text = "Connection resume";
            this.alarmResumed.UseVisualStyleBackColor = true;
            // 
            // alarmConnectionLost
            // 
            this.alarmConnectionLost.AutoSize = true;
            this.alarmConnectionLost.Location = new System.Drawing.Point(6, 45);
            this.alarmConnectionLost.Name = "alarmConnectionLost";
            this.alarmConnectionLost.Size = new System.Drawing.Size(110, 19);
            this.alarmConnectionLost.TabIndex = 8;
            this.alarmConnectionLost.Text = "Connection lost";
            this.alarmConnectionLost.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.labelVersion);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(331, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(78, 46);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(134, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Source code on GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(78, 27);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(75, 15);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version x.x.x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(78, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "PingoMeter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PingoMeter.Properties.Resources.op1;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbStartupRun
            // 
            this.cbStartupRun.AutoSize = true;
            this.cbStartupRun.Location = new System.Drawing.Point(6, 255);
            this.cbStartupRun.Name = "cbStartupRun";
            this.cbStartupRun.Size = new System.Drawing.Size(159, 19);
            this.cbStartupRun.TabIndex = 13;
            this.cbStartupRun.Text = "Run on Windows startup";
            this.cbStartupRun.UseVisualStyleBackColor = true;
            // 
            // cbOfflineCounter
            // 
            this.cbOfflineCounter.AutoSize = true;
            this.cbOfflineCounter.Location = new System.Drawing.Point(6, 246);
            this.cbOfflineCounter.Name = "cbOfflineCounter";
            this.cbOfflineCounter.Size = new System.Drawing.Size(132, 19);
            this.cbOfflineCounter.TabIndex = 9;
            this.cbOfflineCounter.Text = "Offline time counter";
            this.cbOfflineCounter.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(364, 392);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPing)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.graphColorsGroupBox.ResumeLayout(false);
            this.graphColorsGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown delay;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button setBgColor;
        private System.Windows.Forms.Button setGoodColor;
        private System.Windows.Forms.Button setNormalColor;
        private System.Windows.Forms.Button setBadColor;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown maxPing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox alarmTimeOut;
        private System.Windows.Forms.CheckBox alarmConnectionLost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox alarmResumed;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox numbersModeCheckBox;
        private System.Windows.Forms.GroupBox graphColorsGroupBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button pingTimeoutSFXBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button connectionResumeSFXBtn;
        private System.Windows.Forms.Button connectionLostSFXBtn;
        private System.Windows.Forms.CheckBox cbOfflineCounter;
        private System.Windows.Forms.CheckBox cbStartupRun;
    }
}