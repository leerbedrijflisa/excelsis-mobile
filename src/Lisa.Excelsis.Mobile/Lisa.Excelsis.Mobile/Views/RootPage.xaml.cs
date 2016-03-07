using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class RootPage : MasterDetailPage
    {
        MasterPage masterPage;

        public RootPage()
        {
            MasterBehavior = MasterBehavior.Popover;
            masterPage = new MasterPage();
            masterPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

            Master = masterPage;
            Detail = new HomePage();
        }

        void NavigateTo (MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

            Detail = new NavigationPage (displayPage);
            IsPresented = false;
        }
    }
}

