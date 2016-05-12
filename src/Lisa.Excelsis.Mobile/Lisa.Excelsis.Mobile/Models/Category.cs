using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class ObserveCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Observation> Observations { get; set; }
    }
}

