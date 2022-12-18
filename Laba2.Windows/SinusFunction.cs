using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    class SinusFunction : IFunction
    {
        public string Name => "sin(x)";
        public double Calc(double x)
        {
            return Math.Sin(x);
        }
    }
}