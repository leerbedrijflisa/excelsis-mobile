using Foundation;
using Lisa.Excelsis.Mobile.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (TimePicker), typeof (TimePicker24HRenderer))]

namespace Lisa.Excelsis.Mobile.iOS
{
    public class TimePicker24HRenderer : TimePickerRenderer 
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e) 
        {
            base.OnElementChanged(e);
            var timePicker = (UIDatePicker)Control.InputView;
            timePicker.Locale = new NSLocale("en_US");
        }
    }
}