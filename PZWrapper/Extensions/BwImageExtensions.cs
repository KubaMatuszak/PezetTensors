using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Extensions
{
    public static class BwImageExtensions
    {
        public static double ToGrayDouble(this Color col) => (double)(col.R + col.G + col.B) / 3;

        public static Color ToGrayColor(this double v)
        {
            var b = (byte)Math.Max(0, Math.Min(255, v));
            var color = Color.FromArgb(b, b, b);
            return color;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static Bitmap ToBitmap(this Matrix2D bwim)
        {
            Bitmap bitmap = new Bitmap(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => bitmap.SetPixel(c, r, bwim.Data[r, c].ToGrayColor()));
            return bitmap;
        }

        public static Matrix2D ForEachPixChanClone(this Matrix2D bwim, Func<double, double> func)
        {
            Matrix2D cloned = new Matrix2D(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => cloned.Data[r, c] = func.Invoke(r));
            return cloned;
        }

        public static Matrix2D Clone(this Matrix2D bwim)
        {
            Matrix2D cloned = new Matrix2D(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => cloned.Data[r, c] = bwim.Data[r, c]);
            return cloned;
        }

        public static Matrix2D ToMatrix2D(this Matrix2D bwim) => new Matrix2D(bwim.Data);

        public static void ForEach(this Matrix2D bwim, Action<int, int> action)
        {
            for (int rowNo = 0; rowNo < bwim.Height; rowNo++)
                for (int colNo = 0; colNo < bwim.Width; colNo++)
                {
                    action.Invoke(rowNo, colNo);
                }
        }

        public static byte[] ConvertBitmapToAverageByteArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            byte[] byteArray = new byte[width * height]; // Array to hold average values

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    // Calculate the average of the RGB components
                    byte average = (byte)((pixel.R + pixel.G + pixel.B) / 3); // Calculate average

                    // Assign the average to the byte array
                    byteArray[y * width + x] = average;
                }
            }

            return byteArray;
        }



    }
}
