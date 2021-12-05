using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp777
{
    class Equilateral : Triangle
    {
        public double GetArea(int a)
        {
            double p = (a + a + a) / 2.0;
            double area = Math.Round(Math.Sqrt(p * (p - a) * (p - a) * (p - a)), 3);
            if (area == Convert.ToDouble(area))
                return area;
            else
                throw new ArgumentException();
        }
            
        public double GetArea(int a, int b, int c)
        {
            double p = (a + b + c) / 2.0;
            double area = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 3);
            if (area == Convert.ToDouble(area))
                return area;
            else
                throw new ArgumentException();
        }
    }
}