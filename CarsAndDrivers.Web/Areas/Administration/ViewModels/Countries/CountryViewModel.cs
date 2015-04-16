namespace CarsAndDrivers.Areas.Administration.ViewModels.Countries
{
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    using CarsAndDrivers.Areas.Administration.ViewModels.Base;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
    using CarsAndDrivers.Models;

    public class CountryViewModel : AdministrationViewModel, IMapFrom<Country>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}