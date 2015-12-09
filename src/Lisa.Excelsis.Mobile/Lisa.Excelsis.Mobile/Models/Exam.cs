using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Exams")]
    public class Exam
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cohort { get; set; }
        public int Crebo { get; set; }
        public string Subject { get; set; }
    }
}