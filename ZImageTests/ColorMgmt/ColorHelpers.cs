using PZWrapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PZWrapper.ColorMgmt
{
    public static class ColorHelpers
    {

        public static System.Windows.Media.Color MapToColor(double hue, double sat, double lum)
        {
            hue = hue.Clip(0.0D, 1);
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
                var rgbTup = Hue2RGB(hue);
                r = rgbTup.r;
                g = rgbTup.g;
                b = rgbTup.b;
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
            hue = hue.Clip(0.0D, 1);
            var small = Stops.Where(s => s.stop <= hue).Last();
            var big = Stops.Where(s => s.stop >= hue).First();
            var weight = 6 * (hue - small.stop);

            var meanR = (big.r * weight + small.r * (1 - weight)).Clip(0.0D, 1);
            var meanG = (big.g * weight + small.g * (1 - weight)).Clip(0.0D, 1);
            var meanB = (big.b * weight + small.b * (1 - weight)).Clip(0.0D, 1);
            return (meanR, meanG, meanB);
        }

        public static readonly List<(double stop, double r, double g, double b)> Stops = 
            new List<(double stop, double r, double g, double b)>()
            {
                (0.0D,   1.0D, 0.0D, 0.0D),
                (1/6.0D, 1.0D, 1.0D, 0.0D),
                (1/3.0D, 0.0D, 1.0D, 0.0D),
                (1/2.0D, 0.0D, 1.0D, 1.0D),
                (4/6.0D, 0.0D, 0.0D, 1.0D),
                (5/6.0D, 1.0D, 0.0D, 1.0D),
                (1/1.0D, 1.0D, 0.0D, 0.0D),
            };

    }
}

