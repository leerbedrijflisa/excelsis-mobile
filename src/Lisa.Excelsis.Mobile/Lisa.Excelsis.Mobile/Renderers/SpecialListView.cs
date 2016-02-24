using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class SpecialListView : ListView
	{
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create ("Items", typeof(IEnumerable<DataSource>), typeof(SpecialListView), new List<DataSource> ());

		public IEnumerable<DataSource> Items {
			get { return (IEnumerable<DataSource>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		public void NotifyItemSelected (object item)
		{
			if (ItemSelected != null) {
				ItemSelected (this, new SelectedItemChangedEventArgs (item));
			}
		}
	}
}


