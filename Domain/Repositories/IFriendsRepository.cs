using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFriendsRepository
    {
        Task<IEnumerable<Friend>> GetFriends(CancellationToken cancellationToken = default);
    }
}