using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace rehberlik
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            comboBox1.DataSource = a.ogrenciad();
            comboBox1.DisplayMember = "ogretmenadisoyadi";
            comboBox1.ValueMember = "id";
            this.BackColor = Properties.Settings.Default.FormBackground;

        }
       
        SqlConnection baglanti = new SqlConnection("Data Source=.SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=True");
        public DataTable gorusme()
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select ogretmenadisoyadi,gorusme,tarih,konu,ogrt_id from gorusmeogretmen where ogrt_id='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            baglanti.Close();
            return tbl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = gorusme();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("delete from gorusmeogretmen where ogrt_id='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            baglanti.Close();
        }
    }
}
