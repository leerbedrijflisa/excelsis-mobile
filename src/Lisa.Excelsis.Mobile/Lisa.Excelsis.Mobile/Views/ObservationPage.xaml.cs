using System;
using Xamarin.Forms;
using System.Collections.Generic;
using XLabs.Forms.Controls;

namespace Lisa.Excelsis.Mobile
{
	public partial class ObservationPage : ContentPage
	{
		public ObservationPage (Observation observation)
		{
			InitializeComponent();
            Title = observation.Criterion.Title;
			BackgroundColor = Color.White;
            QuestionLabel.Text = observation.Criterion.Title;
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

		private void ChangeTab(object sender, EventArgs e)
		{
			var clickedButton = (Button)sender;
			var page = this.Parent as TabbedPage;

			if (clickedButton.Text == "Volgende") 
			{				
				int index = page.Children.IndexOf (this) + 1;
				page.CurrentPage = page.Children [(index < page.Children.Count )? index : page.Children.Count-1];
			} 
			else 
			{
				int index = page.Children.IndexOf (this) - 1;
				page.CurrentPage = page.Children [(index > 0 )? index : 0];
			}
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

	class ObservationsPage : CarouselPage
	{
        public ObservationsPage (Assessment assessment)
		{
			this.Title = "Beoordeling";
            foreach (var category in assessment.Categories) {
				this.Children.Add (new CategoryPage(category));
				foreach (var observation in category.Observations) {
					this.Children.Add (new ObservationPage(observation));
				}
			}
		}
	}
}