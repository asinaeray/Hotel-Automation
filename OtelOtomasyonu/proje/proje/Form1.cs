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

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel2.mdb");
        string sorgu;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("do not leave blank");
            }
            else
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("select kullaniadi,sifre from kullanici where kullaniadi=@kullaniadi and sifre=@sifre", baglan);
                komut.Parameters.AddWithValue("@kullaniad", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    yetkilipaneli yet = new yetkilipaneli();
                    yet.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Login successful");
                }
               
                else
                {
                    baglan.Close();
                    MessageBox.Show("Authorized external entry prohibited");
                    textBox1.Clear();
                    textBox2.Clear();
                }

                
            }











            //string kadi = textBox1.Text;
            //int sifre = Convert.ToInt32(textBox2.Text);
            //if (kadi=="mustafa"&&sifre==2345||kadi=="serkan"&&sifre==3456)
            //{
            //    yetkilipaneli yet = new yetkilipaneli();
            //    yet.Show();
            //}

            //else
            //{
            //    MessageBox.Show("Yetkili harici giriş yasak");
            //}
            //textBox1.Clear();
            //textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            personal geç = new personal();
            geç.Show();
        }
    }
}
