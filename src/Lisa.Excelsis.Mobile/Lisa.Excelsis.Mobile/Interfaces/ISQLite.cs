using SQLite.Net;

namespace Lisa.Excelsis.Mobile
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}