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

            _examProxy = new Proxy<Exam>("http://excelsis-develop-webapi.azurewebsites.net/exams", new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

            ExamList.ItemsSource = _db.Get();
            ExamList.IsPullToRefreshEnabled = true;
        }

        private async void UpdateExams(object sender, EventArgs e)
        {
            try
            {
                var exams = await _examProxy.GetAsync();
                

                foreach(var exam in exams)
                {
                    if(_db.Get(exam.Id) == null)
                    {
                        _db.Create(exam);
                    }
                    else
                    {
                        _db.Replace(exam);
                    }
                }

                ExamList.ItemsSource = _db.Get();

                ExamList.EndRefresh();

                await DisplayAlert("Gerefreshed", "success", "sluiten");
            }
            catch(Exception ex)
            {
                ExamList.EndRefresh();

                if(ex.GetType().ToString() == "System.Net.WebException")
                {
                    await DisplayAlert("Error", "Kan niet verbinden met de Web API, controleer de internetverbinding", "Sluiten");
                }
                else
                {
                    await DisplayAlert("Error", String.Join("|", ex.Message, ex.GetType()), "Sluiten");
                }
            }
        }

        private readonly Database<Exam> _db = new Database<Exam>();
        private readonly Proxy<Exam> _examProxy;
    }
}