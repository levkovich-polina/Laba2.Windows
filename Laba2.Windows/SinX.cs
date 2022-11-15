using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    class SinX : IFunction
    {
        public double calc(double x)
        {
            return Math.Sin(x);
        }
    }
}