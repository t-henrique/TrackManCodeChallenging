using Android.Content;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;

namespace InterviewApp.Droid.Extensions
{
    public static class GlideExtensions
    {
        public static void LoadImage(this ImageView imageView, string imageUrl, Context? context = null) =>
            GetRequestManager(imageView, context)
                .Load(imageUrl).Into(imageView);

        private static RequestManager GetRequestManager(View imageView, Context? context)
        {
            RequestManager requestManager = context != null ? Glide.With(context) : Glide.With(imageView);
            return requestManager;
        }
    }
}