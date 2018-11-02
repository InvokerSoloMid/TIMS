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
    public partial class ManageFile : Form
    {
        List<int[]> choose = new List<int[]>(0);
        string path = "data.txt";
        int volume;
        public List<double> start = new List<double>(0);
        public List<double> list = new List<double>(0);
        public ManageFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1 = int.Parse(textBox1.Text), val2 = int.Parse(textBox2.Text);
            int size = (int)numericUpDown2.Value;
            int[] arr = new int[size];
            Random rnd = new Random();
            string s = null;
            for (int i = 0; i < size; ++i)
            {
                s = s + (rnd.Next(val1, val2)) + " ";
            }
            MessageBox.Show(s);
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.ShowDialog();
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string s = System.IO.File.ReadAllText(filename);
            path = filename;
            Read();
        }

        public int GetVolume()
        {
            return (int)numericUpDown1.Value;
        }

        public void Read()
        {          
            volume = GetVolume();
            StreamReader file = new StreamReader(path);
            List<int> temp = new List<int>(0);
            List<int> hz = new List<int>(volume);
            string from; string a = null;
            from = file.ReadToEnd();
            Random rnd = new Random();
            for (int i = 0; i < from.Length; ++i)
            {
                if (from[i] != ' ')
                    a += from[i];
                else
                {
                    temp.Add(int.Parse(a));
                    a = null;
                }
            }
            int count = (int)temp.Count / (int)numericUpDown1.Value;
            //MessageBox.Show("Count: " + count);
            for (int i=0; i<count; ++i)
            {
                int[]t = new int[volume];
                for (int j=0; j<volume; ++j)
                {
                    t[j] = temp[i * volume + j];
                    //MessageBox.Show("t[j]: " + t[j]);
                }
                choose.Add(t);
            }
            foreach(var i in choose)
            {
                string s = null;
                for(int j=0; j<i.Length; ++j)
                {
                    s += i[j].ToString()+" ";
                }
                listBox1.Items.Add(s);
            }
            
        }

        public List<double>GetSample()
        {
            return list;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index==-1) index = 0;
            for (int i=0; i<volume; ++i)
            {
                start.Add(choose[index][i]);
                list.Add(choose[index][i]);
            }
            if (checkBox1.Checked == true)
                GetN();
            this.Close();
        }


        public void GetN()
        {
            int size;
            if ((volume / GetR()) % 1 == 0) size = volume / GetR();
            else size = (volume / GetR()) + 1;
            List<double> temp = new List<double>();
            for (int i = 0; i < GetR(); ++i)
            {
                double sum = 0;
                for (int j = 0; j < size; ++j)
                {
                    sum += list[i * size + j];
                }
                sum /= size;
                temp.Add(sum);
            }
            start = temp;
            list = temp;
        }

        public int GetR()
        {
            int res = 1;
            while (Math.Pow(2, res) < volume)
            {
                res++;
            }
            return res;
        }

        private void ManageFile_Load(object sender, EventArgs e)
        {

        }
    }
}
