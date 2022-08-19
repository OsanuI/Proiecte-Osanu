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
    public partial class Form5 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form5()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ionut\Desktop\PAOO\ProiectFinal\ProiectFinal\Data.mdf;Integrated Security=True;Connect Timeout=30");
            co.Open();

            SqlCommand cmd = new SqlCommand("Select * From RISCURI", co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            //DataTable dtData = new DataTable();
            //adapter.Fill(dtData);
            //dataGridView1.DataSource = dtData;
            adapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string insertsql;
            insertsql = "insert into RISCURI (nume_risc,nivel_risc,probabilitate_aparitie,natura_risc,cod_bun) values ('" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox8.Text + "', '" + textBox4.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string updatesql;
            updatesql = "update RISCURI set cod_bun = '" + textBox4.Text + "',nume_risc = '" + textBox7.Text + "', nivel_risc = '" + textBox9.Text + "',  = 'probabilitate_aparitie" + textBox10.Text + "',  = 'natura_risc" + textBox8.Text + "' where cod_risc= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(updatesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from RISCURI where cod_risc= '" + dataGridView1.SelectedCells[0].Value + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From RISCURI", co);
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
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
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox8.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            SqlCommand Comm1 = new SqlCommand("select nume_bun from bunuri where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox1.Text = (string)Comm1.ExecuteScalar();
            
            using (SqlCommand Comm11 = new SqlCommand("select domeniu_categorie,impact_minim,impact_maxim,cost,cost_de_reducere from bunuri where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'"))
            {
                Comm11.CommandType = CommandType.Text;
                Comm11.Connection = co;
                
                using (SqlDataReader sdr = Comm11.ExecuteReader())
                {
                    sdr.Read();
                    richTextBox1.Text = "Domeniu: " + sdr["domeniu_categorie"].ToString() + "\nImpact minim: " + sdr["impact_minim"].ToString() + "\nImpact maxim: " + sdr["impact_maxim"].ToString() + "\nCost: " + sdr["cost"].ToString() + "\nCost de reducere: " + sdr["cost_de_reducere"].ToString();
                    
                }
                
            }

            SqlCommand Comm2 = new SqlCommand("select amenintare from amenintari where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox2.Text = (string)Comm2.ExecuteScalar();

            using (SqlCommand Comm22 = new SqlCommand("select nivel_minim, nivel_maxim from amenintari where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'"))
            {
                Comm22.CommandType = CommandType.Text;
                Comm22.Connection = co;

                using (SqlDataReader sdr = Comm22.ExecuteReader())
                {
                    sdr.Read();
                    richTextBox2.Text = "Nivel minim: " + sdr["nivel_minim"].ToString() + "\nNivel maxim: " + sdr["nivel_maxim"].ToString();

                }

            }

            SqlCommand Comm3 = new SqlCommand("select vulnerabilitate from vulnerabilitati where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            textBox3.Text = (string)Comm3.ExecuteScalar();

            SqlCommand Comm33 = new SqlCommand("select nivel from vulnerabilitati where cod_bun = '" + dataGridView1.SelectedCells[0].Value + "'", co);
            richTextBox3.Text = "Nivel: " + (string)Comm33.ExecuteScalar();




        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 ss = new Form8();
            ss.Show();
        }

        private void button13_Click(object sender, EventArgs e)
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

                            MessageBox.Show("Fisierul a fost exportat cu succes.", "Info");
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
                MessageBox.Show("Nu ai ce exporta!", "Info");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
