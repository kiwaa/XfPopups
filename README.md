# XfPopups
Custom popups in Xamarin.Forms example

This is an example of how to use Xamarin.Forms Renderers to show custom popup dialogs on each platform. 
Details in the blogpost: http://gooingdeep.blogspot.ru/2016/02/custom-popup-dialog-in-xamarinforms.html

How to use it:

	// create popup
	public class PopupSample : PopupBase
    {
        public PopupSample()
        {
            var button = new Button()
            {
                Text = "Close",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("56a2d6"),
                BorderRadius = 0,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };
            button.Clicked += (sender, args) => Close();
            Content = new StackLayout()
            {
                Padding = 20,
                BackgroundColor = Color.White,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    button
                }
            };
        }
    }
	
	// show it
	MainPage.DisplayPopup(new PopupSample())
