using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage (Assessment assessment)
        {
            InitializeComponent();
            this.Title = "Beoordeling";
            List<Observation> observations = new List<Observation>();
            foreach (var category in assessment.Categories) 
            {
                foreach (var observation in category.Observations)
                {
                    observation.DisplayTitle = observation.Criterion.Order + ". " + observation.Criterion.Title;
                    observations.Add(observation);
                }
            }
            ObservationList.ItemsSource = observations;
        }
    }
}

