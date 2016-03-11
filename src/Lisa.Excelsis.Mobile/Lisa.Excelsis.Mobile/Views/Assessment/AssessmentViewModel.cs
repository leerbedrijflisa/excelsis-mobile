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
    public class AssessmentViewModel : INotifyPropertyChanged
    {
        public ICommand SetCellVisible { get; set; }

        public DateTime Assessed { get; set; }
        public Student Student { get; set; }
        public List<Assessor> Assessors { get; set; }
        public Exam Exam { get; set; }
        public ObservableCollection<CategoryViewModel> Categories 
        { 
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<CategoryViewModel> _categories;
    }
}