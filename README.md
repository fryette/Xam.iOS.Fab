# Xam.iOS.Fab

This doc will be updated

#### Usage
```csharp
private void InitializeFloatButton()
        {
            var fabButton = new FabButton
            {
                Frame = FloatButtonContainer.Frame,
                SpaceBetweenMainButtonAndActionItems = 20,
                ActionItemSpacing = 12
            };
            fabButton.Initialize(CreateMainFloatingButton(), FabAligment.BottomRight, new Margin(22, 23));
            fabButton.WithDefaultOverlay(UIColor.FromRGBA(0f, 0f, 0f, 0.34f))
                     .SetOpenDirection(OpenDirections.Top);

            fabButton.SetActionButton(CreateAddActionButton());

            for (var i =0; i< 5; i++)
            {
                fabButton.SetActionButton(CreateActionItem());
            }

            FloatButtonContainer.AddSubview(fabButton);
        }

        private CircleButton CreateActionItem()
        {
            return new CircleButton
            {
                BorderColor = UIColor.White,
                BorderWidth = 2,
                NormalStateImage = UIImage.FromBundle("AppIcon"),
                Diameter = 46,
                IsShadowAvailable = false,
            };
        }

        private CircleButton CreateAddActionButton()
        {
            return new CircleButton
            {
                BackgroundColor = UIColor.White,
                NormalStateImage = UIImage.FromBundle("AppIcon"),
                Diameter = 46
            };
        }

        private CircleButton CreateMainFloatingButton()
        {
            return new CircleButton
            {
                BorderWidth = 2,
                BackgroundColor = Defines.Colors.ApplicationColor,
                NormalStateImage = UIImage.FromBundle("AppIcon"),
                SelectedStateImage = UIImage.FromBundle("AppIcon"),
                Diameter = 56,
            };
        }
```
