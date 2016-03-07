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

        public void SelectObservation(ObservationViewModel observation)
        {
            foreach (var category in Categories)
            {
                foreach (var item in category)
                {
                    if (item.Id != observation.Id)
                    {
                        item.IsCellVisible = false;
                    }
                    else
                    {
                        observation.IsCellVisible = !observation.IsCellVisible;
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