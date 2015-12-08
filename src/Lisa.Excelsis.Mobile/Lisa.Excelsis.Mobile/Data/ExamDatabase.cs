using SQLite.Net;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class ExamDatabase
    {
        public ExamDatabase()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
        }

        private SQLiteConnection _database;
    }
}