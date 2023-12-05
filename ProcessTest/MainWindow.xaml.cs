using ProcessTest.Controls;
using ProcessTest.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

            //this.DataContext = new NodesPresenterViewModel();


            var vm = this.DataContext as NodesPresenterViewModel;
            var root = NodeTests.GimmeTree();
            var nodeList = root.AsList();

            vm.Nodes = new System.Collections.ObjectModel.ObservableCollection<NodeViewModel>(
                            nodeList.Select(n => new NodeViewModel() { XOffset = n.X, YOffset = n.Y }
                            ));

            vm.Cables = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();
            foreach (var node in nodeList)
            {
                var visNode = new VisualNode();
                //MyCanvas.Children.Add(visNode);
                //Canvas.SetLeft(visNode, node.X);
                //Canvas.SetTop(visNode, node.Y);


                foreach (var ch in node.Children)
                {
                    vm.Cables.Add(new CableViewModel() { XFrom = node.X, YFrom = node.Y, XTo = ch.X, YTo = ch.Y });
                    //continue;
                    //var geom1 = CreateSplineBetweenPoints(
                    //    new Point(node.X + 100, node.Y + 25),
                    //    new Point(ch.X, ch.Y + 25));
                    //Path path = new Path();
                    //path.Stroke = Brushes.RosyBrown;
                    //path.StrokeThickness = 3;
                    //path.Data = geom1;

                    //var geom2 = CreateSplineBetweenPoints(
                    //    new Point(node.X + 100, node.Y + 25),
                    //    new Point(ch.X, ch.Y + 25));
                    //Path path2 = new Path();
                    //path2.Stroke = Brushes.White;
                    //path2.StrokeThickness = 1;
                    //path2.Data = geom2;
                }

            }

        }

        
    }
}
