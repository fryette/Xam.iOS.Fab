// Developed for LilBytes by Softeq Development Corporation
//
using System;
using CoreGraphics;
using UIKit;
using Xam.iOS.Fab.Views;

namespace Xam.iOS.Fab.Sample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitilizeEditRedFloatButton();
            InitializeYellowEditButton();
        }

        //Red button
        private void InitilizeEditRedFloatButton()
        {
            var fabButton = new FabButton
            {
                Frame = RootView.Frame,
                SpaceBetweenMainButtonAndActionItems = 20,
                ActionItemSpacing = 12
            };

            var margin = new Margin(8, (int)HeaderView.Frame.Height - 28);
            var mainButton = CreateMainButton(56, UIColor.FromRGB(245, 1, 87));
            fabButton.Initialize(mainButton, FabAligment.TopRight, margin);

            fabButton.WithDefaultOverlay(UIColor.FromRGBA(0f, 0f, 0f, 0.34f))
                     .SetOpenDirection(OpenDirections.Bottom);

            SetActionButtons(fabButton, mainButton.BackgroundColor);

            fabButton.SetActionButton(new CircleButton
            {
                BackgroundColor = UIColor.White,
                NormalStateImage = UIImage.FromBundle("Close"),
                Diameter = 46
            });

            RootView.AddSubview(fabButton);
        }

        private void InitializeYellowEditButton()
        {
            var fabButton = new FabButton
            {
                Frame = RootView.Frame,
                SpaceBetweenMainButtonAndActionItems = 20,
                ActionItemSpacing = 12
            };

            var mainButton = CreateMainButton(56, UIColor.FromRGB(255, 183, 5));

            fabButton.Initialize(mainButton, FabAligment.BottomRight, new Margin(23, 23));
            fabButton.SetActionButton(new CircleButton
            {
                BackgroundColor = UIColor.White,
                NormalStateImage = UIImage.FromBundle("Close"),
                Diameter = 46
            });

            fabButton.WithDefaultOverlay(UIColor.FromRGBA(0f, 0f, 0f, 0.34f)).SetOpenDirection(OpenDirections.Top);
            SetActionButtons(fabButton, mainButton.BackgroundColor);

            RootView.AddSubview(fabButton);
        }

        private void SetActionButtons(FabButton button, UIColor color)
        {
            for (var i = 0; i < 5; i++)
            {
                button.SetActionButton(new CircleButton
                {
                    BorderColor = UIColor.White,
                    BorderWidth = 2,
                    NormalStateImage = UIImage.FromBundle("Edit").Scale(new CGSize(22, 22)),
                    Diameter = 46,
                    IsShadowAvailable = false,
                    BackgroundColor = color
                });
            }
        }

        private CircleButton CreateMainButton(int size, UIColor color)
        {
            var button = new CircleButton
            {
                BorderWidth = 2,
                BackgroundColor = color,
                NormalStateImage = UIImage.FromBundle("Edit"),
                SelectedStateImage = UIImage.FromBundle("CloseWhite"),
                Diameter = size,
            };

            button.SelectedAnimation = button.DeselectedAnimation = new Animation(0.25, () =>
             {
                 button.Transform = CGAffineTransform.MakeRotation((nfloat)Math.PI);
             }, () =>
             {
                 button.Transform = CGAffineTransform.MakeRotation(0);
             });

            return button;
        }
    }
}