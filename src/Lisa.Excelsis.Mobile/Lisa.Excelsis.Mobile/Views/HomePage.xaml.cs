using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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

            InitializeComponent();

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

            _db.CreateTable<Exam>();
            
            ExamList.ItemsSource = _db.Table<Exam>().Select(s => new ExamListItem(s));
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

            var path = String.Format("exams/{0}/{1}/{2}", exam.Subject, exam.Cohort, escapeCharacters(exam.Name));

            var detailedExam = await _proxy.GetSingleAsync<ExamTransfer>(path);
            
            foreach(var categoryTransfer in detailedExam.Categories)
            {
                var category = new Category
                {
                    Name = categoryTransfer.Name,
                    Id = categoryTransfer.Id,
                    Order = categoryTransfer.Order,
                    ExamId = detailedExam.Id
                };

                _db.InsertOrReplace(category);

                foreach(var criterionTransfer in categoryTransfer.Criteria)
                {
                    var criterion = new Criterion
                    {
                        Id = criterionTransfer.Id,
                        CategoryId = category.Id,
                        Order = criterionTransfer.Order,
                        Title = criterionTransfer.Title,
                        ExamId = detailedExam.Id,
                        Description = criterionTransfer.Description
                    };

                    _db.InsertOrReplace(criterion);
                }
            }

            await Navigation.PushAsync(new AssessmentPage(exam));
        }

        private async void Update(object sender, EventArgs e)
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

            IEnumerable<AssessorTransfer> assessors;
            
            try
            {
                assessors = await _proxy.GetAsync<AssessorTransfer>("assessors");
                _db.InsertOrReplaceAll(assessors.Select(s => new Assessor
                {
                    Id = s.Id,
                    UserName = s.UserName
                }));


                foreach (var exam in await _proxy.GetAsync<ExamTransfer>("exams"))
                {
                    var newExam = new Exam
                    {
                        Id = exam.Id,
                        Name = exam.Name,
                        Cohort = exam.Cohort,
                        Crebo = exam.Crebo,
                        Subject = exam.Subject,
                        Status = exam.Status
                    };

                    _db.InsertOrReplace(newExam);
                }
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
            
            _db.InsertOrReplaceAll(assessors.Select(s => new Assessor
            {
                Id = s.Id,
                UserName = s.UserName
            }));

            ExamList.ItemsSource = _db.Table<Exam>().Select(s => new ExamListItem(s));

            ExamList.EndRefresh();

            await DisplayAlert("Gerefreshed", "success", "sluiten");
        }
        
        private string escapeCharacters(string text)
        {
            List<string> nameParts = new List<string>();
            Regex regex = new Regex(@"[\w\d\.]+");
            var matches = regex.Matches(text.ToLower());
            foreach (Match match in matches)
            {
                nameParts.Add(match.Value);
            }
            return string.Join("-", nameParts);
        }

        private readonly Proxy _proxy;
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        private bool _isOffline;
    }
}