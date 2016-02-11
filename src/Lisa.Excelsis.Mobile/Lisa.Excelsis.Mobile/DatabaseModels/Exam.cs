using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Exams")]
    public class Examdb
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
		public string NameId { get; set; }
        public int Cohort { get; set; }
        public int Crebo { get; set; }
        public string Subject { get; set; }
		public string SubjectId { get; set; }
    }
}