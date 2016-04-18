using System;
using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Exam_Category")]
    public class Exam_Categorydb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
    }
}

