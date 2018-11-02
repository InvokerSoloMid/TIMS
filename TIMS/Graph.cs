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

namespace TIMS
{
    public partial class Graph : Form
    {
        Sample samp;
        public Graph()
        {
            InitializeComponent();
        }

        public Graph(Sample smpl)
        {
            samp = smpl;
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].Axes[0].Title = "x"; chart2.ChartAreas[0].Axes[0].Title = "x";
            chart1.ChartAreas[0].Axes[1].Title = "y"; chart2.ChartAreas[0].Axes[1].Title = "y";
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Purple; chart2.Series[0].Color = Color.Purple;
            foreach (var i in samp.sample)
            {
                this.chart1.Series["Series1"].Points.AddXY(i.Key, i.Value);
                this.chart2.Series["Series1"].Points.AddXY(i.Key, i.Value);
            }
            Table_Load();
        }

        private void Table_Load()
        {
            tableLayoutPanel1.RowCount = samp.sample.Count + 1;
            double start = samp.list[0]-1;
            var label = new Label { Text = "<"+start.ToString(), TextAlign = ContentAlignment.MiddleCenter };
            this.tableLayoutPanel1.Controls.Add(label, 0, 0);
            var wtf = new Label { Text = "0", TextAlign = ContentAlignment.MiddleCenter };
            this.tableLayoutPanel1.Controls.Add(wtf, 1, 0);

            List<Label> hz = new List<Label>(0);
            List<Label> hz2 = new List<Label>(0);

            double sum = 0; 

            foreach (var i in samp.sample)
            {
                sum += i.Value;
                double res = sum / samp.volume;
                Label temp = new Label { Text = i.Key.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                hz.Add(temp);
                Label temp2 = new Label { Text = res.ToString("R"), TextAlign = ContentAlignment.MiddleCenter };
                hz2.Add(temp2);
            }

            for (int i = 0; i < samp.sample.Count; ++i)
            {
                Label fff = new Label { Text = " " };
                int j = i + 1;
                this.tableLayoutPanel1.Controls.Add(hz[i], 0, j);
                this.tableLayoutPanel1.Controls.Add(hz2[i], 1, j);
            }
        }
    }
}
