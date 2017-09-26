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
using NAudio.Wave;
using SampleComparer.Classes;

namespace SampleComparer.Forms
{
    public partial class frmLogin : Form
    {

        public int public_userID { get; set; }
        public string public_userName { get; set; }
        public string public_profileID { get; set; }

        Stream audioStream1;

        Boolean validLogin = false;
        Boolean validSpeaker = false;
        Boolean validSpeech = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //On load generate a new sentance
            sentenceGenerator s = new sentenceGenerator();
            txtTextToRead.Text = string.Format("My name is " + public_userName + ". " + s.generateColorSequence());
            lblUserName.Text = "Log in as: " + public_userName;         
        }


        private void btnContinue_Click(object sender, EventArgs e)
        {
            //If the login is valid, return ok so that the main form gets a result we can use
            if (validLogin == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
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
                lblValidation.Text = "Validation Status:";
                timerClock.Start();
                btnRecord.Enabled = false;
                btnStopRecording.Enabled = true;
                btnContinue.Enabled = false;
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

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            stopRecording();
        }

        //This stops the recording functionality and starts the validation
        //INPUT:
        //OUPUT
        private void stopRecording()
        {
            //Stop the timer
            timerClock.Stop();

            lblValidation.ForeColor = Color.Black;

            //stop recordinmg from the microphone
            audioCapture a = new audioCapture();
            a.OnRecordingStopped(null, null);

                        //Enable/Disable the buttons as required
            btnRecord.Enabled = true;
            btnStopRecording.Enabled = false;

            //Show the length of the sample for the user to see
            double sampleLength = (audioCapture.recordingEnded - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblRecordingLength.Text = Math.Round(sampleLength, 2).ToString();
            //If the sample lenght is greater than 2.5 seconds
            if (sampleLength > 2.5)
            {
                //Start the progress bar so the user can see something is happening
                progressBar1.Style = ProgressBarStyle.Marquee;
                lblValidation.Text = "Validating, please wait";
                if (doSpeechTextValidation(txtTextToRead.Text))
                {
                    performSpeakerValidation();
                    validSpeech = true;
                }
                // if (chkAutoLogin.Checked == true) btnContinue_Click(null, null);
                else
                {
                    validSpeech = false;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    lblValidation.Text = "Invalid User";
                    lblValidation.ForeColor = Color.Salmon;

                }


            }

        }


        //This will perform the verification of the user sample against the profile ID
        //INPUT: 
        //OUPUT:
        private async void performSpeakerValidation()
        {
            //Disable the buttons so the user doesn't try to re-record
            btnRecord.Enabled = false;
            btnStopRecording.Enabled = false;
            btnContinue.Enabled = false;
            string profileID = public_profileID;

            //Validate the audio stream against the profile ID
            projectOxfordSpeaker s = new projectOxfordSpeaker();
            speakerVerificationResult result = await s.verifySpeaker(audioStream1, new Guid(profileID), Convert.ToDouble(lblRecordingLength.Text));

            //If all is good, set the validation as true
            if (result.Result == true)
            {
                if (profileID == result.IdentifiedProfileId)
                {
                    validSpeaker = true;
                    lblValidation.Text = "User validated";
                    lblValidation.ForeColor = Color.Green;
                }
                else
                {
                    lblValidation.Text = "Invalid User";
                    validSpeaker = false;
                    lblValidation.ForeColor = Color.Salmon ;
                }

            }

            else
            {
                //If there are errors. display the message
                validLogin = false;
                MessageBox.Show(result.Message, "Function Result: Verify Speaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnRecord.Enabled = true;
            //Stop the progress bar
            progressBar1.Style = ProgressBarStyle.Continuous;
            if (validSpeaker && validSpeech)
            {
                validLogin = true;
                btnContinue.BackColor = Color.Green;
                //If autolog in checked, do login
                if (chkAutoLogin.Checked == true) { this.DialogResult = DialogResult.OK; }
            }
            btnContinue.Enabled = validLogin;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //This will take the recorded speech and compare it against the expected string
        //INPUT: expectedString
        //OUPUT: True if the strings match, false if not
        private Boolean doSpeechTextValidation(string expectedString)
        {
            speechRecognition_system_speech ps = new speechRecognition_system_speech();
            functionResult f = ps.convertToSpeechWithString (audioStream1, expectedString);
            if (f.Result == true)
            {
                //If no recognised result, then no valid phrase if found. this is NOT an error
                if (f.recognitionResult == null)
                {
                    txtRecognisedText.Text = "No Valid Phrase Found, Please try again ensuring to speak slowly and clearly";
                    txtRecognisedText.BackColor = Color.Salmon;
                    return false ;

                }
                else
                {
                    txtRecognisedText.Text = f.recognitionResult.Text  + " (Result Confidence = " + f.recognitionResult.Confidence + ")";
                    txtRecognisedText.BackColor = Color.LightGreen  ;
                    return true;
                }

            }
            else
            {
                MessageBox.Show(f.Message, "doSpeechTextValidation - Error");
                return false;
            }
        }

    }
}
