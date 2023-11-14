using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Extensions
{
    public static class MathExt
    {
        public static double Clip(this double val, double min, double max) => val < min? min: val > max? max: val;
        public static double Clip(this float val, float min, float max) => val < min? min: val > max? max: val;
        public static double Clip(this int val, int min, int max) => val < min? min: val > max? max: val;
    }
}
