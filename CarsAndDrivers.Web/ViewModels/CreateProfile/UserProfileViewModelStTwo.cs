namespace CarsAndDrivers.ViewModels.CreateProfile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
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