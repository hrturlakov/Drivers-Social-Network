namespace CarsAndDrivers.Areas.Drivers.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class UserProfileDetailsViewModel : IMapFrom<UserProfile>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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

        public virtual ICollection<CarProfileDetailsViewModel> CarProfiles { get; set; }

        public ICollection<CommentsViewModel> Comments { get; set; }
    }
}