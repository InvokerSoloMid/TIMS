using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TIMS
{
    public partial class Form1 : Form
    {
        private Sample currentSample;
        public Form1()
        {
            currentSample = new Sample(0);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentSample.start.Count == 0) MessageBox.Show("Read data from file first!");
            else
            {
                Table a = new Table(currentSample);
                a.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentSample.IsSorted = true;
            if (currentSample.start.Count == 0) MessageBox.Show("Read data from file first!");
            else
            {
                currentSample.list.Sort();
                currentSample.list.Add(999666);
                string a = null; int count = 0;
                if (currentSample.sample.Count == 0)
                {
                    for (int i = 0; i < currentSample.list.Count - 1; ++i)
                    {
                        if (currentSample.list[i] == currentSample.list[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            count++;
                            currentSample.sample.Add(currentSample.list[i], count);
                            count = 0;
                        }
                    }
                }
                currentSample.list.Remove(999666);
                SampleTable t = new SampleTable(currentSample);
                t.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageFile f = new ManageFile();
            f.ShowDialog();
            currentSample = new Sample(f.GetSample());
            string s = null;
            foreach (var i in currentSample.start)
            {
                s += i.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentSample.start.Count == 0) MessageBox.Show("Read data from file first!");
            else
            {
                if (currentSample.IsSorted == false)
                {
                    currentSample.IsSorted = true;
                    currentSample.list.Sort();
                    currentSample.list.Add(999666);
                    string a = null; int count = 0;
                    if (currentSample.sample.Count == 0)
                    {
                        for (int i = 0; i < currentSample.list.Count - 1; ++i)
                        {
                            if (currentSample.list[i] == currentSample.list[i + 1])
                            {
                                count++;
                            }
                            else
                            {
                                count++;
                                currentSample.sample.Add(currentSample.list[i], count);
                                count = 0;
                            }
                        }
                    }
                    currentSample.list.Remove(999666);
                }
                Graph g = new Graph(currentSample);
                g.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentSample.IsSorted = true;
            if (currentSample.start.Count == 0) MessageBox.Show("Read data from file first!");
            else
            {
                currentSample.list.Sort();
                currentSample.list.Add(999666);
                string a = null; int count = 0;
                if (currentSample.sample.Count == 0)
                {
                    for (int i = 0; i < currentSample.list.Count - 1; ++i)
                    {
                        if (currentSample.list[i] == currentSample.list[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            count++;
                            currentSample.sample.Add(currentSample.list[i], count);
                            count = 0;
                        }
                    }
                }
                currentSample.list.Remove(999666);
                Characteristics c = new Characteristics(currentSample);
                c.ShowDialog();
            }
        }
    }
}
