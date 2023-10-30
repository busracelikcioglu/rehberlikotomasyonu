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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            comboBox1.DataSource =a.ogrenciad();
            comboBox1.DisplayMember = "isim";
            comboBox1.ValueMember = "ogrencino";
            this.BackColor = Properties.Settings.Default.FormBackground;
            

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP=.\\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=True ");
        public DataTable gorusme() 
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select ogrid,gorusme,tarih,konu from gorusmeogrenci where ogrid='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            baglanti.Close();
            return tbl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =gorusme();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("delete from gorusmeogrenci where ogrid='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            MessageBox.Show("Silme işlemi başarılı");
            baglanti.Close();
           

        }
    }
}