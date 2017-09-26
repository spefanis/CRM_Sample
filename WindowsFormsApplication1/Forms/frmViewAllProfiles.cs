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
    public partial class frmViewAllProfiles : Form
    {
        public frmViewAllProfiles()
        {
            InitializeComponent();
        }

        private async void frmViewAllProfiles_Load(object sender, EventArgs e)
        {
            //this loads all profiles on the MS server for viewing. Only realy needed for testing
            projectOxfordSpeaker s = new projectOxfordSpeaker();
            DataTable dt = await s.UpdateAllSpeakers();
            dataGridView1.DataSource = dt;
        }
    }
}
