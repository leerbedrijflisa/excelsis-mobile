using SQLite.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class ExamPage : ContentPage
    {
        public ExamPage()
        {
            InitializeComponent();
            Title = "Alle examens";

            var exams = new List<Examdb>();
            foreach (var exam in _db.Table<Examdb>())
            {
                exams.Add(exam);
            }

            var context = new ExamPageViewModel()
            {
                Exams = exams
            };
            context.OnNewAssessment += NewAssessment;

            BindingContext = context;

            ExamList.IsPullToRefreshEnabled = true;

            ExamList.ItemTapped += async(sender, e) => {
                if (_Tapped)
                    return;
                _Tapped = true;
                var examId = ((Examdb)e.Item).Id;
                var exam = _database.FetchExam(examId);
                Navigation.InsertPageBefore(new AssessmentPage(null, exam), this);
                await Navigation.PopAsync();

                _Tapped = false;
            };
            ExamList.ItemSelected += (sender, e) => {
                if (ExamList.SelectedItem == null)
                    return;
                //deselect item when pushing
                ExamList.SelectedItem = null;
            };
        }

        public void NewAssessment()
        {
            Navigation.PushAsync(new AssessmentPage());
        }

        public void UpdateExams(object sender, EventArgs e)
        {
            var exams = new List<Examdb>();
            foreach (var exam in _db.Table<Examdb>())
            {
                exams.Add(exam);
            }
            ExamList.ItemsSource = exams;
            ExamList.EndRefresh();
        }

        private bool _Tapped;
        
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        private readonly Database _database = new Database();
    }
}
