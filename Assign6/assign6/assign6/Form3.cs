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
    public partial class Form3 : Form
    {
        private List<string> words;
        private List<int> percent;
        public Form3()
        {
            words = new List<string>();
            percent = new List<int>();
            InitializeComponent();
            ReadFile("chart2.txt");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Chart pieChart = new Chart();
            pieChart.Size = this.Size - new Size(0, 100);
            ChartArea area = new ChartArea("Pie Area");
            area.BorderWidth = this.Width;
            pieChart.ChartAreas.Add(area);
            pieChart.Series.Clear();
            pieChart.Palette = ChartColorPalette.Fire;
            pieChart.BackColor = Color.LightBlue;
            pieChart.Titles.Add("What I do when I cant Hear someone");
            pieChart.ChartAreas[0].BackColor = Color.Transparent;
            Legend l = new Legend()
            {
                BackColor = Color.Transparent,
                ForeColor = Color.Black
            };
            pieChart.Legends.Add(l);
            Series s = new Series()
            {
                Name = "s1",
                IsVisibleInLegend = true,
                Color = Color.Transparent,
                ChartType = SeriesChartType.Pie
            };
            pieChart.Series.Add(s);
                                   
                
           for(int i = 0; i < percent.Count; i++)
           {                
                DataPoint dp = new DataPoint(0, percent[i]);
                dp.AxisLabel = percent[i].ToString();
                dp.LegendText = words[i];
                s.Points.Add(dp);                                               
            }
                                    
            this.Controls.Add(pieChart);
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
                        words.Add(tokens[0]);
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
    }
}
