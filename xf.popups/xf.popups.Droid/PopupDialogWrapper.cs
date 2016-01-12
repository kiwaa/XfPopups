using Android.App;

namespace xf.popups.Droid
{
    class PopupDialogWrapper : IPopup
    {
        private Dialog _dialog;

        public PopupDialogWrapper(Dialog dialog)
        {
            _dialog = dialog;
        }

        public void Close()
        {
            _dialog.Dismiss();
        }
    }
}