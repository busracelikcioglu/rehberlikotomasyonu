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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            this.BackColor = Properties.Settings.Default.FormBackground;

            Form6 a = new Form6();
            comboBox1.DataSource = a.ogrenciad();
            comboBox1.DisplayMember = "isim";
            comboBox1.ValueMember = "id";
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=True ");
        public DataTable gorusme()
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select gorusme,tarih,konu,ogr_id from gorusmeveli where ogr_id='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            baglanti.Close();
            return tbl;
        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gorusme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilen = Convert.ToInt32(comboBox1.SelectedValue);
            baglanti.Open();
            SqlCommand listele = new SqlCommand("delete gorusmeveli from gorusmeveli where ogr_id='" + secilen + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(listele);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            MessageBox.Show("Silme işlemi başarılı");
            baglanti.Close();
            
        }
    }
}
