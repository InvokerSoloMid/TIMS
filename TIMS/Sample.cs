using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TIMS
{
    public class Sample
    {
        public bool IsSorted;
        public int volume;
        public Dictionary<double, int> sample;
        public List<double> start = new List<double>(0);
        public List<double> list=new List<double>(0);
        public Sample(int n)
        {
            IsSorted = false;
            sample = new Dictionary<double, int>();
            volume = n;
        }
        public Sample(List<double>l)
        {
            IsSorted = false;
            sample = new Dictionary<double, int>();
            foreach (var i in l)
            {
                start.Add(i);
            }
            list = l;
            volume = l.Count;
        }

        public void SetVolume(int n)
        {
            volume = n;
        }

        public void ToUnc(int n)
        {
            List<double> hz = new List<double>();
            int k = (volume / n) % n; if (k != 0) k = 1;
            int count = 0;
            for (int i=0; i<volume/n; ++i)
            {
                double sum = 0;
                for (int j = 0; j < n; ++j)
                {
                    sum += list[j];
                    if ((i + 1) % n == 0)
                    {
                        hz.Add(sum);
                    }
                    count++;
                }
            }
            double s = 0;
            for (int i=0; i<k; ++i)
            {
                s += list[count + i];
            }
            hz.Add(s);
            start = hz;
        }

        public double GetModa()
        {
            int max = 0;
            double res=0;
            foreach(var i in sample)
            {
                if (i.Value>max)
                {
                    max = i.Value;
                    res = i.Key;
                }
            }
            return res;
        }

        public double GetMediana()
        {
            double k = volume / 2;
            if (k % 2 != 0) return list[(int)k ];
            else return ((list[(int)k]+list[(int)k+1] )/2)-1;
        }

        public double GetAverage()
        {
            double sum = 0;
            foreach(var i in list)
            {
                sum += i;
            }
            sum /= volume;
            return sum;
        }

        public double GetDev()
        {
            double res = 0;
            double avg = GetAverage();
            foreach (var i in sample)
            {
                res += i.Value * Math.Pow(i.Key - avg, 2);
            }
            return res;
        }

        public double GetRozmah()
        {
            return list[list.Count - 1] - list[0];
        }

        public double GetVar()
        {
            return GetDev() / (volume - 1);
        }

        public double GetStandart()
        {
            return Math.Sqrt(GetVar());
        }

        public double GetVariation()
        {
            return GetStandart() / GetAverage();
        }

        public string GetQuant()
        {
            string res = null;
            int index;
            for (int i = 1; i < list.Count; i++)
            {
                index = (i * 100) / list.Count;
                res += "q{" + index.ToString() + "}" + "=X{" + i.ToString() + "}\n";
            }
            return res;
        }

        public string GetQuartile()
        {
            string res = null;
            for (int i = 25; i <= 75; i += 25)
            {
                double temp = (i * list.Count) / 100;
                double a = i*list.Count / 100;
                if (temp % 1 == 0)
                {
                    res += "Q{" + (i / 25).ToString() + "}=X{" + ((double)a).ToString() + "}\n";
                }
            }
            return res;
        }

        public string GetDecel()
        {
            string res = null;
            for (int i = 10; i <= 90; i += 10)
            {
                double temp = (i * list.Count) / 100;
                double a = i * list.Count / 100;
                if (temp % 1 == 0)
                {
                    res += "Q{" + (i / 25).ToString() + "}=X{" + ((double)a).ToString() + "}\n";
                }
            }
            return res;
        }

        public double StartMoment(int n)
        {
            double sum = 0;
            foreach (var i in list)
            {
                sum += Math.Pow(i, n);
            }
            return sum / list.Count;
        }

        public double CentralMoment(double n)
        {
            double a = GetAverage();
            double sum = 0;
            foreach (var i in list)
            {
                sum += Math.Pow(i-a, n);
            }
            return sum / list.Count;
        }

        public double GetAsymmetry()
        {
            double c3 = CentralMoment(3);
            double c2= CentralMoment(2);
            c2 = Math.Pow(c2, 1.5);
            return c3 / c2;
        }

        public double GetExcess()
        {
            double c4 = CentralMoment(4);
            double c2 = CentralMoment(2);
            c2 *= c2;
            return (c4 / c2) - 3;
        }
    }
}
