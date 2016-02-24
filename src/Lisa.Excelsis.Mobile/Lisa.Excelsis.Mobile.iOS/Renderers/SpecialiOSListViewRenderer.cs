[assembly: ExportRenderer (typeof(SpecialistView), typeof(SpecialiOSListViewRenderer))]
namespace CustomRenderer.iOS
{
	public class SpecialiOSListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			
		}
	}
}