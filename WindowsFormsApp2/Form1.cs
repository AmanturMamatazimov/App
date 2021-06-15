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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("users.jfif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection("Data Source=DESKTOP-DNDEKN8\\SQLEXPRESS;Initial Catalog=manas-kullanici;Integrated Security=True");
            string sql = "select * from users where kadi=@kadi and sifre=@sifre";
            SqlCommand komut = new SqlCommand(sql,bag);//2
            bag.Open();
            komut.Parameters.AddWithValue("@kadi",textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();//3
            if (dr.Read())//4
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }
            else
            {
                label3.Text = "Kullanici adi veya sifre hatali";
            }
            bag.Close();
        }
    }
}
