using SQLite.Net.Attributes;
using System;

namespace Lisa.Excelsis.Mobile
{
    [Table("Assessments")]
    public class Assessment
    {
        public int Id { get; set; }
        public DateTime Assessed { get; set; }

        public int ExamId { get; set; }
    }
}