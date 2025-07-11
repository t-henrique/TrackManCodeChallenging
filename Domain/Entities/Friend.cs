using System;
namespace Domain.Entities
{
    public class Friend
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string NickName { get; init; } = string.Empty;
        public DateTime DateOfBirth  { get; init; }
        public string ProfilePictureUrl { get; init; } = string.Empty;
        public bool IsFriend { get; init; }
        public long MajorsWon { get; init; }
    }
}