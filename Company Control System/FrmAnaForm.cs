using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Personel
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IUJ388K;Initial Catalog=Personel_Kayıt;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personel_KayıtDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.tbl_PersonelTableAdapter.Fill(this.personel_KayıtDataSet.Tbl_Personel);

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personel_KayıtDataSet.Tbl_Personel);
            MessageBox.Show("listeleme Başarılı");
        }

        private void radiobutton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {

            baglanti.Open();
           
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (perad,persoyad,persehir,permaas,perdurum,permeslek,perid) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p7", txtid.Text);
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();          
            SqlCommand komut1 = new SqlCommand("update Tbl_Personel Set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", baglanti);
            
            komut1.Parameters.AddWithValue("@a1", txtad.Text);
            komut1.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komut1.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komut1.Parameters.AddWithValue("@a4", mskmaas.Text);
            komut1.Parameters.AddWithValue("@a5", label8.Text);
            komut1.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komut1.Parameters.AddWithValue("@a7", txtid.Text);
            komut1.ExecuteNonQuery();
           
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı");
    }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
           
            if (label8.Text == "True")
            {
                radioButton1.Checked=true;
            }
            else
            {
                radioButton2.Checked=true;
            }
            txtmeslek.Text= dataGridView1.Rows[sec].Cells[6].Value.ToString();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand komut2 = new SqlCommand("Delete From Tbl_Personel where perid=@d1",baglanti);
            komut2.Parameters.AddWithValue("@d1", txtid.Text);
            komut2.ExecuteNonQuery();
           
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            cmbsehir.Text = "";
            mskmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtmeslek.Text = "";
            txtid.Focus();
        }


        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
           Frmİstatistik ist =new Frmİstatistik();
            ist.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler gra =new FrmGrafikler();
            gra.Show();
        }
    }
}
