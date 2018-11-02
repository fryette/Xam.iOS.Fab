using System;
using UIKit;

namespace Xam.iOS.Fab
{
    public static class UIViewExtensions
    {
        public static void AddTapGesture(this UIView target, Action action, int tapNumber = 1)
        {
            var tap = new UITapGestureRecognizer(action)
            {
                NumberOfTapsRequired = (nuint)tapNumber
            };

            target.AddGestureRecognizer(tap);
            target.UserInteractionEnabled = true;
        }

        public static void ClearConstraints(this UIView view)
        {
            foreach (var subview in view.Subviews)
            {
                subview.ClearConstraints();
            }

            view.RemoveConstraints(view.Constraints);
        }
    }
}
