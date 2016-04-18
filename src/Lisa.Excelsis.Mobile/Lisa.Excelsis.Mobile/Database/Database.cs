using SQLite.Net;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    partial class Database
    {
        public Database()
        {
        }

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}

