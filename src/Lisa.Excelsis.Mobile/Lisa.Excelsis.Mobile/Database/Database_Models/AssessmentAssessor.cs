using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("AssessmentAssessors")]
    public class AssessmentAssessordb
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int AssessorId { get; set; }
    }
}
