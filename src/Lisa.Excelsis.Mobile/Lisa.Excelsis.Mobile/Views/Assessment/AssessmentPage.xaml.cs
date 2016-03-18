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

            if (_oldItem != null && _oldItem != item)
            {
                _oldAnimation.Commit(_oldPage, "the old animation", length: 100);
                _oldItem.IsSelected = false;
            }

            _detailsRow = cell.FindByName<RowDefinition>("ShowButtons");

            if (item.IsSelected)
            {
                _currentAnimation = CollapseAnimation(cell, _detailsRow);
                _currentAnimation.Commit(this, "the animation", length: 100);
                item.IsSelected = false;
            }
            else
            {
                item.IsSelected = true;
                _currentAnimation = ExpandAnimation(cell, _detailsRow);
                _currentAnimation.Commit(this, "the animation", length: 100);
            }           

            _oldItem = item;
            _oldPage = this;
            _oldAnimation = CollapseAnimation(cell, _detailsRow);
        }

        private Animation ExpandAnimation(ViewCell cell, RowDefinition row)
        {
            return new Animation(
                (d) => {
                    row.Height = Anim(d, 0, double.MaxValue);
                    cell.ForceUpdateSize();
                },
                row.Height.Value, _detailsRowHeight, Easing.Linear, () => _currentAnimation = null);
        }

        private Animation CollapseAnimation(ViewCell cell, RowDefinition row)
        {
            return new Animation(
                (d) => 
                {
                    row.Height = new GridLength(Anim(d, 0, double.MaxValue));
                    cell.ForceUpdateSize();
                },
                _detailsRowHeight, 0, Easing.Linear, () =>  _currentAnimation = null);
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
        private Animation _currentAnimation;
        private Animation _oldAnimation;
        private RowDefinition _detailsRow;
        private Page _oldPage;
        private ObservationViewModel _oldItem;

        private readonly Database _db = new Database();
    }
}

