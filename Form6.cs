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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data source=.\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=true");
        public DataTable ogrenciad()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * from veli_kayit ", connection);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            connection.Close();
            return tbl;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = ogrenciad();
            comboBox1.DisplayMember = "isim";
            comboBox1.ValueMember = "id";
            this.BackColor = Properties.Settings.Default.FormBackground;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int veli = Convert.ToInt32(comboBox1.SelectedValue);
            string tarih = Convert.ToString(dateTimePicker1.Value);
            try
            {
                connection.Open();
                SqlCommand gorus = new SqlCommand("insert into gorusmeveli(gorusme,tarih,konu,ogr_id) VALUES(@gorusme,@tarih,@konu,@ogr_id)", connection);
                gorus.Parameters.AddWithValue("@ogr_id", veli);
                gorus.Parameters.AddWithValue("@tarih", tarih);
                gorus.Parameters.AddWithValue("@gorusme", textBox1.Text.Trim());
                gorus.Parameters.AddWithValue("@konu",textBox4.Text.Trim());
                gorus.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Başarılı.");
            }
            catch
            {
                MessageBox.Show("Kayıt başarısız.");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
