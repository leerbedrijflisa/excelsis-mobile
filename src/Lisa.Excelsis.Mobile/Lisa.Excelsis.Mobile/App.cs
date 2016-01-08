using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Assessment>();
            db.CreateTable<AssessmentAssessor>();
            db.CreateTable<Assessor>();
            db.CreateTable<Category>();
            db.CreateTable<Criterion>();
            db.CreateTable<Exam>();
            db.CreateTable<Mark>();
            db.CreateTable<Observation>();
            db.CreateTable<Student>();

            base.OnStart();
        }
    }
}