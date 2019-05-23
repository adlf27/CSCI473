using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assign6
{
    public partial class Form2 : Form
    {
        private List<string> months;
        private List<int> points;

        public Form2()
        {
            InitializeComponent();
            months = new List<string>();
            points = new List<int>();
            ReadFile("chart1.txt");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Titles.Add("2008-2009 NBA Regular Season");

            chart.Size = this.Size - new Size(0, 100);
            chart.BackColor = Color.LightBlue;
            Series series = new Series("Default");
            series.ChartType = SeriesChartType.Column;
   
            chart.Series.Add(series);
            chart.Series[0].IsValueShownAsLabel = true;

            ChartArea chartArea = new ChartArea();
            Axis yAxis = new Axis(chartArea, AxisName.Y);           
            Axis xAxis = new Axis(chartArea, AxisName.X);
            chart.Series["Default"].Points.DataBindXY(months,points);
            chart.ChartAreas.Add(chartArea);
            chart.ChartAreas[0].AxisX.Title = "Months";
            chart.ChartAreas[0].AxisY.Title = "Points Per Month";
            chart.Invalidate();
            this.Controls.Add(chart);
        }
        private void ReadFile(string file)
        {
            string line;
            if(File.Exists(file))
            {
                using (StreamReader data = new StreamReader(file))
                {
                    line = data.ReadLine();
                    string[] tokens;
                    while(line != null)
                    {
                        tokens = line.Split(',');
                       months.Add(tokens[0]);
                       points.Add(Int32.Parse(tokens[1]));                     
                       line = data.ReadLine();         
                    }
                }
            }
            else
            {
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }
    }
}
