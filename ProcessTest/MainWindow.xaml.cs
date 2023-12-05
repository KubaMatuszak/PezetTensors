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
            var vm = this.DataContext as NodesPresenterViewModel;
            var root = NodeTests.GimmeTree();
            var nodeList = root.AsList();

            vm.Nodes = new System.Collections.ObjectModel.ObservableCollection<NodeViewModel>(
                            nodeList.Select(n => new NodeViewModel() { XOffset = n.X, YOffset = n.Y }
                            ));

            vm.Cables = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();

            foreach (var node in nodeList)
                foreach (var ch in node.Children)
                    vm.Cables.Add(new CableViewModel() { XFrom = node.X, YFrom = node.Y, XTo = ch.X, YTo = ch.Y });

            MyNodePresenter.DataContext = vm;
        }
    }
}
