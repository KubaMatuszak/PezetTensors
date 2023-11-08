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

        public static byte[] GetYourImageAsByteArray(int width, int height)
        {
            // 3 colors: Red, Green, Blue
            byte[] data = new byte[width * height * 3]; // 3 bytes per pixel (RGB)

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Calculate the index of the current pixel
                    int index = (y * width + x) * 3;

                    // Assign colors to the image (creating a simple gradient)
                    data[index] = (byte)(255 * x / width);             // Red component
                    data[index + 1] = (byte)(255 * y / height);       // Green component
                    data[index + 2] = (byte)(255 - (255 * x / width)); // Blue component
                }
            }

            return data;
        }


        public static ImageSource ByteArrayToImageSource(byte[] imageData, int width, int height)
        {
            if (imageData == null || imageData.Length == 0)
            {
                // Handle invalid image data
                return null;
            }

            BitmapImage bitmap = new BitmapImage();

            using (MemoryStream stream = new MemoryStream(imageData))
            {
                try
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }

            return bitmap;
        }


        // Function to convert byte array to ImageSource
        public static ImageSource ByteArrayToImageSource(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                // Handle invalid image data
                return null;
            }

            BitmapImage bitmap = new BitmapImage();

            using (MemoryStream stream = new MemoryStream(imageData))
            {
                try
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions (e.g., invalid image format)
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }

            return bitmap;
        }

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
