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

            var properties = Application.Current.Properties;

            if (properties.ContainsKey("IsOffline"))
            {
                _isOffline = (bool) properties["IsOffline"];

                if (_isOffline)
                {
                    OfflineButton.Text = "Ga Online";
                }
            }
            else
            {
                properties["IsOffline"] = false;
                _isOffline = false;

                OfflineButton.Text = "Ga Offline";
            }

            ExamList.ItemsSource = _db.Get();
            ExamList.IsPullToRefreshEnabled = true;
        }

        private async void OfflineButtonClick(object sender, EventArgs e)
        {
            var app = Application.Current;
            var properties = app.Properties;

            _isOffline = !_isOffline;

            properties["IsOffline"] = _isOffline;


            if (_isOffline)
            {
                OfflineButton.Text = "Ga Online";
            }
            else
            {
                OfflineButton.Text = "Ga Offline";
            }

             await app.SavePropertiesAsync();
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

                await DisplayAlert("Error", "Kan niet verbinden met de Web API, controleer de internetverbinding", "Sluiten");

                return;
            }
            catch(Exception ex)
            {
                ExamList.EndRefresh();

                await DisplayAlert("Error", String.Join("|", ex.Message, ex.GetType()), "Sluiten");

                return;
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
        private bool _isOffline;
    }
}