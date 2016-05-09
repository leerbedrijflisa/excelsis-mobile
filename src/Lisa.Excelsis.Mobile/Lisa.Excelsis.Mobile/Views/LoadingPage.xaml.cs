
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class LoadingPage : ContentPage
    {
        private string Page;
        private object Parameter;

        public LoadingPage(string page, object parameter)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Page = page;
            Parameter = parameter;

        }

        private async void LoadPage()
        {
            switch (Page)
            {
                case "assessment_old":
                    var assessment = Parameter as Assessmentdb;
                    await Navigation.PushAsync(new AssessmentPage(assessment));
                    break;
                case "assessment_new":
                    var exam = Parameter as Exam;
                    await Navigation.PushAsync(new AssessmentPage(null, exam));
                    break;
            }

            Navigation.RemovePage(this);
        }
            
        protected override void OnAppearing()
        {
            //The page is loaded when the loading page appeares, otherwise the loading page will come over the "to load" page
            LoadPage();
        }
    }
}
