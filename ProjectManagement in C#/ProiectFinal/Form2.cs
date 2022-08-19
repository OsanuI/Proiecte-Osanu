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
    public partial class Form2 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form2()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();

            SqlCommand cmd = new SqlCommand("Select * From VULNERABILITATI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            int Index = listBox1.Items.IndexOf(text) + 1;



            string insertsql;
            insertsql = "insert into VULNERABILITATI (cod_bun,vulnerabilitate,nivel,bun) values ('" + Index + "','" + textBox1.Text + "', '" + comboBox2.Text + "', '" + text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            int Index = listBox1.Items.IndexOf(text) + 1;

            string updatesql;
            updatesql = "update VULNERABILITATI set cod_bun = '" + Index + "', bun = '" + text + "', vulnerabilitate = '" + textBox1.Text + "', nivel = '" + comboBox2.Text + "' where cod_vulnerabilitate='" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(updatesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from VULNERABILITATI where cod_vulnerabilitate= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From VULNERABILITATI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ss = new Form3();
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
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
