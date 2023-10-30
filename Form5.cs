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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data source=.\SQLEXPRESS;Initial Catalog=sınıf;Integrated Security=true");
        public DataTable ogrenciad() 
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * from ogrenci_kayit ",connection);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            connection.Close();
            return tbl;
        
        }
        private void Form5_Load(object sender, EventArgs e)
        {

            this.BackColor = Properties.Settings.Default.FormBackground;

            comboBox1.DataSource =ogrenciad();
            comboBox1.DisplayMember = "isim";
            comboBox1.ValueMember ="ogrencino";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ogrid = Convert.ToInt32(comboBox1.SelectedValue);
            string tarih =Convert.ToString(dateTimePicker1.Value);

            try
            {

                string str = "";
                
                if(checkedListBox1.CheckedItems.Count>0)
                {
                    for(int i=0; i<checkedListBox1.CheckedItems.Count; i++)
                    {
                        if(str=="" )
                        {
                            str = checkedListBox1.CheckedItems[i].ToString();
                        }
                        else
                        {
                            str += "," + checkedListBox1.CheckedItems[i].ToString();

                        }
                    }

                    connection.Open();
                    SqlCommand gorus = new SqlCommand("insert into gorusmeogrenci(ogrid,gorusme,tarih,konu,Items) VALUES(@ogrid,@gorusme,@tarih,@konu,@Items)", connection);
                    gorus.Parameters.AddWithValue("ogrid", ogrid);
                    gorus.Parameters.AddWithValue("tarih", tarih);
                    gorus.Parameters.AddWithValue("gorusme", textBox1.Text.Trim());
                    gorus.Parameters.AddWithValue("konu", richTextBox1.Text.Trim());
                    gorus.Parameters.AddWithValue("Items", str);
                    gorus.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Başarılı.");
                }
                else
                {
                    MessageBox.Show("checkbox seçilmedi");
                }
            }
            
            catch 
            {
                MessageBox.Show("Kayıt başarısız.");
            
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ekler_Enter(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Form2 frm2 = new Form2();
            frm2.Hide();
        }

      
    }
}
