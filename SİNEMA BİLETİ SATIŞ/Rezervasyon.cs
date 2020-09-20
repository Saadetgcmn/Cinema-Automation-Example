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
    public partial class Rezervasyon : Form
    {
        public Rezervasyon()
        {
            InitializeComponent();
        }

        string yol = Application.StartupPath + "\\yesil.png";    //resimlerin yollarını kolaylık olsun diye globalde tanımladım
        string yol1 = Application.StartupPath + "\\kirmizi.png";
        string yol2 = Application.StartupPath + "\\gri.png";
       

        private void Form1_Load(object sender, EventArgs e)
        {
            label29.Text = filmsec.filmadi.ToString();//filmsec formunda seçilen film ve seansı rezervasyon formunda yazdırmak ve veritabanına aktarmak için
            label30.Text = filmsec.seans.ToString();

            timer1.Start(); //formdaki tarih saatin timerı 

            int x = 30, y = 30;
            int s = 11;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {                                          //butonlar dinamik oluşturulup arkaplanına uygun renkte koltuk resmi koyuldu
                    s--;
                    Button btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    x = x + 40;
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.BackgroundImage = Image.FromFile(yol);
                    btn.BackColor = Color.Green;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Font = new Font("Arial Black", 9, FontStyle.Bold);
                    btn.ForeColor = Color.Black;
                    btn.Click += tiklama;

                    switch (i)                            //koltukların hangi grupta oldugu kısmını butona yazdırmak için 
                    {

                        case 9:
                            btn.Text = "A-" + s.ToString();
                            break;
                        case 8:
                            btn.Text = "B-" + s.ToString();
                            break;
                        case 7:
                            btn.Text = "C-" + s.ToString();
                            break;
                        case 6:
                            btn.Text = "D-" + s.ToString();
                            break;
                        case 5:
                            btn.Text = "E-" + s.ToString();
                            break;
                        case 4:
                            btn.Text = "F-" + s.ToString();
                            break;
                        case 3:
                            btn.Text = "G-" + s.ToString();
                            break;
                        case 2:
                            btn.Text = "H-" + s.ToString();
                            break;
                        case 1:
                            btn.Text = "I-" + s.ToString();
                            break;
                        case 0:
                            btn.Text = "J-" + s.ToString();
                            break;
                    }
                }
                x = 40;
                y = y + 40;
                s = 11;
            }
            giris_form.baglanti.Open();
            OleDbCommand komut =new OleDbCommand();
            komut.Connection = giris_form.baglanti;
            komut.CommandText = ("SELECT * FROM koltuk_sec where filmadi like '" + label29.Text + "'and seans like'" + label30.Text + "%'");
            OleDbDataReader oku = komut.ExecuteReader();
           

             while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["filmadi"].ToString();
                ekle.SubItems.Add(oku["seans"].ToString());
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["k1"].ToString());
                ekle.SubItems.Add(oku["k2"].ToString());
                ekle.SubItems.Add(oku["k3"].ToString());
                ekle.SubItems.Add(oku["k4"].ToString());
                ekle.SubItems.Add(oku["k5"].ToString());
                ekle.SubItems.Add(oku["tutar"].ToString());

                listView1.Items.Add(ekle);    
            }
             giris_form.baglanti.Close();
            foreach (System.Windows.Forms.Button buton in this.flowLayoutPanel1.Controls)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j<10; j++)
                    {if (buton is System.Windows.Forms.Button && buton.Text == listView1.Items[i].SubItems[j].Text)
                        {
                           buton.BackColor = Color.Red;
                           buton.BackgroundImage = Image.FromFile(yol1);
                           buton.Enabled = false;

                        }

                    }

                }
               
            }

            button9.BackgroundImage = Image.FromFile(yol);        
            button10.BackgroundImage = Image.FromFile(yol1);
            button11.BackgroundImage = Image.FromFile(yol2);

        }
      
        private void tiklama(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor==Color.Green)
               {
               (sender as Button).BackColor = Color.Gray;                     //tek tıklamada koltukları griyse yeşil yeşilse gri yapmak için
               (sender as Button).BackgroundImage = Image.FromFile(yol2);
               (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                listBox1.Items.Add((sender as Button).Text);
                
               }
         
           else if ((sender as Button).BackColor == Color.Gray)
            {
                (sender as Button).BackColor = Color.Green;
                (sender as Button).BackgroundImage = Image.FromFile(yol);
                (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                listBox1.Items.Remove((sender as Button).Text);
                

            }
            else if ((sender as Button).BackColor==Color.Red)
            {
                listBox2.Items.Add((sender as Button).Text);

            }
            if (listBox1.Items.Count==6)
                    {
                       listBox1.Items.Remove((sender as Button).Text);
                       (sender as Button).BackColor = Color.Green;
                       (sender as Button).BackgroundImage = Image.FromFile(yol);
                       (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                       MessageBox.Show("En fazla 5 koltuk seçebilirsiniz.");
                    }
        }
        
     
        int a, b,c;
        private void button4_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            c = Convert.ToInt32(textBox3.Text);
            if (a == 5)
            {
                a = 5;
            }
            else if (a <= 5)
            {
                a++;
                textBox1.Text = a.ToString();
                textBox3.Text = (c +10).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b = Convert.ToInt32(textBox2.Text);
            c = Convert.ToInt32(textBox3.Text);
            if (b > 0)
            {
                b--;
                textBox2.Text = b.ToString();
                textBox3.Text = (c -8).ToString();

            }
            else if (b == 0)
            {
                b = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            b = Convert.ToInt32(textBox2.Text);
            c = Convert.ToInt32(textBox3.Text);
            if (b == 5)
            {
                b = 5;
            }
            else if (b<= 5)
            {
                b++;
                textBox2.Text = b.ToString();
                textBox3.Text = (c +8).ToString();

            }
        } private void button3_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            c = Convert.ToInt32(textBox3.Text);
            if (a > 0)
            {
                a--;
                textBox1.Text = a.ToString();
                textBox3.Text = (c-10).ToString();
            }
            else if (a == 0)
            {
                a = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            Form frm =new filmsec();        //bi önceki forma dönüyor
            frm.Show();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox6;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = button7;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            
            foreach (System.Windows.Forms.Button buton in this.flowLayoutPanel1.Controls)
            {
                for (int i = 4; i <9; i++)
                {
                    if (buton is System.Windows.Forms.Button && buton.Text == listView1.SelectedItems[0].SubItems[i].Text)
                {
                    buton.BackColor = Color.Green;
                    buton.BackgroundImage = Image.FromFile(yol);
                    buton.Enabled = true;

                }

               }
                
            }
            
            listView1.SelectedItems[0].Remove();
            MessageBox.Show("Biletiniz iptal edilmiştir.");
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox4.Clear();
            listBox2.Items.Clear();
            textBox7.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            listBox2.Items.Add(listView1.SelectedItems[0].SubItems[4].Text);
            listBox2.Items.Add(listView1.SelectedItems[0].SubItems[5].Text);
            listBox2.Items.Add(listView1.SelectedItems[0].SubItems[6].Text);
            listBox2.Items.Add(listView1.SelectedItems[0].SubItems[7].Text);
            listBox2.Items.Add(listView1.SelectedItems[0].SubItems[8].Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text=="" || textBox6.Text==""|| listBox1.Items==null)
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.");             //rezervasyon işlemi yapıyor
            }
            else
            {     
                    giris_form.baglanti.Open();
                       for (int i = 0; i <4 ; i++)
                          {
                                 listBox1.Items.Add("-");
                          }
                if (textBox5.Text==null|| textBox6.Text==null||listBox1.Items==null||textBox3.Text=="0")
                {
                    MessageBox.Show("Lütfen eksiksiz bilgi giriniz.");
                }
                else
                {
                    OleDbCommand komut = new OleDbCommand("INSERT INTO koltuk_sec(filmadi,seans,ad,soyad,k1,k2,k3,k4,k5,tutar) values('" + label29.Text.ToString() + "','" + label30.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+textBox6.Text+"','"+listBox1.Items[0].ToString()+"','"+listBox1.Items[1].ToString()+"','" + listBox1.Items[2].ToString() +"','" + listBox1.Items[3].ToString() +"','" + listBox1.Items[4].ToString() +"','"+textBox3.Text+"')", giris_form.baglanti);
                    komut.ExecuteNonQuery();
                    giris_form.baglanti.Close();
                    MessageBox.Show("Bilet Satın Alınmıştır. Tutar="+textBox3.Text.ToString()+"TL");
                    listBox1.Items.Clear();
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    textBox5.Clear();
                    textBox6.Clear();
                    foreach (System.Windows.Forms.Button buton in this.flowLayoutPanel1.Controls)
                    {
                        if ( buton is System.Windows.Forms.Button && buton.BackColor==Color.Gray)
                        {
                            buton.BackColor = Color.Red;
                            buton.BackgroundImage = Image.FromFile(yol1);
                            
                        }
                    }
                }
                giris_form.baglanti.Close();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label24.Text = DateTime.Now.ToLongTimeString();
            label25.Text = DateTime.Now.ToLongDateString();
        }

       
    }
}
