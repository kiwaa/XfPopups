using Android.App;

namespace xf.popups.Droid
{
    class PopupDialogAdapter : IPopup
    {
        private Dialog _dialog;

        public PopupDialogAdapter(Dialog dialog)
        {
            _dialog = dialog;
        }

        public void Close()
        {
            _dialog.Dismiss();
        }
    }
}