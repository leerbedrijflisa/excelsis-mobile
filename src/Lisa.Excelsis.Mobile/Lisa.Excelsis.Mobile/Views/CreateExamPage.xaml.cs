using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateExamPage : ContentPage
    {
        public CreateExamPage(Exam exam)
        {
            InitializeComponent();

            foreach(var assessor in _db.Assessors.Get())
            {
                AssessorPicker.Items.Add(assessor.UserName);
            }
        }

        private readonly Database _db = new Database();
    }
}