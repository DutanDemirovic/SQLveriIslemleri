using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniIslemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection();
        void Goruntule()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-HBD9E76;Initial Catalog=Alistirma;Integrated Security=True";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Tablo";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Goruntule();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Goruntule();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from Tablo where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", txtId.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Kayıt Silindi");
                txtId.Clear();
            }
            conn.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Tablo (AdSoyad,Yas,Adres) values (@AdSoyad,@Yas,@Adres)";
            cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@Yas", txtYas.Text);
            cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
            if (cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Kayıt Eklendi");
                txtAdres.Clear();
                txtAdSoyad.Clear();
                txtYas.Clear();
            }
            conn.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Tablo set AdSoyad=@AdSoyad,Yas=@Yas,Adres=@Adres where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", txtId.Text);
            cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@Yas", txtYas.Text);
            cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
            if (cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Kayıt Güncellendi");
                txtId.Clear();
                txtAdres.Clear();
                txtAdSoyad.Clear();
                txtYas.Clear();
            }
            conn.Close();
        }
    }
}
