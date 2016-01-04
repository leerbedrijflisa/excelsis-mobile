using Lisa.Excelsis.Mobile.iOS;
using Xamarin.Forms;
using System.Net;
using SystemConfiguration;

[assembly: Dependency(typeof(ConnectionChecker_iOS))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class ConnectionChecker_iOS : IConnectionChecker
    {
        public ConnectionChecker_iOS() { }

        public bool IsOnline()
        {
            NetworkReachabilityFlags flags;

            var networkReachability = new NetworkReachability(new IPAddress(0));

            return networkReachability.TryGetFlags(out flags) &&
                IsReachableWithoutRequiringConnection(flags);
        }

        private bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            var isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            var noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                noConnectionRequired = true;
            }

            return isReachable && noConnectionRequired;
        }
    }
}