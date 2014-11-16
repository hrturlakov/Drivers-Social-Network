namespace CarsAndDrivers.ViewModels.CreateProfile
{
    using System.ComponentModel.DataAnnotations;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
    using System.Web.Mvc;

    public class UserProfileViewModelStOne : IMapFrom<UserProfile>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Driving experience")]
        public int DrivingExperience { get; set; }

        [Display(Name = "Few words about you")]
        public string AboutYou { get; set; }
    }
}