namespace CarsAndDrivers.Areas.Administration.ViewModels.CarProfiles
{
    using System.Web.Mvc;
    using CarsAndDrivers.Areas.Administration.ViewModels.Base;
    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class CarProfileViewModel : AdministrationViewModel, IMapFrom<CarProfile>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public string Title { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int ReleaseYear { get; set; }

        public int Engine { get; set; }

        public int HorsePower { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }
    }
}