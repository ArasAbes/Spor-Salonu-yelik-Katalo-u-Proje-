using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spor_Salonu_Üyelik_Kataloğu__Proje_
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=üyelik.db"))
            {
                conn.Open();
                string query = "INSERT INTO MUSTERILER (Isim,Soyisim,Mail,Sifre,Paket) VALUES(@Isim,@Soyisim,@Mail,@Sifre,@Paket)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Isim", textBox1.Text);
                cmd.Parameters.AddWithValue("@Soyisim", textBox2.Text);
                cmd.Parameters.AddWithValue("@Mail", textBox3.Text);
                cmd.Parameters.AddWithValue("@Sifre", textBox4.Text);
                cmd.Parameters.AddWithValue("@Paket", comboBox1.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    this.Close();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Hata :" + ex.Message);
                }



                
                
            }
        }
    }
}
