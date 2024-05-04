using PZWrapper.Extensions;
using PZWrapper.Helpers;
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


        public static Matrix2D SampleBlur(Matrix2D inputMatrix)
        {
            var inputValues = inputMatrix.Data;
            var len = inputValues.Length;
            double[] outputVals = new double[len];
            var res = MarshalHelper.TryPtrToArr(() => CppMethods.SampleBlur(len, inputValues), len, outputVals, null);
            if (res == false)
                throw new Exception("LoL");
            var reshaped = outputVals;
            Matrix2D resMatrix = new Matrix2D(inputMatrix.NCols, inputMatrix.NRows, reshaped);
            return resMatrix;
        }

        public static Matrix2D CroppCutMargin(Matrix2D inM, int left, int top, int right, int bottom)
        {
            var inputValues = inM.Data;
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
            Matrix2D resMatrix = new Matrix2D(outH, outW, outputVals);
            return resMatrix;
        }


        public static Matrix2D GetHistogram(Matrix2D inM)
        {
            var inputValues = inM.Data;
            var inW = inM.NCols;
            var inH = inM.NRows;

            var outLen = UInt16.MaxValue;//65535 UInt16.MaxValue;


            int[] histogram = new int[outLen];
            var res = MarshalHelper.TryPtrToArr(() => CppMethods.GetHistogram(inW, inH, inputValues), outLen, histogram, null);
            if (res == false) throw new Exception("LoLo");

            var minVal = histogram.Min();
            var maxVal = histogram.Max();
            var reshaped = histogram.ReshapeByNColWidth(inW);
            var reshapedMatrix = new Matrix2D(reshaped);
            return reshapedMatrix;

        }
        
        public static Matrix2D Get2DHistogram(Matrix2D inM)
        {
            var inputValues = inM.Data;
            var inW = inM.NCols;
            var inH = inM.NRows;
            var histLength = inW * 1024;
            double[] histogram = new double[histLength];
            var res = MarshalHelper.TryPtrToArr(() => CppMethods.Get2DHistogram(inW, inH, inputValues), histLength, histogram, null);
            if (res == false) 
                throw new Exception("LoLo");
            return new Matrix2D(1024, inW, histogram); ;
        }


        public static Matrix2D SquareBlur(Matrix2D inputMatrix, int rad)
        {
            try
            {
                var inputLinear = inputMatrix.Data;
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
                var reshaped = doubles;
                Matrix2D resMatrix = new Matrix2D(inputMatrix.NRows, inputMatrix.NCols, reshaped);
                return resMatrix;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
