using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
		public int AssessmentId { get; set; }
    }
}