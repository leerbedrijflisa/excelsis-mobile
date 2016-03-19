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
            var row = cell.FindByName<RowDefinition>("ShowButtons");

            if (_oldItem != null && _oldItem != item)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    _oldAnimation.Commit(_oldPage, "the old animation", length: 100);                   
                }
                //this is weird
                _oldItem.IsSelected = false;

                if (Device.OS == TargetPlatform.iOS)
                {
                    _oldRow.Height = 0;
                    cell.ForceUpdateSize();
                }
            }

            if (item.IsSelected)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    CollapseAnimation(cell, row).Commit(this, "the animation", length: 100);
                }

                item.IsSelected = false;

                if (Device.OS == TargetPlatform.iOS)
                {
                    row.Height = 0;
                    cell.ForceUpdateSize();
                }
            }
            else
            {
                item.IsSelected = true;

                if (Device.OS == TargetPlatform.Android)
                {
                    ExpandAnimation(cell, row).Commit(this, "the animation", length: 100);
                }

                if (Device.OS == TargetPlatform.iOS)
                {
                    row.Height = _rowHeight;
                    cell.ForceUpdateSize();
                }
            }           

            _oldRow = row;
            _oldCell = cell;
            _oldItem = item;
            _oldPage = this;
            _oldAnimation = CollapseAnimation(cell, row);
        }

        private Animation ExpandAnimation(ViewCell cell, RowDefinition row)
        {
            return new Animation(
                (d) => row.Height = Anim(d, 0, double.MaxValue), row.Height.Value, _rowHeight, Easing.Linear);
        }

        private Animation CollapseAnimation(ViewCell cell, RowDefinition row)
        {
            return new Animation(
                (d) =>   row.Height = new GridLength(Anim(d, 0, double.MaxValue)), _rowHeight, 0, Easing.Linear);
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

        private Animation _oldAnimation;
        public double _rowHeight= 110;
        private Page _oldPage;
        private ObservationViewModel _oldItem;
        private ViewCell _oldCell;
        private RowDefinition _oldRow;

        private readonly Database _db = new Database();
    }
}

