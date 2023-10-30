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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        
        private void Form11_Load(object sender, EventArgs e)
        {
          

        }
        private void Form11_Load_1(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            comboBox1.DataSource = a.ogrenciad();
            comboBox1.DisplayMember = "isim";
            comboBox1.ValueMember = "ogrencino";
            this.BackColor = Properties.Settings.Default.FormBackground;

        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=True ");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tablo = new DataTable();
        private void button4_Click(object sender, EventArgs e)
        {
            int secilenid = Convert.ToInt32(comboBox1.SelectedValue);
            try
            {
                baglanti.Open();
                SqlCommand guncel = new SqlCommand("UPDATE ogrenci_kayit SET sinif='" + textBox1.Text + "', telefon='" + textBox8.Text + "' , sifre='" + textBox12.Text + "' where ogrencino='" + secilenid + "' ", baglanti);
                guncel.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Başarılı.");
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Başarısız.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilenid = Convert.ToInt32(comboBox1.SelectedValue);
            try
            {
                baglanti.Open();
                SqlCommand komutlar = new SqlCommand("DELETE from ogrenci_kayit where ogrencino='" + secilenid + "'", baglanti);
                komutlar.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi başarılı.");
            }
            catch { MessageBox.Show("Silme başarısız."); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ogrenci_kayit", baglanti);
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adapter.Dispose();
            baglanti.Close();
            dataGridView1.Columns[0].HeaderText = "öğrenci no";
            dataGridView1.Columns[1].HeaderText = "isim";
            dataGridView1.Columns[2].HeaderText = "soyisim";
            dataGridView1.Columns[3].HeaderText = "sınıf";
            dataGridView1.Columns[4].HeaderText = "tcno";
            dataGridView1.Columns[5].HeaderText = "telefon";
            dataGridView1.Columns[6].HeaderText = "şifre";
            dataGridView1.Columns[7].HeaderText = "doğum yılı";
            dataGridView1.Columns[8].HeaderText = " cinsiyeti";
            dataGridView1.Columns[9].HeaderText = "doğum yeri";
        }
    }
    
}
