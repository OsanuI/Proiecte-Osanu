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

namespace ProiectFinal
{
    public partial class Form7 : Form
    {
        SqlConnection co;
        public Form7()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into PROIECT(denumire,domeniu,data_inceput,data_final) OUTPUT INSERTED.cod_proiect VALUES ('" + textBox7.Text + "', '" + textBox8.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + dateTimePicker2.Value.ToString() + "')", co);
            //cmd.ExecuteNonQuery();
            Int32 newId = (Int32)cmd.ExecuteScalar();
            Console.WriteLine(newId);
            SqlCommand cmd2 = new SqlCommand("Insert Into ORGANIZATIE(denumire,adresa,persoana_contact,telefon,utilizator,parola,cod_proiect) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" +newId+ "')", co);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("Insert Into LOGIN(username,password) VALUES ('" + textBox5.Text + "', '" + textBox6.Text + "')", co);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Cont creat cu succes!");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
