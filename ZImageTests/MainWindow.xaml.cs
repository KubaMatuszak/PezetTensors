
using PZWrapper.Types;
using System;
using System.Collections.Generic;
using SixLabors.ImageSharp; 
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PZWrapper.Extensions;

using ZImageTests.Process;
using ZImageTests.Visualisation;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using PZWrapper.Links;
using PZWrapper.Helpers;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.ColorSpaces.Conversion;
using SixLabors.ImageSharp.ColorSpaces;
using PZWrapper.Extensions;
using PZControlsWpf.ImageHelpers;

namespace ZImageTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyProcContainer.DataContext = new VM.Controls.ProcessAggregator_VM(StaticPreProcess.SampleAggregator);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var imagePath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\maxresdefault.jpg";
            Image colorImage = Image<L16>.Load(imagePath);
            var pix = colorImage.PixelType;
            
            var NCols = colorImage.Width;
            var NRows = colorImage.Height;

            var rgb24 = colorImage as Image<Rgb24>;
            var l16 = rgb24.ToL16();

            //var imagePath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\TinyTest.jpg";
            Matrix2D matrix2D = new Matrix2D(l16);
            var res = TestRun(matrix2D);
            var resBmp = res.ToBitmap();
            //var bmp = RunProcess(bWImage);
            ////var matrix = bWImage.ToMatrix2D();
            ////matrix.Inverse256();
            ////BWImage res = new BWImage(matrix);
            ////var bmp = res.ToBitmap();
            //var src3 = PZControlsWpf.ImageHelpers.ImageHelper.ConvertBitmapToImageSource(bmp.ToBitmap());
            //MyZImage.Show(src3);
            BitmapImage bitmapImage = null;
            //var cloned = (colorImage as Image<Rgb24>).Clone();
            var cloned = resBmp.Clone();

            using (var stream = new MemoryStream())
            {
                // Save the ImageSharp image to a stream
                cloned.SaveAsBmp(stream);
                bitmapImage = new BitmapImage();
                // Create a new BitmapImage and set its stream source
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(stream.ToArray());
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                
            }

            MyZImage.Show(bitmapImage);
            //BackJobs.RunAndInformDispatched(Dispatcher ,() => TestRun(matrix2D), (im) => MyZImage.Show(im));

        }
        


        private static void SimpleTestMethod()
        {
            var imagePath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\maxresdefault.jpg";
            Matrix2D bWImage = new Matrix2D(imagePath);

            double[] inputDoubles = bWImage.Data.Linearize();
            int len = inputDoubles.Length;
            IntPtr ptr = CppMethods.ArrayCopy(len, inputDoubles);
            double[] outputDoubles = new double[len];
            Marshal.Copy(ptr, outputDoubles, 0, len);
            // Free unmanaged memory
            Marshal.FreeHGlobal(ptr);
        }

        private Matrix2D TestRun(Matrix2D bWImage)
        {
            var sdf = StaticPreProcess.SampleAggregator;
            var res = sdf.ApplyProcess(bWImage);
            return res.ResBwIm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyProcContainer.DataContext = new VM.Controls.ProcessAggregator_VM(StaticPreProcess.SampleAggregator);
        }
    }
}
