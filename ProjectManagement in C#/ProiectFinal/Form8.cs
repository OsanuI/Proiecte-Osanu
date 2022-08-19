using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectFinal
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            fillChart();
        }
        
         
        private void fillChart()
        {
            
            chart1.Series["Probabilitate/Impact"].Points.AddXY("Probabilitate 9.1", "3");
            chart1.Series["Probabilitate/Impact"].Points.AddXY("Probabilitate 15.23", "5");
            chart1.Series["Probabilitate/Impact"].Points.AddXY("Probabilitate 9.05", "2");
            chart1.Series["Probabilitate/Impact"].Points.AddXY("Probabilitate 12", "7");
            chart1.Series["Probabilitate/Impact"].Points.AddXY("Probabilitate 3", "1");
          
            chart1.Titles.Add("Diagrama Probabilitate/Impact");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 ss = new Form5();
            ss.Show();
        }
    }
}
