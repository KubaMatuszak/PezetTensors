using PZWrapper.Extensions;
using PZWrapper.Links;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Types
{
    public class Matrix2D : IStrandable
    {
        public int NRows { get; set; } = 0;
        public int NCols { get; set; } = 0;
        public double[,] Data = new double[0,0];

        //public int Height { get; set; }
        //public int Width { get; set; }

        public int NoOfDims => 2;

        /// <summary>
        /// Construct BW image from file.
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix2D(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            Bitmap bitmap = new Bitmap(filename);
            NCols = bitmap.Width;
            NRows = bitmap.Height;
            Data = new double[NRows, NCols];
            this.ForEach((r, c) => Data[r, c] = bitmap.GetPixel(c, r).ToGrayDouble());
        }


        public Matrix2D(int width, int height)
        {
            NRows = height;
            NCols = width;
            Data = new double[NRows, NCols];
        }

        //public Matrix2D(Matrix2D matrix)
        //{
        //    Data = matrix.Data;
        //    NRows = matrix.NRows;
        //    NCols = matrix.NCols;
        //}

        public Matrix2D(double[,] values) 
        {
            NRows = values.GetLength(0);
            NCols = values.GetLength(1);
            Data = values; 
        }

        public int[] Strand => new int[] { NRows, NCols };


        public override string ToString()
        {
            return base.ToString();
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
                    Data[rowNo, colNo] = doubles[rowNo * NCols + colNo];
                }
            }
        }

    }


}
