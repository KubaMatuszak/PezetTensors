using PZWrapper.Extensions;
using PZWrapper.Links;
using System;
using System.Collections.Generic;
using SixLabors.ImageSharp; 
using SixLabors.ImageSharp.PixelFormats;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;

namespace PZWrapper.Types
{
    public class Matrix2D : AMatrix, IStrandable
    {
        //public int NRows { get; set; } = 0;
        //public int NCols { get; set; } = 0;
        public double[] Data = new double[0];

        //public int Height { get; set; }
        //public int Width { get; set; }

        public int NoOfDims => 2;


        /// <summary>
        /// Constructor of matrix, given Image_L16.
        /// </summary>
        /// <param name="imageL16"></param>
        public Matrix2D(Image<L16> imageL16)
        {
            NCols = imageL16.Width;
            NRows = imageL16.Height;
            Data = new double[NRows * NCols];
            this.ForEach((r, c) => Data[r*NCols + c] = imageL16[c, r].PackedValue);
        }

        /// <summary>
        /// Constructor of blank matrix of dimensions width x height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Matrix2D(int width, int height)
        {
            NRows = height;
            NCols = width;
            Data = new double[NRows * NCols];
        }

        /// <summary>
        /// Constructor of matrix, given width, height, and values in linear form.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="values"></param>
        public Matrix2D(int height, int width, double[] values) 
        {
            NRows = height;
            NCols = width;
            Data = values; 
        }


        /// <summary>
        /// Constructor of matrix, given values in 2D array.
        /// </summary>
        /// <param name="values"></param>
        public Matrix2D(int[,] values)
        {
            NRows = values.GetLength(0);
            NCols = values.GetLength(1);
            Data = new double[NRows * NCols];
            for (int r = 0; r < NRows; r++)
            {
                for(int c= 0; c < NCols; c++)
                {
                    Data[r * NCols + c] = values[r, c];
                }
            }
            
        }

        public int[] Strand => new int[] { NRows, NCols };

    }


}
