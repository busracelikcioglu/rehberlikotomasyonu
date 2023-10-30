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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data source=.\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=true");
        public DataTable ogrenciad()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * from ogretmen ", connection);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            connection.Close();
            return tbl;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = ogrenciad();
            comboBox1.DisplayMember = "ogretmenadisoyadi";
            comboBox1.ValueMember = "id";
            this.BackColor = Properties.Settings.Default.FormBackground;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ogretmenadi= Convert.ToString(comboBox1.Text);
            string tarih = Convert.ToString(dateTimePicker1.Value);
            
            try
            {
                connection.Open();
                SqlCommand gorus = new SqlCommand("insert into gorusme_ogretmen(ogretmenadisoyadi,gorusme,tarih,konu,ogrt_id) " +
                    "VALUES(@ogretmenadisoyadi,@gorusme,@tarih,@konu,@ogrt_id)", connection);
                gorus.Parameters.AddWithValue("@ogretmenadisoyadi", ogretmenadi);
                gorus.Parameters.AddWithValue("@gorusme", textBox1.Text.Trim()); 
                gorus.Parameters.AddWithValue("@tarih", tarih);
                gorus.Parameters.AddWithValue("@konu", textBox4.Text.Trim());
                gorus.Parameters.AddWithValue("@ogrt_id", comboBox1.SelectedValue);
                gorus.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Başarılı.");
            }
            catch(Exception hata)
            {
                MessageBox.Show("Kayıt başarısız."+hata.Message);
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
