using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class DemoFriendsRepository : IFriendsRepository
    {
        private const string ImageUrl = "https://cataas.com/cat";
        private static readonly Random _random = new();

        private static readonly string[] _firstNames = {
            "Aske", "Tomasz", "Jørgen", "Henning", "Klaus", "Tiger", "Isao", "Ruben", "Sid", "Cho", "Shiv", "Rahil"
        };

        private static readonly string[] _lastNames = {
            "Garner", "Fleck", "Estes", "Doyle", "del Moral", "Ho-sung", "Phadungsil", "Brewer", "Aoki", "Lehal",
            "Ortiz", "Pagunsan"
        };

        public Task<IEnumerable<Friend>> GetFriends(CancellationToken cancellationToken = default) =>
            Task.FromResult(Enumerable.Range(0, 12).Select(i => new Friend
            {
                FirstName = _firstNames[i],
                LastName = _lastNames[i],
                NickName = _firstNames[i][..2] + _lastNames[i][..2],
                IsFriend = _random.Next(0, 1) == 1,
                ProfilePictureUrl = $"{ImageUrl}?{Guid.NewGuid().ToString()}",
                DateOfBirth = RandomBirthday(),
                MajorsWon = _random.Next(0, 5)
            }));

        private static DateTime RandomBirthday()
        {
            var year = _random.Next(1957, 2005);
            var day = _random.Next(1, 27);
            var month = _random.Next(1, 12);
            return new DateTime(year, month, day);
        }
    }
}