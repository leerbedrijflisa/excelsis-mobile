using System;
using Xamarin.Forms;
using System.Globalization;

namespace Lisa.Excelsis.Mobile
{
    public class ResultConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter as string;
            var result = value as string;

            return (result == param)? result : "_default";
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

    }
}

