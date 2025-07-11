using CoreGraphics;
using UIKit;

namespace InterviewApp.iOS.Extensions
{
    public static class UINavigationBarExtensions
    {
        /// <summary>
        /// Apply the Golf app style to the navigation bar
        /// </summary>
        public static void ApplyAppAppearance(this UINavigationBar navigationBar, bool isTransparent = false)
        {
            var appearance = new UINavigationBarAppearance();
            if (isTransparent)
            {
                appearance.ConfigureWithTransparentBackground();
                appearance.BackgroundColor = UIColor.Clear;
            }
            else
            {
                appearance.ConfigureWithOpaqueBackground();
                appearance.BackgroundColor = UIColor.White;
                appearance.ShadowColor = UIColor.Clear;
                appearance.ShadowImage = new UIImage();
            }

            var herp = UIFont.FontNamesForFamilyName("Oswald");

            appearance.TitleTextAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName("Oswald-Regular_Medium", 18),
                ForegroundColor = UIColor.FromRGB(0x41, 0x41, 0x41)
            };
            navigationBar.StandardAppearance = appearance;
            navigationBar.ScrollEdgeAppearance = appearance;
            navigationBar.Translucent = isTransparent;
            navigationBar.TintColor = isTransparent ? UIColor.White : UIColor.Black;
            navigationBar.BarTintColor = UIColor.White;

            navigationBar.Layer.MasksToBounds = false;
            navigationBar.Layer.ShadowColor = UIColor.LightGray.CGColor;
            navigationBar.Layer.ShadowOffset = new CGSize(0, 2f);
            navigationBar.Layer.ShadowRadius = 2;
            navigationBar.Layer.ShadowOpacity = 0.4f;
        }
    }
}