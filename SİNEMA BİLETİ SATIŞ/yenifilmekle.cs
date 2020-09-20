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
    public partial class yenifilmekle : Form
    {
        public yenifilmekle()
        {
            InitializeComponent();
        }

        private void yenifilmekle_Load(object sender, EventArgs e)
        {
            string yol = Application.StartupPath + "\\kamera.png";
            pictureBox1.Image = Image.FromFile(yol);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == null || textBox3.Text == null || textBox2.Text == null || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox4.Text == null)
            {
                MessageBox.Show("Lütfen Eksiksiz Bilgi Giriniz.");
            }
            else
            {
               
                giris_form.baglanti.Open();
                OleDbCommand komut = new OleDbCommand("INSERT INTO film_ekle (filmadi,yonetmen,tur,secenek,sure,resim) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox4.Text.ToString() + "')", giris_form.baglanti);
                komut.ExecuteNonQuery();
                giris_form.baglanti.Close();
                MessageBox.Show("Film Adı:" + textBox1.Text + " " + "Yönetmen:" + textBox3.Text + " " + "Tür:" + comboBox1.SelectedItem + " " + "Seçenek:" + comboBox2.SelectedItem + " " + "Süre:" + textBox2.Text + "dk" + " Eklenmiştir.");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox4.Text = openFileDialog1.SafeFileName;
            pictureBox2.ImageLocation = openFileDialog1.FileName;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox3;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = comboBox1;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = comboBox2;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
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
