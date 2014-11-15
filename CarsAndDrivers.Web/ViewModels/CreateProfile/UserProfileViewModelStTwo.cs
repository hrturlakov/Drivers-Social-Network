namespace CarsAndDrivers.ViewModels.CreateProfile
{
    using System.Web;

    using System.ComponentModel.DataAnnotations;

    public class UserProfileViewModelStTwo
    {
        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avatar { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Picture { get; set; }
    }
}