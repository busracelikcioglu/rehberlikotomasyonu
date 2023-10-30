using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;

namespace rehberlik
{
    class ogrencigiris
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rehberlik"].ConnectionString);
        SqlConnection connection = new SqlConnection(@"Data source= .\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=true");
        SqlCommand command;
        SqlDataReader reader;

        public void girisYap(string ad,string sifre, Form frm1)
        {
            command = new SqlCommand("select * from ogrenci_kayit where isim='" + ad + "'and sifre='" + sifre + "'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Başarılı", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form16 frm16 = new Form16();
                frm1.Hide();
                frm16.ShowDialog();
                Application.Exit();
            }
            else
            {
                frm1.BackColor = Color.AliceBlue;
                MessageBox.Show("Hatalı Giriş Yaptınız!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frm1.BackColor = Color.DarkGray;
            }
            connection.Close();
            command.Dispose();
        }
        public SqlDataReader veligirisyap(TextBox veliisim, TextBox velisifre) 
        {
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select*from veli_kayit where isim='" + veliisim.Text + "'";
            reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                if (velisifre.Text == reader["velisifre"].ToString())
                {
                    MessageBox.Show("Başarıyla giriş yapıldı");
                    Form12 frm12 = new Form12();
                    frm12.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Şifreniz yanlış lütfen kontrol ediniz.");
                }
            }
            else if (veliisim.Text == "" || velisifre.Text == "") { MessageBox.Show("veli ismi veya şifresi boş geçilemez."); }
            else
            {
                MessageBox.Show("Bilgileriniz yanlış lütfen kontrol ediniz.");
            }
            connection.Close();
            return reader;
        }
        public SqlDataReader ogretmengirisyap(TextBox ogretmenadisoyadi,TextBox sifre)
        {
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select*from ogretmen_kayit where ogretmenadisoyadi='" + ogretmenadisoyadi.Text + "'";
            reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                if (sifre.Text == reader["sifre"].ToString())
                {
                    MessageBox.Show("Başarıyla giriş yapıldı");
                    Form15 frm15 = new Form15();
                    frm15.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Şifreniz yanlış lütfen kontrol ediniz.");
                }
            }
            else if (ogretmenadisoyadi.Text == "" || sifre.Text == "") { MessageBox.Show("öğretmen ismi veya şifresi boş geçilemez."); }
            else
            {
                MessageBox.Show("Bilgileriniz yanlış lütfen kontrol ediniz.");
            }
            connection.Close();
            return reader;
        }
        public SqlDataReader admingirisyap(TextBox kullaniciadi, TextBox sifre)
        {
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select*from admin where kullaniciadi='" + kullaniciadi.Text + "'";
            reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                if (sifre.Text == reader["sifre"].ToString())
                {
                    MessageBox.Show("Başarıyla giriş yapıldı");
                    Form2 frm2 = new Form2();
                    frm2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Şifreniz yanlış lütfen kontrol ediniz.");
                }
            }
            else if (kullaniciadi.Text == "" || kullaniciadi.Text == "") { MessageBox.Show("kullanıcı adı veya şifresi boş geçilemez."); }
            else
            {
                MessageBox.Show("Bilgileriniz yanlış lütfen kontrol ediniz.");
            }
            connection.Close();
            return reader;
        }
    }


}
