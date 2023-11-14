
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
using Microsoft.Win32;

namespace ZImageTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path;
        public MainWindow()
        {
            InitializeComponent();
            MyProcContainer.DataContext = new VM.Controls.ProcessAggregator_VM(StaticPreProcess.SampleAggregator);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BlackWhiteProcess();
        }

        private void BlackWhiteProcess()
        {
            var imagePath = _path;// "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\Fennel_in_a_field.jpg";
            if (File.Exists(imagePath) == false)
                return;

            Image colorImage = Image<L16>.Load(imagePath);
            var rgb24 = colorImage as Image<Rgb24>;
            var l16 = rgb24.ToL16();

            //var imagePath = "C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\TinyTest.jpg";
            Matrix2D matrix2D = new Matrix2D(l16);
            BackJobs.RunAndInformDispatched(Dispatcher, () =>
            {
                var sdf = StaticPreProcess.SampleAggregator;
                var res = sdf.ApplyProcess(matrix2D);
                return res.ResBwIm;
            },
                     (im) => MyZImage.Show(im, Stretch.Uniform), asBackground: true);


            var histMatrix = Marshaled.Get2DHistogram(matrix2D);
            MyHistogram.Show(histMatrix, Stretch.Fill);
            var histImage = histMatrix.ToBitmap();
            histImage.SaveAsBmp("C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\Fennel_histo.bmp");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyProcContainer.DataContext = new VM.Controls.ProcessAggregator_VM(StaticPreProcess.SampleAggregator);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png|All Files|*.*",
                Title = "Select an Image File",
                Multiselect = false // Set to true if you want to allow multiple file selection
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                PathTxtBox.Text = openFileDialog.FileName;
                _path = openFileDialog.FileName;
            }
            //Stretch="Fill"
        }
    }
}
