using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateExamPage : ContentPage
    {
        public CreateExamPage(Exam exam)
        {
            InitializeComponent();

            _exam = exam;

            foreach(var assessor in _db.Assessors.Get())
            {
                AssessorPicker.Items.Add(assessor.UserName);
                SecondAssessorPicker.Items.Add(assessor.UserName);
            }
        }

        public void StartExam(object sender, EventArgs e)
        {
            var isValid = true;

            if(StudentName.Text == null || StudentName.Text.Length == 0)
            {
                StudentName.BackgroundColor = Color.FromRgb(255, 51, 51);
                isValid = false;
            }
            else
            {
                StudentName.BackgroundColor = Color.Default;
            }

            int studentnumber;

            if(StudentNumber.Text == null || StudentNumber.Text.Length != 8 || !Int32.TryParse(StudentNumber.Text, out studentnumber))
            {
                StudentNumber.BackgroundColor = Color.FromRgb(255, 51, 51);
                isValid = false;
            }
            else
            {
                StudentNumber.BackgroundColor = Color.Default;
            }

            if(AssessorPicker.SelectedIndex == -1)
            {
                AssessorPicker.BackgroundColor = Color.FromRgb(255, 51, 51);
                isValid = false;
            }
            else
            {
                AssessorPicker.BackgroundColor = Color.Default;
            }
            
            if (isValid)
            {
                Navigation.PushAsync(new ExamPage(_exam));
            }
        }

        public void EntryChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;

            if(entry.Text != null && entry.Text.Length != 0)
            {
                int iDontCare;
                if(entry.Keyboard == Keyboard.Numeric && Int32.TryParse(entry.Text, out iDontCare))
                {
                    entry.BackgroundColor = Color.Default;
                }
                else
                {
                    return;
                }

                entry.BackgroundColor = Color.Default;
            }
        }

        public void AssessorChanged(object sender, EventArgs e)
        {
            if(((Picker)sender).SelectedIndex != -1)
            {
                ((Picker)sender).BackgroundColor = Color.Default;
            }
        }

        private readonly Exam _exam;
        private readonly Database _db = new Database();
    }
}