using Foundation;
using ImageCaching.Nuke;
using UIKit;

namespace InterviewApp.iOS.Extensions
{
    public static class NukeExtensions
    {
        public static void LoadImage(this UIImageView imageView, string imageUrl) =>
            ImagePipeline.Shared?.LoadImageWithUrl(new NSUrl(imageUrl), null, null, imageView);
    }
}