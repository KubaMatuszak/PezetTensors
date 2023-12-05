using System;
using System.Collections.Generic;
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

namespace ProcessTest.Controls.Cables
{
    /// <summary>
    /// Interaction logic for SimpleCable.xaml
    /// </summary>
    public partial class SimpleCable : UserControl
    {
        public SimpleCable()
        {
            InitializeComponent();
        }



        public double Xin
        {
            get { return (double)GetValue(XinProperty); }
            set { SetValue(XinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Xin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XinProperty =
            DependencyProperty.Register("Xin", typeof(double), typeof(SimpleCable), new PropertyMetadata(0));




        public double Yin
        {
            get { return (double)GetValue(YinProperty); }
            set { SetValue(YinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Yin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YinProperty =
            DependencyProperty.Register("Yin", typeof(double), typeof(SimpleCable), new PropertyMetadata(0));






        public double Xout
        {
            get { return (double)GetValue(XoutProperty); }
            set { SetValue(XoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Xout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XoutProperty =
            DependencyProperty.Register("Xout", typeof(double), typeof(SimpleCable), new PropertyMetadata(0));





        public double Yout
        {
            get { return (double)GetValue(YoutProperty); }
            set { SetValue(YoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Yout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YoutProperty =
            DependencyProperty.Register("Yout", typeof(double), typeof(SimpleCable), new PropertyMetadata(0));








    }
}
