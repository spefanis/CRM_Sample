namespace SampleComparer.Forms
{
    partial class frmStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartup));
            this.loggedonPanel = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.mcbUserAccounts = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewMSProfiles = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panelLogonMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.panelLogonMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // loggedonPanel
            // 
            this.loggedonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggedonPanel.Location = new System.Drawing.Point(24, 64);
            this.loggedonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.loggedonPanel.Name = "loggedonPanel";
            this.loggedonPanel.Size = new System.Drawing.Size(1193, 653);
            this.loggedonPanel.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.BackgroundImage = global::SampleComparer.Properties.Resources.go;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(480, 326);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(32, 32);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.Location = new System.Drawing.Point(227, 390);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(318, 35);
            this.btnAddUser.TabIndex = 5;
            this.btnAddUser.Text = "Add new user";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // mcbUserAccounts
            // 
            this.mcbUserAccounts.FormattingEnabled = true;
            this.mcbUserAccounts.ItemHeight = 23;
            this.mcbUserAccounts.Location = new System.Drawing.Point(273, 326);
            this.mcbUserAccounts.Name = "mcbUserAccounts";
            this.mcbUserAccounts.Size = new System.Drawing.Size(200, 29);
            this.mcbUserAccounts.TabIndex = 10;
            this.mcbUserAccounts.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(255, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Voice as Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SampleComparer.Properties.Resources.VaP_2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(273, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Login";
            // 
            // btnViewMSProfiles
            // 
            this.btnViewMSProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewMSProfiles.BackColor = System.Drawing.SystemColors.Control;
            this.btnViewMSProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMSProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMSProfiles.Image = ((System.Drawing.Image)(resources.GetObject("btnViewMSProfiles.Image")));
            this.btnViewMSProfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewMSProfiles.Location = new System.Drawing.Point(236, 479);
            this.btnViewMSProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewMSProfiles.Name = "btnViewMSProfiles";
            this.btnViewMSProfiles.Size = new System.Drawing.Size(294, 28);
            this.btnViewMSProfiles.TabIndex = 7;
            this.btnViewMSProfiles.Text = "&View All Microsoft Profiles";
            this.btnViewMSProfiles.UseVisualStyleBackColor = false;
            this.btnViewMSProfiles.Click += new System.EventHandler(this.btnViewMSProfiles_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveUser.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveUser.FlatAppearance.BorderSize = 0;
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveUser.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveUser.Image")));
            this.btnRemoveUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveUser.Location = new System.Drawing.Point(361, 362);
            this.btnRemoveUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(32, 32);
            this.btnRemoveUser.TabIndex = 6;
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btnRemoveUser);
            this.metroPanel1.Controls.Add(this.btnViewMSProfiles);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.mcbUserAccounts);
            this.metroPanel1.Controls.Add(this.btnAddUser);
            this.metroPanel1.Controls.Add(this.btnLogin);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(182, 34);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(726, 532);
            this.metroPanel1.TabIndex = 13;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panelLogonMenu
            // 
            this.panelLogonMenu.Controls.Add(this.metroPanel1);
            this.panelLogonMenu.Location = new System.Drawing.Point(24, 63);
            this.panelLogonMenu.Name = "panelLogonMenu";
            this.panelLogonMenu.Size = new System.Drawing.Size(1194, 654);
            this.panelLogonMenu.TabIndex = 14;
            // 
            // frmStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 730);
            this.Controls.Add(this.panelLogonMenu);
            this.Controls.Add(this.loggedonPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStartup";
            this.Text = "Team 5 - V1.0";
            this.Load += new System.EventHandler(this.frmStartup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panelLogonMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel loggedonPanel;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnViewMSProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox mcbUserAccounts;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelLogonMenu;
    }
}