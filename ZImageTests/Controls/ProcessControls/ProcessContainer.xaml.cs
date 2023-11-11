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

namespace ZImageTests.Controls.ProcessControls
{
    /// <summary>
    /// Interaction logic for ProcessContainer.xaml
    /// </summary>
    public partial class ProcessContainer : UserControl
    {
        public ProcessContainer()
        {
            InitializeComponent();
        }



        public string AggregatorName
        {
            get { return (string)GetValue(AggregatorNameProperty); }
            set { SetValue(AggregatorNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AggregatorName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AggregatorNameProperty =
            DependencyProperty.Register("AggregatorName", typeof(string), typeof(ProcessContainer), new PropertyMetadata(default));


    }
}
