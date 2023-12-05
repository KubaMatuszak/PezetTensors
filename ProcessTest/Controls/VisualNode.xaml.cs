using ProcessTest.ViewModels;
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

namespace ProcessTest.Controls
{
    /// <summary>
    /// Interaction logic for VisualNode.xaml
    /// </summary>
    public partial class VisualNode : UserControl
    {
        public VisualNode()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nodeVM = DataContext as NodeViewModel;
            if (nodeVM == null)
                return;
            if (nodeVM.IsSelected == false)
                nodeVM.IsSelected = true;
            
        }
    }
}
