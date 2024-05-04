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
using SixLabors.ImageSharp.Advanced;

namespace PZControlsWpf.ImageHelpers
{
    public static class ImageHelper
    {


        public static ImageSource ToImageSource(this Image<L16> bmp) => bmp.ToBitmapImage();

        static BitmapImage ToBitmapImage(this Image<L16> image)
        {
            using (var stream = new MemoryStream())
            {
                var currDir = Directory.GetCurrentDirectory();
                image.SaveAsBmp(stream);
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
