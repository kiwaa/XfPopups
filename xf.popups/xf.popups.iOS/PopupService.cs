using System.Linq;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace xf.popups.iOS
{
    internal class XfPopups
    {
		private static XfPopups Instance = new XfPopups();

		public static void Init()
		{
			MessagingCenter.Subscribe<Page, PopupArguments>(Instance, Messages.DisplayPopupMessage, Instance.Show);
		}

        public void Show(Page page, PopupArguments args)
        {
			args.Popup.Parent = page;

			var container = new PopupDialogContainer(args);
			container.Show();
        }
    }
}

