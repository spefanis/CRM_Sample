namespace SampleComparer.Forms
{
    partial class frmMain
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
            this.btnRecord1 = new System.Windows.Forms.Button();
            this.btnStopRecord1 = new System.Windows.Forms.Button();
            this.btnPlayback1 = new System.Windows.Forms.Button();
            this.waveViewerSample1 = new NAudio.Gui.WaveViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSample1Length = new System.Windows.Forms.Label();
            this.txtSubScriptionKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadProfiles = new System.Windows.Forms.Button();
            this.lblog = new System.Windows.Forms.ListBox();
            this.dgvProfiles = new System.Windows.Forms.DataGridView();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this._identificationResultTxtBlk = new System.Windows.Forms.Label();
            this._identificationConfidenceTxtBlk = new System.Windows.Forms.Label();
            this.btnRemoveProfile = new System.Windows.Forms.Button();
            this.btnSaveStream = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._identificationStatusTxtBlk = new System.Windows.Forms.Label();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnConvertToText = new System.Windows.Forms.Button();
            this.btnEncryptionTest = new System.Windows.Forms.Button();
            this.btnSentenceGenrationTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).BeginInit();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecord1
            // 
            this.btnRecord1.Enabled = false;
            this.btnRecord1.Location = new System.Drawing.Point(11, 271);
            this.btnRecord1.Name = "btnRecord1";
            this.btnRecord1.Size = new System.Drawing.Size(91, 23);
            this.btnRecord1.TabIndex = 9;
            this.btnRecord1.Text = "Record";
            this.btnRecord1.UseVisualStyleBackColor = true;
            this.btnRecord1.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnStopRecord1
            // 
            this.btnStopRecord1.Enabled = false;
            this.btnStopRecord1.Location = new System.Drawing.Point(111, 271);
            this.btnStopRecord1.Name = "btnStopRecord1";
            this.btnStopRecord1.Size = new System.Drawing.Size(91, 23);
            this.btnStopRecord1.TabIndex = 10;
            this.btnStopRecord1.Text = "Stop Recording";
            this.btnStopRecord1.UseVisualStyleBackColor = true;
            this.btnStopRecord1.Click += new System.EventHandler(this.btnStopRecord1_Click);
            // 
            // btnPlayback1
            // 
            this.btnPlayback1.Enabled = false;
            this.btnPlayback1.Location = new System.Drawing.Point(208, 271);
            this.btnPlayback1.Name = "btnPlayback1";
            this.btnPlayback1.Size = new System.Drawing.Size(91, 23);
            this.btnPlayback1.TabIndex = 11;
            this.btnPlayback1.Text = "Play Stream";
            this.btnPlayback1.UseVisualStyleBackColor = true;
            this.btnPlayback1.Click += new System.EventHandler(this.btnPlayback1_Click);
            // 
            // waveViewerSample1
            // 
            this.waveViewerSample1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveViewerSample1.Location = new System.Drawing.Point(11, 297);
            this.waveViewerSample1.Name = "waveViewerSample1";
            this.waveViewerSample1.SamplesPerPixel = 128;
            this.waveViewerSample1.Size = new System.Drawing.Size(454, 76);
            this.waveViewerSample1.StartPosition = ((long)(0));
            this.waveViewerSample1.TabIndex = 12;
            this.waveViewerSample1.WaveStream = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sample Length (sec)";
            // 
            // lblSample1Length
            // 
            this.lblSample1Length.AutoSize = true;
            this.lblSample1Length.Location = new System.Drawing.Point(538, 276);
            this.lblSample1Length.Name = "lblSample1Length";
            this.lblSample1Length.Size = new System.Drawing.Size(13, 13);
            this.lblSample1Length.TabIndex = 13;
            this.lblSample1Length.Text = "--";
            // 
            // txtSubScriptionKey
            // 
            this.txtSubScriptionKey.Location = new System.Drawing.Point(116, 6);
            this.txtSubScriptionKey.Name = "txtSubScriptionKey";
            this.txtSubScriptionKey.Size = new System.Drawing.Size(282, 20);
            this.txtSubScriptionKey.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Subscription Key";
            // 
            // btnLoadProfiles
            // 
            this.btnLoadProfiles.Location = new System.Drawing.Point(404, 4);
            this.btnLoadProfiles.Name = "btnLoadProfiles";
            this.btnLoadProfiles.Size = new System.Drawing.Size(97, 23);
            this.btnLoadProfiles.TabIndex = 19;
            this.btnLoadProfiles.Text = "Load Profiles";
            this.btnLoadProfiles.UseVisualStyleBackColor = true;
            this.btnLoadProfiles.Click += new System.EventHandler(this.btnLoadEnrollments_Click);
            // 
            // lblog
            // 
            this.lblog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblog.FormattingEnabled = true;
            this.lblog.HorizontalScrollbar = true;
            this.lblog.Location = new System.Drawing.Point(612, 6);
            this.lblog.Name = "lblog";
            this.lblog.Size = new System.Drawing.Size(412, 537);
            this.lblog.TabIndex = 20;
            // 
            // dgvProfiles
            // 
            this.dgvProfiles.AllowUserToAddRows = false;
            this.dgvProfiles.AllowUserToDeleteRows = false;
            this.dgvProfiles.AllowUserToResizeRows = false;
            this.dgvProfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfiles.Location = new System.Drawing.Point(11, 36);
            this.dgvProfiles.Name = "dgvProfiles";
            this.dgvProfiles.RowHeadersVisible = false;
            this.dgvProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfiles.Size = new System.Drawing.Size(585, 200);
            this.dgvProfiles.TabIndex = 21;
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Enabled = false;
            this.btnAddProfile.Location = new System.Drawing.Point(11, 242);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(191, 23);
            this.btnAddProfile.TabIndex = 22;
            this.btnAddProfile.Text = "Add Profile";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Enabled = false;
            this.btnEnroll.Location = new System.Drawing.Point(11, 379);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(191, 23);
            this.btnEnroll.TabIndex = 25;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Enabled = false;
            this.btnVerify.Location = new System.Drawing.Point(11, 408);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(191, 23);
            this.btnVerify.TabIndex = 26;
            this.btnVerify.Text = "Verify Sample";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // _identificationResultTxtBlk
            // 
            this._identificationResultTxtBlk.AutoSize = true;
            this._identificationResultTxtBlk.Location = new System.Drawing.Point(204, 16);
            this._identificationResultTxtBlk.Name = "_identificationResultTxtBlk";
            this._identificationResultTxtBlk.Size = new System.Drawing.Size(13, 13);
            this._identificationResultTxtBlk.TabIndex = 27;
            this._identificationResultTxtBlk.Text = "--";
            // 
            // _identificationConfidenceTxtBlk
            // 
            this._identificationConfidenceTxtBlk.AutoSize = true;
            this._identificationConfidenceTxtBlk.Location = new System.Drawing.Point(204, 39);
            this._identificationConfidenceTxtBlk.Name = "_identificationConfidenceTxtBlk";
            this._identificationConfidenceTxtBlk.Size = new System.Drawing.Size(13, 13);
            this._identificationConfidenceTxtBlk.TabIndex = 28;
            this._identificationConfidenceTxtBlk.Text = "--";
            // 
            // btnRemoveProfile
            // 
            this.btnRemoveProfile.Enabled = false;
            this.btnRemoveProfile.Location = new System.Drawing.Point(208, 242);
            this.btnRemoveProfile.Name = "btnRemoveProfile";
            this.btnRemoveProfile.Size = new System.Drawing.Size(191, 23);
            this.btnRemoveProfile.TabIndex = 29;
            this.btnRemoveProfile.Text = "Remove Profile";
            this.btnRemoveProfile.UseVisualStyleBackColor = true;
            this.btnRemoveProfile.Click += new System.EventHandler(this.btnRemoveProfile_Click);
            // 
            // btnSaveStream
            // 
            this.btnSaveStream.Enabled = false;
            this.btnSaveStream.Location = new System.Drawing.Point(471, 297);
            this.btnSaveStream.Name = "btnSaveStream";
            this.btnSaveStream.Size = new System.Drawing.Size(122, 23);
            this.btnSaveStream.TabIndex = 30;
            this.btnSaveStream.Text = "Save Stream to File";
            this.btnSaveStream.UseVisualStyleBackColor = true;
            this.btnSaveStream.Click += new System.EventHandler(this.btnSaveStream_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Identification Confidence:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Speaker ID Matched";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "This will enroll the saved audio stream against the selected user";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(306, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "This will verify the saved audio stream against the selected user";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Identification Status";
            // 
            // _identificationStatusTxtBlk
            // 
            this._identificationStatusTxtBlk.AutoSize = true;
            this._identificationStatusTxtBlk.Location = new System.Drawing.Point(204, 59);
            this._identificationStatusTxtBlk.Name = "_identificationStatusTxtBlk";
            this._identificationStatusTxtBlk.Size = new System.Drawing.Size(13, 13);
            this._identificationStatusTxtBlk.TabIndex = 35;
            this._identificationStatusTxtBlk.Text = "--";
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.label5);
            this.gbResults.Controls.Add(this.label7);
            this.gbResults.Controls.Add(this._identificationResultTxtBlk);
            this.gbResults.Controls.Add(this._identificationStatusTxtBlk);
            this.gbResults.Controls.Add(this._identificationConfidenceTxtBlk);
            this.gbResults.Controls.Add(this.label3);
            this.gbResults.Location = new System.Drawing.Point(12, 437);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(581, 129);
            this.gbResults.TabIndex = 37;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(507, 4);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(89, 23);
            this.btnSaveData.TabIndex = 37;
            this.btnSaveData.Text = "Save Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnConvertToText
            // 
            this.btnConvertToText.Enabled = false;
            this.btnConvertToText.Location = new System.Drawing.Point(471, 326);
            this.btnConvertToText.Name = "btnConvertToText";
            this.btnConvertToText.Size = new System.Drawing.Size(124, 23);
            this.btnConvertToText.TabIndex = 38;
            this.btnConvertToText.Text = "Convert To Text";
            this.btnConvertToText.UseVisualStyleBackColor = true;
            this.btnConvertToText.Visible = false;
            this.btnConvertToText.Click += new System.EventHandler(this.btnConvertToText_Click);
            // 
            // btnEncryptionTest
            // 
            this.btnEncryptionTest.Location = new System.Drawing.Point(612, 549);
            this.btnEncryptionTest.Name = "btnEncryptionTest";
            this.btnEncryptionTest.Size = new System.Drawing.Size(144, 23);
            this.btnEncryptionTest.TabIndex = 39;
            this.btnEncryptionTest.Text = "Encryption Text";
            this.btnEncryptionTest.UseVisualStyleBackColor = true;
            this.btnEncryptionTest.Click += new System.EventHandler(this.btnEncryptionTest_Click);
            // 
            // btnSentenceGenrationTest
            // 
            this.btnSentenceGenrationTest.Location = new System.Drawing.Point(762, 549);
            this.btnSentenceGenrationTest.Name = "btnSentenceGenrationTest";
            this.btnSentenceGenrationTest.Size = new System.Drawing.Size(144, 23);
            this.btnSentenceGenrationTest.TabIndex = 40;
            this.btnSentenceGenrationTest.Text = "Sentence Generation Test";
            this.btnSentenceGenrationTest.UseVisualStyleBackColor = true;
            this.btnSentenceGenrationTest.Click += new System.EventHandler(this.btnSentenceGenrationTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(946, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSentenceGenrationTest);
            this.Controls.Add(this.btnEncryptionTest);
            this.Controls.Add(this.btnConvertToText);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveStream);
            this.Controls.Add(this.btnRemoveProfile);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.waveViewerSample1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSample1Length);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnPlayback1);
            this.Controls.Add(this.btnAddProfile);
            this.Controls.Add(this.btnStopRecord1);
            this.Controls.Add(this.btnRecord1);
            this.Controls.Add(this.dgvProfiles);
            this.Controls.Add(this.lblog);
            this.Controls.Add(this.btnLoadProfiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubScriptionKey);
            this.Name = "frmMain";
            this.Text = "Speaker Validation";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).EndInit();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRecord1;
        private System.Windows.Forms.Button btnStopRecord1;
        private System.Windows.Forms.Button btnPlayback1;
        private NAudio.Gui.WaveViewer waveViewerSample1;
        private System.Windows.Forms.Label lblSample1Length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubScriptionKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadProfiles;
        private System.Windows.Forms.DataGridView dgvProfiles;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label _identificationResultTxtBlk;
        private System.Windows.Forms.Label _identificationConfidenceTxtBlk;
        private System.Windows.Forms.Button btnRemoveProfile;
        private System.Windows.Forms.Button btnSaveStream;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _identificationStatusTxtBlk;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnConvertToText;
        public System.Windows.Forms.ListBox lblog;
        private System.Windows.Forms.Button btnEncryptionTest;
        private System.Windows.Forms.Button btnSentenceGenrationTest;
        private System.Windows.Forms.Button button1;
    }
}

