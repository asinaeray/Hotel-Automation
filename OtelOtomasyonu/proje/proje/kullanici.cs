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
    public partial class kullanici : Form
    {
        public kullanici()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel2.mdb");
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
        private void kullanici_Load(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            bagla.Open();
            sorgu = "select * from kullanici";
            OleDbCommand komut = new OleDbCommand(sorgu, bagla);
            OleDbDataReader okut = komut.ExecuteReader();
            while (okut.Read())
            {
                dataGridView1.Rows.Add(okut["id"], okut["ad"], okut["soyad"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"], okut["kullaniadi"], okut["sifre"]);
            }
            bagla.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme//
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Bu alanlar boş geçilemez");
                return;
            }
            else
            {
                dataGridView1.Rows.Clear();
                sorgu = "insert into kullanici(ad,soyad,tc,telefon,adres,mail,kullaniadi,sifre)values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," + textBox8.Text + ")";
                bagla.Open();
                OleDbCommand kom = new OleDbCommand(sorgu, bagla);
                int adet = kom.ExecuteNonQuery();
                bagla.Close();
                dataGridView1.Rows.Clear();

                bagla.Open();
                sorgu = "select * from kullanici";
                OleDbCommand komut = new OleDbCommand(sorgu, bagla);
                OleDbDataReader okut = komut.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["id"], okut["ad"], okut["soyad"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"], okut["kullaniadi"], okut["sifre"]);
                }
                bagla.Close();
                MessageBox.Show(adet + "Kayıt eklendi");
                temizle();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sil//
            if (textBox10.Text == "")
            {
                MessageBox.Show("Bu alan boş geçilemez");
                return;
            }
            else
            {
                sorgu = "delete from kullanici where id=" + textBox10.Text + "";


                bagla.Open();
                OleDbCommand komu = new OleDbCommand(sorgu, bagla);
                int adet = komu.ExecuteNonQuery();
                bagla.Close();

                dataGridView1.Rows.Clear();

                bagla.Open();
                sorgu = "select * from kullanici";
                OleDbCommand komut = new OleDbCommand(sorgu, bagla);
                OleDbDataReader okut = komut.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["id"], okut["ad"], okut["soyad"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"], okut["kullaniadi"], okut["sifre"]);
                }
                bagla.Close();
                MessageBox.Show(adet + "Kayıt silindi");
                temizle();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle//
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Bu alanlar boş geçilemez");
                return;
            }
            else
            {
                sorgu = "update kullanici set ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',tc='" + textBox3.Text + "',telefon='" + textBox4.Text + "',adres='" + textBox5.Text + "',mail='" + textBox6.Text + "',kullaniadi='" + textBox7.Text + "',sifre='" + textBox8.Text + "'where id=" + textBox10.Text + "";
                bagla.Open();
                OleDbCommand komut1 = new OleDbCommand(sorgu, bagla);
                int adet = komut1.ExecuteNonQuery();
                bagla.Close();

                dataGridView1.Rows.Clear();

                sorgu = "select * from kullanici";
                bagla.Open();
                OleDbCommand komut = new OleDbCommand(sorgu, bagla);
                OleDbDataReader okut = komut.ExecuteReader();
                while (okut.Read())
                {
                    dataGridView1.Rows.Add(okut["id"], okut["ad"], okut["soyad"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"], okut["kullaniadi"], okut["sifre"]);
                }
                bagla.Close();
                MessageBox.Show(adet + "Kayıt güncellendi");
                temizle();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            bagla.Open();
            OleDbCommand kom = new OleDbCommand("select * from kullanici where ad like '%"+textBox9.Text+"%'",bagla);
            OleDbDataReader okut = kom.ExecuteReader();
            while (okut.Read())
            {
                dataGridView1.Rows.Add(okut["id"], okut["ad"], okut["soyad"], okut["tc"], okut["telefon"], okut["adres"], okut["mail"], okut["kullaniadi"], okut["sifre"]);
            }
            bagla.Close();
        }
    }
}

