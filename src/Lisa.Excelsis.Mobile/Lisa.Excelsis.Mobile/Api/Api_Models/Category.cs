using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Category
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public List<Observation> Observations { get; set; }
    }
}

