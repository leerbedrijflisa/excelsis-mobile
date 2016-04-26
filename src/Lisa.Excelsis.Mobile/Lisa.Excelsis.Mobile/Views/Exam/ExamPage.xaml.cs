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
            noDataMessage.IsVisible = (exams.Count == 0);
            BindingContext = context;

            ExamList.IsPullToRefreshEnabled = true;

            ExamList.ItemTapped += OnItemTapped;
            ExamList.ItemSelected += OnItemSelected;
        }

        public void UpdateExams(object sender, EventArgs e)
        {
            var exams = new List<Examdb>();
            foreach (var exam in _db.Table<Examdb>())
            {
                exams.Add(exam);
            }
            noDataMessage.IsVisible = (exams.Count == 0);
            ExamList.ItemsSource = exams;
            ExamList.EndRefresh();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_Tapped)
                return;
            var loadingPage = new LoadingPage();
            await Navigation.PushAsync(loadingPage);
            _Tapped = true;
            var examId = ((Examdb)e.Item).Id;
            var exam = _database.FetchExam(examId);
            Navigation.InsertPageBefore(new AssessmentPage(null, exam), loadingPage);
            _Tapped = false;
            await Navigation.PopAsync();
            Navigation.RemovePage(this);
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            if (ExamList.SelectedItem == null)
                return;
            //deselect item when pushing
            ExamList.SelectedItem = null;
        }
        private bool _Tapped;
        
        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        private readonly Database _database = new Database();
    }
}
