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
    public partial class Characteristics : Form
    {
        Sample samp;

        public Characteristics()
        {
            InitializeComponent();
        }

        public Characteristics(Sample s)
        {
            samp = s;
            InitializeComponent();
            label2.Text = samp.GetModa().ToString();
            label4.Text = samp.GetMediana().ToString();
            label6.Text = samp.GetAverage().ToString();
            label8.Text = samp.GetDev().ToString();
            label10.Text = samp.GetRozmah().ToString();
            label12.Text = samp.GetVar().ToString();
            label14.Text = samp.GetStandart().ToString();
            label16.Text = samp.GetVariation().ToString();
            richTextBox1.Text += samp.GetQuant();
            richTextBox2.Text += samp.GetQuartile();
            richTextBox3.Text += samp.GetDecel();
            label21.Text = samp.StartMoment(ReturnDeg1()).ToString();
            label23.Text = samp.CentralMoment(ReturnDeg2()).ToString();
            label25.Text = samp.GetAsymmetry().ToString();
            label27.Text = samp.GetExcess().ToString();
        }

        public int ReturnDeg1()
        {
            return (int)numericUpDown1.Value;
        }

        public int ReturnDeg2()
        {
            return (int)numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label21.Text = samp.StartMoment(ReturnDeg1()).ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label23.Text = samp.CentralMoment(ReturnDeg2()).ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
