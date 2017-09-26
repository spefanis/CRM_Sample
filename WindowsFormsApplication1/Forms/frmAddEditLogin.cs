using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleComparer.Classes;

namespace SampleComparer.Forms
{
    public partial class frmAddEditLogin : Form
    {
        public int public_userID { get; set; }
        public bool public_isNew { get; set; }
        public int public_AccountID { get; set; }

        public frmAddEditLogin()
        {
            InitializeComponent();
        }

        private void frmAddLogin_Load(object sender, EventArgs e)
        {

            //If it's a new login, change the text so it looks better
            if (public_isNew == true)
            {
                btnAddLogin.Text = "Add";
            }
            else
            {
                //Load the details for the Logon from the database
                Database db = new Database();
                List<UserLogin> logins = db.getSpecificLogin(public_AccountID);
                if (logins.Count >= 1)
                {
                    txtSiteKey.Text = logins[0].SiteKey;
                    txtUserName.Text = logins[0].username;
                    EncryptionDecrypt ende = new EncryptionDecrypt();
                    txtPassword.Text = ende.Decrypt(logins[0].password);
                    txtWebsite.Text = logins[0].website;
                }
                this.Text = "Edit Login";
                btnAddLogin.Text = "Update";
            }
        }


        
        private void btnAddLogin_Click(object sender, EventArgs e)
        {
            //Validate the data
            if (ValidateData() == true)
            {
                //Combine all the values into a single variable
                UserLogin l = new UserLogin();
                l.UserID = public_userID;
                l.SiteKey = txtSiteKey.Text;
                l.username = txtUserName.Text;
                l.password = txtPassword.Text;
                l.website = txtWebsite.Text;
                //Write the user logon
                Database db = new Database();
                functionResult result;
                if (public_isNew == true)
                {
                    l.AccountID = 0;
                    result = db.AddAccountLogin(l);
                }
                else
                {
                    l.AccountID = public_AccountID;
                    result = db.UpdateAccountLogin(l);
                }

                if (result.Result == true)
                {

                    this.DialogResult = DialogResult.OK;
                }

                else
                {
                    //If there are errors. display the message
                    MessageBox.Show(result.Message, "Add Login for user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //This will ensure valid data is entered before continuing
        private bool ValidateData()
        {
            bool returnVal = true;

            //Reset Background Colors
            txtSiteKey.BackColor = Color.White;
            txtUserName.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            txtWebsite.BackColor = Color.White;

            if (txtSiteKey.Text.Length == 0)
            {
                txtSiteKey.BackColor = Color.Salmon;
                returnVal = false;
            }
            if (txtUserName.Text.Length == 0)
            {
                txtUserName.BackColor = Color.Salmon;
                returnVal = false;
            }
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.BackColor = Color.Salmon;
                returnVal = false;
            }
            if (txtWebsite.Text.Length == 0)
            {
                txtWebsite.BackColor = Color.Salmon;
                returnVal = false;
            }

            return returnVal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
