using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class Database
    {
        public Database()
        {
            var connection = DependencyService.Get<ISQLite>().GetConnection();

            Exams = new Table<Exam>(connection);
            Assessors = new Table<Assessor>(connection);
            Criteria = new Table<Criterion>(connection);
            Assessments = new Table<Assessment>(connection);
            Observations = new Table<Observation>(connection);
            Categories = new Table<Category>(connection);
        }

        public Table<Exam> Exams { get; set; }
        public Table<Assessor> Assessors { get; set; }
        public Table<Criterion> Criteria { get; set; }
        public Table<Assessment> Assessments { get; set; }
        public Table<Observation> Observations { get; set; }
        public Table<Category> Categories { get; set; }
    }
}