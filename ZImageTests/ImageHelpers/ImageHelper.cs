using System;
using System.Collections.Generic;
using SixLabors.ImageSharp; 
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Collections;

namespace PZControlsWpf.ImageHelpers
{
    public static class ImageHelper
    {


        public static ImageSource ToImageSource(this Image<L16> bmp) => bmp.ToBitmapImage();

        // Function to convert byte array to ImageSource
        public static byte[] BitmapToByteArray(Image<L16> image)
        {
            byte[] imageData = null;

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save the Bitmap image to the stream as a JPEG format
                    SixLabors.ImageSharp.Formats.ImageEncoder imageEncoder = new JpegEncoder();
                    image.Save(stream, imageEncoder);

                    // Get the bytes from the stream
                    imageData = stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle any potential exceptions
                Console.WriteLine("Error: " + ex.Message);
            }

            return imageData;
        }


        static BitmapImage ToBitmapImage(this Image<L16> image)
        {
            
            using (var stream = new MemoryStream())
            {
                // Save the ImageSharp image to a stream
                image.SaveAsBmp(stream);

                // Create a new BitmapImage and set its stream source
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(stream.ToArray());
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            internal static extern bool DeleteObject(IntPtr hObject);
        }
    }
}
