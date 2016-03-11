using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace Lisa.Excelsis.Mobile
{
    public class CategoryViewModel : ObservableCollection<ObservationViewModel>
    {

        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Order { get; set; }
        public string Name { get; set; } 

        public ObservableCollection<ObservationViewModel> Observations
        {
            get { return _observations; }
            set
            {
                _observations = value;
                OnPropertyChanged("Observations");
            }
        }

        public ObservationViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem == value)
                    return;
                if(_selectedItem != null)
                {
                    _selectedItem.IsSelected = false;
                }

                _selectedItem = value;
                if(_selectedItem != null)
                {
                    _selectedItem.IsSelected = true;
                }
            }
        }

        private ObservationViewModel _selectedItem;
        private ObservableCollection<ObservationViewModel> _observations;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

