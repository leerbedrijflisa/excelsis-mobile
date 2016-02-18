using SQLite.Net;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateAssessmentPage : ContentPage
    {
        public CreateAssessmentPage(Examdb exam)
        {
            InitializeComponent();
            _exam = exam;

            _proxy = new Proxy("http://excelsis-develop-webapi.azurewebsites.net/", new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
            
            foreach (var assessor in _db.Table<Assessordb>())
            {
                AssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
                SecondAssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
            }
        }

        public async void StartAssessment(object sender, EventArgs e)
        {
            StartButton.IsEnabled = false;

            bool studentNumberIsValid = Validate.StudentNumberIsValid(StudentNumber?.Text.ToString());
            bool assessorIsValid = Validate.AssessorIsValid(AssessorPicker.SelectedIndex);

            StudentNumber.BackgroundColor = (!studentNumberIsValid)? Color.FromRgb(255, 51, 51) : Color.Default;
            AssessorPicker.BackgroundColor = (!assessorIsValid)? Color.FromRgb(255, 51, 51) : Color.Default;

            if (studentNumberIsValid && assessorIsValid)
            {
                SaveAssessment();
                dynamic assessment = PostAssessmentToApi();               
                await Navigation.PushAsync(new AssessmentPage(assessment.ToObject<Assessment>()));
            }
            StartButton.IsEnabled = true;
        }

        public void EntryChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            if (entry.Text != null && entry.Text.Length != 0)
            {
                entry.BackgroundColor = (entry.Keyboard == Keyboard.Numeric && Regex.IsMatch(entry.Text, @"^\d$"))? Color.Default : entry.BackgroundColor;
            }
        }

        public void AssessorChanged(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedIndex != -1)
            {
                ((Picker)sender).BackgroundColor = Color.Default;
            }
        }

        public async Task<object> PostAssessmentToApi()
        {
            var data = new 
                {
                    Student = new 
                        {
                            Name = StudentName.Text?? string.Empty,
                            Number = StudentNumber.Text?? string.Empty
                        },
                    Assessed = "2015-11-29T12:00:00Z",
                    Assessors = Assessors
                };
            return await _proxy.PostAsync<dynamic>(data, "assessments/" + _exam.SubjectId + "/" + _exam.Cohort + "/" + _exam.NameId);
        }
        private readonly Examdb _exam;
        private readonly Proxy _proxy;
        private List<string> Assessors;
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}