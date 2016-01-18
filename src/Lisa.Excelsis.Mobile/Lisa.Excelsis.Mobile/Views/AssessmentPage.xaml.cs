using Xamarin.Forms;
using SQLite.Net;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : CarouselPage
    {
        public AssessmentPage(Exam exam)
        {
            Children.Add(new CreateAssessmentPage(exam));

            foreach (var category in _db.Table<Category>().Where(s => s.ExamId == exam.Id))
            {
                foreach (var criterion in _db.Table<Criterion>().Where(x => x.CategoryId == category.Id))
                {
                    Children.Add(new CriterionPage(criterion));
                }
            }

            InitializeComponent();
        }

        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}