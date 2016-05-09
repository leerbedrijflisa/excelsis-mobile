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

            noDataMessage.IsVisible = (assessments.Count == 0);
            BindingContext = context;

            HistoryList.IsPullToRefreshEnabled = true;
            HistoryList.ItemTapped += OnItemTapped;
            HistoryList.ItemSelected += OnItemSelected;
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
            noDataMessage.IsVisible = (assessments.Count == 0);
            HistoryList.ItemsSource = assessments;
            HistoryList.EndRefresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, true);
            UpdateAssessments();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_Tapped)
                return;
            _Tapped = true;
            var assessment = (Assessmentdb)e.Item;
            NavigationPage.SetHasNavigationBar(this, false);
            await Navigation.PushAsync(new LoadingPage("assessment_old", assessment));
            _Tapped = false;
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            if (HistoryList.SelectedItem == null)
                return;
            //deselect item when pushing
            HistoryList.SelectedItem = null;
        }

        private bool _Tapped;

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}
