//using Xamarin.Forms.Platform.iOS;
//using Xamarin.Forms;
//using Lisa.Excelsis.Mobile.iOS;
//using Foundation;
//using Lisa.Excelsis.Mobile;
//using UIKit;
//
//[assembly: ExportRenderer(typeof(SpecialListView), typeof(SpecialListViewRenderer))]
//namespace Lisa.Excelsis.Mobile.iOS
//{
//    public class SpecialListViewRenderer : ListViewRenderer
//    {
//        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
//        {
//            base.OnElementChanged (e);
//            var test = NSIndexPath.FromIndex(1);
//            Control.ReloadRows(new NSIndexPath[]{ test }, UIKit.UITableViewRowAnimation.Automatic);           
//        }
//    }
//}