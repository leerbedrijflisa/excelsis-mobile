using Lisa.Excelsis.Mobile.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionChecker_iOS))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class ConnectionChecker_iOS : IConnectionChecker
    {
        public ConnectionChecker_iOS() { }

        public bool IsOnline()
        {
            return Reachability.Reachability.IsHostReachable("http://google.com");
        }
    }
}