using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Assessment
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime Assessed { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public IEnumerable<Assessor> Assessors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}