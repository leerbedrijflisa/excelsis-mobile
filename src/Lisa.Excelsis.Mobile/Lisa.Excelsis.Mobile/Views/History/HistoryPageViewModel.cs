using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class HistoryPageViewModel
    {
        public HistoryPageViewModel()
        {
            NewCommand = new Command(NewAssessment);
        }

        public event NewAssessmentEventHandler OnOpenExamPage;
        public ICommand NewCommand { get; set; }

        public void NewAssessment()
        {
            OnOpenExamPage();
        }

        public bool NoDataMessage { get; set; }
        public List<Assessmentdb> Assessments { get; set; }
    }
}
