using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Exam_Category
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public List<Criterion> Criteria { get; set; }
    }
}

