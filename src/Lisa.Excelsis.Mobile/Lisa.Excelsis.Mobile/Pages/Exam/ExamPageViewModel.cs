using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class ExamPageViewModel
    {
        public ExamPageViewModel()
        {
            NewCommand = new Command(NewAssessment);
        }

        public event NewAssessmentEventHandler OnNewAssessment;
        public ICommand NewCommand { get; set; }

        public void NewAssessment()
        {
            OnNewAssessment();
        }

        public bool NoDataMessage { get; set; }
        public List<Examdb> Exams { get; set; }
    }
}
