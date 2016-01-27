using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class CriterionPage : ContentPage
    {
        public CriterionPage(Criterion criterion)
        {
            InitializeComponent();

            QuestionLabel.Text = criterion.Title;
        }

        private void ToggleSwitch(object sender, EventArgs e)
        {
            var button = (Button)sender;
            bool t = false;

            if (button.Text == "Ja")
            {
                YesButton.BackgroundColor = Color.Green;
                NoButton.BackgroundColor = Color.Default;
                t = !t;
            }
            else if (button.Text == "Nee")
            {
                YesButton.BackgroundColor = Color.Default;
                NoButton.BackgroundColor = Color.Red;
            }

            _toggle = t;
        }

        private void DisableSwitch(object sender, EventArgs e)
        {
            YesButton.BackgroundColor = Color.Default;
            NoButton.BackgroundColor = Color.Default;
        }

        private bool _toggle = false;
    }
}
