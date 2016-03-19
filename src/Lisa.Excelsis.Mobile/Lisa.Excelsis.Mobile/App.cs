using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Lisa.Excelsis.Mobile
{
    public class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStart()
        {
            // make sure the tables are created before doing any database logic
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Examdb>();
            db.CreateTable<Assessordb>();
            db.CreateTable<AssessmentAssessordb>();
            db.CreateTable<Assessmentdb>();
            db.CreateTable<Categorydb>();
            db.CreateTable<Observationdb>();
            db.CreateTable<Markdb>();

            base.OnStart();

            MainPage = new NavigationPage(new AssessmentPage()){
                BarBackgroundColor = Color.FromRgb(255, 165, 0),
                BarTextColor = Color.White
            };

        }
    }
}