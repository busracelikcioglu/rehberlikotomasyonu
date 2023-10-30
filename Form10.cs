using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rehberlik
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18();
            form18.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            form20.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();
            form23.Show();
        }
    }
}
