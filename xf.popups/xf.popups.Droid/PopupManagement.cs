using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace xf.popups.Droid
{
    class PopupManagement
    {
        public static PopupManagement Instance = new PopupManagement();

        public void Initialize()
        {
            MessagingCenter.Subscribe<Page, PopupArguments>(this, Messages.DisplayPopupMessage, Show);
        }

        private void Show(Page page, PopupArguments args)
        {
            var popup = args.Popup;
            // part of layout system
            popup.Parent = page;

            // convert Xamarin.Forms view to native view
            ViewGroup viewGroup = new PopupContainer(Forms.Context, popup);

            var dialog = new Dialog(Forms.Context);
            dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
            dialog.SetContentView(viewGroup);

            // adapter to provide close ability for client code
            var wrapper = new PopupDialogAdapter(dialog);
            popup.Container = wrapper;

            // to show dialog container 'fullscreen'
            WindowManagerLayoutParams lp = new WindowManagerLayoutParams();
            lp.CopyFrom(dialog.Window.Attributes);
            lp.Width = ViewGroup.LayoutParams.MatchParent;
            lp.Height = ViewGroup.LayoutParams.MatchParent;
            dialog.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
            dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            dialog.Show();
            dialog.Window.Attributes = lp;
        }
    }
}