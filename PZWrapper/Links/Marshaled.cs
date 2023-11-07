using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Links
{
    /// <summary>
    /// Class unwraps 
    /// </summary>
    public static class Marshaled
    {

        /*
         * Notation [a,b,c....i] mans 'i' is number of column
         */

        public static Matrix2D MulBy2(this Matrix2D matrixA, Matrix2D matrixB)
        {
            var multPtr = CppMethods.MatrixMultiply(2, 2, 2, matrixA.Values.Linearize(), matrixA.Values.Linearize());
            var mult = MarshalHelper.GetFromPtr(4, multPtr);
            var reshaped = mult.Reshape(matrixB.NCols);
            var resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }

        public static Matrix2D MulBy(this Matrix2D matrixA, Matrix2D matrixB)
        {
            var linearB = matrixB.Values.Linearize();
            var linearA = matrixA.Values.Linearize();
            var len = linearB.Length;
            double[] doubles = new double[len];
            var res = MarshalHelper.TryPtrToDoubleArr(() => CppMethods.MatrixMultiply(2, 2, 2, linearA, linearB), linearB.Length, doubles, null);
            if (res == false)
                return null;
            var reshaped = doubles.Reshape(linearB.Length);
            Matrix2D resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }



    }
}
