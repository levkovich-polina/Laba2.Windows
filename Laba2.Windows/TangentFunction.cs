using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    class TangentFunction : IFunction
    {
        public double Calc(double x)
        {
            return Math.Tan(x);
        }
    }
}