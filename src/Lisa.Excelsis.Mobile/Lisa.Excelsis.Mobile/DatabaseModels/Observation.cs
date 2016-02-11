using System;
using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Observations")]
    public class Observationdb
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Result { get; set; }
        public int CategoryId { get; set; }
    }
}

