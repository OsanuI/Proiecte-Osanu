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
    public partial class Form4 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form4()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();

            SqlCommand cmd = new SqlCommand("Select * From AMENINTARI", co);
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
            insertsql = "insert into AMENINTARI (cod_bun,amenintare,nivel_minim,nivel_maxim) values ('" + Index + "', '" + textBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox4.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            int Index = listBox1.Items.IndexOf(text) + 1;

            string updatesql;
            updatesql = "update AMENINTARI set cod_bun = '" + Index + "', amenintare = '" + textBox1.Text + "', nivel_minim = '" + comboBox2.Text + "', nivel_maxim = '" + comboBox4.Text + "' where cod_amenintare= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(updatesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from AMENINTARI where cod_amenintare= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From AMENINTARI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e) // reseteaza
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ss = new Form3();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
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

        
    }
}
