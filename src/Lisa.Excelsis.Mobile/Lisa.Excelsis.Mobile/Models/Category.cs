﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lisa.Excelsis.Mobile
{
	public class ObserveCategory  : ObservableCollection<ObserveObservation>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

