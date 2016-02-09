using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage (Category category)
		{
			InitializeComponent();
			Title = "#"+ category.Order.ToString();
			BackgroundColor = Color.White;
			Name.Text = category.Name;
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
	}
}

