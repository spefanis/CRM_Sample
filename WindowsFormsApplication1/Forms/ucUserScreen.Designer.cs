namespace SampleComparer.Forms
{
    partial class ucUserScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserScreen));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvUserAccounts = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddLogin = new System.Windows.Forms.Button();
            this.btnRemoveLogin = new System.Windows.Forms.Button();
            this.btnStartCommand = new System.Windows.Forms.Button();
            this.txtTextRecognises = new System.Windows.Forms.TextBox();
            this.txtCommandAction = new System.Windows.Forms.TextBox();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.btnStopCommand = new System.Windows.Forms.Button();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblRecordingLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLoggedInAs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dgvUserAccounts
            // 
            this.dgvUserAccounts.AllowUserToAddRows = false;
            this.dgvUserAccounts.AllowUserToDeleteRows = false;
            this.dgvUserAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserAccounts.Location = new System.Drawing.Point(8, 59);
            this.dgvUserAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUserAccounts.Name = "dgvUserAccounts";
            this.dgvUserAccounts.ReadOnly = true;
            this.dgvUserAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserAccounts.Size = new System.Drawing.Size(858, 266);
            this.dgvUserAccounts.TabIndex = 4;
            this.dgvUserAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserAccounts_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Saved Logins (double click to edit):";
            // 
            // btnAddLogin
            // 
            this.btnAddLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLogin.Image")));
            this.btnAddLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLogin.Location = new System.Drawing.Point(638, 24);
            this.btnAddLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLogin.Name = "btnAddLogin";
            this.btnAddLogin.Size = new System.Drawing.Size(110, 28);
            this.btnAddLogin.TabIndex = 6;
            this.btnAddLogin.Text = "Add";
            this.btnAddLogin.UseVisualStyleBackColor = true;
            this.btnAddLogin.Click += new System.EventHandler(this.btnAddLogin_Click);
            // 
            // btnRemoveLogin
            // 
            this.btnRemoveLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveLogin.Image")));
            this.btnRemoveLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveLogin.Location = new System.Drawing.Point(756, 24);
            this.btnRemoveLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveLogin.Name = "btnRemoveLogin";
            this.btnRemoveLogin.Size = new System.Drawing.Size(110, 28);
            this.btnRemoveLogin.TabIndex = 7;
            this.btnRemoveLogin.Text = "Remove";
            this.btnRemoveLogin.UseVisualStyleBackColor = true;
            this.btnRemoveLogin.Click += new System.EventHandler(this.btnRemoveLogin_Click);
            // 
            // btnStartCommand
            // 
            this.btnStartCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartCommand.Image = ((System.Drawing.Image)(resources.GetObject("btnStartCommand.Image")));
            this.btnStartCommand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartCommand.Location = new System.Drawing.Point(10, 50);
            this.btnStartCommand.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartCommand.Name = "btnStartCommand";
            this.btnStartCommand.Size = new System.Drawing.Size(153, 28);
            this.btnStartCommand.TabIndex = 8;
            this.btnStartCommand.Text = "Speak Command";
            this.btnStartCommand.UseVisualStyleBackColor = true;
            this.btnStartCommand.Click += new System.EventHandler(this.btnSpeakCommand_Click);
            // 
            // txtTextRecognises
            // 
            this.txtTextRecognises.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextRecognises.Enabled = false;
            this.txtTextRecognises.Location = new System.Drawing.Point(332, 53);
            this.txtTextRecognises.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextRecognises.Name = "txtTextRecognises";
            this.txtTextRecognises.ReadOnly = true;
            this.txtTextRecognises.Size = new System.Drawing.Size(535, 23);
            this.txtTextRecognises.TabIndex = 9;
            // 
            // txtCommandAction
            // 
            this.txtCommandAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandAction.Enabled = false;
            this.txtCommandAction.Location = new System.Drawing.Point(8, 86);
            this.txtCommandAction.Margin = new System.Windows.Forms.Padding(4);
            this.txtCommandAction.Multiline = true;
            this.txtCommandAction.Name = "txtCommandAction";
            this.txtCommandAction.ReadOnly = true;
            this.txtCommandAction.Size = new System.Drawing.Size(860, 69);
            this.txtCommandAction.TabIndex = 10;
            // 
            // btnLogOff
            // 
            this.btnLogOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOff.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOff.Image")));
            this.btnLogOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOff.Location = new System.Drawing.Point(669, 4);
            this.btnLogOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(212, 51);
            this.btnLogOff.TabIndex = 11;
            this.btnLogOff.Text = "LogOff";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // btnStopCommand
            // 
            this.btnStopCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopCommand.Image = ((System.Drawing.Image)(resources.GetObject("btnStopCommand.Image")));
            this.btnStopCommand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopCommand.Location = new System.Drawing.Point(171, 50);
            this.btnStopCommand.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopCommand.Name = "btnStopCommand";
            this.btnStopCommand.Size = new System.Drawing.Size(153, 28);
            this.btnStopCommand.TabIndex = 12;
            this.btnStopCommand.Text = "Stop";
            this.btnStopCommand.UseVisualStyleBackColor = true;
            this.btnStopCommand.Click += new System.EventHandler(this.btnStopCommand_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(696, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Sample Length:";
            // 
            // lblRecordingLength
            // 
            this.lblRecordingLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordingLength.AutoSize = true;
            this.lblRecordingLength.Location = new System.Drawing.Point(813, 159);
            this.lblRecordingLength.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRecordingLength.Name = "lblRecordingLength";
            this.lblRecordingLength.Size = new System.Drawing.Size(36, 17);
            this.lblRecordingLength.TabIndex = 23;
            this.lblRecordingLength.Text = "0.00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(693, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Commands should be in the format of \"Open XXXX\", where \"XXXX\" is the Keyword for " +
    "the login";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvUserAccounts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddLogin);
            this.groupBox1.Controls.Add(this.btnRemoveLogin);
            this.groupBox1.Location = new System.Drawing.Point(8, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(874, 333);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Logins";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnStartCommand);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblRecordingLength);
            this.groupBox2.Controls.Add(this.btnStopCommand);
            this.groupBox2.Controls.Add(this.txtTextRecognises);
            this.groupBox2.Controls.Add(this.txtCommandAction);
            this.groupBox2.Location = new System.Drawing.Point(7, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 183);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commands";
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoggedInAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInAs.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblLoggedInAs.Location = new System.Drawing.Point(7, 4);
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(655, 51);
            this.lblLoggedInAs.TabIndex = 27;
            this.lblLoggedInAs.Text = "User:";
            this.lblLoggedInAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucUserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogOff);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucUserScreen";
            this.Size = new System.Drawing.Size(885, 589);
            this.Load += new System.EventHandler(this.ucUserScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvUserAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddLogin;
        private System.Windows.Forms.Button btnRemoveLogin;
        private System.Windows.Forms.Button btnStartCommand;
        private System.Windows.Forms.TextBox txtTextRecognises;
        private System.Windows.Forms.TextBox txtCommandAction;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.Button btnStopCommand;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRecordingLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLoggedInAs;
    }
}
