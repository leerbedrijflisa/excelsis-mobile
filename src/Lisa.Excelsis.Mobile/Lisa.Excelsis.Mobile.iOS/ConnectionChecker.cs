using Lisa.Excelsis.Mobile.iOS;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionChecker))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class ConnectionChecker : IConnectionChecker
    {
        public bool IsOnline()
        {
            return Reachability.Reachability.IsHostReachable("http://google.com");
        }
    }
}
