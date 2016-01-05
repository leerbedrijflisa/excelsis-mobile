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
        }

        public Table<Exam> Exams { get; set; }
        public Table<Assessor> Assessors { get; set; }
    }
}