using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xam.iOS.Fab.Views
{
    [Register("RoundedButton")]
    public class RoundedButton : UIButton
    {
        private bool _isStylesFirstApplied;

        public nfloat BorderWidth { get; set; }
        public UIColor BorderColor { get; set; }
        public UIColor ShadowColor { get; set; }
        public CGSize ShadowOffset { get; set; }
        public float ShadowOpacity { get; set; }
        public float ShadowRadius { get; set; }
        public nfloat CornerRadius { get; set; } = 25;
        public UIImage NormalStateImage { get; set; }
        public UIImage SelectedStateImage { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public RoundedButton(IntPtr handle) : base(handle)
        {
            InitializeFields();
        }

        public RoundedButton()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            BorderColor = UIColor.Clear;
            ShadowColor = UIColor.FromCGColor(Layer.ShadowColor);
            BorderWidth = Layer.BorderWidth;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Layer.CornerRadius = CornerRadius;

            ApplyShadow();
            ApplyBorder();
            ApplyDimensions();
            ApplyImages();

            _isStylesFirstApplied = true;
        }

        private void ApplyShadow()
        {
            Layer.ShadowColor = ShadowColor.CGColor;
            Layer.ShadowOffset = ShadowOffset;
            Layer.ShadowOpacity = ShadowOpacity;
            Layer.ShadowRadius = ShadowRadius;
        }

        private void ApplyBorder()
        {
            Layer.BorderWidth = BorderWidth;
            Layer.BorderColor = BorderColor.CGColor;
        }

        private void ApplyImages()
        {
            if (_isStylesFirstApplied)
            {
                return;
            }
            if (NormalStateImage != null)
            {
                SetImage(NormalStateImage, UIControlState.Normal);
            }
            if (SelectedStateImage != null)
            {
                SetImage(SelectedStateImage, UIControlState.Selected);
            }
        }

        private void ApplyDimensions()
        {
            if (Width == 0 && Height == 0)
            {
                return;
            }

            TranslatesAutoresizingMaskIntoConstraints = false;

            if (Width != 0)
            {
                WidthAnchor.ConstraintEqualTo(Width).Active = true;
            }
            if (Height != 0)
            {
                HeightAnchor.ConstraintEqualTo(Height).Active = true;
            }
        }
    }
}
