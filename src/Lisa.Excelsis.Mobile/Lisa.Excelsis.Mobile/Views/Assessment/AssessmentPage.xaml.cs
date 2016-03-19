using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using SQLite.Net;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage ()
        {
            Assessment assessment = _db.FetchAssessment();
            if( assessment == null)
            {
                assessment = DummyData.Fetch();
                _db.SaveAssessment(assessment);
            }
            InitializeComponent();
            this.Title = "Beoordeling";

            var _assessment = new AssessmentViewModel(this.Navigation, this)
            {
                Id = assessment.Id,
                Assessed = assessment.Assessed,
                Assessors = assessment.Assessors,
                Student = assessment.Student,
                Exam = assessment.Exam
            };
            
            _assessment.Categories = new ObservableCollection<CategoryViewModel>();
            foreach (var categories in assessment.Categories)
            {
                var _category = new CategoryViewModel()
                {
                    Order = categories.Order.ToString(),
                    Name = categories.Name
                };

                _assessment.Categories.Add(_category);
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
                    _observation.ChangeObserveColor();
                   _category.Add(_observation);
                }
            }

            this.BindingContext = _assessment;

        }

        void OpenItem(object sender, EventArgs e)
        {
            var stacklayout = sender as StackLayout;
            var cell = stacklayout.Parent.FindByName<ViewCell>("ObservationCell");
            var item = cell.BindingContext as ObservationViewModel;

            if (oldCell != null && oldItem != null && oldItem != item)
            {
                AnimateRow(oldPage, oldRow, oldItem);
                oldCell.ForceUpdateSize();
            }

            _detailsRow = cell.FindByName<RowDefinition>("ShowButtons");

            if (item.IsSelected)
            {
                AnimateRow(this,_detailsRow, item);
            }
            else
            {
                item.IsSelected = true;
                AnimateRow(this,_detailsRow, item);
            }           

            cell.ForceUpdateSize();

            oldCell = cell;
            oldRow = _detailsRow;
            oldItem = item;
            oldPage = this;
        }

        private void AnimateRow(Page page,RowDefinition row, ObservationViewModel item = null)
        {
            if(row.Height.Value < _detailsRowHeight)
            {
                // Move back to original height
                _animation = new Animation(
                    (d) => row.Height = Anim(d, 0, double.MaxValue),
                    row.Height.Value, _detailsRowHeight, Easing.Linear, () => _animation = null);
            }
            else
            {
                // Hide the row
                _animation = new Animation(
                    (d) => row.Height = new GridLength(Anim(d, 0, double.MaxValue)),
                    _detailsRowHeight, 0, Easing.Linear, () => {_animation = null; item.IsSelected = false;});
            }

            _animation.Commit(page.ParentView, "the animation");
        }


        // Make sure we don't go below zero
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

        public double _detailsRowHeight= 90;
        private Animation _animation;
        private RowDefinition _detailsRow;
        private RowDefinition oldRow;
        private Page oldPage;

        private ObservationViewModel oldItem;
        private ViewCell oldCell;

        private readonly Database _db = new Database();
    }
}

