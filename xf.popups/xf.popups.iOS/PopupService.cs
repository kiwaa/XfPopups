using System.Linq;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace xf.popups.iOS
{
    public class PopupManagement
    {
        public static PopupManagement Instance = new PopupManagement();

        public void Initialize()
        {
            MessagingCenter.Subscribe<Page, PopupArguments>(this, popups.Messages.DisplayPopupMessage, Show);
        }

        public void Show(Page page, PopupArguments args)
        {
            var popup = args.Popup;

            var app = UIApplication.SharedApplication.Windows.Last();
            var renderer = RendererFactory.GetRenderer(popup);

            var dialogView = new PopupContainer(renderer);
            dialogView.AddSubview(renderer.NativeView);

            var wrapper = new PopupDialogWrapper(dialogView);
            popup.Container = wrapper;

            var bounds = new CGRect(0, 0, app.Bounds.Width, app.Bounds.Height);
            renderer.Element.Layout(bounds.ToRectangle());
            renderer.NativeView.SetNeedsLayout();

            dialogView.Frame = bounds;
            app.AddSubview(dialogView);
        }
    }
}

