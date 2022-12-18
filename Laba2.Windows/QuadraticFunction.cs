using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    class QuadraticFunction : IFunction
    {
        public string Name => "x^2";
        public double Calc(double x)
        {
            return x * x;
        }
    }
}