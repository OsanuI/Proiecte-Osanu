using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectFinal
{
    public partial class Form6 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form6()
        {
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();
            InitializeComponent();

            SqlCommand cmd = new SqlCommand("Select * From CONTRAMASURI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
            ss.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            string insertsql;
            insertsql = "insert into contramasuri (cod_risc,metoda_de_tratare,categorie_contramasuri,tratat) values ('" + textBox5.Text + "', '" + textBox3.Text + "', '" + richTextBox1.Text + "', '" + comboBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string updatesql;
            updatesql = "update contramasuri set cod_risc = '" + textBox5.Text + "',metoda_de_tratare = '" + textBox3.Text + "', categorie_contramasuri = '" + richTextBox1.Text + "',  = 'tratat" + comboBox1.Text + "' where cod_contramasura= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(updatesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from contramasuri where cod_contramasura= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            SqlCommand Comm1 = new SqlCommand("select nume_risc from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox7.Text = (string)Comm1.ExecuteScalar();
            SqlCommand Comm2 = new SqlCommand("select nivel_risc from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox9.Text = Comm2.ExecuteScalar().ToString();
            SqlCommand Comm3 = new SqlCommand("select probabilitate_aparitie from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox10.Text = Comm3.ExecuteScalar().ToString();
            
            
            SqlCommand Comm4 = new SqlCommand("select nume_bun from bunuri where cod_bun = (SELECT cod_bun from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "')", co);
            textBox1.Text = (string)Comm4.ExecuteScalar();
            SqlCommand Comm5 = new SqlCommand("select amenintare from amenintari where cod_bun = (SELECT cod_bun from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "')", co);
            textBox2.Text = (string)Comm5.ExecuteScalar();
            SqlCommand Comm6 = new SqlCommand("select vulnerabilitate from vulnerabilitati where cod_bun = (SELECT cod_bun from riscuri where cod_risc = '" + dataGridView1.SelectedCells[0].Value + "')", co);
            textBox4.Text = (string)Comm6.ExecuteScalar();

            SqlCommand cmd = new SqlCommand("Select * From CONTRAMASURI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Ceva nu a mers bine." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("PDF-ul a fost exportat!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("NU sunt date pentru export!", "Info");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
