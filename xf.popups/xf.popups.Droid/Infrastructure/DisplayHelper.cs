using Android.App;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace xf.popups.Droid.Infrastructure
{
    internal static class DisplayHelper
    {
        public static Rectangle GetSize()
        {
            Display display = (Forms.Context as Activity).WindowManager.DefaultDisplay;
            var size = new Android.Graphics.Point();
            display.GetSize(size);

            int width = (int)Forms.Context.FromPixels(size.X);
            int height = (int)Forms.Context.FromPixels(size.Y);
            return new Rectangle(0, 0, width, height);
        }
    }
}