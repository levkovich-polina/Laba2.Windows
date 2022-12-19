using NFun;
using NFun.Runtime;
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
        private FunnyRuntime _runtime;
      
        public CustomFunction(String function)
        {
            _function = function;
            _runtime = Funny.Hardcore.Build($"y:real = {function}");
        }
        public string Name => _function;

        public double Calc(double x)
        {
            _runtime["x"].Value = x;
            _runtime.Run();
            var result = _runtime["y"].Value;
            return (double)result;
        }
    }
}
