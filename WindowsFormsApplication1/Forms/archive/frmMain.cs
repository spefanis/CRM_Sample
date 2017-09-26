using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data;

using Microsoft.ProjectOxford.SpeakerRecognition;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;

using NAudio.Wave;
using SampleComparer.Classes;

namespace SampleComparer.Forms
{
    public partial class frmMain : Form
    {

        private Stream audioStream1;
        public static string speakerVerificationKey = "2af416386d37457ebfeb7d0779ba38b9";
        private string bingSpeakKey = "d26b954751b346bba59b249f25c07e3a";

        private Database db;

        public frmMain()
        {
            InitializeComponent();
            db = new Database();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //await UpdateAllSpeakersAsync();
            //txtSubScriptionKey.Text = speakerVerificationKey;
        }

        #region LogMessage Functions
        // This is all required so that we can call the function from another class 
        public void publicLogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new OutputDelegate(logMessage), message);
            }
            else
            {
                logMessage(message);
            }
        }
        public delegate void OutputDelegate(string message);
        public void logMessage(string message)
        {
            lblog.Items.Add(DateTime.Now + "  " + message);
        }
        #endregion



        private void btnRecord1_Click(object sender, EventArgs e)
        {
            //Enable/Disable the buttons as required
            audioCapture a = new audioCapture();
            functionResult f = a.onRecord(ref audioStream1);
            if (f.Result == true)
            {
                timerClock.Start();
                setValidStream(false);
                btnStopRecord1.Enabled = true;
            }
        }

        private void btnStopRecord1_Click(object sender, EventArgs e)
        {
            timerClock.Stop();
            audioCapture a = new audioCapture();
            a.OnRecordingStopped(sender, null);

            //This create the wave output that is shown on the screen
            var waveFormat = WaveFormat.CreateMuLawFormat(8000, 1);
            using (var x = new RawSourceWaveStream(audioStream1, waveFormat))
            {
                waveViewerSample1.WaveStream = x;
            }

            //Enable/Disable the buttons as required

            setValidStream(true);

            //Show the length of the sample for the user to see
            double sampleLength = (audioCapture.recordingEnded - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblSample1Length.Text = Math.Round(sampleLength, 2).ToString();

        }
        private void btnPlayback1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            audioCapture a = new audioCapture();
            a.onPlayback(ref audioStream1);
            this.Cursor = Cursors.Default;
        }
        private void btnSaveStream_Click(object sender, EventArgs e)
        {
            audioCapture a = new audioCapture();
            a.onSaveFile(ref audioStream1, "wavefile1.wav");
        }




        private void btnLoadEnrollments_Click(object sender, EventArgs e) { LoadProfiles(); }
        private void btnAddProfile_Click(object sender, EventArgs e) { AddProfile(); }
        private void btnRemoveProfile_Click(object sender, EventArgs e) { RemoveProfile(); }
        private void btnEnroll_Click(object sender, EventArgs e) { EnrollProfile(); }
        private void btnVerify_Click(object sender, EventArgs e) { VerifySpeaker(); }


        #region Speaker Verificaiton Function

        //This calls the functionality to add a profile
        private async void AddProfile()
        {
            projectOxfordSpeaker s = new projectOxfordSpeaker();
            functionResult result = await s.addSpeaker();
            if (result.Result == true)
            {
                LoadProfiles();
            }
            else
            {
                MessageBox.Show(result.Message, "Function Result: Add Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This calls the functionality to load all available profiles
        private async void LoadProfiles()
        {
            this.Cursor = Cursors.WaitCursor;

            setValidStream(false);

            projectOxfordSpeaker s = new projectOxfordSpeaker();
            DataTable dt = await s.UpdateAllSpeakers();
            dgvProfiles.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                setValidStream(false);
                btnAddProfile.Enabled = true;
                btnRemoveProfile.Enabled = true;
                btnRecord1.Enabled = true;

            }
            else
            {
                btnAddProfile.Enabled = false;
                btnRemoveProfile.Enabled = false;
                btnRecord1.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }

        //This calls the functionality to verify the recorded audio samlpe
        private async void VerifySpeaker()
        {
            //DataGridViewRow dr = dgvProfiles.CurrentRow;
            //if (dr != null)
            //{
            //    string profileID = dr.Cells["SpeakerID"].Value.ToString();
            //    projectOxfordSpeaker s = new projectOxfordSpeaker(txtSubScriptionKey.Text);
            //    speakerVerificationResult result = await s.verifySpeaker(audioStream1, new Guid(profileID), Convert.ToDouble(lblSample1Length.Text));
            //    if (result.Result == true)
            //    {
            //        _identificationConfidenceTxtBlk.Text = result.Confidence;
            //        _identificationStatusTxtBlk.Text = result.Status;
            //        _identificationResultTxtBlk.Text = result.IdentifiedProfileId;

            //        if (profileID == result.IdentifiedProfileId)
            //        {
            //            gbResults.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            gbResults.BackColor = Color.Red;
            //        }

            //    }

            //    else
            //    {
            //        gbResults.BackColor = DefaultBackColor;
            //        MessageBox.Show(result.Message, "Function Result: Verify Speaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a profile to Verify against", "Verify Sample", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        //This calls the functionality to remove the selected profile
        private async void RemoveProfile()
        {
            if (dgvProfiles.RowCount > 0)
            {
                DataGridViewRow dr = dgvProfiles.CurrentRow;
                if (dr != null)
                {
                    string profileID = dr.Cells["SpeakerID"].Value.ToString();
                    DialogResult dresult = MessageBox.Show("Are you sure you want to remove profile ID: " + profileID + "?", "Remove Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult == DialogResult.Yes)
                    {
                        projectOxfordSpeaker s = new projectOxfordSpeaker();
                        functionResult result = await s.removeSpeaker(new Guid(profileID));
                        if (result.Result == true)
                        {
                            LoadProfiles();
                        }
                        else
                        {
                            MessageBox.Show(result.Message, "Function Result: Remove Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a profile to remove", "Remove Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("There are no profiles available. Please press the 'Load Profiles' to check for profiles on the server or 'Create Profile' to create a new profile", "Remove Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //This calls the functionality to enroll the recorded audio samlpe
        private async void EnrollProfile()
        {
            DataGridViewRow dr = dgvProfiles.CurrentRow;
            if (dr != null)
            {
                string profileID = dr.Cells["SpeakerID"].Value.ToString();
                projectOxfordSpeaker s = new projectOxfordSpeaker();
                functionResult result = await s.enrollSpeaker(audioStream1, new Guid(profileID), Convert.ToDouble(lblSample1Length.Text));

                if (result.Result == true)
                {
                    //setValidStream(true);
                    LoadProfiles();
                }
                else
                {
                    MessageBox.Show(result.Message, "Function Result: Enroll Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please select a profile to enroll to", "Enroll Sample", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void setValidStream(Boolean isValid)
        {
            btnRecord1.Enabled = true;
            btnPlayback1.Enabled = isValid;
            btnStopRecord1.Enabled = isValid;
            btnSaveStream.Enabled = isValid;
            btnEnroll.Enabled = isValid;
            btnVerify.Enabled = isValid;
            btnConvertToText.Enabled = isValid;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            saveToDatabase();
            //saveToXML();

            this.Cursor = Cursors.WaitCursor;
        }

        //This is here toi provide an indication to the user how long their audio sample is
        private void timerClock_Tick(object sender, EventArgs e)
        {

            double sampleLength = (DateTime.Now - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblSample1Length.Text = Math.Round(sampleLength, 2).ToString();
        }


        private void saveToDatabase()
        {
            List<UserRecord> users = new List<UserRecord>();
            int x = 0;
            //Create a list of all the data that is in the grid
            foreach (DataGridViewRow row in dgvProfiles.Rows)
            {
                //Increment the ID
                x += 1;
                //Create a temp UserRecord to populate
                UserRecord tmp = new UserRecord();
                tmp.ID = x;
                tmp.PROFILEID = (row.Cells["SpeakerID"].Value.ToString());
                //Ensure ther is a valid string in the "SpeakerName" column
                if (row.Cells["SpeakerName"].Value == null)
                {
                    tmp.NAME = "";
                }
                else
                {
                    tmp.NAME = row.Cells["SpeakerName"].Value.ToString();
                }

                //Ensure ther is a valid string in the "ID" column
                if ((row.Cells["ID"].Value == null) || (row.Cells["ID"].Value.ToString().Length == 0))
                {
                    tmp.ID = 0;
                }
                else
                {

                    tmp.ID = Convert.ToInt32(row.Cells["ID"].Value);
                }
                //Add the temp UserRecord to the list
                users.Add(tmp);
            }
            // MessageBox.Show(users.Count.ToString());
            if (db.writeUserList(users) == true)
            {
                LoadProfiles();
            }
            else
            {
                MessageBox.Show("Error when saving the user data to the database", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnConvertToText_Click(object sender, EventArgs e)
        {
            speechRecognition_system_speech s = new speechRecognition_system_speech();
            //MessageBox.Show(s.convertToSpeech(audioStream1, null));
        }

        private void btnEncryptionTest_Click(object sender, EventArgs e)
        {
            frmEncryptionTest f = new frmEncryptionTest();
            f.Show();
        }

        private void btnSentenceGenrationTest_Click(object sender, EventArgs e)
        {
            frmSentenceGenerationTest f = new frmSentenceGenerationTest();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //speechRecognition_windows_media f = new speechRecognition_windows_media(this);
            //f.convertToSpeech(audioStream1 );
            frmWebTest f = new frmWebTest();
            f.Show();
        }
    }
}
