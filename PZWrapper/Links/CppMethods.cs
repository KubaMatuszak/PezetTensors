using PZWrapper.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Links
{

    /// <summary>
    /// Binding class for C++ methods from dll. 
    /// </summary>
    internal static class CppMethods
    {
        public const string dllPath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\x64\\Debug\\PezetTensors.dll";


        [DllImport(dllPath)]
        public static extern double Sum(int len, double[] values);

        [DllImport(dllPath)]
        public static extern double MultiplyAHSum(int len, double[] doublesA, double[] doublesB);

        [DllImport(dllPath)]
        public static extern IntPtr MultiplyIndiv(int len, double[] doublesA, double[] doublesB);

        [DllImport(dllPath)]
        public static extern IntPtr MatrixMultiply(int nARows, int nAColsBRows, int nBCols, double[] doublesA, double[] doublesB);

        [DllImport(dllPath)]
        public static extern int CreateExpression(int len, OpType[] types, double[] values, OperatorNo[] operators);

        [DllImport(dllPath)]
        public static extern void Inverse256(int len, double[] doubles);
    }
}
