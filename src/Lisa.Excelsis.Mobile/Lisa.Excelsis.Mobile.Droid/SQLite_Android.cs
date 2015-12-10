using SQLite.Net;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Lisa.Excelsis.Mobile.Droid.SQLite_Android))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public SQLiteConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, "ExcelsisDb.db3");

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            return new SQLiteConnection(platform, path);
        }
    }
}