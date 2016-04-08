using System;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class DummyPage : ContentPage
    {
        public DummyPage()
        {
            Redirect();
        }
        public void Redirect()
        {
            var data = DummyData.FetchAssessment();
           // await Navigation.PushAsync(new AssessmentPage(data));
        }
    }
}


