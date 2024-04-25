using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class yetkilipaneli : Form
    {
        public yetkilipaneli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            kullanici yetki = new kullanici();
            yetki.MdiParent = this;
            panel2.Controls.Add(yetki);
            yetki.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult tercih1 = MessageBox.Show("Programdan Çıkılsın mı?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (tercih1 == DialogResult.Yes)
            {
                Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            müsteri mu = new müsteri();
            mu.MdiParent = this;
            panel2.Controls.Add(mu);
            mu.Show();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            anasayfa ana = new anasayfa();
            ana.MdiParent = this;
            panel2.Controls.Add(ana);
            ana.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            odakayit kayi = new odakayit();
            kayi.MdiParent = this;
            panel2.Controls.Add(kayi);
            kayi.Show();
        }
    }
}
