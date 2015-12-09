using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Database<T> where T : class
    {
        public Database()
        {
            _database = Xamarin.Forms.DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<T>();
        }

        public void Create(T model)
        {
            _database.InsertWithChildren(model);
        }

        public T Get(int id)
        {
            return _database.GetWithChildren<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return _database.GetAllWithChildren<T>();
        }

        public int Delete(int id)
        {
            return _database.Delete<T>(id);
        }

        public void DeleteAll()
        {
            _database.DeleteAll<T>();
        }

        private SQLiteConnection _database;
    }
}