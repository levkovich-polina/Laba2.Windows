using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    class CustomFunction : IFunction
    {
        private string _function;

        public CustomFunction(String function)
        {
            _function = function;
        }
        public string Name => throw new NotImplementedException();

        public double Calc(double x)
        {

        }
    }
}
