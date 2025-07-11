using Domain.Entities;

namespace Presentation.ViewModels
{
    public class FriendViewModel : BaseViewModel
    {
        public string ProfilePictureUrl { get; }
        public string Name { get; }
        public string NickName { get; }
        public Friend Model { get; }

        public FriendViewModel(Friend model)
        {
            ProfilePictureUrl = model.ProfilePictureUrl;
            Name = $"{model.FirstName} {model.LastName}";
            NickName = model.NickName;
            Model = model;
        }
    }
}