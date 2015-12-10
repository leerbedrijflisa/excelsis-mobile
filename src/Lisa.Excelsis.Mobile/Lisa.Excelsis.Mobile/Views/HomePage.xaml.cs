using Lisa.Common.Access;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
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
            var exams = new List<Exam>();

            try
            {
                exams = (List<Exam>) await _examProxy.GetAsync();
            }
            catch(WebException ex)
            {
                ExamList.EndRefresh();

                //await DisplayAlert("Error", "Kan niet verbinden met de Web API, controleer de internetverbinding", "Sluiten");
            }
            catch(Exception ex)
            {
                ExamList.EndRefresh();

                //await DisplayAlert("Error", String.Join("|", ex.Message, ex.GetType()), "Sluiten");
            }
            
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

        private readonly Database<Exam> _db = new Database<Exam>();
        private readonly Proxy<Exam> _examProxy;
    }
}