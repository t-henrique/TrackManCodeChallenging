using CoreGraphics;
using InterviewApp.iOS.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.ViewModels;
using UIKit;

namespace InterviewApp.iOS
{
    public class ViewController : UIViewController
    {
        private MainViewModel? _viewModel;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            _viewModel = AppDelegate.ServiceProvider?.GetRequiredService<MainViewModel>();

            Title = _viewModel?.Title;
            View.BackgroundColor = UIColor.White;

            var collectionView =
                new UICollectionView(CGRect.Empty,
                    new UICollectionViewFlowLayout
                    {
                        ScrollDirection = UICollectionViewScrollDirection.Vertical,
                        ItemSize = new CGSize(View.Bounds.Width, 60)
                    })
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    ContentInset = new UIEdgeInsets(16, 0, 40, 0)
                };

            collectionView.RegisterClassForCell(typeof(FriendViewCell), FriendViewCell.Identifier);
            collectionView.DataSource = new FriendsDataSource(_viewModel?.Friends);

            Add(collectionView);

            collectionView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            collectionView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            collectionView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            collectionView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.ApplyAppAppearance();

            _viewModel?.LoadFriends();
        }
    }
}
