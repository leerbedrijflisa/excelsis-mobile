using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStart()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Exam>();

            base.OnStart();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}