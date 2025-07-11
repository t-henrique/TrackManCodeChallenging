using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Maui.ApplicationModel;

namespace Presentation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IFriendsRepository _friendsRepository;

        public ObservableCollection<FriendViewModel> Friends { get; } = new();
        public string Title { get; } = "FRIENDS";

        public MainViewModel(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public async Task LoadFriends()
        {
            IEnumerable<Friend> friends = await _friendsRepository.GetFriends().ConfigureAwait(false);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Friends.Clear();
                foreach(FriendViewModel friend in friends.Select(f => new FriendViewModel(f)))
                    Friends.Add(friend);
            }).ConfigureAwait(false);
        }
    }
}