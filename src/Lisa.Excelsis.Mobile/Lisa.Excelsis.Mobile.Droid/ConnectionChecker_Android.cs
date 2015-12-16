using Android.Content;
using Android.Net;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile.Droid;

[assembly: Dependency(typeof(ConnectionChecker_Android))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class ConnectionChecker_Android
    {
        public ConnectionChecker_Android() { }

        public bool IsOnline()
        {
            ConnectivityManager cm = (ConnectivityManager) Android.App.Application.Context.GetSystemService(Context.ConnectivityService);

            var netInfo = cm.ActiveNetworkInfo;

            return netInfo != null && netInfo.IsConnectedOrConnecting;
        }
    }
}