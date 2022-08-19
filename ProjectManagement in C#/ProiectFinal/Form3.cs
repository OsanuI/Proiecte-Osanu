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
    public partial class Form3 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form3()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();

            SqlCommand cmd = new SqlCommand("Select * From BUNURI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string insertsql;
            insertsql = "insert into BUNURI (nume_bun,cod_proiect,impact_minim,impact_maxim,domeniu_categorie,cost,cost_de_reducere) values ('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox4.Text + "','" + comboBox3.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From BUNURI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            string updatesql;
            updatesql = "update BUNURI set cod_proiect= '" + comboBox1.Text + "', nume_bun= '" + textBox1.Text + "', impact_minim= '" + comboBox2.Text + "', impact_maxim= '" + comboBox4.Text + "', domeniu_categorie= '" + comboBox3.Text + "', cost= '" + textBox2.Text + "', cost_de_reducere= '" + textBox3.Text + "' where cod_bun= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(updatesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from BUNURI where cod_bun= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 ss = new Form4();
            ss.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 ss = new Form5();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 ss = new Form6();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
