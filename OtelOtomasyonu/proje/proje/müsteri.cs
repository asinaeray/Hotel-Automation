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
    public partial class müsteri : Form
    {
        public müsteri()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel2.mdb");
        string sorgu;

        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void müsteri_Load(object sender, EventArgs e)
        {
           

            comboBox1.Items.Add("ERKEK");
            comboBox1.Items.Add("KIZ");

            dataGridView1.Rows.Clear();
            //kayıtlar//
            baglan.Open();
            sorgu = "select * from müsteri";
            OleDbCommand kom = new OleDbCommand(sorgu, baglan);
            OleDbDataReader okut = kom.ExecuteReader();
            while (okut.Read())
            {
                dataGridView1.Rows.Add(okut["sira"], okut["ad"], okut["soyad"], okut["cinsiyet"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"]);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekle//
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("bu alanlar boş geçilemez");
                return;
            }
            else
            {

                sorgu = "insert into müsteri(ad,soyad,cinsiyet,tc,telefon,adres,mail)values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "'," + textBox4.Text + "," + textBox5.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "')";
                baglan.Open();
                OleDbCommand kom = new OleDbCommand(sorgu, baglan);
                int adet = kom.ExecuteNonQuery();
                baglan.Close();

                dataGridView1.Rows.Clear();

                baglan.Open();
                sorgu = "select * from müsteri";
                OleDbCommand komu = new OleDbCommand(sorgu, baglan);
                OleDbDataReader okut = komu.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["sira"], okut["ad"], okut["soyad"], okut["cinsiyet"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"]);
                }
                baglan.Close();
                MessageBox.Show(adet + "Adet kişi eklendi");
                temizle();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sil//
            if (textBox1.Text == "")
            {
                MessageBox.Show("bu alanlar boş geçilemez");
                return;
            }
            else
            {

                sorgu = "delete from müsteri where sira=" + textBox3.Text + "";
                baglan.Open();
                OleDbCommand komt = new OleDbCommand(sorgu, baglan);
                int adet = komt.ExecuteNonQuery();
                baglan.Close();

                dataGridView1.Rows.Clear();

                baglan.Open();
                sorgu = "select * from müsteri";
                OleDbCommand kom = new OleDbCommand(sorgu, baglan);
                OleDbDataReader okut = kom.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["sira"], okut["ad"], okut["soyad"], okut["cinsiyet"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"]);
                }
                baglan.Close();
                MessageBox.Show(adet + " Adet kişi silindi");
                temizle();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle//
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Bu alanlar boş geçilemez");
                return;
            }
            else
            {
                sorgu = "update müsteri set ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',cinsiyet='" + comboBox1.SelectedItem + "',tc='" + textBox4.Text + "',telefon='" + textBox5.Text + "',adres='" + textBox6.Text + "',mail='" + textBox7.Text + "'where sira=" + textBox3.Text + "";
                baglan.Open();
                OleDbCommand komut1 = new OleDbCommand(sorgu, baglan);
                int adet = komut1.ExecuteNonQuery();
                baglan.Close();

                dataGridView1.Rows.Clear();

                baglan.Open();
                sorgu = "select * from müsteri";
                OleDbCommand komu = new OleDbCommand(sorgu, baglan);
                OleDbDataReader okut = komu.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["sira"], okut["ad"], okut["soyad"], okut["cinsiyet"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"]);
                }
                baglan.Close();
                MessageBox.Show(adet + " Adet kişi silindi");
                temizle();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //temizle//
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        
        
    }
}