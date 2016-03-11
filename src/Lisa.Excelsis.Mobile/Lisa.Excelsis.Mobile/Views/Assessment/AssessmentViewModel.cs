using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Input;

namespace Lisa.Excelsis.Mobile
{
    public class AssessmentViewModel : INotifyPropertyChanged
    {

        public AssessmentViewModel()
        {
            this.SetCellVisible = new Command<ObservationViewModel>(SelectObservation);
        }

        public ICommand SetCellVisible { get; set; }

        public DateTime Assessed { get; set; }
        public Student Student { get; set; }
        public List<Assessor> Assessors { get; set; }
        public Exam Exam { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        private ObservableCollection<ObservationViewModel> _observations;
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


        public void SelectObservation(ObservationViewModel observation)
        {
            foreach (var category in Categories)
            {
                foreach (var item in category)
                {
                    if (item.Id != observation.Id)
                    {
                        item.IsSelected = false;
                    }
                    else
                    {
                        observation.IsSelected = !observation.IsSelected;
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}