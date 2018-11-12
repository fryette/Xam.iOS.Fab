// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Xam.iOS.Fab.Sample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIView HeaderView { get; set; }

		[Outlet]
		UIKit.UIView RootView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RootView != null) {
				RootView.Dispose ();
				RootView = null;
			}

			if (HeaderView != null) {
				HeaderView.Dispose ();
				HeaderView = null;
			}
		}
	}
}
