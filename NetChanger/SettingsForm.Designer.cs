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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.profilesCbx = new System.Windows.Forms.ComboBox();
            this.profileNameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ipGbx = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ifaceCbx = new System.Windows.Forms.ComboBox();
            this.moveDnsDownBtn = new System.Windows.Forms.Button();
            this.moveDnsUpBtn = new System.Windows.Forms.Button();
            this.removeNameServerBtn = new System.Windows.Forms.Button();
            this.addNameserverBtn = new System.Windows.Forms.Button();
            this.nameserversLbx = new System.Windows.Forms.ListBox();
            this.dnsTxt = new System.Windows.Forms.TextBox();
            this.nameserversLbl = new System.Windows.Forms.Label();
            this.ifaceLbl = new System.Windows.Forms.Label();
            this.gatewayTxt = new System.Windows.Forms.TextBox();
            this.gatewayLbl = new System.Windows.Forms.Label();
            this.netmaskTxt = new System.Windows.Forms.TextBox();
            this.netmaskLbl = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.addressLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dhcpRbn = new System.Windows.Forms.RadioButton();
            this.staticRbn = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ipGbx.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.okBtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.profilesCbx);
            this.panel3.Controls.Add(this.profileNameTxt);
            this.panel3.Controls.Add(this.nameLbl);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // profilesCbx
            // 
            this.profilesCbx.FormattingEnabled = true;
            this.profilesCbx.Items.AddRange(new object[] {
            resources.GetString("profilesCbx.Items"),
            resources.GetString("profilesCbx.Items1")});
            resources.ApplyResources(this.profilesCbx, "profilesCbx");
            this.profilesCbx.Name = "profilesCbx";
            // 
            // profileNameTxt
            // 
            resources.ApplyResources(this.profileNameTxt, "profileNameTxt");
            this.profileNameTxt.Name = "profileNameTxt";
            // 
            // nameLbl
            // 
            resources.ApplyResources(this.nameLbl, "nameLbl");
            this.nameLbl.Name = "nameLbl";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ipGbx);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ipGbx
            // 
            this.ipGbx.Controls.Add(this.panel5);
            this.ipGbx.Controls.Add(this.panel4);
            resources.ApplyResources(this.ipGbx, "ipGbx");
            this.ipGbx.Name = "ipGbx";
            this.ipGbx.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ifaceCbx);
            this.panel5.Controls.Add(this.moveDnsDownBtn);
            this.panel5.Controls.Add(this.moveDnsUpBtn);
            this.panel5.Controls.Add(this.removeNameServerBtn);
            this.panel5.Controls.Add(this.addNameserverBtn);
            this.panel5.Controls.Add(this.nameserversLbx);
            this.panel5.Controls.Add(this.dnsTxt);
            this.panel5.Controls.Add(this.nameserversLbl);
            this.panel5.Controls.Add(this.ifaceLbl);
            this.panel5.Controls.Add(this.gatewayTxt);
            this.panel5.Controls.Add(this.gatewayLbl);
            this.panel5.Controls.Add(this.netmaskTxt);
            this.panel5.Controls.Add(this.netmaskLbl);
            this.panel5.Controls.Add(this.addressTxt);
            this.panel5.Controls.Add(this.addressLbl);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // ifaceCbx
            // 
            this.ifaceCbx.FormattingEnabled = true;
            resources.ApplyResources(this.ifaceCbx, "ifaceCbx");
            this.ifaceCbx.Name = "ifaceCbx";
            // 
            // moveDnsDownBtn
            // 
            resources.ApplyResources(this.moveDnsDownBtn, "moveDnsDownBtn");
            this.moveDnsDownBtn.Name = "moveDnsDownBtn";
            this.moveDnsDownBtn.UseVisualStyleBackColor = true;
            this.moveDnsDownBtn.Click += new System.EventHandler(this.moveDnsDownBtn_Click);
            // 
            // moveDnsUpBtn
            // 
            resources.ApplyResources(this.moveDnsUpBtn, "moveDnsUpBtn");
            this.moveDnsUpBtn.Name = "moveDnsUpBtn";
            this.moveDnsUpBtn.UseVisualStyleBackColor = true;
            this.moveDnsUpBtn.Click += new System.EventHandler(this.moveDnsUpBtn_Click);
            // 
            // removeNameServerBtn
            // 
            resources.ApplyResources(this.removeNameServerBtn, "removeNameServerBtn");
            this.removeNameServerBtn.Name = "removeNameServerBtn";
            this.removeNameServerBtn.UseVisualStyleBackColor = true;
            this.removeNameServerBtn.Click += new System.EventHandler(this.removeNameServerBtn_Click);
            // 
            // addNameserverBtn
            // 
            resources.ApplyResources(this.addNameserverBtn, "addNameserverBtn");
            this.addNameserverBtn.Name = "addNameserverBtn";
            this.addNameserverBtn.UseVisualStyleBackColor = true;
            this.addNameserverBtn.Click += new System.EventHandler(this.addNameserverBtn_Click);
            // 
            // nameserversLbx
            // 
            resources.ApplyResources(this.nameserversLbx, "nameserversLbx");
            this.nameserversLbx.Items.AddRange(new object[] {
            resources.GetString("nameserversLbx.Items"),
            resources.GetString("nameserversLbx.Items1"),
            resources.GetString("nameserversLbx.Items2"),
            resources.GetString("nameserversLbx.Items3")});
            this.nameserversLbx.Name = "nameserversLbx";
            // 
            // dnsTxt
            // 
            resources.ApplyResources(this.dnsTxt, "dnsTxt");
            this.dnsTxt.Name = "dnsTxt";
            // 
            // nameserversLbl
            // 
            resources.ApplyResources(this.nameserversLbl, "nameserversLbl");
            this.nameserversLbl.Name = "nameserversLbl";
            // 
            // ifaceLbl
            // 
            resources.ApplyResources(this.ifaceLbl, "ifaceLbl");
            this.ifaceLbl.Name = "ifaceLbl";
            // 
            // gatewayTxt
            // 
            resources.ApplyResources(this.gatewayTxt, "gatewayTxt");
            this.gatewayTxt.Name = "gatewayTxt";
            // 
            // gatewayLbl
            // 
            resources.ApplyResources(this.gatewayLbl, "gatewayLbl");
            this.gatewayLbl.Name = "gatewayLbl";
            // 
            // netmaskTxt
            // 
            resources.ApplyResources(this.netmaskTxt, "netmaskTxt");
            this.netmaskTxt.Name = "netmaskTxt";
            // 
            // netmaskLbl
            // 
            resources.ApplyResources(this.netmaskLbl, "netmaskLbl");
            this.netmaskLbl.Name = "netmaskLbl";
            // 
            // addressTxt
            // 
            resources.ApplyResources(this.addressTxt, "addressTxt");
            this.addressTxt.Name = "addressTxt";
            // 
            // addressLbl
            // 
            resources.ApplyResources(this.addressLbl, "addressLbl");
            this.addressLbl.Name = "addressLbl";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dhcpRbn);
            this.panel4.Controls.Add(this.staticRbn);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            this.panel4.TabStop = true;
            // 
            // dhcpRbn
            // 
            resources.ApplyResources(this.dhcpRbn, "dhcpRbn");
            this.dhcpRbn.Checked = true;
            this.dhcpRbn.Name = "dhcpRbn";
            this.dhcpRbn.TabStop = true;
            this.dhcpRbn.UseVisualStyleBackColor = true;
            // 
            // staticRbn
            // 
            resources.ApplyResources(this.staticRbn, "staticRbn");
            this.staticRbn.Name = "staticRbn";
            this.staticRbn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelBtn;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ipGbx.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox ipGbx;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox dnsTxt;
        private System.Windows.Forms.Label nameserversLbl;
        private System.Windows.Forms.Label ifaceLbl;
        private System.Windows.Forms.TextBox gatewayTxt;
        private System.Windows.Forms.Label gatewayLbl;
        private System.Windows.Forms.TextBox netmaskTxt;
        private System.Windows.Forms.Label netmaskLbl;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton dhcpRbn;
        private System.Windows.Forms.RadioButton staticRbn;
        private System.Windows.Forms.Button addNameserverBtn;
        private System.Windows.Forms.ListBox nameserversLbx;
        private System.Windows.Forms.ComboBox profilesCbx;
        private System.Windows.Forms.Button removeNameServerBtn;
        private System.Windows.Forms.Button moveDnsDownBtn;
        private System.Windows.Forms.Button moveDnsUpBtn;
        private System.Windows.Forms.ComboBox ifaceCbx;
    }
}

