using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    [Table("Exams")]
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cohort { get; set; }
        public int Crebo { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
    }
}