using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xf.popups
{
    public class App : Application
    {
        public App()
        {
            var showpopup = new Button()
            {
                Text = "Show Popup"
            };
            showpopup.Clicked += (sender, args) => MainPage.DisplayPopup(new PopupSample());
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        showpopup
                    }
                }
            };
        }
    }
}
