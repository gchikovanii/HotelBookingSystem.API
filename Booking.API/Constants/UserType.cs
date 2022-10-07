using System.Reflection.Metadata;

namespace Booking.API.Constants
{
    public class UserType
    {
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string User = "User";
        public const string AdminModerator = "Admin, Moderator";
        public const string AdminUser = "Admin, User";
    }
}
