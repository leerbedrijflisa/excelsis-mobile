using Xamarin.Forms;
using System.Collections.Generic;
using System;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage ()
        {
            Assessment assessment = _db.FetchAssessment();
            if( assessment == null)
            {
                assessment = DummyData.FetchAssessment();
                _db.SaveAssessment(assessment);
            }
            InitializeComponent();
            Title = "Beoordeling";

            var _assessment = new AssessmentViewModel(this.Navigation, this)
            {
                Id = assessment.Id,
                Assessed = assessment.Assessed,
                Assessors = assessment.Assessors,
                Student = assessment.Student,
                Exam = assessment.Exam
            };
            
            _assessment.Categories = new List<CategoryViewModel>();
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
                    var _observation = new ObservationViewModel(this)
                    {
                        Id = observations.Id.ToString(),
                        Result = observations.Result,
                        Criterion = observations.Criterion,
                        Maybe_Not = observations.Marks.Contains("maybenot"),
                        Skip = observations.Marks.Contains("skip"),
                        Unclear = observations.Marks.Contains("unclear"),
                        Change = observations.Marks.Contains("change")
                    };           
                    _observation.ChangeObserveColor();
                    _category.Observations.Add(_observation);
                }
                _assessment.Categories.Add(_category);
            }

            BindingContext = _assessment;
            foreach (var assessor in DummyData.FetchAssessors())
            {
                AssessorPicker.Items.Add(string.Join(" ", assessor.FirstName, assessor.LastName));
            }
        }

        public void OpenItem(object sender)
        {
            var stacklayout = sender as StackLayout;
            var item = stacklayout.BindingContext as ObservationViewModel;
            var row = stacklayout.FindByName<RowDefinition>("ShowButtons");

            if (_oldItem != null && _oldItem != item)
            {
                _oldAnimation.Commit(_oldPage, "the old animation", length: 100);
                _oldItem.IsSelected = false;
            }
            if (item.IsSelected)
            {
                CollapseAnimation(row).Commit(this, "the animation", length: 100);
                item.IsSelected = false;
            }
            else
            {
                item.IsSelected = true;
                ExpandAnimation(row).Commit(this, "the animation", length: 100);
            }

            _oldRow = row;
            _oldItem = item;
            _oldPage = this;
            _oldAnimation = CollapseAnimation(row);
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

        private readonly Database _db = new Database();
    }
}

