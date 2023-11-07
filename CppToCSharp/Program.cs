using System.Runtime.InteropServices;

namespace CppToCSharp
{
    internal class Program
    {
        private const string dllPath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\x64\\Debug\\MyDll.dll";

        [StructLayout(LayoutKind.Sequential)]
        class MyStruct
        {
            public int a;
            public char b;
        }


        [DllImport(dllPath)]
        private static extern int CppTestFunc();

        static void Main(string[] args)
        {
            var valueFromCpp = CppTestFunc();
            Console.WriteLine("Hello, World!");
        }
    }
}