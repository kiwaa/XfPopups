using UIKit;

namespace xf.popups.iOS
{
    class PopupDialogWrapper : IPopup
    {
        private UIView _dialog;

        public PopupDialogWrapper(UIView dialog)
        {
            _dialog = dialog;
        }

        public void Close()
        {
            if (_dialog != null)
            {
                _dialog.RemoveFromSuperview();
                _dialog = null;
            }
        }
    }
}

