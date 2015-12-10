using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class ExamsHomePage : ContentPage
    {
        public ExamsHomePage()
        {
            InitializeComponent();
        }

        public void ExamsList(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        public void CreateExam(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateExamPage());
        }
    }
}

