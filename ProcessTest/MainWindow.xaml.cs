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





            return;




            MyCanvas.Children.Clear();




            foreach (var node in nodeList)
            {
                var visNode = new VisualNode();
                MyCanvas.Children.Add(visNode);
                Canvas.SetLeft(visNode, node.X);
                Canvas.SetTop(visNode, node.Y);


                foreach (var ch in node.Children)
                {
                    var geom = CreateSplineBetweenPoints(
                        new Point(node.X + 100, node.Y + 25),
                        new Point(ch.X, ch.Y + 25));
                    Path path = new Path();
                    path.Stroke = Brushes.RosyBrown;
                    path.StrokeThickness = 3;
                    path.Data = geom;
                    MyCanvas.Children.Add(path);

                    geom = CreateSplineBetweenPoints(
                        new Point(node.X + 100, node.Y + 25),
                        new Point(ch.X, ch.Y + 25));
                    Path path2 = new Path();
                    path2.Stroke = Brushes.White;
                    path2.StrokeThickness = 1;
                    path2.Data = geom;
                    MyCanvas.Children.Add(path2);
                }

            }
        }

        public static PathGeometry CreateSplineBetweenPoints(Point startPoint, Point endPoint)
        {
            PathFigure pathFigure = new PathFigure() { StartPoint = startPoint };
            var dx = endPoint.X - startPoint.X;
            var dxAbs = Math.Abs(dx);
            var dy = endPoint.Y - startPoint.Y;
            var beg = dx / 3;
            var rc = new Point(startPoint.X + beg, startPoint.Y);
            var lc = new Point(endPoint.X - beg, endPoint.Y);
            pathFigure.Segments.Add(new BezierSegment(rc, lc, endPoint, true));
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            return pathGeometry;
        }
    }
}
