using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Table<T> where T : class
    {
        public Table(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<T>();
        }

        public int Insert(T model) => _connection.Insert(model);

        public int InsertMultiple(IEnumerable<T> models) => _connection.InsertAll(models);

        public T Get(int id)
        {
            try
            {
                return _connection.GetWithChildren<T>(id, true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<T> Get() => _connection.GetAllWithChildren<T>();

        public int Delete(int id) => _connection.Delete<T>(id);

        public void DeleteAll() => _connection.DeleteAll<T>();

        public void Replace(T model) => _connection.InsertOrReplaceWithChildren(model);

        private readonly SQLiteConnection _connection;
    }
}