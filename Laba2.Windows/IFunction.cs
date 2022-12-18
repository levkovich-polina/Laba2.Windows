using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    public  interface IFunction
    {
        double Calc(double x);
        string Name { get; }
    }
}
