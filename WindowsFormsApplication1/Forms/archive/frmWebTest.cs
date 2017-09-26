using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleComparer
{
    public partial class frmWebTest : Form
    {
        public frmWebTest()
        {
            InitializeComponent();
        }

        private void frmWebTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = "email";
            string password = "password";

            // navigate to facebook
           // webBrowser1.Navigate(@"http://www.facebook.com/");

            webBrowser1.Navigate(@"youtube.com/signin");

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
                temp = webBrowser1.Document.GetElementById("email");
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            // once we find it place the value
            temp.SetAttribute("value", email);


            temp = null;
            // wiat till element with id pass exists
            while (temp == null)
            {
                temp = webBrowser1.Document.GetElementById("pass");
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }
            // once it exist set it value equal to passowrd
            temp.SetAttribute("value", password);

            // if you already found the last fields the button should also be there...

            var inputs = webBrowser1.Document.GetElementsByTagName("input");

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
