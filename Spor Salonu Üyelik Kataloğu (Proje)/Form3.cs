using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spor_Salonu_Üyelik_Kataloğu__Proje_
{
    public partial class Form3: Form
    {
        public Form3(string isim, string soyisim, string paket)
        {
            InitializeComponent();
            label4.Text = isim + " ";
            label5.Text = soyisim + " ";
            label6.Text = paket + " ";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
