using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Assessment
    {
        public int Id { get; set; }
        public DateTime Assessed { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public List<Assessor> Assessors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
