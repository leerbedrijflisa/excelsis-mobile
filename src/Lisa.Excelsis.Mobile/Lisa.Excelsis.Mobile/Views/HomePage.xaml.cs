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

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            _db = new Database();

            var resourceUrl = "http://excelsis-develop-webapi.azurewebsites.net/";

            _examProxy = new Proxy<Exam>(resourceUrl + "exams", serializerSettings);
            _assessorProxy = new Proxy<Assessor>(resourceUrl + "assessors", serializerSettings);

            var properties = Application.Current.Properties;

            if (properties.ContainsKey("IsOffline"))
            {
                _isOffline = (bool)properties["IsOffline"];

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

            var exams = new List<ExamListItem>();

            foreach (var exam in _db.Exams.Get())
            {
                exams.Add(new ExamListItem(exam));
            }

            ExamList.ItemsSource = exams;
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

        private async void CreateExam(object sender, EventArgs e)
        {
            var exam = (Exam)((ListView)sender).SelectedItem;
            
            await Navigation.PushAsync(new CreateExamPage(exam));
        }

        private async void UpdateExams(object sender, EventArgs e)
        {
            if (_isOffline)
            {
                if (DependencyService.Get<IConnectionChecker>().IsOnline())
                {
                    if (await DisplayAlert("App is Offline", "Wil je overschakelen naar online?", "Ja", "Nee"))
                    {
                        _isOffline = false;
                        Application.Current.Properties["IsOffline"] = false;
                        OfflineButton.Text = "Ga Offline";

                        await Application.Current.SavePropertiesAsync();
                    }
                    else
                    {
                        ExamList.EndRefresh();

                        return;
                    }
                }
                else
                {
                    ExamList.EndRefresh();

                    await DisplayAlert("App is Offline", "App staat in offline, en er is geen verbinding met het netwerk", "Sluiten");

                    return;
                }
            }

            var exams = new List<Exam>();
            var assessors = new List<Assessor>();

            try
            {
                exams = (List<Exam>)await _examProxy.GetAsync();
                assessors = (List<Assessor>)await _assessorProxy.GetAsync();
            }
            catch (WebException)
            {
                ExamList.EndRefresh();

                await DisplayAlert("Error", "Kan niet verbinden met de Web API, controleer de internetverbinding", "Sluiten");

                return;
            }
            catch (Exception ex)
            {
                ExamList.EndRefresh();

                await DisplayAlert("Error", String.Join("|", ex.Message, ex.GetType()), "Sluiten");

                return;
            }

            foreach (var exam in exams)
            {
                if (_db.Exams.Get(exam.Id) == null)
                {
                    _db.Exams.Insert(exam);
                }
                else
                {
                    _db.Exams.Replace(exam);
                }
            }

            foreach(var assessor in assessors)
            {
                if(_db.Assessors.Get(assessor.Id) == null)
                {
                    _db.Assessors.Insert(assessor);
                }
                else
                {
                    _db.Assessors.Replace(assessor);
                }
            }

            var examsFromDb = new List<ExamListItem>();

            foreach (var exam in _db.Exams.Get())
            {
                examsFromDb.Add(new ExamListItem(exam));
            }

            ExamList.ItemsSource = examsFromDb;

            ExamList.EndRefresh();

            await DisplayAlert("Gerefreshed", "success", "sluiten");
        }

        private readonly Database _db;
        private readonly Proxy<Exam> _examProxy;
        private readonly Proxy<Assessor> _assessorProxy;
        private bool _isOffline;
    }
}