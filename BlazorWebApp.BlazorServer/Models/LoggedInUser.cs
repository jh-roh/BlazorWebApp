using System;

namespace BlazorWebApp.BlazorServer.Models
{
    public readonly struct LoggedInUser
    {
        public int UserId { get; }

        public string DisplayName { get; }

        public LoggedInUser(int userId, string displayName)
        {
            UserId = userId;
            DisplayName = displayName;
        }

        public override bool Equals(object obj)
        {
            if(obj is LoggedInUser user)
            {
                return user.UserId == UserId && user.DisplayName == DisplayName;
            }

            return false;
        
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, DisplayName);
        }
    }
}

