using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{

    public class MenuListData : List<MenuItem>
    {
        public MenuListData ()
        {
            this.Add (new MenuItem () { 
                Title = "Dashboard", 
                IconSource = "leads.png", 
                TargetType = typeof(Dashboard)
            });

            this.Add (new MenuItem () { 
                Title = "Proeven", 
                IconSource = "contacts.png", 
                TargetType = typeof(HomePage)
            });

            this.Add (new MenuItem () { 
                Title = "Test data", 
                IconSource = "contacts.png", 
                TargetType = typeof(DummyPage)
            });
        }
    }
}