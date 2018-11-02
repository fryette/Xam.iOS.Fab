using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Xam.iOS.Fab
{
    [Register("FabButton")]
    public partial class FabButton : UIViewWithBublingEffect
    {
        private UIStackView _stackView;
        private ISwitchableUIView _switchableUIView;
        private UIView _overlay;

        public int ActionItemSpacing { get; set; } = 10;
        public int SpaceBetweenMainButtonAndActionItems { get; set; } = 10;

        public void Initialize(ISwitchableUIView switchableUIView, IEnumerable<NSLayoutConstraint> constraints)
        {
            InitializeInternal(switchableUIView, constraints);
        }

        public void Initialize(ISwitchableUIView switchableUIView, FabAligment aligment, Margin margins)
        {
            var view = (UIView)switchableUIView;
            var constraints = new List<NSLayoutConstraint>(2);

            switch (aligment)
            {
                case FabAligment.TopLeft:
                    constraints.Add(view.TopAnchor.ConstraintEqualTo(TopAnchor, margins.Top));
                    constraints.Add(view.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, margins.Left));
                    break;
                case FabAligment.TopRight:
                    constraints.Add(view.TopAnchor.ConstraintEqualTo(TopAnchor, margins.Top));
                    constraints.Add(view.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -margins.Right));
                    break;
                case FabAligment.BottomLeft:
                    constraints.Add(view.BottomAnchor.ConstraintEqualTo(BottomAnchor, -margins.Bottom));
                    constraints.Add(view.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, margins.Left));
                    break;
                case FabAligment.BottomRight:
                    constraints.Add(view.BottomAnchor.ConstraintEqualTo(BottomAnchor, -margins.Bottom));
                    constraints.Add(view.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -margins.Right));
                    break;
                case FabAligment.Center:
                    constraints.Add(view.CenterXAnchor.ConstraintEqualTo(CenterXAnchor));
                    constraints.Add(view.CenterYAnchor.ConstraintEqualTo(CenterYAnchor));
                    break;
            }

            InitializeInternal(switchableUIView, constraints);
        }

        public FabButton SetActionButton(UIView view)
        {
            _stackView.AddArrangedSubview(view);
            _stackView.SizeToFit();

            return this;
        }

        public FabButton WithOverlay(UIView overlay)
        {
            InitializeOverlay(overlay);
            return this;
        }

        public FabButton WithDefaultOverlay(UIColor color)
        {
            InitializeOverlay(new UIView { BackgroundColor = color });
            return this;
        }

        public FabButton SetOpenDirection(OpenDirections openDirection)
        {
            var mainButtonView = (UIView)_switchableUIView;

            _stackView.ClearConstraints();

            _stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            _stackView.CenterXAnchor.ConstraintEqualTo(mainButtonView.CenterXAnchor).Active = true;

            switch (openDirection)
            {
                case OpenDirections.Top:
                    _stackView.BottomAnchor.ConstraintEqualTo(mainButtonView.TopAnchor, -SpaceBetweenMainButtonAndActionItems).Active = true;
                    break;
                case OpenDirections.Bottom:
                    _stackView.TopAnchor.ConstraintEqualTo(mainButtonView.BottomAnchor, SpaceBetweenMainButtonAndActionItems).Active = true;
                    break;
            }

            return this;
        }

        private void InitializeOverlay(UIView overlayView)
        {
            _overlay?.ClearConstraints();
            overlayView?.ClearConstraints();
            _overlay = overlayView;

            if (_overlay == null)
            {
                return;
            }

            _overlay.Hidden = true;
            InsertSubview(_overlay, 0);

            _overlay.TranslatesAutoresizingMaskIntoConstraints = false;
            _overlay.WidthAnchor.ConstraintEqualTo(WidthAnchor).Active = true;
            _overlay.HeightAnchor.ConstraintEqualTo(HeightAnchor).Active = true;
            _overlay.AddGestureRecognizer(new UITapGestureRecognizer(OnShowChildrenButtonTapped));
        }

        private void InitializeInternal(ISwitchableUIView switchableUIView, IEnumerable<NSLayoutConstraint> constraints)
        {
            var view = switchableUIView as UIView;

            _switchableUIView = switchableUIView;
            AddSubview(view);
            ActivateConstraints(view, constraints);
            view.AddTapGesture(OnShowChildrenButtonTapped);

            InitializeStackView();
        }

        private void InitializeStackView()
        {
            _stackView = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
                Distribution = UIStackViewDistribution.EqualCentering,
                Alignment = UIStackViewAlignment.Center,
                Spacing = ActionItemSpacing,
                Alpha = 0
            };

            AddSubview(_stackView);
        }

        private void OnShowChildrenButtonTapped()
        {
            UpdateActionItemVisibility();
            TryToUpdateOverlay();
            _switchableUIView.SwitchState();
        }

        private void UpdateActionItemVisibility()
        {
            const float animationTime = 0.3f;
            Animate(animationTime, () => _stackView.Alpha = _stackView.Alpha == 0 ? 1 : 0, null);
        }

        private void TryToUpdateOverlay()
        {
            if (_overlay == null)
            {
                return;
            }

            _overlay.Hidden = !_overlay.Hidden;
        }

        private void ActivateConstraints(UIView view, IEnumerable<NSLayoutConstraint> constraints)
        {
            if (constraints == null)
            {
                return;
            }

            view.TranslatesAutoresizingMaskIntoConstraints = false;

            foreach (var constraint in constraints)
            {
                if (constraint.SecondItem != null && constraint.SecondItem.GetType() != typeof(FabButton))
                {
                    view.AddConstraint(constraint);
                }

                constraint.Active = true;
            }
        }
    }
}