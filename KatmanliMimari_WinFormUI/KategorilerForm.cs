using KatmanliMimariEntity;
using KatmanliMimariORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatmanliMimari_WinFormUI
{
    public partial class KategorilerForm : Form
    {
        public KategorilerForm()
        {
            InitializeComponent();
        }

        KategoriORM kategoriORM = new KategoriORM();
        private void KategorilerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kategoriORM.Select();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategoriler kategori = new Kategoriler { KategoriAdi = txtKategoriAdi.Text, Tanimi = txtTanimi.Text, Resim = new byte[0] };
            bool sonuc = kategoriORM.Insert(kategori);
            if (sonuc)
            {
                MessageBox.Show("Kategori Eklendi.");
                dataGridView1.DataSource = kategoriORM.Select();
            }
            else
                MessageBox.Show("Kategori Eklerken bir hata oluştu.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
