using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PZWrapper.ColorMgmt;
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
                var color = ColorHelpers.MapToColor(currX, 1, 0.5);
                MyBrush.GradientStops.Add(new GradientStop(color, currX));
            }
        }
    }
}
