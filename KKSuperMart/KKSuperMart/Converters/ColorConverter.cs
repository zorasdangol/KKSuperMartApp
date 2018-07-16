using KKSuperMart.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace KKSuperMart.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DBNull.Value)
                return "Black";
            else
            {
                if (GParse.ToDecimal(value) == 0)
                    return "Red";
                else
                    return "Green";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GParse.ToLong(value);

        }
    }
}
