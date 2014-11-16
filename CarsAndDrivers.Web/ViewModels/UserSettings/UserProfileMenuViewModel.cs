namespace CarsAndDrivers.ViewModels.UserSettings
{
    using System.Collections.Generic;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class UserProfileMenuViewModel : IMapFrom<UserProfile>
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string AvatarUrl { get; set; }

        public string PictureUrl { get; set; }
    }
}