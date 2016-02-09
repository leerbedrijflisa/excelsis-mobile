using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class Observation
	{
		public int Order {get;set;}
		public string Title { get; set;}
	}

	public class Category
	{
		public int Order {get;set;}
		public string Name { get; set;}
		public List<Observation> Observations { get; set; }
	}

	public partial class ObservationPage : ContentPage
	{
		public ObservationPage (Observation observation)
		{
			InitializeComponent();
			Title = observation.Order.ToString ();
			BackgroundColor = Color.White;
			QuestionLabel.Text = observation.Order.ToString() + ". - " + observation.Title;
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

	class ObservationsPage : TabbedPage
	{
		public ObservationsPage ()
		{
			var categories = new List<Category> () {
				new Category {
					Order = 1,
					Name = "Dit is de eerste categorie.",
					Observations = new List<Observation>(){
						new Observation {
							Order = 1,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 2,
							Title = "De kandidaat heeft Bla gedaan en ook blablablabla."
						},
						new Observation {
							Order = 3,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel "
						},
						new Observation {
							Order = 4,
							Title = "De kandidaat  BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 5,
							Title = "De kandidaat heeft Bla la en een deel van Blablabla maar niet blablablabla."
						}
					}
				},
				new Category {
					Order = 2,
					Name = "Dit is de tweede categorie.",
					Observations = new List<Observation>(){
						new Observation {
							Order = 1,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 2,
							Title = "De kandidaat heeft Bla gedaan en ook blablablabla."
						},
						new Observation {
							Order = 3,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel "
						},
						new Observation {
							Order = 4,
							Title = "De kandidaat  BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 5,
							Title = "De kandidaat heeft Bla la en een deel van Blablabla maar niet blablablabla."
						}
					}
				},
				new Category {
					Order = 3,
					Name = "Dit is de derde categorie.",
					Observations = new List<Observation>(){
						new Observation {
							Order = 1,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 2,
							Title = "De kandidaat heeft Bla gedaan en ook blablablabla."
						},
						new Observation {
							Order = 3,
							Title = "De kandidaat heeft Bla gedaan en ook BlaBla en een deel "
						},
						new Observation {
							Order = 4,
							Title = "De kandidaat  BlaBla en een deel van Blablabla maar niet blablablabla."
						},
						new Observation {
							Order = 5,
							Title = "De kandidaat heeft Bla la en een deel van Blablabla maar niet blablablabla."
						}
					}
				}
			};

			this.Title = "Observations";
			foreach (var category in categories) {
				this.Children.Add (new CategoryPage(category));
				foreach (var observation in category.Observations) {
					this.Children.Add (new ObservationPage(observation));
				}
			}
		}
	}
}