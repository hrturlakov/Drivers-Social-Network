namespace CarsAndDrivers.Areas.Administration.ViewModels.UserProfiles
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CarsAndDrivers.Areas.Administration.ViewModels.Base;
    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class UserProfileViewModel: AdministrationViewModel, IMapFrom<UserProfile>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int DrivingExperience { get; set; }

        public string AboutYou { get; set; }

        public string AvatarUrl { get; set; }

        public string PictureUrl { get; set; }
    }
}