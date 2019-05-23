using System;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assign6
{
    public partial class Form5 : Form
    {
        private List<string> foods;
        private List<int> percent;
        public Form5()
        {
            InitializeComponent();
            foods = new List<string>();
            percent = new List<int>();
            ReadFile("chart4.txt");
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReadFile(string file)
        {
            string line;
            if (File.Exists(file))
            {
                using (StreamReader data = new StreamReader(file))
                {
                    line = data.ReadLine();
                    string[] tokens;
                    while (line != null)
                    {
                        tokens = line.Split(',');
                        foods.Add(tokens[0]);
                        percent.Add(Int32.Parse(tokens[1]));
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

        private void Form5_Load_1(object sender, EventArgs e)
        {

            Chart pyramidChart = new Chart();
            pyramidChart.Size = this.Size - new Size(0, 100);
            ChartArea area = new ChartArea("Pyramid Area");
            area.BorderWidth = this.Width;
            pyramidChart.ChartAreas.Add(area);
            pyramidChart.Series.Clear();
            pyramidChart.Palette = ChartColorPalette.EarthTones;
            pyramidChart.BackColor = Color.LightBlue;
            pyramidChart.Titles.Add("Low-Carb Diet");
            pyramidChart.ChartAreas[0].BackColor = Color.Transparent;
            Legend l = new Legend()
            {
                BackColor = Color.Transparent,
                ForeColor = Color.Black
            };
            pyramidChart.Legends.Add(l);
            Series s = new Series()
            {
                Name = "s1",
                IsVisibleInLegend = true,
                Color = Color.Transparent,
                ChartType = SeriesChartType.Pyramid
            };
            pyramidChart.Series.Add(s);


            for (int i = 0; i < percent.Count; i++)
            {
                DataPoint dp = new DataPoint(0, percent[i]);
                dp.AxisLabel = percent[i].ToString();
                dp.LegendText = foods[i];
                s.Points.Add(dp);
            }

            this.Controls.Add(pyramidChart);
        }
    }
}
