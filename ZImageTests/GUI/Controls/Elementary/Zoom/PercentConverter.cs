using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZImageTests.GUI.Controls.Elementary.Zoom
{
    public class PercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value == null ? null : value is double ? $"{value} %" : "100 %";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 100;
            if (value is string)
            {
                var str = value as string;
                var sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                var sub = str.Replace(" ", "").Replace("%", "").Replace(sep, ".");
                if (double.TryParse(sub, out var percentage))
                    return percentage;
            }

            return 100;
        }
    }
}
