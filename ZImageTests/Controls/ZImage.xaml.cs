using System;
using System.Collections.Generic;
using System.Drawing;
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
using PZControlsWpf.Converters;
using PZWrapper.Types;
using static System.Net.Mime.MediaTypeNames;

namespace ZImageTests.Controls
{
    /// <summary>
    /// Interaction logic for ZImage.xaml
    /// </summary>
    public partial class ZImage : UserControl
    {
        public ZImage()
        {
            InitializeComponent();
        }

        public void Show(Matrix2D image) { ZImageDisp.Source = AutoConverter.ConvChain.Convert<Matrix2D, ImageSource>(image); }
        public void Show(ImageSource imageSource) { ZImageDisp.Source = imageSource; }

    }
}
