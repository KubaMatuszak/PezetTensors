using PZWrapper.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Links
{

	/// <summary>
	/// Binding class for C++ methods from dll. 
	/// </summary>
	public static class CppMethods
    {
        public const string dllPath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\bin\\PezetTensors.dll";

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

        [DllImport(dllPath)]
        public static extern IntPtr ArrayCopy(int len, double[] doubles);

        [DllImport(dllPath)]
        public static extern IntPtr SampleBlur(int len, double[] doubles);

        [DllImport(dllPath)]
        public static extern IntPtr ReturnDoubleArray(int size);

        [DllImport(dllPath)]
        public static extern IntPtr CroppCutMargin(int width, int height, double[] inVals, int left, int top, int right, int bottom);
        [DllImport(dllPath)]
        public static extern IntPtr GetHistogram(int width, int height, double[] intValues);

        [DllImport(dllPath)]
        public static extern IntPtr Get2DHistogram(int width, int height, double[] intValues);
    }
}
