using System;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using InterviewApp.Droid.Extensions;
using Presentation.ViewModels;

namespace InterviewApp.Droid
{
    public sealed class FriendViewHolder : RecyclerView.ViewHolder
    {
        private readonly TextView? _nameTextView;
        private readonly TextView? _nickNameTextView;
        private readonly ImageView? _profilePicture;

        public FriendViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public FriendViewHolder(View itemView) : base(itemView)
        {
            _nameTextView = itemView.FindViewById<TextView>(Resource.Id.nameTextView);
            _nickNameTextView = itemView.FindViewById<TextView>(Resource.Id.nickName);
            _profilePicture = itemView.FindViewById<ImageView>(Resource.Id.profileImageView);
            if (_profilePicture != null)
            {
                _profilePicture.OutlineProvider = new CircleOutlineProvider();
                _profilePicture.ClipToOutline = true;
            }
        }

        public void BindViewHolder(FriendViewModel viewModel)
        {
            _profilePicture?.LoadImage(viewModel.ProfilePictureUrl);
            _nameTextView?.SetText(viewModel.Name, TextView.BufferType.Normal);
            _nickNameTextView?.SetText(viewModel.NickName, TextView.BufferType.Normal);
        }
    }

    public sealed class CircleOutlineProvider : ViewOutlineProvider
    {
        public override void GetOutline(View? view, Outline? outline)
        {
            outline?.SetRoundRect(0, 0, view?.Width ?? 0, view?.Height ?? 0, (view?.Height ?? 1) / 2f);
        }
    }
}