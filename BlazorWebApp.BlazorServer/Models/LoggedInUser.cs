using System;

namespace BlazorWebApp.BlazorServer.Models
{
    public struct LoggedInUser 
    {
        public int UserId { get; set; }

        public string DisplayName { get; set; }

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

        public void Deconstruct(out int userId, out string displayName)
        {
            userId = UserId;
            displayName = DisplayName;
        }

        public readonly bool IsEmpty() => UserId == 0 && string.IsNullOrWhiteSpace(DisplayName);

        public override string ToString() => $"LoggedInUser {{ UserId = {UserId}, DisplayName = {DisplayName} }}";
    }
}

