namespace NetChanger
{
    partial class mainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.netmaskTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.staticRbn = new System.Windows.Forms.RadioButton();
            this.dhcpRbn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.netmaskTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addressTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Static IP";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(12, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 71);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Address";
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(171, 42);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(178, 31);
            this.addressTxt.TabIndex = 1;
            this.addressTxt.Text = "172.16.17.4";
            // 
            // netmaskTxt
            // 
            this.netmaskTxt.Location = new System.Drawing.Point(171, 84);
            this.netmaskTxt.Name = "netmaskTxt";
            this.netmaskTxt.Size = new System.Drawing.Size(178, 31);
            this.netmaskTxt.TabIndex = 3;
            this.netmaskTxt.Text = "255.255.252.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Netmask";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 31);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "172.16.16.9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Gateway";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(586, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 44);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(445, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 44);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dhcpRbn);
            this.panel2.Controls.Add(this.staticRbn);
            this.panel2.Location = new System.Drawing.Point(430, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 117);
            this.panel2.TabIndex = 6;
            // 
            // staticRbn
            // 
            this.staticRbn.AutoSize = true;
            this.staticRbn.Location = new System.Drawing.Point(15, 12);
            this.staticRbn.Name = "staticRbn";
            this.staticRbn.Size = new System.Drawing.Size(97, 29);
            this.staticRbn.TabIndex = 0;
            this.staticRbn.TabStop = true;
            this.staticRbn.Text = "&Static";
            this.staticRbn.UseVisualStyleBackColor = true;
            // 
            // dhcpRbn
            // 
            this.dhcpRbn.AutoSize = true;
            this.dhcpRbn.Location = new System.Drawing.Point(15, 47);
            this.dhcpRbn.Name = "dhcpRbn";
            this.dhcpRbn.Size = new System.Drawing.Size(102, 29);
            this.dhcpRbn.TabIndex = 1;
            this.dhcpRbn.TabStop = true;
            this.dhcpRbn.Text = "&DHCP";
            this.dhcpRbn.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(754, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 400);
            this.Name = "mainForm";
            this.Text = "NetChanger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox netmaskTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton dhcpRbn;
        private System.Windows.Forms.RadioButton staticRbn;
    }
}

