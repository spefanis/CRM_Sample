namespace SampleComparer.Forms
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.txtTextToRead = new System.Windows.Forms.TextBox();
            this.txtRecognisedText = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.lblRecordingLength = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblValidation = new System.Windows.Forms.Label();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(13, 9);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(613, 28);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "--";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(619, 47);
            this.label4.TabIndex = 4;
            this.label4.Text = "Please ensure you are in a quite enviroment, Press the \"Start\" Button and repeat " +
    "the phrase in the \"Text to Read\" box. Once you have completed the statement plea" +
    "se click the \"Stop\" button.";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.White;
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.Location = new System.Drawing.Point(422, 97);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(100, 42);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.Text = "Start";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.BackColor = System.Drawing.Color.White;
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRecording.Image")));
            this.btnStopRecording.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopRecording.Location = new System.Drawing.Point(530, 97);
            this.btnStopRecording.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(100, 42);
            this.btnStopRecording.TabIndex = 7;
            this.btnStopRecording.Text = "Stop";
            this.btnStopRecording.UseVisualStyleBackColor = false;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // txtTextToRead
            // 
            this.txtTextToRead.Location = new System.Drawing.Point(13, 147);
            this.txtTextToRead.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextToRead.Multiline = true;
            this.txtTextToRead.Name = "txtTextToRead";
            this.txtTextToRead.ReadOnly = true;
            this.txtTextToRead.Size = new System.Drawing.Size(613, 50);
            this.txtTextToRead.TabIndex = 8;
            // 
            // txtRecognisedText
            // 
            this.txtRecognisedText.Location = new System.Drawing.Point(13, 242);
            this.txtRecognisedText.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecognisedText.Multiline = true;
            this.txtRecognisedText.Name = "txtRecognisedText";
            this.txtRecognisedText.ReadOnly = true;
            this.txtRecognisedText.Size = new System.Drawing.Size(616, 64);
            this.txtRecognisedText.TabIndex = 9;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.White;
            this.btnContinue.Enabled = false;
            this.btnContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.Image")));
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Location = new System.Drawing.Point(503, 347);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(4);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(129, 28);
            this.btnContinue.TabIndex = 10;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // lblRecordingLength
            // 
            this.lblRecordingLength.AutoSize = true;
            this.lblRecordingLength.Location = new System.Drawing.Point(570, 212);
            this.lblRecordingLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordingLength.Name = "lblRecordingLength";
            this.lblRecordingLength.Size = new System.Drawing.Size(36, 17);
            this.lblRecordingLength.TabIndex = 11;
            this.lblRecordingLength.Text = "0.00";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(13, 347);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(193, 311);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(437, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 19;
            // 
            // lblValidation
            // 
            this.lblValidation.BackColor = System.Drawing.Color.Transparent;
            this.lblValidation.Location = new System.Drawing.Point(13, 310);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(174, 30);
            this.lblValidation.TabIndex = 20;
            this.lblValidation.Text = "Validation Status:";
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Checked = true;
            this.chkAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoLogin.Location = new System.Drawing.Point(400, 351);
            this.chkAutoLogin.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(95, 21);
            this.chkAutoLogin.TabIndex = 21;
            this.chkAutoLogin.Text = "Auto Login";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Sample Length:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(168, 347);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Skip Login (Testing Only)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Text to Read";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Recognised Text";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(642, 387);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkAutoLogin);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblRecordingLength);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtRecognisedText);
            this.Controls.Add(this.txtTextToRead);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUserName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.TextBox txtTextToRead;
        private System.Windows.Forms.TextBox txtRecognisedText;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label lblRecordingLength;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}