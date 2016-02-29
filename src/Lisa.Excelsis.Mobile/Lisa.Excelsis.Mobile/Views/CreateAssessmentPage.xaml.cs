using SQLite.Net;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateAssessmentPage : ContentPage
    {
        public CreateAssessmentPage(Examdb exam)
        {
            InitializeComponent();

            _proxy = new Proxy("http://excelsis-develop-webapi.azurewebsites.net/", new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
            
            _exam = exam;
            foreach (var assessor in _db.Table<Assessordb>())
            {
                AssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
                SecondAssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
            }
        }

        public async void StartAssessment(object sender, EventArgs e)
        {
            var isValid = true;
			StartButton.IsEnabled = false;

			if (StudentNumber != null && Regex.IsMatch(StudentNumber.ToString(), @"^\d{8}$"))
            {
                StudentNumber.BackgroundColor = Color.FromRgb(255, 51, 51);
                isValid = false;
            }
            else
            {
				StudentNumber.BackgroundColor = Color.Default;
            }

            if (AssessorPicker.SelectedIndex == -1)
            {
                AssessorPicker.BackgroundColor = Color.FromRgb(255, 51, 51);
                isValid = false;
            }
            else
            {
                AssessorPicker.BackgroundColor = Color.Default;
            }

            if (isValid)
            {
                var assessmentMetaData = new Assessmentdb
                {
                    Assessed = ExamDate.Date,
                    StudentName = StudentName?.Text,
                    StudentNumber = StudentNumber?.Text,
					Subject = _exam.SubjectId,
                    Crebo = _exam.Crebo.ToString(),
					Name = _exam.NameId,
                    Cohort = _exam.Cohort.ToString()
				};

                _db.Insert(assessmentMetaData);

                var username = AssessorPicker.Items[AssessorPicker.SelectedIndex];
                var assessorId = (from s in _db.Table<Assessordb>() where s.UserName == username select s.Id).FirstOrDefault();

                var assessmentAssessor = new AssessmentAssessordb
                {
                    AssessmentId = assessmentMetaData.Id,
                    AssessorId = assessorId
                };

                _db.Insert(assessmentAssessor);

                if (SecondAssessorPicker.SelectedIndex != -1)
                {
                    var secondUserName = SecondAssessorPicker.Items[SecondAssessorPicker.SelectedIndex];

                    assessorId = _db.Table<Assessordb>().Where(s => s.UserName == secondUserName).Select(s => s.Id).FirstOrDefault();

                    assessmentAssessor = new AssessmentAssessordb
                    {
                        AssessmentId = assessmentMetaData.Id,
                        AssessorId = assessorId
                    };

                    _db.Insert(assessmentAssessor);
                }
                var data = new 
                {
                    Student = new 
                    {
                            Name = StudentName.Text?? string.Empty,
                            Number = StudentNumber.Text?? string.Empty
                    },
                    Assessed = "2015-11-29T12:00:00Z",
                    Assessors = new string[]
                    {
                        "joostronkesagerbeek",
                        "petersnoek"
                    }
                };
                var assessment = await _proxy.PostAsync<dynamic>(data, "assessments/" + _exam.SubjectId + "/" + _exam.Cohort + "/" + _exam.NameId);
                await Navigation.PushAsync(new AssessmentPage(assessment.ToObject<Assessment>()));
            }
			StartButton.IsEnabled = true;
        }

        public void EntryChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text != null && entry.Text.Length != 0)
            {
                int iDontCare;
                if (entry.Keyboard == Keyboard.Numeric && Int32.TryParse(entry.Text, out iDontCare))
                {
                    entry.BackgroundColor = Color.Default;
                }
                else
                {
                    return;
                }

                entry.BackgroundColor = Color.Default;
            }
        }

        public void AssessorChanged(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedIndex != -1)
            {
                ((Picker)sender).BackgroundColor = Color.Default;
            }
        }

        private readonly Examdb _exam;
        private readonly Proxy _proxy;
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}