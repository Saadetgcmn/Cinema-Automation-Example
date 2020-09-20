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
    public partial class filmsec : Form
    {
        public filmsec()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            giris_form.baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection= giris_form.baglanti;
            komut.CommandText = ("select * from film_ekle");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["filmadi"]);
            }
            giris_form.baglanti.Close();

        }
        public static string filmadi;
        public static string seans;
        private void button1_Click(object sender, EventArgs e)
        {
           
            
             if (comboBox1.SelectedIndex == -1 && comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Film ve Seans seçiniz.");

            }
            else if (comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Lütfen Film seçiniz.");
            }
            else if (comboBox3.SelectedIndex==-1)
            {
                MessageBox.Show("Lütfen Seans seçiniz.");

            }
            
            else 
            {
                Form frm = new Rezervasyon();
                  if (ActiveForm != null)
                     {
                    filmadi = comboBox1.SelectedItem.ToString();
                    seans = comboBox3.SelectedItem.ToString();
                        ActiveForm.Close();
                     }
                  frm.Show();

                

            }
            
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 1; i <= comboBox1.Items.Count+1; i++)
            {
                if (i==comboBox1.SelectedIndex+1)
                {    giris_form.baglanti.Open();
                     OleDbCommand komut = new OleDbCommand("Select * from film_ekle WHERE kimlik=" + i + "",giris_form.baglanti);
                     komut.Connection = giris_form.baglanti;
                     OleDbDataReader oku=komut.ExecuteReader();
                       while (oku.Read())
                         {
                            label9.Text = oku["filmadi"].ToString();
                            label10.Text = oku["yonetmen"].ToString();
                            label11.Text = oku["tur"].ToString();
                            label12.Text = oku["secenek"].ToString();
                            label13.Text = oku["sure"].ToString();
                            string yol = Application.StartupPath +"\\" +oku["resim"].ToString();
                            pictureBox1.Image = Image.FromFile(yol);
                        
                    }
                    giris_form.baglanti.Close();
                }
                

            }
            

              
                        
                
            
            giris_form.baglanti.Close();    
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = comboBox3;
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = button1;
            }
        }
    }
}
