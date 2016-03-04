using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Input;

namespace Lisa.Excelsis.Mobile
{
    public class ObservationViewModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Result { get; set; }
        public Criterion Criterion { get; set; }
        public List<string> Marks { get; set; }

        public bool IsCellVisible
        { 
            get { return _IsCellVisible; } 
            set
            {
                if (_IsCellVisible != value)
                {
                    _IsCellVisible = value;
                    OnPropertyChanged("IsCellVisible");
                }
            }
        }
        private bool _IsCellVisible;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

