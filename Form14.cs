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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrencigiris giris = new ogrencigiris();
            giris.ogretmengirisyap(textBox1, textBox2);
            this.Hide();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }
    }
}
