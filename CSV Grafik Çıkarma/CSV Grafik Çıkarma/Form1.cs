using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace CSV_Grafik_Çıkarma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fn = openFileDialog1.FileName;
            string readfile = File.ReadAllText(fn);
            string[] line = readfile.Split('\n');
            int count = 0;
            foreach (string str in line[0].Split(','))
            {
                count++;
            }
            dataGridView1.ColumnCount = count;
            foreach (string s1 in readfile.Split('\n'))
            {
                if (s1 != "")
                {
                    dataGridView1.Rows.Add(s1.Split(','));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowcount = dataGridView1.RowCount - 1;
            string c1 , c2 , c3 , c4;
            for (int i = 0; i < rowcount; i++)
            {
                c1 = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                c2 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                c3 = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                c4 = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                chart1.Series["Hat Basıncı"].Points.AddXY(c1, c2);
                chart1.Series["Ust Sınır"].Points.AddXY(c1, c3);
                chart1.Series["Alt Sınır"].Points.AddXY(c1, c4);
            }
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 200;
            chart1.ChartAreas[0].AxisY.Minimum = 4500;
            chart1.ChartAreas[0].AxisY.Maximum = 5500;
            chart1.ChartAreas[0].AxisX.Interval =10;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //chart1.ChartAreas[0].AxisY.Interval = 25;
        }
    }
}
        
