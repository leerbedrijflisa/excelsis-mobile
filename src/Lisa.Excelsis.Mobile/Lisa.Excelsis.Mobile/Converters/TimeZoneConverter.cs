using System;
using Xamarin.Forms;
using System.Globalization;

namespace Lisa.Excelsis.Mobile
{
    public class TimeZoneConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = TimeZoneInfo.ConvertTime((DateTime)value, TimeZoneInfo.Local).Date.ToString("ddd d MMMM yyyy");
            var time = TimeZoneInfo.ConvertTime((DateTime)value, TimeZoneInfo.Local).TimeOfDay.ToString();
            var datetime = date + "  " + time;
            return datetime;
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

    }
}

