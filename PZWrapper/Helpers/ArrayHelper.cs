using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Helpers
{
    public static class ArrayHelper
    {


        public static double[,] ReshapeByNColWidth(this double[] data, int nCols)
        {
            var nRows = data.Length / nCols;
            if (data.Length % nCols != 0)
                return null;
            double[,] res2DArr = new double[nRows, nCols];

            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    res2DArr[rowNo, colNo] = data[rowNo * nCols + colNo];
                }
            }
            return res2DArr;
        }

        public static int[,] ReshapeByNColWidth(this int[] data, int nCols)
        {
            var nRows = data.Length / nCols;
            if (data.Length % nCols != 0)
                return null;
            int[,] res2DArr = new int[nRows, nCols];

            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    res2DArr[rowNo, colNo] = data[rowNo * nCols + colNo];
                }
            }
            return res2DArr;
        }



        public static double[] Linearize(this double[,] in2DArr)
        {
            var nCols = in2DArr.GetLength(1);
            var nRows = in2DArr.GetLength(0);
            var linear = new double[nCols * nRows];
            var len = nCols * nRows;

            for (int rowNo = 0; rowNo < nRows; ++rowNo)
            {
                for (int colNo = 0; colNo < nCols; ++colNo)
                {
                    var d = in2DArr[rowNo, colNo];
                    linear[rowNo * nCols + colNo] = d;
                }
            }
            return linear;
        }
    }
}
