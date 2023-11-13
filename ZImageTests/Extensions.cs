using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZImageTests
{
    public static class Extensions
    {
        static BitmapImage ConvertToImageSource(Image<Rgba32> image)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {
                // Save the ImageSharp image to a MemoryStream in a format supported by BitmapImage
                image.SaveAsBmp(memoryStream);

                // Create a BitmapImage and set its source to the MemoryStream
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new System.IO.MemoryStream(memoryStream.ToArray());
                bitmapImage.EndInit();

                // Freeze the BitmapImage to make it usable on a different thread (if needed)
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
