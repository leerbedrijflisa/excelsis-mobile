using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Observations")]
    public class Observation
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int CriterionId { get; set; }
        public int AssessmentId { get; set; }
    }
}