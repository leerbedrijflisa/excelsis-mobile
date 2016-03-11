using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage ()
        {
            Assessment assessment = DummyData.Fetch();
            InitializeComponent();
            this.Title = "Beoordeling";

            var _assessment = new AssessmentViewModel()
            {
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
                        Maybe_Not = observations.Marks.Contains("maybe_not"),
                        Skip = observations.Marks.Contains("skip"),
                        Unclear = observations.Marks.Contains("unclear"),
                        Change = observations.Marks.Contains("change")
                    };                    
                   _category.Add(_observation);
                }
            }

            this.BindingContext = _assessment;
            CategoryList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                var item = ((ObservationViewModel)e.SelectedItem);
                if(oldItem != null && item.Id == oldItem.Id)
                {
                    item.IsSelected = !item.IsSelected;
                }
                else
                {
                    item.IsSelected = true;
                    if(oldItem != null)
                        oldItem.IsSelected = false;
                    oldItem = item;
                }
            };
        }

        private ObservationViewModel oldItem;
    }
}

