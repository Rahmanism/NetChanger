﻿namespace NetChanger
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
            this.logoPbx = new System.Windows.Forms.PictureBox();
            this.titleLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.myNameLlb = new System.Windows.Forms.LinkLabel();
            this.dateLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPbx
            // 
            this.logoPbx.Image = global::NetChanger.Properties.Resources.MainIconPng;
            this.logoPbx.InitialImage = global::NetChanger.Properties.Resources.MainIconPng;
            this.logoPbx.Location = new System.Drawing.Point(15, 17);
            this.logoPbx.Name = "logoPbx";
            this.logoPbx.Size = new System.Drawing.Size(293, 293);
            this.logoPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPbx.TabIndex = 0;
            this.logoPbx.TabStop = false;
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.titleLbl.Location = new System.Drawing.Point(350, 17);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(145, 29);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "NetChanger";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.versionLbl.Location = new System.Drawing.Point(350, 54);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(55, 27);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "v1.0";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLbl.Location = new System.Drawing.Point(350, 102);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(602, 129);
            this.descriptionLbl.TabIndex = 3;
            this.descriptionLbl.Text = "Change your network IP settings easily.";
            // 
            // myNameLlb
            // 
            this.myNameLlb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myNameLlb.AutoSize = true;
            this.myNameLlb.Location = new System.Drawing.Point(350, 248);
            this.myNameLlb.Name = "myNameLlb";
            this.myNameLlb.Size = new System.Drawing.Size(161, 29);
            this.myNameLlb.TabIndex = 5;
            this.myNameLlb.TabStop = true;
            this.myNameLlb.Text = "Rahmanism.ir";
            this.myNameLlb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.myNameLlb_LinkClicked);
            // 
            // dateLbl
            // 
            this.dateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(350, 279);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(457, 29);
            this.dateLbl.TabIndex = 6;
            this.dateLbl.Text = "Release date of this version: 1397/03/08";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(786, 327);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(166, 66);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "&Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.okBtn;
            this.ClientSize = new System.Drawing.Size(978, 407);
            this.ControlBox = false;
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.myNameLlb);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.logoPbx);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
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
    }
}