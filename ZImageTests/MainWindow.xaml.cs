
using Microsoft.Win32;
using PZControlsWpf.Converters;

//using System.Windows.Controls;
using PZWrapper.Extensions;
using PZWrapper.Links;
using PZWrapper.Types;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

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
            //MyProcContainer.DataContext = new VM.Controls.ProcessAggregator_VM(StaticPreProcess.SampleAggregator);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BlackWhiteProcess();
        }

        private void BlackWhiteProcess()
        {
            var imagePath = _path;
            if (File.Exists(imagePath) == false)
                return;

            Image colorImage = Image<L16>.Load(imagePath);

            var bitsPerPix = colorImage.PixelType.BitsPerPixel;
            var rgb24 = colorImage as Image<Rgb24>;
            var l16 = rgb24.ToL16();



            Matrix2D matrix2D = new Matrix2D(l16);

            var histMatrix = Marshaled.Get2DHistogram(matrix2D);
            MessageBox.Show("Code for showing is commented out.....");
            //MyHistogram.Show(histMatrix, Stretch.Fill);
            var histImage = histMatrix.ToBitmap();
            //histImage.SaveAsBmp("C:\\Users\\rpeze\\source\\repos\\PezetTensors\\ZImageTests\\TestImages\\Fennel_histo.bmp");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CppMethods.Init();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png|All Files|*.*",
                Title = "Select an Image File",
                Multiselect = false // Set to true if you want to allow multiple file selection
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            PathTxtBox.Text = openFileDialog.FileName;
            _path = openFileDialog.FileName;
            var imagePath = _path;
            if (File.Exists(imagePath) == false)
                return;

            Image<Rgb24> rgb24 = null;
            using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
            {
                rgb24 = image.CloneAs<Rgb24>();
            }

            if(rgb24 == null)
            {
                MessageBox.Show("rgb24 is null!");
                return;
            }

            var l16 = rgb24.ToL16();
            Matrix2D matrix2D = new Matrix2D(l16);

            var histMatrix = Marshaled.Get2DHistogram(matrix2D);

            var min = histMatrix.Data.Min();
            var max = histMatrix.Data.Max();


            var imgSrc = AutoConverter.ConvChain.Convert<Matrix2D, ImageSource>(histMatrix);
            MyZImage.Show(imgSrc, Stretch.Fill);
            var histImage = histMatrix.ToBitmap();
            
        }
    }
}
