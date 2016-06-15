using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage (Assessmentdb item = null, Exam exam = null)
        {
            if (item != null)
            {
                assessment = _db.FetchAssessment(item.Id);
                if (assessment == null)
                {
                    Navigation.PopAsync();
                }
            }
            else
            {
                var id = _db.InsertAssessment(exam);
                assessment = _db.FetchAssessment(id);
            }

            InitializeComponent();
            Title = assessment.Exam.Subject + " - " + assessment.Exam.Name + " " + assessment.Exam.Cohort;

            assessmentView = new AssessmentViewModel(this.Navigation, this)
            {
                Id = assessment.Id,
                Assessed = assessment.Assessed,
                Assessors = assessment.Assessors,
                Student = assessment.Student,
                Exam = assessment.Exam
            };

            assessmentView.Categories = new List<CategoryViewModel>();
            foreach (var categories in assessment.Categories)
            {
                var _category = new CategoryViewModel()
                {
                    Order = categories.Order.ToString(),
                    Name = categories.Name
                };

               _category.Observations = new List<ObservationViewModel>();
                foreach (var observations in categories.Observations)
                {
                    var _observation = new ObservationViewModel()
                    {
                        Id = observations.Id.ToString(),
                        Result = observations.Result,
                        Criterion = observations.Criterion,
                        Maybe_Not = observations.Marks.Contains("maybenot"),
                        Skip = observations.Marks.Contains("skip"),
                        Unclear = observations.Marks.Contains("unclear"),
                        Change = observations.Marks.Contains("change")
                    };
                    UpdateFooter(_observation, "notrated");     
                    _observation.OnResultChanged += UpdateFooter;
                    _observation.OnToggleChanged += ToggleItem;
                    _observation.ChangeObserveColor();
                    _category.Observations.Add(_observation);
                }
                assessmentView.Categories.Add(_category);
            }

            BindingContext = assessmentView;       
        }

        public void UpdateFooter(ObservationViewModel item, string result)
        {
            switch(item.Criterion.Weight)
            {
                case "fail":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalFail--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalFail++;
                    }
                    break;
                case "pass":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalPass--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalPass++;
                    }
                    break;
                case "excellent":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalExcellent--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalExcellent++;
                    }
                    break;
            }
        }
        
        public void ToggleItem(object sender)
        {
            var buttonRow = sender as RowDefinition;
            var item = buttonRow.BindingContext as ObservationViewModel;

            if (_oldItem != null && _oldItem != item)
            {
                _oldAnimation.Commit(_oldPage, "the old animation", length: 100);
                _oldItem.IsSelected = false;
            }
            if (item.IsSelected)
            {
                CollapseAnimation(buttonRow).Commit(this, "the animation", length: 100);
                item.IsSelected = false;
            }
            else
            {
                item.IsSelected = true;
                ExpandAnimation(buttonRow).Commit(this, "the animation", length: 100);
            }

            _oldRow = buttonRow;
            _oldItem = item;
            _oldPage = this;
            _oldAnimation = CollapseAnimation(buttonRow);
        }

        private Animation ExpandAnimation(RowDefinition row)
        {
            return new Animation(
                (d) => row.Height = Anim(d, 0, double.MaxValue), row.Height.Value, _rowHeight, Easing.Linear);
        }

        private Animation CollapseAnimation(RowDefinition row)
        {
            return new Animation(
                (d) => row.Height = new GridLength(Anim(d, 0, double.MaxValue)), _rowHeight, 0, Easing.Linear);
        }

        private double Anim(double value, double minValue, double maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }

            if (value > maxValue)
            {
                return maxValue;
            }

            return value;
        }

        private static double _rowHeight= 90;
        private static Animation _oldAnimation;
        private static RowDefinition _oldRow;
        private static Page _oldPage;
        private static ObservationViewModel _oldItem;
        private static Assessment assessment;
        private static AssessmentViewModel assessmentView;
        private readonly Database _db = new Database();
    }
}