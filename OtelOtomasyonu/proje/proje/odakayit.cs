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
    public partial class odakayit : Form
    {
        public odakayit()
        {
            InitializeComponent();
        }
        void temizle()
        {
            
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox6.Clear();
            
        }
        OleDbConnection bagla = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel2.mdb");
        string sorgu = "";
        private void odakayit_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("room for two people");
            comboBox3.Items.Add("room for three people");
            comboBox3.Items.Add("room for four people");

            comboBox5.Items.Add("1");

            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");

            comboBox4.Items.Add("north");
            comboBox4.Items.Add("south");


            bagla.Open();
            OleDbCommand komu = new OleDbCommand("select distinct tc from müsteri ", bagla);
            OleDbDataReader okut1 = komu.ExecuteReader();
            while (okut1.Read())
            {

                comboBox1.Items.Add(okut1["tc"]);

            }
            bagla.Close();


            if (comboBox1.SelectedIndex==1)
            {
                bagla.Open();
                OleDbCommand komut = new OleDbCommand("select * from müsteri", bagla);
                OleDbDataReader okut12 = komu.ExecuteReader();
                while (okut12.Read())
                {
                    textBox1.Text = okut12["ad"].ToString();
                }
                bagla.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int gunsayi;
            gunsayi = Convert.ToInt32(textBox2.Text);

            if (textBox2.Text == "")
            {
                MessageBox.Show("alanları boş bırakmayınız");
                return;
            }
            else
            {
                gunsayi = gunsayi * 200;
                textBox5.Text = gunsayi.ToString();
            }
        }
        //,,g_tarih,c_tarih,oda_tip,tc,gün_sayisi,banyo_sayisi,kat,cephe,fiyat
        //||textBox6.Text==""||textBox2.Text==""||textBox5.Text==""||comboBox3.SelectedItem==""
        private void button4_Click(object sender, EventArgs e)
        {
            sorgu = "insert into odakayit(ad,soyad,g_tarih,c_tarih,oda_tip,tc,gün_sayisi,banyo_sayisi,kat,cephe,fiyat)values('" + textBox1.Text+"','"+textBox7.Text+"',"+textBox3.Text+","+textBox6.Text+",'"+comboBox3.SelectedItem+"',"+comboBox1.SelectedItem+","+textBox2.Text+","+comboBox5.SelectedItem+","+comboBox2.SelectedItem+",'"+comboBox4.SelectedItem+"',"+textBox5.Text+")";
            bagla.Open();
            OleDbCommand komu = new OleDbCommand(sorgu,bagla);
            int adet=komu.ExecuteNonQuery();
            bagla.Close();
            MessageBox.Show(adet+"kişi odaya kaydedildi");
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            bagla.Open();
            sorgu = "select * from odakayit";
            OleDbCommand komut = new OleDbCommand(sorgu, bagla);
            OleDbDataReader okut = komut.ExecuteReader();
            while (okut.Read())
            {
                dataGridView1.Rows.Add(okut["oda_no"],okut["ad"],okut["soyad"], okut["g_tarih"], okut["c_tarih"], okut["oda_tip"], okut["tc"], okut["gün_sayisi"], okut["banyo_sayisi"], okut["kat"], okut["cephe"], okut["fiyat"]);
            }
            bagla.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bagla.Open();
            OleDbCommand komut = new OleDbCommand("select * from müsteri where tc="+comboBox1.SelectedItem+"", bagla);
            OleDbDataReader okut = komut.ExecuteReader();
            while (okut.Read())
            {
                textBox1.Text = okut["ad"].ToString();
                textBox7.Text = okut["soyad"].ToString();
            }
            bagla.Close();
        }
    }
}
