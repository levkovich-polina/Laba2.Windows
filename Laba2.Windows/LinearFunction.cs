using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    public class LinearFunction : IFunction
    {
        private readonly double _a;
        private readonly double _b;
        public string Name => "2*x+5";
        public LinearFunction(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public double Calc(double x)
        {
            return _a * x + _b;
        }
    }
}