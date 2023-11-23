using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PZWrapper.Extensions;

namespace ZImageTests.GUI.Controls.Elementary.ColorNmsp
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
                var color = MapToColor(currX, 1, 0.5);
                MyBrush.GradientStops.Add(new GradientStop(color, currX));
            }
        }


        public static System.Windows.Media.Color MapToColor(double hue, double sat, double lum)
        {
            hue = hue.Clip(0, 1);
            double r, g, b;
            if (sat == 0)
            {
                r = lum;
                g = lum;
                b = lum;
            }
            else
            {
                double q = lum < 0.5 ? lum * (1 + sat) : lum + sat - lum * sat;
                double p = 2 * lum - q;

                //r = Hue2RgbAdv(p, q, hue + 1.0 / 3);
                //g = Hue2RgbAdv(p, q, hue);
                //b = Hue2RgbAdv(p, q, hue - 1.0 / 3);
                var t = Hue2RGB(hue);
                r = t.r;
                g = t.g;
                b = t.b;
            }

            return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
            
        }

        public static double Hue2RgbAdv(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2) return q;
            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;
            return p;
        }


        public static (double r, double g, double b) Hue2RGB(double hue)
        {
            hue = hue.Clip(0, 1);
            var small = Stops.Where(s => s.stop <= hue).Last();
            var big = Stops.Where(s => s.stop >= hue).First();
            var weight = 6 * (hue - small.stop);


            var meanR = (big.r * weight + small.r * (1 - weight)).Clip(0, 1);
            var meanG = (big.g * weight + small.g * (1 - weight)).Clip(0, 1);
            var meanB = (big.b * weight + small.b * (1 - weight)).Clip(0, 1);
            return (meanR, meanG, meanB);
        }

        public static List<(double stop, double r, double g, double b)> Stops = new List<(double stop, double r, double g, double b)>() 
        {
            (0,            1,   0,   0  ),
            (1/(double)6,  0.7, 0.7, 0  ),
            (1/(double)3,  0,   1,   0  ),
            (1/(double)2,  0,   0.7, 0.7),
            (4/(double)6,  0,   0,   1  ),
            (5/(double)6,  0.7, 0,   0.7),
            (1/(double)1,  1,   0,   0  ),
        };

    }
}
