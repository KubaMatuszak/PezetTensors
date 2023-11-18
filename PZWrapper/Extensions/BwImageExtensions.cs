using PZWrapper.Types;
namespace PZWrapper.Extensions
{
    public static class BwImageExtensions
    {
        public static Image<L16> ToL16(this Image<Rgb24> image)
        {
            // Create an empty image with the same dimensions
            var grayscaleImage = new Image<L16>(image.Width, image.Height);

            // Iterate over each pixel and set its value to the average of RGB channels
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image[x, y];
                    var average = (ushort)(255 * ((pixel.R + pixel.G + pixel.B) / 3));
                    grayscaleImage[x, y] = new L16(average);
                }
            }

            return grayscaleImage;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static Image<SixLabors.ImageSharp.PixelFormats.L16> ToBitmap(this Matrix2D bwim)
        {
            double[] pixelArray = bwim.Data; // Replace this with your actual method to get the L16 pixel array

            // Dimensions of the pixel array
            int height = bwim.NRows;
            int width = bwim.NCols; ;

            // Create a new Image with L16 format
            Image<L16> image = null;

            image = new Image<L16>(width, height);

            // Copy L16 pixel data from the array to the Image
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    L16 pixel = new L16((ushort)pixelArray[r*bwim.NCols + c]);
                    image[c, r] = pixel;
                }
            }
            return image;
        }



        public static Matrix2D ForEachPixChanClone(this Matrix2D bwim, Func<double, double> func)
        {
            Matrix2D cloned = new Matrix2D(bwim.NCols, bwim.NRows);
            bwim.ForEach((r, c) => cloned.Data[r*bwim.NCols + c] = func.Invoke(r));
            return cloned;
        }

        public static Matrix2D Clone(this Matrix2D bwim)
        {
            Matrix2D cloned = new Matrix2D(bwim.NCols, bwim.NRows);
            bwim.ForEach((r, c) => cloned.Data[r * bwim.NCols + c] = bwim.Data[r * bwim.NCols + c]);
            return cloned;
        }



        public static void ForEach(this Matrix2D bwim, Action<int, int> action)
        {
            for (int rowNo = 0; rowNo < bwim.NRows; rowNo++)
                for (int colNo = 0; colNo < bwim.NCols; colNo++)
                {
                    action.Invoke(rowNo, colNo);
                }
        }



    }
}
