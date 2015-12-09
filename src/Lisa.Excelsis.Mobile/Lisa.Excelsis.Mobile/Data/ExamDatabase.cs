using SQLite.Net;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class DataBase<T> where T : class
    {
        public DataBase()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<T>();
        }

        private SQLiteConnection _database;
    }
}