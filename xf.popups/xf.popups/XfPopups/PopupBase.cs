using Xamarin.Forms;

namespace xf.popups
{
    public abstract class PopupBase : ContentView, IPopup
    {
        public IPopup Container { get; set; }
        
        public void Close()
        {
            Container?.Close();
            Parent = null;
        }
    }
}