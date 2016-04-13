using SQLite.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public delegate void NewAssessmentEventHandler();

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
            context.OnNewAssessment += NewAssessment;

            BindingContext = context;

            HistoryList.IsPullToRefreshEnabled = true;
        }

        public void NewAssessment()
        {
            Navigation.PushAsync(new AssessmentPage());
        }

        public void OpenAssessment(object sender, EventArgs e)
        {
            var assessment = (Assessmentdb)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new AssessmentPage(assessment));
        }

        public void UpdateAssessments(object sender, EventArgs e)
        {
            var assessments = new List<Assessmentdb>();
            foreach (var assessment in _db.Table<Assessmentdb>())
            {
                assessments.Add(assessment);
            }
            HistoryList.ItemsSource = assessments;
            HistoryList.EndRefresh();
        }

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}
