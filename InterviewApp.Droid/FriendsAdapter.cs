using System.Collections.ObjectModel;
using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Presentation.ViewModels;

namespace InterviewApp.Droid
{
    public sealed class FriendsAdapter : RecyclerView.Adapter
    {
        private readonly ObservableCollection<FriendViewModel>? _friends;
        private readonly LayoutInflater? _layoutInflater;

        public FriendsAdapter(Context context, ObservableCollection<FriendViewModel>? friends)
        {
            _friends = friends;
            _layoutInflater = LayoutInflater.FromContext(context);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is FriendViewHolder friendViewHolder)
            {
                friendViewHolder.BindViewHolder(_friends![position]);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
            new FriendViewHolder(_layoutInflater!.Inflate(Resource.Layout.item_friend, parent, false)!);

        public override int ItemCount => _friends?.Count ?? 0;
    }
}