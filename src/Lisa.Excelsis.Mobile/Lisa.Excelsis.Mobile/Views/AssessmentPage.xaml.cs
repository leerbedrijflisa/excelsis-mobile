using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage (Assessment assessment)
        {
            InitializeComponent();
            this.Title = "Beoordeling";
			categories = new ObservableCollection<ObserveCategory>();
            foreach (var category in assessment.Categories) 
            {
				var categoryItem = new ObserveCategory () {
					Id = category.Id,
					Name = category.Name
				};
				categories.Add (categoryItem);

                foreach (var observation in category.Observations)
                {
					var observationItem = new ObserveObservation () {
						Id = observation.Id,
						Order = observation.Criterion.Order.ToString(),
						Title = observation.Criterion.Title,
						DisplayTitle = observation.Criterion.Order + ". " + observation.Criterion.Title
					};

					categoryItem.Add(observationItem);
                }
            }
			CategoryList.ItemsSource = categories;

			CategoryList.ItemTapped += (sender, e) => {
				// don't do anything if we just de-selected the row
				if (e.Item == null) return; 
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row after ripple effect
			};
        }

		public void OpenItem(object sender, EventArgs e)
		{
		}

		public void SetYesImage(object sender, EventArgs e)
		{
			var source = ((Image)sender).Source as FileImageSource;
			((Image)sender).Source = (source.File == "yesnobutton1.png")? "yesnobutton0.png": "yesnobutton1.png";
		}

		public void SetNoImage(object sender, EventArgs e)
		{
			var source = ((Image)sender).Source as FileImageSource;
			((Image)sender).Source = (source.File == "yesnobutton2.png")? "yesnobutton0.png": "yesnobutton2.png";
		}

		public ObservableCollection<ObserveCategory> categories;
    }
}

