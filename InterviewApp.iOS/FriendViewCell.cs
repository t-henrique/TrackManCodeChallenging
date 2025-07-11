using System;
using InterviewApp.iOS.Extensions;
using Presentation.ViewModels;
using UIKit;

namespace InterviewApp.iOS
{
    public sealed class FriendViewCell : UICollectionViewCell
    {
        public const string Identifier = nameof(FriendViewCell);

        private readonly UILabel? _title;
        private readonly UILabel? _subtitle;
        private readonly UIImageView? _image;

        public FriendViewCell(IntPtr handle) : base(handle)
        {
            _image = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                UserInteractionEnabled = true,
                ContentMode = UIViewContentMode.ScaleAspectFill,
                ClipsToBounds = true
            };

            _image.Layer.CornerRadius = 56 / 2.0f;

            ContentView.Add(_image);

            _image.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor).Active = true;
            _image.WidthAnchor.ConstraintEqualTo(56f).Active = true;
            _image.HeightAnchor.ConstraintEqualTo(56f).Active = true;
            _image.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16f).Active = true;

            var stackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Distribution = UIStackViewDistribution.FillEqually,
                Spacing = 0f
            };

            ContentView.Add(stackView);

            stackView.HeightAnchor.ConstraintEqualTo(45f).Active = true;
            stackView.LeadingAnchor.ConstraintEqualTo(_image.TrailingAnchor, 16f).Active = true;
            stackView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16f).Active = true;
            stackView.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor).Active = true;

            _title = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.FromName("Lato-Bold", 15f),
                TextColor = UIColor.FromRGB(0x41, 0x41, 0x41),
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _subtitle = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.FromName("Lato-Regular", 15f),
                TextColor = UIColor.FromRGB(0xa0, 0xa0, 0xa0),
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            stackView.AddArrangedSubview(_title);
            stackView.AddArrangedSubview(_subtitle);
        }

        public void BindCell(FriendViewModel friendViewModel)
        {
            _image?.LoadImage(friendViewModel.ProfilePictureUrl);
            _title?.SetText(friendViewModel.Name);
            _subtitle?.SetText(friendViewModel.NickName);
        }
    }
}