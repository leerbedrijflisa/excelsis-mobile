using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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
            var item = ((StackLayout)sender).Parent.FindByName<StackLayout>("ObservationButtons");
            item.IsVisible = (item.IsVisible) ? false : true;
            if (OldItem != null && OldItem.ClassId != item.ClassId)
            {
                OldItem.IsVisible = false;
            }
            OldItem = item;
		}

		public void SetYesImage(object sender, EventArgs e)
		{
            ((Image)sender).Parent.FindByName<Image>("noImage").Source = "yesnobutton0.png";

            var source =  ((Image)sender).Source as FileImageSource;
            if(source.File == "yesnobutton1.png")
            { 
                ((Image)sender).Source = "yesnobutton0.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            else
            { 
                ((Image)sender).Source = "yesnobutton1.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Lime;
            }
		}

		public void SetNoImage(object sender, EventArgs e)
		{
            ((Image)sender).Parent.FindByName<Image>("yesImage").Source = "yesnobutton0.png";

            var source =  ((Image)sender).Source as FileImageSource;
            if(source.File == "yesnobutton2.png")
            { 
                ((Image)sender).Source = "yesnobutton0.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            else
            { 
                ((Image)sender).Source = "yesnobutton2.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Red;
            }
		}

        private void SetMark(object sender, EventArgs e)
        {
            var source = ((Image)sender).Source as FileImageSource;
            string image;

            if(Regex.IsMatch(source.File,"_COLOR.png"))
            { 
                MarkActiveCount--;
                image = source.File.Split('_')[0] + ".png"; 
            }
            else
            {
                MarkActiveCount++;
                image = source.File.Split('.')[0] + "_COLOR.png";
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.FromRgb(255,165,0);
            }

            if (MarkActiveCount == 0)
            {
                ((Image)sender).Parent.FindByName<Label>("ObservationTitle").TextColor = Color.Black;
            }
            ((Image)sender).Source = image;
        }
       
		private ObservableCollection<ObserveCategory> categories;

        private StackLayout OldItem;

        private int MarkActiveCount = 0;
    }
}

