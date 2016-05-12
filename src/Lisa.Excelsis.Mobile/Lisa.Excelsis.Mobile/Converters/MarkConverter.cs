using System;
using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lisa.Excelsis.Mobile
{
    public class MarkConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mark = (bool) value;
            var param = parameter as string;

            return (mark)? param + "_COLOR" : param;
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

    }
}

