using Lisa.Excelsis.Mobile;
using Lisa.Excelsis.Mobile.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeiOSListViewRenderer))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class NativeiOSListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
            }
        }
	}
}