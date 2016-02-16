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
						Title = observation.Criterion.Title
					};

					categoryItem.Add(observationItem);
                }
            }
			CategoryList.ItemsSource = categories;

			CategoryList.ItemTapped += (sender, e) => {
				if (e.Item == null) return; 
				((ListView)sender).SelectedItem = null;
			};
        }

        public void OpenItem(object sender, EventArgs e)
        {
            var item = ((StackLayout)sender);
           
            AnimateObservationButtons(item);
		}

        private void AnimateObservationButtons(StackLayout item)
        {
            var buttons = item.FindByName<Grid>("ObservationButtons");
            if (item.ClassId == "opened")
            {           
                item.ClassId = null;
                collapseExpandHeightAnimation("Observation", item, item.Height, item.Height - 91, 1);
                buttons.IsVisible = false;
            }
            else
            {
                item.ClassId = "opened";
                buttons.IsVisible = true;
                collapseExpandHeightAnimation("Observation", item, item.Height, item.Height + 91, 1);
            }
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

        private void collapseExpandHeightAnimation(string name, VisualElement obj, double fromHeight, double toHeight, uint length)
        {
            obj.Animate(
                name: name,
                animation: new Animation(
                    callback: (double d) => { obj.HeightRequest = d; },
                    start: fromHeight,
                    end: toHeight,
                    easing: Easing.SinInOut,
                    finished: null),
                rate: 1,
                length: length);
        }
		public ObservableCollection<ObserveCategory> categories;
    }
}

