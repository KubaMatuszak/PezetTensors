using System;
using System.Windows;
using System.Windows.Controls;

namespace ZImageTests.GUI.Controls.Elementary.Color
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var width = MyColorCanvas.ActualWidth;
            var height = MyColorCanvas.ActualHeight;
            MyBrush.GradientStops.Clear();
            for (int col = 0; col < width; col++)
            {
                var currX = col / width;
                MyBrush.GradientStops.Add(new System.Windows.Media.GradientStop(MapToColor(currX), currX));
                for (int row = 0; row < height; row++)
                {

                    //Ellipse point = new Ellipse() { Width = 2, Height = 2 };
                    //Canvas.SetLeft(point, 150);
                    //Canvas.SetTop(point, 75);
                    //MyColorCanvas.Children.Add(point);
                }
            }
        }


        public static System.Windows.Media.Color MapToColor(double value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 1.");
            }

            // Map the value to a hue between 0 and 360 (360 degrees in the color wheel)
            double hueAngle = value < 0? 0: value > 1? 360: value * 360;

            // Create a Color using the HSL color space
            double h = hueAngle, sat = 1, lum = 0.5;
            h /= 360;

            double r, g, b;

            if (sat == 0)
            {
                r = g = b = lum; // achromatic
            }
            else
            {
                

                double q = lum < 0.5 ? lum * (1 + sat) : lum + sat - lum * sat;
                double p = 2 * lum - q;

                r = Hue2Rgb(p, q, h + 1.0 / 3);
                g = Hue2Rgb(p, q, h);
                b = Hue2Rgb(p, q, h - 1.0 / 3);
            }

            return System.Windows.Media.Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
            
        }

        public static double Hue2Rgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2) return q;
            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;
            return p;
        }

        //private static System.Windows.Media.Color HslToRgb(double h, double sat, double lum)
        //{
        //    h /= 360;

        //    double r, g, b;

        //    if (sat == 0)
        //    {
        //        r = g = b = lum; // achromatic
        //    }
        //    else
        //    {
        //        double Hue2Rgb(double p, double q, double t)
        //        {
        //            if (t < 0) t += 1;
        //            if (t > 1) t -= 1;
        //            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
        //            if (t < 1.0 / 2) return q;
        //            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;
        //            return p;
        //        }

        //        double q = lum < 0.5 ? lum * (1 + sat) : lum + sat - lum * sat;
        //        double p = 2 * lum - q;

        //        r = Hue2Rgb(p, q, h + 1.0 / 3);
        //        g = Hue2Rgb(p, q, h);
        //        b = Hue2Rgb(p, q, h - 1.0 / 3);
        //    }

        //    return System.Windows.Media.Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        //}

    }
}
