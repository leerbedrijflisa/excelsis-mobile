using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Criteria")]
    public class Criterion
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public int CategoryId { get; set; }
        public int ExamId { get; set; }
    }
}