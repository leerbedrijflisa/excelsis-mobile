using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Observation
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public Criterion Criterion { get; set; }
        public List<string> Marks { get; set; }
    }
}

