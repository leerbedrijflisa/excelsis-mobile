using System;
using Xamarin.Forms;
using SQLite.Net;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : CarouselPage
    {
        public AssessmentPage(Assessment assessment)
        {
			foreach(var category in _db.Table<Category>().Where(s => s.e))
			{

			}
            InitializeComponent();
        }

        private void ToggleSwitch(object sender, EventArgs e)
        {
            var button = (Button)sender;
            bool t = false;

            if (button.Text == "Ja")
            {
                YesButton.BackgroundColor = Color.Green;
                NoButton.BackgroundColor = Color.Default;
                t = !t;
            }
            else if (button.Text == "Nee")
            {
                YesButton.BackgroundColor = Color.Default;
                NoButton.BackgroundColor = Color.Red;
            }

            _toggle = t;
        }

        private void DisableSwitch(object sender, EventArgs e)
        {
            YesButton.BackgroundColor = Color.Default;
            NoButton.BackgroundColor = Color.Default;
        }

        private bool _toggle = false;
		private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}