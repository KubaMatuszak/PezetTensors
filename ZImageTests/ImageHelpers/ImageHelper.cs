using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PZControlsWpf.ImageHelpers
{
    public static class ImageHelper
    {


        public static ImageSource ToImageSource(this Bitmap bmp) => ImageHelpers.ImageHelper.ConvertBitmapToImageSource(bmp);

        // Function to convert byte array to ImageSource
        public static byte[] BitmapToByteArray(Bitmap image)
        {
            byte[] imageData = null;

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save the Bitmap image to the stream as a JPEG format
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

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

        public static System.Windows.Media.ImageSource ConvertBitmapToImageSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();

            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );
            }
            catch (Exception ex) { return null; }
            finally
            {
                NativeMethods.DeleteObject(hBitmap);
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
