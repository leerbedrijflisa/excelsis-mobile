using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
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

        public int Create(T model)
        {
            return _database.Insert(model);
        }

        public int CreateMultiple(IEnumerable<T> models)
        {
            return _database.InsertAll(models);
        }

        public T Get(int id)
        {
            try
            {
                return _database.GetWithChildren<T>(id, true);
            }
            catch(Exception)
            {
                return null;
            }
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

        public void Replace(T model)
        {
            _database.InsertOrReplaceWithChildren(model);
        }
        
        private SQLiteConnection _database;
    }
}