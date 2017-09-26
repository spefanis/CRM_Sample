using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SampleComparer.Classes;

namespace SampleComparer.Forms
{
    public partial class frmAddUser : Form
    {
        Stream audioStream1;
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid user name", "Add User");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            btnCreate.Text = "Please Wait";
            btnCancel.Enabled = false;
            btnCreate.Enabled = false;
            Database db = new Database();
            functionResult r = db.addNewUser(txtUserName.Text);
            if (r.Result == true)
            {

                string newUserID = r.Message;
                projectOxfordSpeaker s = new projectOxfordSpeaker();
                r = await s.addSpeaker();
                if (r.Result == true)
                {
                    db.updateUser(newUserID, txtUserName.Text, r.Message);
                    performSpeakerEnrollment(r.Message);
                }
                else
                {
                    MessageBox.Show(r.Message, "Error when creating new profile");
                    btnCreate.Text = "Create";
                    btnCancel.Enabled = true;
                    btnCreate.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(r.Message, "Error when adding new user");
                                btnCreate.Text = "Create";
                btnCancel.Enabled = true;
                btnCreate.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }



        private void btnRecord_Click(object sender, EventArgs e)
        {
            //create the audio capture functionality and start recording
            audioCapture a = new audioCapture();
            functionResult r = a.onRecord(ref audioStream1);
            if (r.Result == true)
            {
                //If there are no errors. Set the lable text and button enable/disable.
                //also start the timer
                timerClock.Start();
                btnRecord.Enabled = false;
                btnCreate.Enabled = false;
                btnStopRecording.Enabled = true;
            }
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            stopRecording();
        }

        //This stops the recording functionality
        private void stopRecording()
        {
            //Stop the timer
            timerClock.Stop();
            //stop recordinmg from the microphone
            audioCapture a = new audioCapture();
            a.OnRecordingStopped(null, null);

            //Enable/Disable the buttons as required
            btnRecord.Enabled = true;
            btnStopRecording.Enabled = false;

            //Show the length of the sample for the user to see
            double sampleLength = (audioCapture.recordingEnded - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblRecordingLength.Text = Math.Round(sampleLength, 2).ToString();
            //If the sample lenght is greater than 5 seconds
            if (sampleLength > 5)
            {
                btnCreate.Enabled = true;
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            //Timer is used to update the label on the form
            double sampleLength = (DateTime.Now - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblRecordingLength.Text = Math.Round(sampleLength, 2).ToString();
            //Once we have 10 seconds of audio, we can stop recording
            if (sampleLength >= 10)
            {
                stopRecording();
            }
        }

        //This will perform the verification of the user sample against the profile ID
        //INPUT: profile ID
        //OUPUT:
        private async void performSpeakerEnrollment(string profileID)
        {
            //Disable the buttons so the user doesn't try to re-record
            btnRecord.Enabled = false;
            btnStopRecording.Enabled = false;
            btnCreate.Enabled = false;

            //Validate the audio stream against the profile ID
            projectOxfordSpeaker s = new projectOxfordSpeaker();
            functionResult result = await s.enrollSpeaker(audioStream1, new Guid(profileID), Convert.ToDouble(lblRecordingLength.Text));

            //If all is good, set the validation as true
            if (result.Result == true)
            {

                this.DialogResult = DialogResult.OK;
            }

            else
            {
                //If there are errors. display the message
                MessageBox.Show(result.Message, "Function Result: Enroll Speaker", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Cursor = Cursors.Default;
                btnCreate.Text = "Create";
                btnCancel.Enabled = true;
                btnCreate.Enabled = true;
            }
        }

    }
}
