using Xamarin.Forms;

namespace xf.popups.Droid
{
    internal class XfPopups
    {
        private static XfPopups Instance = new XfPopups();

        public static void Init()
        {
            MessagingCenter.Subscribe<Page, PopupArguments>(Instance, Messages.DisplayPopupMessage, Instance.Show);
        }

        private void Show(Page page, PopupArguments args)
        {
            args.Popup.Parent = page;

            var container = new PopupDialogContainer(args);
            container.Show();
        }
    }
}