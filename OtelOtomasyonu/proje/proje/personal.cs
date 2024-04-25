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
    public partial class personal : Form
    {
        public personal()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel2.mdb");
        string sorgu = "";
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox8.Text==textBox9.Text)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Bu alanlar Boş bırakılamaz");
                    return;
                }
                else
                {
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("insert into kullanici(ad,soyad,tc,telefon,adres,mail,kullaniadi,sifre)values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," + textBox8.Text + ")", baglan);
                    OleDbDataReader okut = komut.ExecuteReader();
                    baglan.Close();
                }
                temizle();
                MessageBox.Show("kayıt başarılı");
            }
            else
            {
                MessageBox.Show("şifre girilmedi veya yanlış");
            }
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox9.Visible =true;
            label9.Visible = true;
        }

        private void personal_Load(object sender, EventArgs e)
        {
            textBox9.Visible = false;
            label9.Visible = false;
        }
    }
}
