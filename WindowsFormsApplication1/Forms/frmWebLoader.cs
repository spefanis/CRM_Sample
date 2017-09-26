using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleComparer.Forms
{
    public partial class frmWebLoader : Form
    {
        string _website = "";
        string _username = "";
        string _password = "";
        public frmWebLoader(string website, string username, string password)
        {
            InitializeComponent();
            _website = website;
            _username = username;
            _password = password;


        }


        private void frmWebLoader_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Navigate to the passed site
            _webBrowser.Navigate(_website);

            //Check if website is facebook, if it is do the required commands
            if (_website.ToLower().Contains("facebook"))
            {
                loadFacebook();
            }
            else
            {
                MessageBox.Show("No custom command has been configured for " + _website + Environment.NewLine + "Username: " + _username + Environment.NewLine + "Pasword: " + _password, "Loggin into site");
            }

            this.Cursor = Cursors.Default;
        }


        //If the site is Facebook, load and enter the username/password into the fields. this code was found on StackOverFlow and adapted for use
        //INPUT:
        //OUPUT:
        private void loadFacebook()
        {
            MessageBox.Show("Logging into Facebook" + Environment.NewLine + "Username: " + _username + Environment.NewLine + "Pasword: " + _password, "Loggin into site");
            // wait a little
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }


            HtmlElement temp = null;

            // while we find an element by id named email
            while (temp == null)
            {
                temp = _webBrowser.Document.GetElementById("email");
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            // once we find it place the value
            temp.SetAttribute("value", _username);
            temp = null;

            // wiat till element with id pass exists
            while (temp == null)
            {
                temp = _webBrowser.Document.GetElementById("pass");
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            // once it exist set it value equal to passowrd
            temp.SetAttribute("value", _password);

            // if you already found the last fields the button should also be there...
                        var inputs = _webBrowser.Document.GetElementsByTagName("input");

            int counter = 0;
            bool enableClick = false;

            // iterate through all the inputs in the document
            foreach (HtmlElement btn in inputs)
            {

                try
                {
                    var att = btn.GetAttribute("tabindex");
                    var name = btn.GetAttribute("id");

                    if (enableClick)// button to submit always has a differnt id. it should be after password textbox
                    {
                        btn.InvokeMember("click");
                        counter++;
                    }

                    if (name.ToUpper().Contains("PASS") || att == "4")
                    {
                        enableClick = true;  // button should be next to the password input                    
                    }

                    // try a max of 5 times
                    if (counter > 5)
                        break;
                }
                catch
                {

                }
            }
        }

    }
}

