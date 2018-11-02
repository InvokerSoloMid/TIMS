using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMS
{
    public partial class Table : Form
    {
        Sample samp;
        public Table()
        {
            InitializeComponent();
        }

        public Table(Sample sample)
        {
            samp = sample;
            samp.start = sample.start;
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = samp.volume + 1;
            var label = new Label { Text = "X", TextAlign = ContentAlignment.MiddleCenter };
            this.tableLayoutPanel1.Controls.Add(label, 0, 0);

            List<Label> hz = new List<Label>(0);
            MessageBox.Show("Sample count: " + samp.start.Count.ToString());
            foreach (var i in samp.start)
            {
                Label temp = new Label { Text = i.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                hz.Add(temp);
            }
            for (int i = 0; i < hz.Count; ++i)
            {
                Label fff = new Label { Text = " " };
                int j = i + 1;
                this.tableLayoutPanel1.Controls.Add(hz[i], j, 0);
            }

        }
    }
}
