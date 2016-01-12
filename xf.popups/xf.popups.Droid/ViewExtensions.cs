using System.Reflection;
using Xamarin.Forms;

namespace xf.popups.Droid
{
    public static class ViewExtensions
    {
        private const string Platform = "Platform";

        public static IPlatform GetPlatform(this VisualElement element)
        {
            var type = typeof(View);
            var fieldInfo = type.GetProperty(Platform, BindingFlags.NonPublic | BindingFlags.Instance);
            return (IPlatform)fieldInfo.GetValue(element);
        }

        public static void SetPlatform(this VisualElement element, IPlatform platform)
        {
            var elementType = typeof(View);
            var elementPlatformProp = elementType.GetProperty(Platform, BindingFlags.NonPublic | BindingFlags.Instance);
            elementPlatformProp.SetValue(element, platform);
        }
    }
}
