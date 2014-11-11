namespace CarsAndDrivers.ViewModels.CreateProfile
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class CarProfileViewModelStThree
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        [Required]
        [Display(Name = "Engine")]
        public int Engine { get; set; }

        [Required]
        [Display(Name = "Horse Power")]
        public int HorsePower { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Car Pictures")]
        public IEnumerable<HttpPostedFileBase> CarPictures { get; set; }
    }
}