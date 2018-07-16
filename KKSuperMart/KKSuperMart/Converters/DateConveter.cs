
using KKSuperMart.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace KKSuperMart.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DBNull.Value)
                return string.Empty;
            else
            {
                try
                {
                    DateTime result;
                    if (DateTime.TryParse((value ?? "").ToString(), out result))
                    {
                        return result.ToShortDateString();
                    }
                    else
                    {
                        return value;
                    }
                }catch(Exception e)
                { return value; }
               
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GParse.ToLong(value);
        }
    }
}
