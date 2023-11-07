using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Expressions
{
    public enum OperatorNo
    {
        None = 0,

        // UNARY
        Opp = 1,
        Inv = 2,
        Squ = 10,
        Cub = 11,
        RootSq = 15,
        RootCub = 16,
        LogN = 17,
        ExpN = 18,
        // BINARY
        Add = 5,
        Sub = 6,
        Mul = 7,
        Div = 8,
        Pow = 20,
        Log = 21,
        

    }
}
