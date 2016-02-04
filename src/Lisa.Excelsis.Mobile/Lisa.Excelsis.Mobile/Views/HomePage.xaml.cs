using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLite.Net;
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

            _proxy = new Proxy("http://excelsis-develop-webapi.azurewebsites.net/", new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

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

            if (_db.Table<Exam>().Count() == 0)
            {

                ErrorList.ItemsSource = new List<string>()
                {
                    "Error boys"
                   
                };

                ErrorList.IsPullToRefreshEnabled = true;

                ErrorList.ItemSelected += (sender, e) => {
                    ((ListView)sender).SelectedItem = null;
                };

            }
            else
            {
                ErrorList.IsVisible = false;

                var exams = new List<Exam>();

                foreach (var exam in _db.Table<Exam>())
                {
                    exam.Name = String.Format("{0}: {1}, {2}", exam.Subject, exam.Name, exam.Cohort);

                    exams.Add(exam);
                }

                ExamList.ItemsSource = exams;
                ExamList.IsPullToRefreshEnabled = true;
            }
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

            try
            {
                await Navigation.PushAsync(new CreateExamPage(exam));
            }
            catch
            {
                throw;
            }
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
                        ErrorList.EndRefresh();

                        return;
                    }
                }
                else
                {
                    ExamList.EndRefresh();
                    ErrorList.EndRefresh();

                    await DisplayAlert("App is Offline", "App staat in offline, en er is geen verbinding met het netwerk", "Sluiten");

                    return;
                }
            }

            var exams = new List<Exam>();

            try
            {
                exams = (List<Exam>)await _proxy.GetAsync<Exam>("exams");
            }
            catch (WebException)
            {
                ExamList.EndRefresh();
                ErrorList.EndRefresh();

                await DisplayAlert("Error", "Kan niet verbinden met de Web API, controleer de internetverbinding", "Sluiten");

                return;
            }
            catch (Exception ex)
            {
                ExamList.EndRefresh();
                ErrorList.EndRefresh();

                await DisplayAlert("Error", String.Join("|", ex.Message, ex.GetType()), "Sluiten");

                return;
            }

            foreach (var exam in exams)
            {
                _db.InsertOrReplace(exam);
            }

            var examsFromDb = new List<Exam>();

            foreach (var exam in _db.Table<Exam>())
            {
                exam.Name = String.Format("{0}: {1}, {2}", exam.Subject, exam.Name, exam.Cohort);

                examsFromDb.Add(exam);
            }

            ExamList.ItemsSource = examsFromDb;

            ErrorList.IsVisible = false;
            ExamList.EndRefresh();
            ErrorList.EndRefresh();

            await DisplayAlert("Gerefreshed", "success", "sluiten");
        }

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        private readonly Proxy _proxy;
        private bool _isOffline;
    }
}