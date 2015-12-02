using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            ExamList.ItemsSource = new Exam[]
            {
                new Exam
                {
                    Id = 1,
                    Name = "Spreken",
                    Cohort = 2015,
                    Subject = "Nederlands"
                },
                new Exam
                {
                    Id = 2,
                    Name = "Lezen & Luisteren",
                    Cohort = 2015,
                    Subject = "Nederlands"
                },
                new Exam
                {
                    Id = 3,
                    Name = "Gesprekken voeren",
                    Cohort = 2015,
                    Subject = "Nederlands"
                }
            };
        }
    }
}
