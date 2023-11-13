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
        public Matrix2D(string imagePath)
        {
            Image colorImage = Image<L16>.Load(imagePath);
            colorImage.Mutate(ctx => ctx.BlackWhite());
            var pix = colorImage.PixelType;

            var NCols = colorImage.Width;
            var NRows = colorImage.Height;

            var rgb24 = colorImage as Image<Rgb24>;
            if (rgb24 is null)
                return;
            var l16 = rgb24.ToL16();
        }

        public Matrix2D(Image<L16> imageL16)
        {
            NCols = imageL16.Width;
            NRows = imageL16.Height;
            Data = new double[NRows, NCols];
            this.ForEach((r, c) => Data[r, c] = imageL16[c, r].PackedValue);
        }



        static Image<L16> ConvertToL16(Image<Rgba32> rgbaImage)
        {
            //// Create a new L16 image with the same dimensions
            //Image<L16> l16Image = new Image<L16>(rgbaImage.Width, rgbaImage.Height);

            //// Process each pixel and convert RGBA to L16
            //for (int y = 0; y < rgbaImage.Height; y++)
            //{
            //    Span<Rgba32> rgbaRowSpan = rgbaImage.GetPixelRowSpan(y);
            //    Span<L16> l16RowSpan = l16Image.GetPixelRowSpan(y);

            //    for (int x = 0; x < rgbaImage.Width; x++)
            //    {
            //        // Convert RGBA to luminance (grayscale)
            //        float luminance = rgbaRowSpan[x].R * 0.299f + rgbaRowSpan[x].G * 0.587f + rgbaRowSpan[x].B * 0.114f;

            //        // Convert luminance to L16 format
            //        l16RowSpan[x] = new L16((ushort)(luminance * ushort.MaxValue));
            //    }
            //}

            return null;
        }

        public Matrix2D(int width, int height)
        {
            NRows = height;
            NCols = width;
            Data = new double[NRows, NCols];
        }

        public Matrix2D(double[,] values) 
        {
            NRows = values.GetLength(0);
            NCols = values.GetLength(1);
            Data = values; 
        }

        public int[] Strand => new int[] { NRows, NCols };

    }


}
