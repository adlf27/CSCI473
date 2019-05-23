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
    public partial class Form4 : Form
    {
        private List<Crashes> cars;
       
        public Form4()
        {
            cars = new List<Crashes>();
            InitializeComponent();
            ReadFile("chart3.txt");
           
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Chart lineChart = new Chart();
            lineChart.Size = this.Size - new Size(0, 100);
            ChartArea cArea = new ChartArea();
            cArea.BorderWidth = this.Width;
            lineChart.ChartAreas.Add(cArea);
            lineChart.Series.Clear();
            lineChart.Palette = ChartColorPalette.Fire;
            lineChart.BackColor = Color.LightBlue;
            lineChart.Titles.Add("Average of Car Crashes per Month");

            Legend l = new Legend()
            {
                BackColor = Color.Transparent,
                ForeColor = Color.Black
            };
            lineChart.Legends.Add(l);
            Series s = new Series()
            {
                Name = "Tokyo",
                IsVisibleInLegend = true,
                Color = Color.Red,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Triangle
            };
            Series s2 = new Series()
            {
                Name = "New York",
                IsVisibleInLegend = true,
                Color = Color.DeepSkyBlue,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Circle
            };
            Series s3 = new Series()
            {
                Name = "Berlin",
                IsVisibleInLegend = true,
                Color = Color.Purple,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Cross
            };
            Series s4 = new Series()
            {
                Name = "London",
                IsVisibleInLegend = true,
                Color = Color.DarkGreen,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Diamond
            };
            Series s5 = new Series()
            {
                Name = "Moscow",
                IsVisibleInLegend = true,
                Color = Color.DarkOrange,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Square
            };

            lineChart.Series.Add(s);
            lineChart.Series.Add(s2);
            lineChart.Series.Add(s3);
            lineChart.Series.Add(s4);
            lineChart.Series.Add(s5);
            foreach (Crashes c in cars)
            {
                if(c.city.Equals("Tokyo"))
                    s.Points.AddXY(c.month, c.carCrashes);
                if(c.city.Equals("New York"))
                    s2.Points.AddXY(c.month, c.carCrashes);
                if(c.city.Equals("Berlin"))
                    s3.Points.AddXY(c.month, c.carCrashes);
                if(c.city.Equals("London"))
                    s4.Points.AddXY(c.month, c.carCrashes);
                if(c.city.Equals("Moscow"))
                    s5.Points.AddXY(c.month, c.carCrashes);
                

            }
           
            this.Controls.Add(lineChart);

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
                        cars.Add(new Crashes(tokens[1], Int32.Parse(tokens[2]), tokens[0]));
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
    }
    public class Crashes
    {
        public string city { get; set; }
        public int carCrashes { get; set; }
        public string month { get; set; }
        
        public Crashes(string city, int carCrashes, string month)
        {
            this.city = city;
            this.carCrashes = carCrashes;
            this.month = month;
        }

    }

}
