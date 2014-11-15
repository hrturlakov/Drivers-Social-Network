namespace CarsAndDrivers.ViewModels.Home
{
    using System.Collections.Generic;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class UserProfileViewModel : IMapFrom<UserProfile>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string Country { get; set; }

        public int DrivingExperience { get; set; }

        public string AboutYou { get; set; }

        public string AvatarUrl { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<CarProfile> CarProfiles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}