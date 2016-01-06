using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Category
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public IEnumerable<Criterion> Criteria { get; set; }
    }
}