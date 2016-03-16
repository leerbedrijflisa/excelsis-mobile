using System;
using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Observations")]
    public class Observationdb
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Result { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Weight { get; set; }
        public int AssessmentId { get; set; }
    }
}

