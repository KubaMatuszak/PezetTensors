
using PZWrapper;
using PZWrapper.Expressions;
using PZWrapper.Links;
using PZWrapper.Types;
using System.Runtime.InteropServices;

namespace Test01
{

    internal class Program
    {





        static void Main(string[] args)
        {
            //ExprExtensions.Test();
            //return;



            var inputs = new double[] { 0, 1, 2, 3, 4 };
            ArrayOneDimV arrayOneDimV = new ArrayOneDimV(new double[] { 0, 1, 2, 3, 4 });
            ArrayOneDimH arrayOneDimH = new ArrayOneDimH(new double[] { 0, 1, 2, 3, 4 });
            //var multPtr = CppMethods.MatrixMultiply(2, 2, 2, new double[] { 0, 1, 2, 3 }, new double[] { 0, 1, 2, 3 });
            //var mult = MarshalHelper.GetFromPtr(4, multPtr);

            var multiplied = (new Matrix2D(new double[,] { { 1, 2 }, { 3, 4 } }).MulBy(new Matrix2D(new double[,] { { 1, 2 }, { 3, 4 } })));
            var res = arrayOneDimH * arrayOneDimV;
            Console.WriteLine(res);
            var resArr = arrayOneDimV * arrayOneDimV;
            Console.ReadLine();
        }

        
    }

}