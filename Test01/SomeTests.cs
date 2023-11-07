using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test01
{
    internal static class SomeTests
    {
        private const string dllPath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\x64\\Debug\\PezetTensors.dll";
        static int LocalMethod(MyStruct myStruct)
        {
            int res = 0;
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                    res = i + j;
                }
            }
            return res;
        }


        [DllImport(dllPath)]
        private static extern int CppMethod(MyStruct myStruct);

        [DllImport(dllPath)]
        private static extern double Sum(int len, double[] values);

        private static void Test01()
        {

        }
    }
}
