using SQLite.Net;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateAssessmentPage : ContentPage
    {
        public CreateAssessmentPage(Exam exam)
        {
            InitializeComponent();

            _exam = exam;

            foreach (var assessor in _db.Table<Assessor>())
            {
                AssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
                SecondAssessorPicker.Items.Add(String.Join(" ", assessor.FirstName, assessor.LastName));
            }
        }

        public async void StartAssessment(object sender, EventArgs e)
        {
            var isValid = true;
			StartButton.IsEnabled = false;
            int studentnumber = 0;

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
                var student = new Student
                {
                    Name = StudentName.Text,
                    Number = studentnumber
                };

                _db.Insert(student);

                var assessment = new Assessment
                {
                    Assessed = ExamDate.Date,
					Subject = _exam.SubjectId,
					Name = _exam.NameId,
					Cohort = _exam.Cohort
				};

                _db.Insert(assessment);

                var username = AssessorPicker.Items[AssessorPicker.SelectedIndex];
                var assessorId = (from s in _db.Table<Assessor>() where s.UserName == username select s.Id).FirstOrDefault();

                var assessmentAssessor = new AssessmentAssessor
                {
                    AssessmentId = assessment.Id,
                    AssessorId = assessorId
                };

                _db.Insert(assessmentAssessor);

                if (SecondAssessorPicker.SelectedIndex != -1)
                {
                    var secondUserName = SecondAssessorPicker.Items[SecondAssessorPicker.SelectedIndex];

                    assessorId = _db.Table<Assessor>().Where(s => s.UserName == secondUserName).Select(s => s.Id).FirstOrDefault();

                    assessmentAssessor = new AssessmentAssessor
                    {
                        AssessmentId = assessment.Id,
                        AssessorId = assessorId
                    };

                    _db.Insert(assessmentAssessor);
                }
                
				await Navigation.PushAsync(new ObservationPage());
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

        private readonly Exam _exam;
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}