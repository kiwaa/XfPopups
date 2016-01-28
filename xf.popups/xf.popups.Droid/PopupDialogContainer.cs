using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using xf.popups.Droid.Infrastructure;
using Xamarin.Forms;

namespace xf.popups.Droid
{
    class PopupDialogContainer
    {
        private readonly PopupArguments _popupArguments;
        private readonly PopupBase _popup;
        private readonly Dialog _dialog;

        public PopupDialogContainer(PopupArguments popupArguments)
        {
            _popupArguments = popupArguments;
            _popup = popupArguments.Popup;

            _dialog = new Dialog(Forms.Context);
            _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

            _popup.CloseRequest += OnCloseRequest;
        }

        public void Show()
        {
            var viewGroup = FormsViewHelper.ConvertFormsToNative(_popup, DisplayHelper.GetSize());
            _dialog.SetContentView(viewGroup);

            // to show dialog container 'fullscreen'
            WindowManagerLayoutParams lp = new WindowManagerLayoutParams();
            lp.CopyFrom(_dialog.Window.Attributes);
            lp.Width = ViewGroup.LayoutParams.MatchParent;
            lp.Height = ViewGroup.LayoutParams.MatchParent;
            _dialog.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
            _dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            _dialog.Show();
            _dialog.Window.Attributes = lp;
        }

        public void Close()
        {
            _dialog.Dismiss();
            _popup.CloseRequest -= OnCloseRequest;
            _popupArguments.SetResult(true);
        }

        private void OnCloseRequest(object sender, EventArgs e)
        {
            Close();
        }
    }
}