﻿using System;
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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IUJ388K;Initial Catalog=Personel_Kayıt;Integrated Security=True");
        private void istatistik_Load(object sender, EventArgs e)
        {
            // Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel ", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();

            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString(); 

            }
            baglanti.Close();
            
            // Evli personel sayısı

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel Where perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString(); 
            }

            baglanti.Close();

            // Bekar personel sayısı

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel Where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();   
            }
            baglanti.Close();

            // Şehir sayısı

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(persehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while(dr4.Read()){
             lblsehirsayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // Toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(permaas) From Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();          
            while (dr5.Read())
            {
                lbltoplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maaş

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortalamamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select avg(permaas) From Tbl_Personel Where persehir = 'Ankara'", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                label5.Text = dr7[0].ToString();
            }
            baglanti.Close();


        }
    }
}
