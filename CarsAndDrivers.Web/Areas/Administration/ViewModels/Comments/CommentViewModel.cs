namespace CarsAndDrivers.Areas.Administration.ViewModels.Comments
{
    using System.Web.Mvc;

    using CarsAndDrivers.Areas.Administration.ViewModels.Base;
    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel : AdministrationViewModel, IMapFrom<Comment>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public int UserProfileId { get; set; }
    }
}