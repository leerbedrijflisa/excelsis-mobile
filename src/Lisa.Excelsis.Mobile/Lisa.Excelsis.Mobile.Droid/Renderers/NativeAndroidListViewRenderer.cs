using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile;
using Lisa.Excelsis.Mobile.Droid;
using Android.Animation;

[assembly: ExportRenderer (typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
namespace Lisa.Excelsis.Mobile.Droid
{
	public class NativeAndroidListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				// unsubscribe
				Control.ItemClick -= OnItemClick;
			}

			if (e.NewElement != null) {
				// subscribe
				Control.ItemClick += OnItemClick;
			}
		}

		void OnItemClick (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{           
			//((SpecialListView)Element).NotifyItemSelected (((SpecialListView)Element).Items.ToList () [e.Position - 1]);
		}
	}
}