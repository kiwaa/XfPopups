using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

namespace xf.popups.iOS
{
	internal static class FormsViewHelper
	{
		// Code taken from 
		// http://www.michaelridland.com/xamarin/creating-native-view-xamarin-forms-viewpage/
		public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
		{
			var renderer = Platform.CreateRenderer(view);

			renderer.NativeView.Frame = size;

			renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
			renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

			renderer.Element.Layout (size.ToRectangle());

			var nativeView = renderer.NativeView;

			nativeView.SetNeedsLayout ();

			return nativeView;
		}
	}
}

