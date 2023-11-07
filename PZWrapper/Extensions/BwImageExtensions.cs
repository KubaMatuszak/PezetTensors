using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Extensions
{
    public static class BwImageExtensions
    {
        public static double ToGrayDouble(this Color col) => (double)(col.R + col.G + col.B) / 3;

        public static Color ToGrayColor(this double v)
        {
            var b = (byte)Math.Max(0, Math.Min(255, v));
            var color = Color.FromArgb(b, b, b);
            return color;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static Bitmap ToBitmap(this BWImage bwim)
        {
            Bitmap bitmap = new Bitmap(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => bitmap.SetPixel(c, r, bwim.Data[r, c].ToGrayColor()));
            return bitmap;
        }

        public static BWImage ForEachPixChanClone(this BWImage bwim, Func<double, double> func)
        {
            BWImage cloned = new BWImage(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => cloned.Data[r, c] = func.Invoke(r));
            return cloned;
        }

        public static BWImage Clone(this BWImage bwim)
        {
            BWImage cloned = new BWImage(bwim.Width, bwim.Height);
            bwim.ForEach((r, c) => cloned.Data[r, c] = bwim.Data[r, c]);
            return cloned;
        }

        public static Matrix2D ToMatrix2D(this BWImage bwim) => new Matrix2D(bwim.Data);

        public static void ForEach(this BWImage bwim, Action<int, int> action)
        {
            for (int rowNo = 0; rowNo < bwim.Height; rowNo++)
                for (int colNo = 0; colNo < bwim.Width; colNo++)
                {
                    action.Invoke(rowNo, colNo);
                }
        }

    }
}
