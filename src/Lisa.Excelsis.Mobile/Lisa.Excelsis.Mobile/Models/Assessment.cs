using SQLite.Net.Attributes;
using System;

namespace Lisa.Excelsis.Mobile
{
    [Table("Assessments")]
    public class Assessment
    {
        public int Id { get; set; }
        public DateTime Assessed { get; set; }
        public string Name { get; set; }
		public string Subject { get; set; }
		public string Cohort { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }

    }
}
