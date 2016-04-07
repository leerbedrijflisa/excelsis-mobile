using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class CategoryViewModel
    {      
        public string Order { get; set; }
        public string Name { get; set; }

        public List<ObservationViewModel> Observations { get; set; }
    }
}

