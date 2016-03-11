using Lisa.Excelsis.Mobile;
using Lisa.Excelsis.Mobile.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(SpecialiOSListViewRenderer))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class SpecialiOSListViewRenderer : ListViewRenderer
	{
        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ListView.SelectedItemProperty.PropertyName)
            {
                Device.BeginInvokeOnMainThread(() => Control.ReloadData());
            }
        }
	}
}