using System;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
	public class CategoryPage : ContentPage
	{
		public CategoryPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


