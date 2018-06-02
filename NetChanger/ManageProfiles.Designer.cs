namespace NetChanger
{
    partial class ManageProfiles
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.profilesLbx = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(11, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 77);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profiles List";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(11, 89);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.profilesLbx);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.closeBtn);
            this.splitContainer1.Panel2.Controls.Add(this.deleteBtn);
            this.splitContainer1.Panel2.Controls.Add(this.editBtn);
            this.splitContainer1.Panel2.Controls.Add(this.newBtn);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.splitContainer1.Size = new System.Drawing.Size(617, 469);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 4;
            // 
            // profilesLbx
            // 
            this.profilesLbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesLbx.FormattingEnabled = true;
            this.profilesLbx.ItemHeight = 27;
            this.profilesLbx.Items.AddRange(new object[] {
            "Office",
            "Home",
            "DHCP"});
            this.profilesLbx.Location = new System.Drawing.Point(0, 0);
            this.profilesLbx.Name = "profilesLbx";
            this.profilesLbx.Size = new System.Drawing.Size(387, 469);
            this.profilesLbx.TabIndex = 4;
            // 
            // closeBtn
            // 
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.closeBtn.Location = new System.Drawing.Point(22, 386);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(182, 60);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(22, 151);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(182, 63);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.editBtn.Location = new System.Drawing.Point(22, 88);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(182, 63);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.newBtn.Location = new System.Drawing.Point(22, 23);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(182, 65);
            this.newBtn.TabIndex = 6;
            this.newBtn.Text = "&New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // ManageProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 570);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.Name = "ManageProfiles";
            this.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.Text = "ManageProfiles";
            this.Load += new System.EventHandler(this.ManageProfiles_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox profilesLbx;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}