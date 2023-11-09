using PZWrapper.Extensions;
using PZWrapper.Types;
using System.Runtime.InteropServices;

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
            var multPtr = CppMethods.MatrixMultiply(2, 2, 2, matrixA.Data.Linearize(), matrixA.Data.Linearize());
            var mult = MarshalHelper.GetFromPtr(4, multPtr);
            var reshaped = mult.ReshapeByNinRow(matrixB.NCols);
            var resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }

        public static Matrix2D MulBy(this Matrix2D matrixA, Matrix2D matrixB)
        {
            var linearB = matrixB.Data.Linearize();
            var linearA = matrixA.Data.Linearize();
            var len = linearB.Length;
            double[] doubles = new double[len];
            var res = MarshalHelper.TryPtrToArr(() => CppMethods.MatrixMultiply(2, 2, 2, linearA, linearB), linearB.Length, doubles, null);
            if (res == false)
                return null;
            var reshaped = doubles.ReshapeByNinRow(linearB.Length);
            Matrix2D resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }


        


        public static Matrix2D SquareBlur(Matrix2D bWImage, int rad)
        {
            try
            {


                var inputMatrix = bWImage.ToMatrix2D();
                var inputLinear = inputMatrix.Data.Linearize();
                var len = inputLinear.Length;
                double[] doubles = new double[100];
                var ptr = CppMethods.ArrayCopy(len, inputLinear);
                if (ptr != IntPtr.Zero)
                {
                 

                    // Copy data from unmanaged memory to managed memory
                    Marshal.Copy(ptr, doubles, 0, len);

                    // Free unmanaged memory when you're done with it
                }
                Marshal.FreeHGlobal(ptr);
                var reshaped = doubles.ReshapeByNinRow(bWImage.Width);
                Matrix2D resMatrix = new Matrix2D(reshaped);
                return resMatrix;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
