using Android.Content;
using Android.Net;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile.Droid;

[assembly: Dependency(typeof(ConnectionChecker))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class ConnectionChecker
    {
        public ConnectionChecker() { }

        public bool IsOnline()
        {
            ConnectivityManager cm = (ConnectivityManager) Android.App.Application.Context.GetSystemService(Context.ConnectivityService);

            var netInfo = cm.ActiveNetworkInfo;

            return netInfo != null && netInfo.IsConnectedOrConnecting;
        }
    }
}