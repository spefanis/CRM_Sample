using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleComparer.Classes;
using System.IO;

using System.Speech.Recognition;

namespace SampleComparer.Forms
{
    public partial class ucUserScreen : UserControl
    {
        int _userID;
        string _userName;
        string _profileID;

        Stream audioStream1;

        public ucUserScreen(int UserID, string UserName, string ProfileID)
        {
            InitializeComponent();
            _userID = UserID;
            _userName = UserName;
            _profileID = ProfileID;
            lblLoggedInAs .Text = "Logged in as " + _userName;
        }

        private void ucUserScreen_Load(object sender, EventArgs e)
        {
            LoadLogins();
        }
        private void btnLogOff_Click(object sender, EventArgs e)
        {
            //Cause the user to logoff by calling a function on the parent form to remove permissions
            ((frmStartup)this.ParentForm).setValidUser(false);
        }

        //This will load the logins for the passed user
        //INPUT:
        //OUPUT:
        private void LoadLogins()
        {
            this.Cursor = Cursors.WaitCursor;
            Database db = new Database();
            List<UserLogin> logins = db.getLoginList(_userID);

            //Create a datatable with the data
            DataTable dt = db.ToDataTable(logins);
            dgvUserAccounts.DataSource = dt;
            //Format the datagridview if there are rows
            if (dgvUserAccounts.Columns.Count > 0)
            {
                dgvUserAccounts.Columns["AccountID"].Visible = false;
                dgvUserAccounts.Columns["UserID"].Visible = false;
                dgvUserAccounts.Columns["password"].Visible = false;
                dgvUserAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUserAccounts.Columns["SiteKey"].HeaderText = "Site Keyword";
            }

            this.Cursor = Cursors.Default ;

        }

        private void btnAddLogin_Click(object sender, EventArgs e)
        {
            frmAddEditLogin f = new frmAddEditLogin();
            f.public_userID = _userID;
            f.public_isNew = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadLogins();
            }

        }

        //When we double click on a cell, we open the "Edit" functionality of the AddEditLogin
        private void dgvUserAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get the selected row
            int selectedrowindex = dgvUserAccounts.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvUserAccounts.Rows[selectedrowindex];

            frmAddEditLogin f = new frmAddEditLogin();
            f.public_userID = _userID;
            f.public_isNew = false;
            f.public_AccountID = Convert.ToInt32(selectedRow.Cells["AccountID"].Value.ToString());
            //If we get an "OK" on the edit, refresh the data
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadLogins();
            }
        }

        private void btnRemoveLogin_Click(object sender, EventArgs e)
        {
            //Get the selected row
            int selectedrowindex = dgvUserAccounts.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvUserAccounts.Rows[selectedrowindex];
            //Get the information about the selected row
            int AccountID = Convert.ToInt32(selectedRow.Cells["AccountID"].Value.ToString());
            string SiteKey = selectedRow.Cells["SiteKey"].Value.ToString();
            //Make sure a row is selected
            if (AccountID > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                //Ensure the user wants to delete the row
                if (MessageBox.Show("Are you sure you want to remove Account: " + SiteKey + " (" + AccountID + ") ?" + Environment.NewLine + "This will remove account and the assigned information will be lost.", "Remove Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    functionResult r = new functionResult();

                    //Next remove the user from our database
                    Database db = new Database();
                    r = db.RemoveAccountLogin(AccountID);

                    //If there is no issues, reload the listing
                    if (r.Result == true)
                    {
                        LoadLogins();
                    }
                    else
                    {
                        MessageBox.Show(r.Message, "Error removing from database");
                    }

                }

                this.Cursor = Cursors.Default;
            }
        }
        
        private void btnSpeakCommand_Click(object sender, EventArgs e)
        {

            //create the audio capture functionality and start recording
            audioCapture a = new audioCapture();
            functionResult r = a.onRecord(ref audioStream1);
            if (r.Result == true)
            {
                //If there are no errors. Set the lable text and button enable/disable.
                //also start the timer
                txtTextRecognises.Text = "Please say your command:";
                timerClock.Start();
                btnStartCommand.Enabled = false;
                btnStopCommand.Enabled = true;
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

        private void btnStopCommand_Click(object sender, EventArgs e)
        {
            stopRecording();
        }

        //This stops the recording functionality and does the speack to text convertion
        //INPUT:
        //OUTPUT:
        private void stopRecording()
        {
            //Stop the timer
            timerClock.Stop();


            //stop recordinmg from the microphone
            audioCapture a = new audioCapture();
            a.OnRecordingStopped(null, null);

            //Enable/Disable the buttons as required
            btnStartCommand.Enabled = true;
            btnStopCommand.Enabled = false;

            //Show the length of the sample for the user to see
            double sampleLength = (audioCapture.recordingEnded - audioCapture.recordingStarted).TotalMilliseconds * 0.001;
            lblRecordingLength.Text = Math.Round(sampleLength, 2).ToString();
            //If the sample lenght is greater than 2.5 seconds

            if (doSpeechTextValidation())
            {
                string sitekey = "";
                string username = "";
                string website = "";
                string encryptedPass = "";
                bool keyFound = false;


                //If we find a valid login, then find the matching website and login credientials
                foreach (DataGridViewRow dr in dgvUserAccounts.Rows)
                {
                    sitekey = dr.Cells["SiteKey"].Value.ToString();
                    username = dr.Cells["username"].Value.ToString();
                    website = dr.Cells["website"].Value.ToString();
                    encryptedPass = dr.Cells["password"].Value.ToString();
                    if (txtTextRecognises.Text.ToLower().Contains(sitekey.ToLower()))
                    {
                        keyFound = true;
                        break;
                    }
                }
                if (keyFound)
                {
                    EncryptionDecrypt ende = new EncryptionDecrypt();
                    frmWebLoader f = new frmWebLoader(website, username, ende.Decrypt(encryptedPass));
                    f.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Unable to find matching logon details for the command spoken");
                }
            }
            else
            {
                MessageBox.Show("Do Nothing here");

            }

        }


        //This will do the speech validation functionality
        //INPUT:
        //OUPUT: true for valid command found
        private Boolean doSpeechTextValidation()
        {
            speechRecognition_system_speech ps = new speechRecognition_system_speech();

            Choices c = new Choices();
            //Now build a list of choices
            foreach (DataGridViewRow dr in dgvUserAccounts.Rows)
            {
                string keyword = dr.Cells["SiteKey"].Value.ToString();
                //Generate a list of available commands
                c.Add("Open " + keyword);
            }



            functionResult f = ps.convertToSpeechwithChoices(audioStream1, c);
            if (f.Result == true)
            {
                if (f.recognitionResult == null)
                {
                    txtTextRecognises.Text = "No Valid Phrase Found, Please try again ensuring to speak slowly and clearly";
                    return false;

                }
                else
                {
                    txtTextRecognises.Text = f.recognitionResult.Text + " (Result Confidence = " + f.recognitionResult.Confidence + ")";
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

