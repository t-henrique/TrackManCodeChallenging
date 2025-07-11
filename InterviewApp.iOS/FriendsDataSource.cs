using System;
using System.Collections.ObjectModel;
using Foundation;
using Presentation.ViewModels;
using UIKit;

namespace InterviewApp.iOS
{
    public sealed class FriendsDataSource : UICollectionViewDataSource
    {
        private readonly ObservableCollection<FriendViewModel>? _friends;

        public FriendsDataSource(ObservableCollection<FriendViewModel>? friends)
        {
            _friends = friends;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section) => _friends?.Count ?? 0;

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (FriendViewCell)collectionView.DequeueReusableCell(FriendViewCell.Identifier, indexPath);
            cell.BindCell(_friends![indexPath.Row]);
            return cell;
        }
    }
}