using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xf.popups
{
    public static class PageExtension
    {
        public static Task<bool> DisplayPopup(this Page page, PopupBase popup)
        {
            if (popup == null)
            {
                throw new ArgumentNullException("popup");
            }
            var popupArguments = new PopupArguments(popup);
            MessagingCenter.Send(page, Messages.DisplayPopupMessage, popupArguments);
            return popupArguments.Result.Task;
        }
    }
}
