using System;
using System.Runtime.InteropServices;
using PZWrapper.Helpers;
using PZWrapper.Links;

namespace PZWrapper.Types
{
    /// <summary>
    /// Representation of vertical array of double.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ArrayOneDimV : IStrandable
    {
        public double[] Values = new double[0];
        public int Size = 0;
        public ArrayOneDimV(double[] inValues)
        {
            if (inValues == null)
                throw new ArgumentNullException(nameof(inValues));
            Values = inValues;
            Size = inValues.Length;
        }
        public ArrayOneDimV() { }
        public int NoOfDims => 1;
        public int[] Strand => new int[] { 1 };
        public static double operator *(ArrayOneDimH a, ArrayOneDimV b)
        => CppMethods.MultiplyAHSum(Math.Min(a.Size, b.Size), a.Values, b.Values);

        public static ArrayOneDimV operator *(ArrayOneDimV a, ArrayOneDimV b)
        {
            var minLen = Math.Min(a.Size, b.Size);
            IntPtr arrayPtr = CppMethods.MultiplyIndiv(minLen, a.Values, b.Values);
            double[] managedArray = MarshalHelper.GetFromPtr(minLen, arrayPtr);
            return new ArrayOneDimV(managedArray);
        }


    }


}
