using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class CriterionPage : ContentPage
    {
        public CriterionPage()
        {
            InitializeComponent();
            QuestionLabel.Text = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel van Blablabla maar niet blablablabla.";
        }

        private void ToggleSwitch(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            bool t = false;

            if (clickedButton.Text == "Ja")
            {
                YesButton.BackgroundColor = Color.Green;
                NoButton.BackgroundColor = Color.Default;
                t = !t;
            }
            else if (clickedButton.Text == "Nee")
            {
                YesButton.BackgroundColor = Color.Default;
                NoButton.BackgroundColor = Color.Red;
            }

            toggle = t;
        }

        private void DisableSwitch(object sender, EventArgs e)
        {
            YesButton.BackgroundColor = Color.Default;
            NoButton.BackgroundColor = Color.Default;
        }

        private void ToggleInfo(object sender, EventArgs e)
        {
            if (InfoLabel.Text == null)
            {
                InfoLabel.Text = "test tekst!";
            }
            else
            {
                InfoLabel.Text = null;
            }
        }

        private bool toggle = false;
    }
}
