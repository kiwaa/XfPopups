using System.Threading.Tasks;

namespace xf.popups
{
    public class PopupArguments
    {
        public PopupBase Popup { get; }
        public TaskCompletionSource<bool> Result { get; }

        public PopupArguments(PopupBase popup)
        {
            Popup = popup;
            Result = new TaskCompletionSource<bool>();
        }

        public void SetResult(bool result)
        {
            this.Result.TrySetResult(result);
        }
    }
}