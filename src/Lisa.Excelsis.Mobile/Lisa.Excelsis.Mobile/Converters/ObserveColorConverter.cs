using System;
using Xamarin.Forms;
using System.Globalization;

namespace Lisa.Excelsis.Mobile
{
    public class ObserveColorConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        { 
            var item = (ObservationViewModel)value;
            if (item.Maybe_Not || item.Change || item.Skip || item.Unclear)
            {
                return Color.Maroon;
            }
            else if (item.Result == "notrated")
            {
               return Color.Gray;
            }
            else
            {
                return (item.Result == "seen") ? Color.Green : Color.Red;
            }
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}

