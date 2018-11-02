using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xam.iOS.Fab.Views
{
    [Register("CircleButton")]
    public class CircleButton : RoundedButton, ISwitchableUIView
    {
        private int _diameter;

        public bool IsSelected
        {
            get => Selected;
            private set => Selected = value;
        }

        //because this is rounded button width = height, and you need to setup only one property
        public override int Height { get => Diameter; set => Diameter = value; }
        public override int Width { get => Diameter; set => Diameter = value; }
        public int Diameter
        {
            get => _diameter == 0 ? (int)Bounds.Size.Width : _diameter;
            set => _diameter = value;
        }

        public bool IsShadowAvailable { get; set; } = true;
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

            CornerRadius = 0.5f * Diameter;

            if (IsShadowAvailable)
            {
                ShadowColor = UIColor.Gray;
                ShadowOffset = new CGSize(0, 4);
                ShadowOpacity = 0.85f;
                ShadowRadius = 5;
            }
            else
            {
                ClipsToBounds = true;
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
