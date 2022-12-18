using NFun;
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
            var runtime = Funny.Hardcore.Build("y = 2*x+1");
        }
        public string Name => _function;

        public double Calc(double x)
        {

        }
    }
}
