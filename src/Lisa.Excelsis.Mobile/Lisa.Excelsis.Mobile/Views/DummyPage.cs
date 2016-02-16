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
        public async void Redirect()
        {
            var data = DummyData.Fetch();
            await Navigation.PushAsync(new AssessmentPage(data));
        }
    }
}


