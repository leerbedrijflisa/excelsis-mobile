using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class LoadingPage : ContentPage
    {     
        public LoadingPage(string page, object parameter)
        {           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _page = page;
            _parameter = parameter;
        }

        protected async override void OnAppearing()
        {            
            //android hack https://forums.xamarin.com/discussion/comment/93957/#Comment_93957;
            await Task.Yield();
            //The page is loaded when the loading page appeares, otherwise the loading page will come over the "to load" page
            LoadPage();
        }
               
        private async void LoadPage()
        {
            switch (_page)
            {
                case "assessment_old":
                    var assessment = _parameter as Assessmentdb;
                    await Navigation.PushAsync(new AssessmentPage(assessment));
                    break;
                case "assessment_new":
                    var exam = _parameter as Exam;
                    await Navigation.PushAsync(new AssessmentPage(null, exam));
                    break;
            }

            Navigation.RemovePage(this);
        }

        private string _page;
        private object _parameter;
    }
}