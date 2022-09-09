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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IUJ388K;Initial Catalog=Personel_Kayıt;Integrated Security=True");
        private void FrmGiris_Load(object sender, EventArgs e)
        {
            
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_yonetici Where kullaniciad=@p1 and sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
                MessageBox.Show("Giriş Başarılı");
            }
            else
            {               
                MessageBox.Show("Hatalı Giriş yaptınız. Lütfen tekrar deneyin","Hatalı Giriş",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                txtkullaniciad.Focus();
            }
            baglanti.Close();
        }
    }
}
