using Lisa.Common.Access;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            ExamList.ItemsSource = _exams;
            ExamList.IsPullToRefreshEnabled = true;
        }

        private async void UpdateExams(object sender, EventArgs e)
        {
            try
            {
                var exams = await _examProxy.GetAsync();

                ExamList.ItemsSource = exams;

                await DisplayAlert("Gerefreshed", "success", "sluiten");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Sluiten");
            }

            ExamList.EndRefresh();
        }

        private readonly Exam[] _exams = new Exam[]
        {
            new Exam
                {
                    Id = 1,
                    Name = "Spreken",
                    Cohort = 2015,
                    Subject = "Nederlands"
                },
                new Exam
                {
                    Id = 2,
                    Name = "Lezen & Luisteren",
                    Cohort = 2015,
                    Subject = "Nederlands"
                },
                new Exam
                {
                    Id = 3,
                    Name = "Gesprekken voeren",
                    Cohort = 2015,
                    Subject = "Nederlands"
                }
        };

        private readonly Proxy<Exam> _examProxy = new Proxy<Exam>("http://excelsis-develop-webapi.azurewebsites.net/exams", new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });
    }
}