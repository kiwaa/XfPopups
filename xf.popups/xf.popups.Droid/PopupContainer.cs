using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Xamarin.Forms.View;

namespace xf.popups.Droid
{
    internal class PopupContainer : ViewGroup
    {
        public PopupContainer(Context context, View view)
          : base(context)
        {
            _child = RendererFactory.GetRenderer(view);
            SetPlatform(view);
            var viewGroup = _child.ViewGroup;
            _child.Tracker.UpdateLayout();

            AddView(viewGroup);
        }

        private void SetPlatform(View view)
        {
            var platform = App.Current.MainPage.GetPlatform();
            view.SetPlatform(platform);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var width = Context.FromPixels(r - l);
            var height = Context.FromPixels(b - t);
            _child.Element.Layout(new Rectangle(0, 0, width, height));
            _child.UpdateLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _child.Dispose();
            }
            base.Dispose(disposing);
        }

        private readonly IVisualElementRenderer _child;
    }
}