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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrencigiris giris = new ogrencigiris();
            giris.veligirisyap(textBox1,textBox2);
            this.Hide();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }
    }
}
