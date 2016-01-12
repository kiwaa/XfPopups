using Xamarin.Forms;

namespace xf.popups
{
    public abstract class PopupBase : ContentView, IPopup
    {
        // DI
        public IPopup Container { get; set; }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var vm = BindingContext as PopupViewModelBase;
            if (vm == null)
                return;

            vm.Popup = this;
        }

        public void Close()
        {
            Container?.Close();
        }
    }
}