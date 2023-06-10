namespace NetChanger
{
    partial class ProxyServerFrom
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
            if (disposing && (components != null)) {
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
            ipLbl = new System.Windows.Forms.Label();
            ipTxt = new System.Windows.Forms.TextBox();
            portLbl = new System.Windows.Forms.Label();
            portTxt = new System.Windows.Forms.TextBox();
            saveBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();
            defaultValueBtn = new System.Windows.Forms.Button();
            finalProxylbl = new System.Windows.Forms.Label();
            finalProxyValueLbl = new System.Windows.Forms.Label();
            socksChb = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // ipLbl
            // 
            ipLbl.AutoSize = true;
            ipLbl.Location = new System.Drawing.Point( 12, 9 );
            ipLbl.Name = "ipLbl";
            ipLbl.Size = new System.Drawing.Size( 93, 15 );
            ipLbl.TabIndex = 0;
            ipLbl.Text = "Proxy IP address";
            // 
            // ipTxt
            // 
            ipTxt.Location = new System.Drawing.Point( 12, 27 );
            ipTxt.Name = "ipTxt";
            ipTxt.Size = new System.Drawing.Size( 148, 23 );
            ipTxt.TabIndex = 1;
            // 
            // portLbl
            // 
            portLbl.AutoSize = true;
            portLbl.Location = new System.Drawing.Point( 225, 9 );
            portLbl.Name = "portLbl";
            portLbl.Size = new System.Drawing.Size( 29, 15 );
            portLbl.TabIndex = 2;
            portLbl.Text = "Port";
            // 
            // portTxt
            // 
            portTxt.Location = new System.Drawing.Point( 225, 27 );
            portTxt.Name = "portTxt";
            portTxt.Size = new System.Drawing.Size( 69, 23 );
            portTxt.TabIndex = 3;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            saveBtn.Location = new System.Drawing.Point( 204, 161 );
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size( 90, 29 );
            saveBtn.TabIndex = 4;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelBtn.Location = new System.Drawing.Point( 108, 161 );
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size( 90, 29 );
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // defaultValueBtn
            // 
            defaultValueBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            defaultValueBtn.Location = new System.Drawing.Point( 12, 161 );
            defaultValueBtn.Name = "defaultValueBtn";
            defaultValueBtn.Size = new System.Drawing.Size( 90, 29 );
            defaultValueBtn.TabIndex = 6;
            defaultValueBtn.Text = "Default";
            defaultValueBtn.UseVisualStyleBackColor = true;
            defaultValueBtn.Click += defaultValueBtn_Click;
            // 
            // finalProxylbl
            // 
            finalProxylbl.AutoSize = true;
            finalProxylbl.Location = new System.Drawing.Point( 12, 98 );
            finalProxylbl.Name = "finalProxylbl";
            finalProxylbl.Size = new System.Drawing.Size( 65, 15 );
            finalProxylbl.TabIndex = 7;
            finalProxylbl.Text = "Final Proxy";
            // 
            // finalProxyValueLbl
            // 
            finalProxyValueLbl.AutoSize = true;
            finalProxyValueLbl.Font = new System.Drawing.Font( "Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point );
            finalProxyValueLbl.Location = new System.Drawing.Point( 12, 113 );
            finalProxyValueLbl.Name = "finalProxyValueLbl";
            finalProxyValueLbl.Size = new System.Drawing.Size( 89, 15 );
            finalProxyValueLbl.TabIndex = 8;
            finalProxyValueLbl.Text = "127.0.0.1:1080";
            // 
            // socksChb
            // 
            socksChb.AutoSize = true;
            socksChb.Location = new System.Drawing.Point( 12, 56 );
            socksChb.Name = "socksChb";
            socksChb.Size = new System.Drawing.Size( 56, 19 );
            socksChb.TabIndex = 9;
            socksChb.Text = "Socks";
            socksChb.UseVisualStyleBackColor = true;
            socksChb.CheckedChanged += socksChb_CheckedChanged;
            // 
            // ProxyServerFrom
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size( 307, 202 );
            Controls.Add( socksChb );
            Controls.Add( finalProxyValueLbl );
            Controls.Add( finalProxylbl );
            Controls.Add( defaultValueBtn );
            Controls.Add( cancelBtn );
            Controls.Add( saveBtn );
            Controls.Add( portTxt );
            Controls.Add( portLbl );
            Controls.Add( ipTxt );
            Controls.Add( ipLbl );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProxyServerFrom";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Proxy Server";
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button defaultValueBtn;
        private System.Windows.Forms.Label finalProxylbl;
        private System.Windows.Forms.Label finalProxyValueLbl;
        private System.Windows.Forms.CheckBox socksChb;
    }
}