using Xamarin.Forms;

namespace xf.popups
{
    public class PopupSample : PopupBase
    {
        public PopupSample()
        {
            var button = new Button()
            {
                Text = "Hello XF.Popups!",
                BorderRadius = 5,
                BackgroundColor = Color.FromHex("56a2d6"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            button.Clicked += (sender, args) => Close();
            Content = button;
        }
    }
}
