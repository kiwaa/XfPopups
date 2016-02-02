using System.Linq;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace xf.popups.iOS
{
	public class PopupDialogContainer
	{
		PopupArguments _popupArguments;
		PopupBase _popup;

		UIView _view;

		public PopupDialogContainer(PopupArguments popupArguments)
		{
			_popupArguments = popupArguments;
			_popup = popupArguments.Popup;

			_popup.CloseRequest += OnCloseRequest;
		}

		public void Show()
		{
			var parentWindow = UIApplication.SharedApplication.KeyWindow;
			_view = FormsViewHelper.ConvertFormsToNative (_popup, parentWindow.Bounds);

			parentWindow.AddSubview (_view);
		}

		public void Close()
		{
			if (_view != null)
				_view.RemoveFromSuperview ();
			_popup.CloseRequest -= OnCloseRequest;
			_popupArguments.SetResult(true);
		}

		void OnCloseRequest (object sender, System.EventArgs e)
		{
			Close ();
		}
	}

}

