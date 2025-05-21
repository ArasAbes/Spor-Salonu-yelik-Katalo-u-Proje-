using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spor_Salonu_Üyelik_Kataloğu__Proje_
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string veritabani = "üyelik.db";
            if (!File.Exists(veritabani)) { 
                SQLiteConnection.CreateFile(veritabani);
                using (var conn = new SQLiteConnection("Data Source=üyelik.db")) { 
                    conn.Open();
                    string sql = @"CREATE TABLE MUSTERILER(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Isim TEXT,
                        Soyisim TEXT,
                        Mail TEXT,
                        Sifre TEXT,
                        Paket TEXT
                        );";
                    SQLiteCommand cmd=new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
