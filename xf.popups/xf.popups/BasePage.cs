using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xf.popups
{
    internal abstract class BasePage : ContentPage
    {
        public Task<bool> DisplayPopup(PopupBase popup)
        {
            if (popup == null)
            {
                throw new ArgumentNullException("popup");
            }
            var popupArguments = new PopupArguments(popup);
            MessagingCenter.Send<Page, PopupArguments>(this, Messages.DisplayPopupMessage, popupArguments);
            return popupArguments.Result.Task;
        }
    }
}
