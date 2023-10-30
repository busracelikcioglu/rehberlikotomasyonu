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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            form19.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Form2 frm2 = new Form2();
            frm2.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }
    }
}
