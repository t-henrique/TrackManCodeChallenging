using UIKit;

namespace InterviewApp.iOS.Extensions
{
    public static class UILabelExtensions
    {
        public static void SetText(this UILabel label, string? text) => label.Text = text;
    }
}