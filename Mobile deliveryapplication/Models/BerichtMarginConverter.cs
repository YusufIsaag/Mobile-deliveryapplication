using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace Mobile_deliveryapplication.Models
{
    public class BerichtMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUser = (bool)value;
            return isUser ? new Thickness(50, 5, 0, 5) : new Thickness(0, 5, 50, 5);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
