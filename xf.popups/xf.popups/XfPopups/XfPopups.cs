using System.Threading.Tasks;
using Xamarin.Forms;

namespace xf.popups
{
    public static class XfPopups
    {
        public static Task<bool> ShowPopup(Page page, PopupBase popup)
        {
            var popupArguments = new PopupArguments(popup);
            MessagingCenter.Send(page, Messages.DisplayPopupMessage, popupArguments);
            return popupArguments.Result.Task;
        }
    }
}