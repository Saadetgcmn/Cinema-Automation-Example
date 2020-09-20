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
    public partial class grsyenifilmekle : Form
    {
        public grsyenifilmekle()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

            string yol = Application.StartupPath + "\\ikon.png";
            pictureBox1.Image = Image.FromFile(yol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris_form.baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select count(*) from kullanici_giris where kullanici_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", giris_form.baglanti);
            int deger = Convert.ToInt32(komut.ExecuteScalar());
            giris_form.baglanti.Close();

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
                if (ActiveForm!=null)
                {
                    ActiveForm.Close();
                }
                Form frm = new yenifilmekle();
                frm.Show();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
