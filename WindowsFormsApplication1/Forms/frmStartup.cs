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
using MetroFramework.Forms;

namespace SampleComparer.Forms
{
    public partial class frmStartup : MetroForm
    {

        DataTable userDatatable;
        Boolean userLoggedIn = false;

        public frmStartup()
        {
            InitializeComponent();
            metroPanel1.Show();
            this.BorderStyle = MetroFormBorderStyle.None;
            this.ShadowType = MetroFormShadowType.Flat;
        }

        private void frmStartup_Load(object sender, EventArgs e)
        {

            panelLogonMenu.Visible = true;
            loggedonPanel.Visible = false;
            LoadListing();
        }

        //This function loads the data from the database and assigns it to the datagird
        //INPUT:
        //OUPUT:
        private void LoadListing()
        {   //Load the users from the database
            Database db = new Database();
            List<UserRecord> users = db.getUserList();

            //Create a datatable with the required columns
            userDatatable = new DataTable();
            userDatatable.Columns.Add("ID", typeof(int));
            userDatatable.Columns.Add("NAME", typeof(String));
            userDatatable.Columns.Add("PROFILEID", typeof(String));


            //Add each of the found user records to the database
            foreach (UserRecord u in users)
            {
                userDatatable.Rows.Add(u.ID, u.NAME, u.PROFILEID);
            }

            //Format the datatable 
            mcbUserAccounts.DataSource = userDatatable;
            mcbUserAccounts.DisplayMember = "NAME";
            mcbUserAccounts.ValueMember = "ID";
            mcbUserAccounts.SelectedIndex = 0;
        }

        //As we click in the datagrid, enable/disable the button
        //private void dgvUserAccounts_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvUserAccounts.SelectedCells.Count > 0)
        //    {
        //        DataGridViewRow selectedRow = dgvUserAccounts.Rows[dgvUserAccounts.SelectedCells[0].RowIndex];
        //        //Assign the required values to variables
        //        btnLogin.Text = "Log in as " + Convert.ToString(selectedRow.Cells["NAME"].Value);
        //        btnLogin.Enabled = true;
        //    }
        //    else
        //    {
        //        btnLogin.Text = "Log in";
        //        btnLogin.Enabled = false;
        //    }
        //}

        //When we click the login button, we want to show a dialog and the result of the dialog says if the logon was successfull
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Only continue if there is a row selected
            if (mcbUserAccounts.SelectedValue != null)
            {
                //Get the actual data row
                DataRowView drv = (DataRowView)mcbUserAccounts.SelectedItem;
                //Assign the required values to variables
                string ProfileID = Convert.ToString(drv["PROFILEID"].ToString());              
                string Name = Convert.ToString(drv["NAME"].ToString());
                int ID = Convert.ToInt32(drv["ID"]);

                //Create an instance of the login form and assign the public variables
                frmLogin f = new frmLogin();
                f.public_userID = ID;
                f.public_userName = Name;
                f.public_profileID = ProfileID;

                //If there is a valid profile, then show the dialog
                if (ID > 0)
                {
                    //If we get a "OK" we know it is a valid login
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        setValidUser(true);
                        //essageBox.Show("Valid Login");
                    }
                    else
                    {
                        setValidUser(false);
                        //MessageBox.Show("invalid Login");
                    }
                }
            }
        }


        //This function will enable/disable all items based on if the user is logged in successfully or not.
        //INPUT: true/false
        //OUPUT:
        public void setValidUser(Boolean isValid)
        {
            userLoggedIn = isValid;            
            loggedonPanel.Controls.Clear();
            
           

            if (isValid == true)
            {               
                DataRowView drv = (DataRowView)mcbUserAccounts.SelectedItem;
                //Assign the required values to variables
                string ProfileID = Convert.ToString(drv["PROFILEID"].ToString());
                string Name = Convert.ToString(drv["NAME"].ToString());
                int ID = Convert.ToInt32(drv["ID"]);

                ucUserScreen uc = new ucUserScreen(ID, Name, ProfileID);
                uc.Dock = DockStyle.Fill;
                loggedonPanel.Controls.Add(uc);
                panelLogonMenu.Visible = false;
                loggedonPanel.Visible = true;
            }
            else
            {
                panelLogonMenu.Visible = true ;
                loggedonPanel.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //Decleare new instance of AddUser
            frmAddUser f = new frmAddUser();
            if (f.ShowDialog() == DialogResult.OK)
            {
                //If the user is added successfull, load the listring
                LoadListing();
            }
        }


        private async void btnRemoveUser_Click(object sender, EventArgs e)
        {
            //Make sure a row is selected
            if (mcbUserAccounts.SelectedValue != null)
            {
                this.Cursor = Cursors.WaitCursor;
                //Get the actual data row
                DataRowView drv = (DataRowView)mcbUserAccounts.SelectedItem;
                //Assign the required values to variables
                string ProfileID = Convert.ToString(drv["PROFILEID"].ToString());
                string Name = Convert.ToString(drv["NAME"].ToString());
                int ID = Convert.ToInt32(drv["ID"]);

                //Ensure the user wasnt to delete the row
                if (MessageBox.Show("Are you sure you want to remove User ID: " + ID.ToString() + "?" + Environment.NewLine + "This will remove their profile and enrollment information and cannot be reversed.", "Remove User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    functionResult r = new functionResult();
                    //If there is a valid profile ID, remove it from the server, else just set the result as true to continue                
                    if (ProfileID.Length > 0)
                    {
                        projectOxfordSpeaker s = new projectOxfordSpeaker();
                        r = await s.removeSpeaker(new Guid(ProfileID));
                    }
                    else
                    {
                        r.Result = true;
                        r.Message = "No Profile ID";
                    }

                    if (r.Result == true)
                    {
                        //Next remove the user from our database
                        Database db = new Database();
                        r = db.removeUser(ID.ToString());
                        //If there is no issues, reload the listing
                        if (r.Result == true)
                        {
                            LoadListing();
                        }
                        else
                        {
                            MessageBox.Show(r.Message, "Error removing from database");
                        }
                    }
                    else
                    {
                        MessageBox.Show(r.Message, "Error removing Microsoft profile");
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void btnViewMSProfiles_Click(object sender, EventArgs e)
        {
            frmViewAllProfiles f = new frmViewAllProfiles();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadListing();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
