using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Students")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int AssessmentId { get; set; }
    }
}