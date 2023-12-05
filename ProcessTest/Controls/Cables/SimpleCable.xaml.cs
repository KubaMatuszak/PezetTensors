using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            set { SetValue(XinProperty, value); SetGeometries(); }
        }

        // Using a DependencyProperty as the backing store for Xin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XinProperty =
            DependencyProperty.Register("Xin", typeof(double), typeof(SimpleCable), new PropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)
                ));



        public double Yin
        {
            get { return (double)GetValue(YinProperty); }
            set { SetValue(YinProperty, value); SetGeometries(); }
        }

        // Using a DependencyProperty as the backing store for Yin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YinProperty =
            DependencyProperty.Register("Yin", typeof(double), typeof(SimpleCable), new PropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));






        public double Xout
        {
            get { return (double)GetValue(XoutProperty); }
            set { SetValue(XoutProperty, value); SetGeometries(); }
        }

        // Using a DependencyProperty as the backing store for Xout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XoutProperty =
            DependencyProperty.Register("Xout", typeof(double), typeof(SimpleCable), new PropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));





        public double Yout
        {
            get { return (double)GetValue(YoutProperty); }
            set { SetValue(YoutProperty, value); SetGeometries(); }
        }

        // Using a DependencyProperty as the backing store for Yout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YoutProperty =
            DependencyProperty.Register("Yout", typeof(double), typeof(SimpleCable), new PropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));



        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // This method will be called when MyProperty changes
            ((SimpleCable)d).SetGeometries();
        }


        private void SetGeometries()
        {
            var geom1 = CreateSplineBetweenPoints(
                      new Point(Xin + 100, Yin + 25),
                      new Point(Xout, Yout + 25));
            Path1.Data = geom1;

            var geom2 = CreateSplineBetweenPoints(
                      new Point(Xin + 100, Yin + 25),
                      new Point(Xout, Yout + 25));
            Path2.Data = geom2;
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
