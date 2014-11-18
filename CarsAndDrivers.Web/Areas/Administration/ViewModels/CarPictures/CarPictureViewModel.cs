namespace CarsAndDrivers.Areas.Administration.ViewModels.CarPictures
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CarsAndDrivers.Areas.Administration.ViewModels.Base;
    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class CarPictureViewModel : AdministrationViewModel, IMapFrom<CarPicture>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int CarProfileId { get; set; }
    }
}