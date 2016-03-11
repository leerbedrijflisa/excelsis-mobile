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
            _assessment.Observations = new ObservableCollection<ObservationViewModel>();
            //_assessment.Categories = new ObservableCollection<CategoryViewModel>();
            foreach (var categories in assessment.Categories)
            {
           //     var _category = new CategoryViewModel()
           //     {
            //        Order = categories.Order.ToString(),
            //        Name = categories.Name
           //     };

           //     _assessment.Categories.Add(_category);
          //      _category.Observations = new ObservableCollection<ObservationViewModel>();

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
                    
                  //  _category.Observations.Add(_observation);
                   // _category.Add(_observation);
                    _assessment.Observations.Add(_observation);
                }
            }

            this.BindingContext = _assessment;
        }
    }
}

