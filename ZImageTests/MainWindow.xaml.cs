
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
            BWImage bWImage = new BWImage(imagePath);
            var bmp = RunProcess(bWImage);
            //var matrix = bWImage.ToMatrix2D();
            //matrix.Inverse256();
            //BWImage res = new BWImage(matrix);
            //var bmp = res.ToBitmap();
            var src3 = PZControlsWpf.ImageHelpers.ImageHelper.ConvertBitmapToImageSource(bmp.ToBitmap());
            MyZImage.Show(src3);
        }

        private BWImage RunProcess(BWImage bWImage)
        {
            var sdf = StaticPreProcess.Aggregator;
            var res = sdf.ApplyProcess(bWImage);
            return res.ResBwIm;
        }




    }
}
