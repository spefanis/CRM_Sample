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
    public partial class frmSentenceGenerationTest : Form
    {
        public frmSentenceGenerationTest()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sentenceGenerator s = new sentenceGenerator();
            textBox1.Text = ("This will build a random sentance based on format: Article adjective nound verb preposition " + Environment.NewLine + " - " + s.generateRandomSentence());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sentenceGenerator s = new sentenceGenerator();
            textBox1.Text = ("This load a random paragraph from the file" + Environment.NewLine + " - " + s.RandomParagraph());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sentenceGenerator s = new sentenceGenerator();
            textBox1.Text = ("This will build a random sentance from the file: " + Environment.NewLine + " - " + s.RandomSentence());
        }

        private void frmSentenceGenerationTest_Load(object sender, EventArgs e)
        {

        }
    }
}
