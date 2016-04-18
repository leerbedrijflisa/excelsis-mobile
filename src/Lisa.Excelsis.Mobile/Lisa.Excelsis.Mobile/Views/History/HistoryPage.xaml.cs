using SQLite.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            Title = "Alle Beoordelingen";

            var assessments = new List<Assessmentdb>();
            foreach (var assessment in _db.Table<Assessmentdb>())
            {
                assessments.Add(assessment);
            }

            var context = new HistoryPageViewModel()
            {
                Assessments = assessments
            };
            context.OnOpenExamPage += OpenExamPage;

            BindingContext = context;

            HistoryList.IsPullToRefreshEnabled = true;
            HistoryList.ItemTapped += async(sender, e) => {
                if (_Tapped)
                    return;
                _Tapped = true;
                var assessment = (Assessmentdb)e.Item;
                await Navigation.PushAsync(new AssessmentPage(assessment));
                _Tapped = false;
            };
            HistoryList.ItemSelected += (sender, e) => {
                if (HistoryList.SelectedItem == null)
                    return;
                //deselect item when pushing
                HistoryList.SelectedItem = null;
            };
        }

        public void OpenExamPage()
        {
            Navigation.PushAsync(new ExamPage());
        }

        public void UpdateAssessments(object sender = null, EventArgs e = null)
        {
            var assessments = new List<Assessmentdb>();
            foreach (var assessment in _db.Table<Assessmentdb>())
            {
                assessments.Add(assessment);
            }
            HistoryList.ItemsSource = assessments;
            HistoryList.EndRefresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateAssessments();
        }

        private bool _Tapped;

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}
