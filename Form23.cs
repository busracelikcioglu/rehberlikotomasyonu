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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            comboBox1.DataSource = a.ogrenciad();
            comboBox1.DisplayMember = "ogretmenadisoyadi";
            comboBox1.ValueMember = "id";
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
                SqlCommand guncel = new SqlCommand("UPDATE ogretmen_kayit SET ogretmenbransi='" + textBox1.Text + "', telefon='" + textBox8.Text + "' , sifre='" + textBox12.Text + "' where id='" + secilenid + "' ", baglanti);
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
                SqlCommand komutlar = new SqlCommand("DELETE from ogretmen_kayit where id='" + secilenid + "'", baglanti);
                komutlar.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi başarılı.");
            }
            catch { MessageBox.Show("Silme başarısız."); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ogretmen_kayit", baglanti);
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adapter.Dispose();
            baglanti.Close();
            dataGridView1.Columns[0].HeaderText = "isim";
            dataGridView1.Columns[1].HeaderText = "soyisim";
            dataGridView1.Columns[2].HeaderText = "telefon";
            dataGridView1.Columns[3].HeaderText = "öğrenci numarası";
        }
    }
}
