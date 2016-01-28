using System;
using Xamarin.Forms;

namespace xf.popups
{
    public abstract class PopupBase : ContentView
    {
        public event EventHandler CloseRequest = delegate { };

        public void Close()
        {
            Parent = null;
            RaiseCloseRequest();
        }

        private void RaiseCloseRequest()
        {
            CloseRequest(this, EventArgs.Empty);
        }
    }
}