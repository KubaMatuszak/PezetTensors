using PZWrapper.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Types
{
    public class Matrix2D : IStrandable
    {
        public int NRows = 0;
        public int NCols = 0;
        public double[,] Values = new double[0,0];
        public int NoOfDims => 2;

        public Matrix2D(double[,] values) 
        {
            NRows = values.GetLength(0);
            NCols = values.GetLength(1);
            Values = values; 
        }

        public int[] Strand => new int[] { NRows, NCols };


        public override string ToString()
        {
            return base.ToString();
        }

        //TODO Maybe Matrix should be represented linearly.....................
        //TODO maybe Image should have linear repr. also!!!???
        public void Inverse256()
        {
            var lin = Linearize(Values);
            var len = lin.Length;
            CppMethods.Inverse256(len, lin);
            CopyFromLinear(lin);
        }

        public void ToInverse256()
        {
            var lin = Linearize(Values);
           
            var len = lin.Length;
            CppMethods.Inverse256(len, lin);
            CopyFromLinear(lin);
        }

        public double[] Linearize(double[,] data)
        {
            var nCols = data.GetLength(1);
            var nRows = data.GetLength(0);
            var linear = new double[nCols * nRows];
            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    //linear[rowNo * nCols + colNo] = data[colNo, rowNo];
                    linear[rowNo * NCols + colNo] = data[rowNo, colNo] ;
                }
            }
            return linear;
        }

        public void CopyFromLinear(double[] doubles)
        {
            for (int rowNo = 0; rowNo < NRows; rowNo++)
            {
                for (int colNo = 0; colNo < NCols; colNo++)
                {
                    Values[rowNo, colNo] = doubles[rowNo * NCols + colNo];
                }
            }
        }

    }


}
