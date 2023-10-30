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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string sifre = textBox2.Text;
            ogrencigiris islem = new ogrencigiris();
            islem.girisYap(isim,sifre,this);
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();
            form17.Show();

        }
    }
}
