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
            var reshaped = mult.ReshapeByNColWidth(matrixB.NCols);
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
            var reshaped = doubles.ReshapeByNColWidth(linearB.Length);
            Matrix2D resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }


        public static Matrix2D SampleBlur(Matrix2D inputMatrix)
        {
            var inputValues = inputMatrix.Data.Linearize();
            var len = inputValues.Length;
            double[] outputVals = new double[len];
            var res = MarshalHelper.TryPtrToArr(() => CppMethods.SampleBlur(len, inputValues), len, outputVals, null);
            if (res == false)
                throw new Exception("LoL");
            var reshaped = outputVals.ReshapeByNColWidth(inputMatrix.NCols);
            Matrix2D resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }

        public static Matrix2D CroppCutMargin(Matrix2D inM, int left, int top, int right, int bottom)
        {
            var inputValues = inM.Data.Linearize();
            var inLen = inputValues.Length;

            var inW = inM.NCols;
            var inH = inM.NRows;

            var outW = inW - left - right;
            var outH = inH - top - bottom;
            var outLen = outW * outH;

            double[] outputVals = new double[outLen];

            var res = MarshalHelper.TryPtrToArr(() => CppMethods.CroppCutMargin(inM.NCols, inM.NRows, inputValues, left, top, right, bottom), outLen, outputVals, null);
            if (res == false)
                throw new Exception("LoL");
            var reshaped = outputVals.ReshapeByNColWidth(outW);
            Matrix2D resMatrix = new Matrix2D(reshaped);
            return resMatrix;
        }


        public static Matrix2D SquareBlur(Matrix2D inputMatrix, int rad)
        {
            try
            {
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
                var reshaped = doubles.ReshapeByNColWidth(inputMatrix.NCols);
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
