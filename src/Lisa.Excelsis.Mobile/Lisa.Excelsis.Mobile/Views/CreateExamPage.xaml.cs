﻿using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateExamPage : ContentPage
    {
        public bool toggle = false;

        public CreateExamPage(Exam exam)
        {
            InitializeComponent();

            question.Text = "De kanidaat heeft Bla gedaan en ook BlaBla en een deel van Blablabla maar niet blablablabla.";
        }

        private void ToggleSwitch(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool t = false;

            if (btn.Text == "Yes")
            {
                yesBtn.BackgroundColor = Color.Green;
                noBtn.BackgroundColor = Color.Default;
                t = !t;
            }
            else if (btn.Text == "No")
            {
                yesBtn.BackgroundColor = Color.Default;
                noBtn.BackgroundColor = Color.Red;
            }

            toggle = t;
        }

        private void DisableSwitch(object sender, EventArgs e)
        {
            yesBtn.BackgroundColor = Color.Default;
            noBtn.BackgroundColor = Color.Default;
        }
    }
}
