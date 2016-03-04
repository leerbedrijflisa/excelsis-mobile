using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage (Assessment assessment)
        {
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
                            Marks = observations.Marks
                        };
                    _category.Add(_observation);
                }
            }

            this.BindingContext = _assessment;
        }

        public void SetYesImage(object sender, EventArgs e)
        {
            ((Image)sender).Parent.FindByName<Image>("noImage").Source = "yesnobutton0.png";

            var source =  ((Image)sender).Source as FileImageSource;
            if(source.File == "yesnobutton1.png")
            { 
                ((Image)sender).Source = "yesnobutton0.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            else
            { 
                ((Image)sender).Source = "yesnobutton1.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Lime;
            }
        }

        public void SetNoImage(object sender, EventArgs e)
        {
            ((Image)sender).Parent.FindByName<Image>("yesImage").Source = "yesnobutton0.png";

            var source =  ((Image)sender).Source as FileImageSource;
            if(source.File == "yesnobutton2.png")
            { 
                ((Image)sender).Source = "yesnobutton0.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            else
            { 
                ((Image)sender).Source = "yesnobutton2.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Red;
            }
        }

        private void SetMark(object sender, EventArgs e)
        {
            var source = ((Image)sender).Source as FileImageSource;
            string image;

            if(Regex.IsMatch(source.File,"_COLOR.png"))
            { 
                MarkActiveCount--;
                image = source.File.Split('_')[0] + ".png"; 
            }
            else
            {
                MarkActiveCount++;
                image = source.File.Split('.')[0] + "_COLOR.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.FromRgb(255,165,0);
            }

            if (MarkActiveCount == 0)
            {
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            ((Image)sender).Source = ImageSource.FromFile(image);
        }
       
        private StackLayout OldItem;

        private int MarkActiveCount = 0;
    }
}

