using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProcessTest.Converters
{
    internal class OffsetToMarginMulticonverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return null;

            if (values.Length < 2)
                return null;
            try
            {
                var left = (double)values[0];
                var top = (double)values[1];
                Thickness thickness = new Thickness(left, top, 0, 0);
                return thickness;
            }
            catch
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
