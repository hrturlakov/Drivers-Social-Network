namespace CarsAndDrivers.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CarProfileViewModel : IMapFrom<CarProfile>
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public string Title { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int ReleaseYear { get; set; }

        public int Engine { get; set; }

        public int HorsePower { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}