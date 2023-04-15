namespace NetChanger
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.logoPbx = new System.Windows.Forms.PictureBox();
            this.titleLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.myNameLlb = new System.Windows.Forms.LinkLabel();
            this.dateLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.sloganLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPbx
            // 
            this.logoPbx.Image = global::NetChanger.Properties.Resources.MainIconPng;
            this.logoPbx.InitialImage = global::NetChanger.Properties.Resources.MainIconPng;
            resources.ApplyResources(this.logoPbx, "logoPbx");
            this.logoPbx.Name = "logoPbx";
            this.logoPbx.TabStop = false;
            // 
            // titleLbl
            // 
            resources.ApplyResources(this.titleLbl, "titleLbl");
            this.titleLbl.Name = "titleLbl";
            // 
            // versionLbl
            // 
            resources.ApplyResources(this.versionLbl, "versionLbl");
            this.versionLbl.Name = "versionLbl";
            // 
            // descriptionLbl
            // 
            resources.ApplyResources(this.descriptionLbl, "descriptionLbl");
            this.descriptionLbl.Name = "descriptionLbl";
            // 
            // myNameLlb
            // 
            resources.ApplyResources(this.myNameLlb, "myNameLlb");
            this.myNameLlb.Name = "myNameLlb";
            this.myNameLlb.TabStop = true;
            this.myNameLlb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.myNameLlb_LinkClicked);
            // 
            // dateLbl
            // 
            resources.ApplyResources(this.dateLbl, "dateLbl");
            this.dateLbl.Name = "dateLbl";
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // sloganLbl
            // 
            resources.ApplyResources(this.sloganLbl, "sloganLbl");
            this.sloganLbl.Name = "sloganLbl";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.okBtn;
            this.ControlBox = false;
            this.Controls.Add(this.sloganLbl);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.myNameLlb);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.logoPbx);
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPbx;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.LinkLabel myNameLlb;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label sloganLbl;
    }
}