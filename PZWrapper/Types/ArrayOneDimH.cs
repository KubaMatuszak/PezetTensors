using System.Runtime.InteropServices;

namespace PZWrapper.Types
{
    /// <summary>
    /// Representation of vertical array of double.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ArrayOneDimH : IStrandable
    {
        public double[] Values = new double[0];
        public int Size = 0;
        public ArrayOneDimH(double[] inValues)
        {
            if (inValues == null)
                throw new ArgumentNullException(nameof(inValues));
            Values = inValues;
            Size = inValues.Length;
        }
        public ArrayOneDimH() { }
        public int NoOfDims => 1;
        public int[] Strand => new int[] { Size };

    }


}
