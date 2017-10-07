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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.isStartUp = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPing)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update time in milisec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Background color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Good ping color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Normal ping color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bad ping color:";
            // 
            // isStartUp
            // 
            this.isStartUp.AutoSize = true;
            this.isStartUp.Location = new System.Drawing.Point(12, 229);
            this.isStartUp.Name = "isStartUp";
            this.isStartUp.Size = new System.Drawing.Size(234, 19);
            this.isStartUp.TabIndex = 8;
            this.isStartUp.Text = "Run PingoMeter when Windows starts";
            this.isStartUp.UseVisualStyleBackColor = true;
            this.isStartUp.Visible = false;
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
            this.delay.Location = new System.Drawing.Point(150, 12);
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
            this.setBgColor.Location = new System.Drawing.Point(150, 77);
            this.setBgColor.Name = "setBgColor";
            this.setBgColor.Size = new System.Drawing.Size(23, 23);
            this.setBgColor.TabIndex = 3;
            this.setBgColor.UseVisualStyleBackColor = false;
            this.setBgColor.Click += new System.EventHandler(this.setBgColor_Click);
            // 
            // setGoodColor
            // 
            this.setGoodColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.setGoodColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setGoodColor.Location = new System.Drawing.Point(150, 106);
            this.setGoodColor.Name = "setGoodColor";
            this.setGoodColor.Size = new System.Drawing.Size(23, 23);
            this.setGoodColor.TabIndex = 4;
            this.setGoodColor.UseVisualStyleBackColor = false;
            this.setGoodColor.Click += new System.EventHandler(this.setGoodColor_Click);
            // 
            // setNormalColor
            // 
            this.setNormalColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.setNormalColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setNormalColor.Location = new System.Drawing.Point(150, 135);
            this.setNormalColor.Name = "setNormalColor";
            this.setNormalColor.Size = new System.Drawing.Size(23, 23);
            this.setNormalColor.TabIndex = 5;
            this.setNormalColor.UseVisualStyleBackColor = false;
            this.setNormalColor.Click += new System.EventHandler(this.setNormalColor_Click);
            // 
            // setBadColor
            // 
            this.setBadColor.BackColor = System.Drawing.Color.Red;
            this.setBadColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBadColor.Location = new System.Drawing.Point(150, 164);
            this.setBadColor.Name = "setBadColor";
            this.setBadColor.Size = new System.Drawing.Size(23, 23);
            this.setBadColor.TabIndex = 6;
            this.setBadColor.UseVisualStyleBackColor = false;
            this.setBadColor.Click += new System.EventHandler(this.setBadColor_Click);
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(12, 254);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 26);
            this.apply.TabIndex = 9;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(236, 254);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 26);
            this.reset.TabIndex = 11;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(124, 254);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 26);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
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
            this.maxPing.Location = new System.Drawing.Point(150, 39);
            this.maxPing.Maximum = new decimal(new int[] {
            10000,
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
            this.label7.Location = new System.Drawing.Point(12, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ping IP addres:";
            // 
            // ipAddress
            // 
            this.ipAddress.Font = new System.Drawing.Font("Consolas", 9F);
            this.ipAddress.Location = new System.Drawing.Point(150, 199);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(161, 22);
            this.ipAddress.TabIndex = 7;
            this.ipAddress.Text = "8.8.8.8";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 293);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.setBadColor);
            this.Controls.Add(this.setNormalColor);
            this.Controls.Add(this.setGoodColor);
            this.Controls.Add(this.setBgColor);
            this.Controls.Add(this.maxPing);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.isStartUp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isStartUp;
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
    }
}