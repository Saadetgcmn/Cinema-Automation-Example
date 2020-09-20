using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SİNEMA_BİLETİ_SATIŞ
{
    public partial class giris_form : Form
    {
        public giris_form()
        {
            InitializeComponent();
        }


        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sinema_otomasyonu.accdb");
       
       
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            string yol = Application.StartupPath + "\\perde.jpg";
            BackgroundImage = Image.FromFile(yol);
            
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new grsyenifilmekle();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select count(*) from kullanici_giris where kullanici_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'",baglanti);
            int deger = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            string k_adi = Convert.ToString(textBox1.Text);
            string sifre = Convert.ToString(textBox2.Text);
           
            if (k_adi == "" && sifre == "")
            {
                MessageBox.Show("Kullanıcı adı ve Şifre giriniz.");
            }

            else if (k_adi == "")
            {
                MessageBox.Show("Lütfen Kullanıcı adı giriniz.");
            }
            else if (sifre == "")
            {
                MessageBox.Show("Lütfen Şifre Giriniz");
            }

            else if (deger==0)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.Lütfen tekrar deneyin.");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Giriş Yapılmıştır.");
                Form frm2 = new filmsec();
                frm2.Show();
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox2;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = button1;
            }
        }
    }
}
