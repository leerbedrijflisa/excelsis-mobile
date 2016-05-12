using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

namespace Lisa.Excelsis.Mobile
{
    public class AssessmentViewModel : BindableObject
    {
        public AssessmentViewModel(INavigation navigation, Page page)
        {
            _Navigation = navigation;
            _Page = page;
            CloseInfo = new Command(CloseInfoPopup);
            OpenFeedback = new Command(ToggleFeedback);
            CloseFeedback = new Command(ToggleFeedback);
        }

        public ICommand OpenFeedback { get; set; }
        public ICommand CloseFeedback { get; set; }
        public ICommand CloseInfo { get; set; }
        
        public event TogglePopupEventHandler OnTogglePopup;

        public int Id { get; set; }
        public DateTime Assessed { get; set; }
        public Student Student { get; set; }
        public List<Assessor> Assessors { get; set; }
        public Exam Exam { get; set; }
        public List<CategoryViewModel> Categories 
        { 
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            } 
        }

        public int TotalFail
        {
            get { return _totalFail; }
            set
            {
                if (_totalFail != value)
                {
                    _totalFail = value;
                    OnPropertyChanged("TotalFail");
                }
            }
        }

        public int TotalPass
        {
            get { return _totalPass; }
            set
            {
                if (_totalPass != value)
                {
                    _totalPass = value;
                    OnPropertyChanged("TotalPass");
                }
            }
        }

        public int TotalExcellent
        {
            get { return _totalExcellent; }
            set
            {
                if (_totalExcellent != value)
                {
                    _totalExcellent = value;
                    OnPropertyChanged("TotalExcellent");
                }
            }
        }

        public void ToggleFeedback()
        {
            OnTogglePopup("feedback");
        }


        public void CloseInfoPopup()
        {
            OnTogglePopup("info", null);
        }
        
        private int _totalFail = 0;
        private int _totalPass = 0;
        private int _totalExcellent = 0;

        private INavigation _Navigation { get; set; }
        private Page _Page { get; set; }

        private List<CategoryViewModel> _categories;

        private readonly Database _db = new Database();
    }
}