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

namespace SampleComparer
{
    public partial class frmEncryptionTest : Form
    {
        public frmEncryptionTest()
        {

            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptionDecrypt encrypt = new EncryptionDecrypt();
            txtDestination.Text = encrypt.EncryptString (txtSource.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            EncryptionDecrypt decrypt = new EncryptionDecrypt();
            txtDestination.Text = decrypt.Decrypt(txtSource.Text);
        }
    }
}
