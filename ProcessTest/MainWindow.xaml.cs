using ProcessTest.ViewModels;
using System.Linq;
using System.Windows;

namespace ProcessTest
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var wrkflw = NodeTests.GimmeWorkflow();
            var vm = new WorkflowViewModel(wrkflw);

            //vm.NodeVMs = new System.Collections.ObjectModel.ObservableCollection<NodeViewModel>(
            //                nodeList.Select(n => new NodeViewModel() { XOffset = n.X, YOffset = n.Y }
            //                ));

            //vm.CableVMs = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();

            //foreach (var node in nodeList)
            //    foreach (var ch in node.Children)
            //        vm.CableVMs.Add(new CableViewModel() { XFrom = node.X, YFrom = node.Y, XTo = ch.X, YTo = ch.Y });

            MyNodePresenter.DataContext = vm;
        }
    }
}
