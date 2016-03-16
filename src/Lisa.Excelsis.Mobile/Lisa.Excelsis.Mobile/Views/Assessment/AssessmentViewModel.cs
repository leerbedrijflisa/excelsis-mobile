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
        public AssessmentViewModel(INavigation navigation, Page page)
        {
            _Navigation = navigation;
            _Page = page;
            this.ClearAssessment = new Command<AssessmentViewModel>(Clear);
        }

        public ICommand ClearAssessment { get; set; }

       

        public int Id { get; set; }
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

        public ObservationViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;

                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = false;
                }

                _selectedItem = value;
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = true;
                }
            }
        }

        private INavigation _Navigation { get; set; }
        private Page _Page { get; set; }

        private async void Clear(AssessmentViewModel item)
        {
            if (await _Page.DisplayAlert("Alles resetten", "Weet u zeker dat u alles wilt weggooien?", "Ja", "Nee"))
            {
                if (await _Page.DisplayAlert("Alles resetten", "Weet u het heel zeker? ", "Ja", "Nee"))
                {
                    _db.RemoveAssessment(item.Id);

                    _Navigation.InsertPageBefore(new AssessmentPage(), _Page);
                    await _Navigation.PopAsync();
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<CategoryViewModel> _categories;

        private ObservationViewModel _selectedItem;

        private readonly Database _db = new Database();
    }
}