
using KKSuperMart.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace KKSuperMart.Converters
{
   
    public class HideZeroConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DBNull.Value)
                return string.Empty;
            if (GParse.ToDecimal(value) == 0)
                return string.Empty;
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GParse.ToLong(value);
        }
    }

    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DBNull.Value)
                return string.Empty;
            else
            {
                double val = Math.Round(GParse.ToDouble(value), 3);
                return val;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GParse.ToLong(value);
           
        }
    }


}
