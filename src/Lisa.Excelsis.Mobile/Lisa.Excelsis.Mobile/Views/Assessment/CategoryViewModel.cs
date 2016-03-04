using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Input;

namespace Lisa.Excelsis.Mobile
{
    public class CategoryViewModel : ObservableCollection<ObservationViewModel>
    {
        public string Order { get; set; }
        public string Name { get; set; }       
    }
}

