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
    public partial class SampleTable : Form
    {
        Sample samp;
        public SampleTable()
        {
            InitializeComponent();
        }

        public SampleTable(Sample sample)
        {
            samp = sample;
            samp.list = sample.list;
            InitializeComponent();
        }


        private void SampleTable_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = samp.sample.Count + 1;
            var label = new Label { Text = "X", TextAlign = ContentAlignment.MiddleCenter };
            this.tableLayoutPanel1.Controls.Add(label, 0, 0);
            var wtf = new Label { Text = "N", TextAlign = ContentAlignment.MiddleCenter };
            this.tableLayoutPanel1.Controls.Add(wtf, 0, 1);

            List<Label> hz = new List<Label>(0);
            List<Label> hz2 = new List<Label>(0);
            MessageBox.Show("Sample count: " + samp.sample.Count.ToString());
            foreach (var i in samp.sample)
            {
                Label temp = new Label { Text = i.Key.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                hz.Add(temp);
                Label temp2 = new Label { Text = i.Value.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                hz2.Add(temp2);
            }
            for (int i = 0; i < samp.sample.Count; ++i)
            {
                Label fff = new Label { Text = " " };
                int j = i + 1;
                this.tableLayoutPanel1.Controls.Add(hz[i], j, 0);
                this.tableLayoutPanel1.Controls.Add(hz2[i], j, 1);
            }

        }
    }
}
