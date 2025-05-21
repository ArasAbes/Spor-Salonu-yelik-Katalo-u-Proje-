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
using System.IO;

namespace Spor_Salonu_Üyelik_Kataloğu__Proje_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 kayitol = new Form2();
            kayitol.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            string sifre = textBox1.Text;


            using (SQLiteConnection conn = new SQLiteConnection("Data Source = üyelik.db"))
            {
                conn.Open();
                string query = "SELECT * FROM MUSTERILER WHERE Mail =@Mail AND Sifre=@Sifre";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mail", email);
                cmd.Parameters.AddWithValue("@Sifre", sifre);

                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string isim = reader["Isim"].ToString();
                    string soyisim = reader["Soyisim"].ToString();
                    string paket = reader["Paket"].ToString();

                    Form3 form3 = new Form3(isim, soyisim, paket);
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }
            }
        }
    }
}
