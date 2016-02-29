using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Lisa.Excelsis.Mobile
{
    public class ObservationViewModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Result { get; set; }
        public Criterion Criterion { get; set; }
        public List<string> Marks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

