using System;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
	public class SpecialListView : ListView
	{
		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		public void NotifyItemSelected (object item)
		{
			if (ItemSelected != null) {
				ItemSelected (this, new SelectedItemChangedEventArgs (item));
			}
		}
	}
}


