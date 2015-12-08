using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
#if __ANDROID__
            var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
#else
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
#endif
            var path = Path.Combine(libraryPath, "excelsis.db3");

            var db = new SQLiteConnection(path);

            base.OnStart();
        }
    }
}