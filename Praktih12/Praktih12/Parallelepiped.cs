using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktih12
{
    internal class Parallelepiped
    {
        public double Volume(double a, double b, double c)
        {
            return a * b * c;
        }

        public double Area(double a, double b, double c)
        {
            return 2 * (a * b + a * c + c * b);
        }
    }
}
