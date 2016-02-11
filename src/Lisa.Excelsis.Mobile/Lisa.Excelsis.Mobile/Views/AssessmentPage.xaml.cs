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
			ObservableCollection<ObserveCategory> categories = new ObservableCollection<ObserveCategory>();
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
						DisplayTitle = observation.Criterion.Order + ". " + observation.Criterion.Title
					};

					categoryItem.Add(observationItem);
                }
            }
			CategoryList.ItemsSource = categories;
        }
    }
}

