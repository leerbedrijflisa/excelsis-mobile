using SQLite.Net;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Lisa.Excelsis.Mobile.iOS.SQLite_iOS))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, "ExcelsisDb.db3");
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

            return new SQLiteConnection(platform, path);
        }
    }
}