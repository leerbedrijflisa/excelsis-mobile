using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string NameId { get; set; }
        public string Cohort { get; set; }
        public string Crebo { get; set; }
        public string Subject { get; set; }
		public string SubjectId { get; set; }
        
        public List<Exam_Category> Categories { get; set; }
    }
}