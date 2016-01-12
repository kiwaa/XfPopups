using System.Reflection;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace xf.popups.iOS
{
    public class PopupContainer : UIView
    {
        private IVisualElementRenderer _child;
        public VisualElement Element { get { return _child.Element; } }

        public PopupContainer(IVisualElementRenderer renderer)
        {
            _child = renderer;
            SetPlatform(Element as View);
            _child.NativeView.UserInteractionEnabled = true;
        }

        private void SetPlatform(View view)
        {
            var type = typeof(VisualElement);
            var formsPlatformField = type.GetProperty("Platform", BindingFlags.NonPublic | BindingFlags.Instance);
            var root = App.Current.MainPage;
            var platform = formsPlatformField.GetValue(root);

            var elementType = typeof(Element);
            var elementPlatformProp = elementType.GetProperty("Platform", BindingFlags.NonPublic | BindingFlags.Instance);
            elementPlatformProp.SetValue(view, platform);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (this.Subviews.Length == 0)
                return;
            this.Subviews[0].Frame = new CGRect(0, 0, Element.Width, Element.Height);
        }

    }
}

