// Developed for LilBytes by Softeq Development Corporation

using System;
using CoreGraphics;
using Foundation;
using UIKit;
using Xam.iOS.Fab;

namespace LilWatches.iOS.Views
{
    [Register("CircleButton")]
    public class CircleButton : RoundedButton, ISwitchableUIView
    {
        public bool IsSelected
        {
            get => Selected;
            private set => Selected = value;
        }

        //because this is rounded button width = height, and you need to setup only one property
        public override int Height { get => Diameter; set => Diameter = value; }
        public override int Width { get => Diameter; set => Diameter = value; }
        public int Diameter { get; set; }
        public bool IsShadowAvailable { get; set; }
        public Animation SelectedAnimation { get; set; }
        public Animation DeselectedAnimation { get; set; }

        public CircleButton(IntPtr handle) : base(handle)
        {
        }

        public CircleButton()
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            CornerRadius = 0.5f * Bounds.Size.Width;

            if (!IsShadowAvailable)
            {
                ShadowColor = UIColor.Gray;
                ShadowOffset = new CGSize(0, 4);
                ShadowOpacity = 0.85f;
                ShadowRadius = 5;
            }
        }

        public void SwitchState()
        {
            if (IsSelected && DeselectedAnimation != null)
            {
                Animate(DeselectedAnimation.Duration, DeselectedAnimation.Action, SwitchStateInternal);
            }
            else if (SelectedAnimation != null)
            {
                Animate(SelectedAnimation.Duration, SelectedAnimation.Action, SwitchStateInternal);
            }
            else
            {
                IsSelected = !IsSelected;
            }
        }

        private void SwitchStateInternal()
        {
            IsSelected = !IsSelected;

            if (IsSelected)
            {
                SetImage(SelectedStateImage, UIControlState.Normal);
            }
            else if (SelectedStateImage != null)
            {
                SetImage(NormalStateImage, UIControlState.Normal);
            }
        }
    }
}
