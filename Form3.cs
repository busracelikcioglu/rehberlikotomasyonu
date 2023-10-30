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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.FormBackground;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            
            comboBox2.DataSource = a.ogrenciad();
            comboBox2.DisplayMember = "isim";
            comboBox2.ValueMember = "ogrencino";

            this.BackColor = Properties.Settings.Default.FormBackground;

        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP=.\\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=True ");
        //SqlDataReader oku;

        private void button1_Click(object sender, EventArgs e)
        {

                
            if (textBox2.Text != "" && textBox7.Text!="")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into ogrenci_kayit(isim,soyisim,sinif,tcno,telefon,sifre,dogumyili,cinsiyeti,dogumyeri) " +
                        "values (@isim,@soyisim,@sinif,@tcno,@telefon,@sifre,@dogumyili,@cinsiyeti,@dogumyeri)", baglanti);
                    komut.Parameters.AddWithValue("isim", textBox2.Text);
                    komut.Parameters.AddWithValue("soyisim", textBox3.Text);
                    komut.Parameters.AddWithValue("sinif", textBox4.Text);
                    komut.Parameters.AddWithValue("tcno", textBox5.Text);
                    komut.Parameters.AddWithValue("telefon", textBox6.Text);
                    komut.Parameters.AddWithValue("sifre", textBox7.Text);
                    komut.Parameters.AddWithValue("dogumyili", textBox13.Text);
                    komut.Parameters.AddWithValue("cinsiyeti", textBox14.Text);
                    komut.Parameters.AddWithValue("dogumyeri", textBox15.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarılı");
                }
                catch
                {
                    MessageBox.Show("Başarısız kayıt.");
                }
            }
            else { MessageBox.Show("İsim ve şifre  boş bırakılamaz."); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "") { MessageBox.Show("isim boş geçilemez!"); }
            else if (textBox10.Text == "") { MessageBox.Show("soyisim boş geçilemez!"); }
            else if (textBox9.Text == "") { MessageBox.Show("telefon boş geçilemez!"); }
            else
            {

                try
                {
                    int ogrencino = Convert.ToInt32(comboBox2.SelectedValue);
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into veli_kayit(isim,soyisim,telefon,ogrencinumarasi,velisifre) " +
                            "values (@isim,@soyisim,@telefon,@ogrencinumarasi,@velisifre)", baglanti);
                    komut.Parameters.AddWithValue("isim", textBox11.Text);
                    komut.Parameters.AddWithValue("soyisim", textBox10.Text);
                    komut.Parameters.AddWithValue("telefon", textBox9.Text);
                    komut.Parameters.AddWithValue("ogrencinumarasi", textBox5.Text);
                    komut.Parameters.AddWithValue("velisifre", textBox1.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarılı");
                }
                catch
                {
                    MessageBox.Show("Hatalı kayıt girdiniz");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

      
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            if (textBox21.Text != "" && textBox19.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into ogretmen_kayit(ogretmenadisoyadi,ogretmenbransi,sifre,telefon,tcno) " +
                        "values (@ogretmenadisoyadi,@ogretmenbransi,@sifre,@telefon,@tcno)", baglanti);
                    komut.Parameters.AddWithValue("ogretmenadisoyadi", textBox21.Text);
                    komut.Parameters.AddWithValue("ogretmenbransi", textBox20.Text);
                    komut.Parameters.AddWithValue("sifre", textBox19.Text);
                    komut.Parameters.AddWithValue("telefon", textBox17.Text);
                    komut.Parameters.AddWithValue("tcno", textBox16.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarılı");
                }
                catch
                {
                    MessageBox.Show("Başarısız kayıt.");
                }
            }
            else { MessageBox.Show("öğretmen adı ve şifre  boş bırakılamaz."); }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

