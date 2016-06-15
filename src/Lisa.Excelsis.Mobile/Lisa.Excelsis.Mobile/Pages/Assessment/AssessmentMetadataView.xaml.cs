using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentMetadataView : StackLayout
    {
        public AssessmentMetadataView()
        {
            InitializeComponent();           
        }

        public void DateTimeChanged(object sender, PropertyChangingEventArgs e)
        {
            var assessment = BindingContext as AssessmentViewModel;
            if (assessment != null)
            {
                if(e.PropertyName == "Date" || e.PropertyName == "Time")
                {
                    var newDate = new DateTime(ExamDate.Date.Year, ExamDate.Date.Month, ExamDate.Date.Day, 
                                               ExamTime.Time.Hours, ExamTime.Time.Minutes, ExamTime.Time.Seconds);
                    assessment.Assessed = newDate;
                    assessment.SaveAssessedCommand.Execute(null);
                }
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var assessment = BindingContext as AssessmentViewModel;
            if (assessment != null)
            {
                ExamDate.Date = assessment.Assessed;
                ExamTime.Time = TimeZoneInfo.ConvertTime(assessment.Assessed, TimeZoneInfo.Local).TimeOfDay;
            }
        }
    }
}