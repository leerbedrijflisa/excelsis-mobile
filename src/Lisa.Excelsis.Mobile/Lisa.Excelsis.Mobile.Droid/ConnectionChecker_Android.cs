using Android.Content;
using Android.Net;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile.Droid;

[assembly: Dependency(typeof(ConnectionChecker_Android))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class ConnectionChecker_Android : IConnectionChecker
    {
        public ConnectionChecker_Android() { }

        public bool IsOnline()
        {
            var connectivityManager = (ConnectivityManager) Android.App.Application.Context.GetSystemService(Context.ConnectivityService);

            var netInfo = connectivityManager.ActiveNetworkInfo;

            return netInfo != null && netInfo.IsConnected;
        }
    }
}