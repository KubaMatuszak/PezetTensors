
using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PZWrapper.Extensions;
using static System.Net.Mime.MediaTypeNames;
using ZImageTests.Process;
using ZImageTests.Visualisation;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using PZWrapper.Links;
using PZWrapper;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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



            //var imagePath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\maxresdefault.jpg";
            //Matrix2D bWImage = new Matrix2D(imagePath);
            ////var bmp = RunProcess(bWImage);
            //////var matrix = bWImage.ToMatrix2D();
            //////matrix.Inverse256();
            //////BWImage res = new BWImage(matrix);
            //////var bmp = res.ToBitmap();
            ////var src3 = PZControlsWpf.ImageHelpers.ImageHelper.ConvertBitmapToImageSource(bmp.ToBitmap());
            ////MyZImage.Show(src3);

            //var t1 = DateTime.Now;
            //BackJobs.RunAndInformDispatched(Dispatcher ,() => TestRun(bWImage), (im) => MyZImage.Show(im));
            //var t2 = DateTime.Now;
            //var diff = (t2 - t1).TotalMilliseconds;
        }

        private Matrix2D TestRun(Matrix2D bWImage)
        {
            var sdf = StaticPreProcess.SampleAggregator;
            var res = sdf.ApplyProcess(bWImage);
            return res.ResBwIm;
        }




    }
}
