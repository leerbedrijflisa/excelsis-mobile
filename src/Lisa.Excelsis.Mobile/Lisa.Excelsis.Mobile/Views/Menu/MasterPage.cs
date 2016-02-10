using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public partial class MasterPage : ContentPage
    {
        public ListView Menu { get; set; }

        public MasterPage()
        {
            Title = "menu";
            Icon = "settings.png";
            BackgroundColor = Color.FromHex ("333333");

            Menu = new MenuListView ();

            var menuLabel = new ContentView {
                Padding = new Thickness (10, 36, 0, 5),
                Content = new Label {
                    TextColor = Color.FromHex ("AAAAAA"),
                    Text = "MENU", 
                }
            };

            var layout = new StackLayout { 
                Spacing = 0, 
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            layout.Children.Add (menuLabel);
            layout.Children.Add (Menu);

            Content = layout;
        }
    }
}

