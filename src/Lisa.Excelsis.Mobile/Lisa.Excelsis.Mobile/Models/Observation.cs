using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Observation
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Result { get; set; }
        public Criterion Criterion { get; set; }
        public IEnumerable<string> Marks { get; set; }
    }
}