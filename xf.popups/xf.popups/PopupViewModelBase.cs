using System.Windows.Input;
using Xamarin.Forms;

namespace xf.popups
{
    internal abstract class PopupViewModelBase
    {
        #region Properties
        // DI via property
        public IPopup Popup { get; set; }
        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new Command(Close));

        #endregion // Properties

        public void Close()
        {
            Popup?.Close();
            OnClose();
        }

        protected virtual void OnClose() { }

        private ICommand _closeCommand;
    }
}