using Xamarin.Forms;
using Lisa.Excelsis.Mobile.Droid;
using Lisa.Excelsis.Mobile;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SpecialListView), typeof(SpecialListViewRenderer))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class SpecialListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged (e);
        }
    }
}

