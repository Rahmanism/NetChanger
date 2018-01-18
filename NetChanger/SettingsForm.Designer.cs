namespace NetChanger
{
    partial class SettingsForm
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
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.profileNameTxt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dns1Txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dns2Txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ifaceTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dhcpRbn = new System.Windows.Forms.RadioButton();
            this.staticRbn = new System.Windows.Forms.RadioButton();
            this.gatewayTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.netmaskTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 95);
            this.panel1.TabIndex = 1;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(523, 25);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(136, 55);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(665, 25);
            this.okBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(136, 55);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "&Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.profileNameTxt);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 100);
            this.panel3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Profile\'s Name";
            // 
            // profileNameTxt
            // 
            this.profileNameTxt.Location = new System.Drawing.Point(18, 48);
            this.profileNameTxt.Name = "profileNameTxt";
            this.profileNameTxt.Size = new System.Drawing.Size(252, 35);
            this.profileNameTxt.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 310);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dns1Txt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dns2Txt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ifaceTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.gatewayTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.netmaskTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addressTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(828, 310);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Settings";
            // 
            // dns1Txt
            // 
            this.dns1Txt.Location = new System.Drawing.Point(589, 48);
            this.dns1Txt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dns1Txt.Name = "dns1Txt";
            this.dns1Txt.Size = new System.Drawing.Size(188, 35);
            this.dns1Txt.TabIndex = 12;
            this.dns1Txt.Text = "172.16.16.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nameserver 1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dns2Txt
            // 
            this.dns2Txt.Location = new System.Drawing.Point(589, 99);
            this.dns2Txt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dns2Txt.Name = "dns2Txt";
            this.dns2Txt.Size = new System.Drawing.Size(188, 35);
            this.dns2Txt.TabIndex = 10;
            this.dns2Txt.Text = "8.8.8.8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nameserver 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ifaceTxt
            // 
            this.ifaceTxt.Location = new System.Drawing.Point(193, 48);
            this.ifaceTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ifaceTxt.Name = "ifaceTxt";
            this.ifaceTxt.Size = new System.Drawing.Size(188, 35);
            this.ifaceTxt.TabIndex = 8;
            this.ifaceTxt.Text = "Wi-Fi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dhcpRbn);
            this.panel4.Controls.Add(this.staticRbn);
            this.panel4.Location = new System.Drawing.Point(574, 171);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(213, 107);
            this.panel4.TabIndex = 6;
            // 
            // dhcpRbn
            // 
            this.dhcpRbn.AutoSize = true;
            this.dhcpRbn.Checked = true;
            this.dhcpRbn.Location = new System.Drawing.Point(16, 57);
            this.dhcpRbn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dhcpRbn.Name = "dhcpRbn";
            this.dhcpRbn.Size = new System.Drawing.Size(102, 33);
            this.dhcpRbn.TabIndex = 1;
            this.dhcpRbn.TabStop = true;
            this.dhcpRbn.Text = "&DHCP";
            this.dhcpRbn.UseVisualStyleBackColor = true;
            // 
            // staticRbn
            // 
            this.staticRbn.AutoSize = true;
            this.staticRbn.Location = new System.Drawing.Point(16, 15);
            this.staticRbn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.staticRbn.Name = "staticRbn";
            this.staticRbn.Size = new System.Drawing.Size(108, 33);
            this.staticRbn.TabIndex = 0;
            this.staticRbn.Text = "&Static";
            this.staticRbn.UseVisualStyleBackColor = true;
            // 
            // gatewayTxt
            // 
            this.gatewayTxt.Location = new System.Drawing.Point(192, 206);
            this.gatewayTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gatewayTxt.Name = "gatewayTxt";
            this.gatewayTxt.Size = new System.Drawing.Size(188, 35);
            this.gatewayTxt.TabIndex = 5;
            this.gatewayTxt.Text = "172.16.16.9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Gateway";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // netmaskTxt
            // 
            this.netmaskTxt.Location = new System.Drawing.Point(192, 153);
            this.netmaskTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.netmaskTxt.Name = "netmaskTxt";
            this.netmaskTxt.Size = new System.Drawing.Size(188, 35);
            this.netmaskTxt.TabIndex = 3;
            this.netmaskTxt.Text = "255.255.252.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Netmask";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(193, 99);
            this.addressTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(188, 35);
            this.addressTxt.TabIndex = 1;
            this.addressTxt.Text = "172.16.17.4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(828, 505);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(26, 478);
            this.Name = "SettingsForm";
            this.Text = "NetChanger Settings";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox profileNameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dns1Txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dns2Txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ifaceTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton dhcpRbn;
        private System.Windows.Forms.RadioButton staticRbn;
        private System.Windows.Forms.TextBox gatewayTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox netmaskTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.Label label1;
    }
}

