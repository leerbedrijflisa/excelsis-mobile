using Lisa.Common.Access;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections;

namespace Lisa.Excelsis.Mobile
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

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

            ExamList.ItemsSource = _db.Table<Exam>().Select(s => new ExamListItem(s));

            ExamList.EndRefresh();

            await DisplayAlert("Gerefreshed", "success", "sluiten");
        }

		private async Task Update()
		{
			var assessors = new IEnumerable<AssessorTransfer>();
			var assessments = new IEnumerable<AssessmentTransfer>();

			var serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				NullValueHandling = NullValueHandling.Ignore
			};

			var proxy = new Proxy("http://excelsis-develop-webapi.azurewebsites.net/", serializerSettings);

			try
			{
				assessors = await proxy.GetAsync<AssessorTransfer>("assessors");
				_db.InsertOrReplaceAll(assessors.Select(s => new Assessor
				{
					Id = s.Id,
					UserName = s.UserName
				}));


				foreach(var exam in await proxy.GetAsync<ExamTransfer>("exams"))
				{
					var examDetail = await proxy.GetSingleAsync<ExamTransfer>( String.Format("exams/{0}/{1}/{2}", exam.Subject, exam.Cohort, exam.Name));

					_db.InsertOrReplace(new Exam
					{
						Id = examDetail.Id,
						Name = examDetail.Name,
						Cohort = examDetail.Cohort,
						Crebo = examDetail.Crebo,
						Subject = examDetail.Subject,
						Status = examDetail.Status
					});

					foreach(var categoryTransfer in examDetail.Categories)
					{
						var category = new Category
						{
								
						};
					}
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

				_db.InsertOrReplaceAll(exams);

			_db.InsertOrReplaceAll(assessors);
		}

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        private bool _isOffline;
    }
}