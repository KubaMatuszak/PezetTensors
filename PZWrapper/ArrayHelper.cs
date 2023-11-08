using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper
{
    public static class ArrayHelper
    {
        public static double[,] ReshapeByNinRow(this double[] data, int nCols) 
        {
            var nRows = data.Length / nCols;
            if(data.Length % nCols != 0)
                return null;
            double[,] doubles = new double[nRows, nCols];

            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    doubles[rowNo, colNo] = data[rowNo*nCols + colNo];
                }
            }
            return doubles;
        }

        public static double[] Linearize(this double[,] data)
        {
            var nCols = data.GetLength(1);
            var nRows = data.GetLength(0);
            var linear = new double[nCols * nRows];
            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    var d = data[rowNo, colNo];
                    linear[rowNo * nCols + colNo] = d;
                }
            }
            return linear;
        }
    }
}
