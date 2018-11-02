using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xam.iOS.Fab
{
    [Register("UIViewWithBublingEffect")]
    public class UIViewWithBublingEffect : UIView
    {
        public UIViewWithBublingEffect()
        {
        }

        protected internal UIViewWithBublingEffect(IntPtr handle) : base(handle)
        {
        }

        public override bool PointInside(CGPoint point, UIEvent uievent)
        {
            foreach (var subview in Subviews)
            {
                if (!subview.Hidden && subview.UserInteractionEnabled && subview.PointInside(ConvertPointToView(point, subview), uievent))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
