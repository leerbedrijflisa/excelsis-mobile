using System;

namespace Lisa.Excelsis.Mobile
{
    public class ExamListItem : Exam
    {
        public ExamListItem(Exam exam)
        {
            Id = exam.Id;
            Name = exam.Name;
            Cohort = exam.Cohort;
            Crebo = exam.Crebo;
            Subject = exam.Subject;
            Text = String.Format("{0}: {1}, {2}", Subject, Name, Cohort);
        }
        public string Text { get; set; }
    }
}