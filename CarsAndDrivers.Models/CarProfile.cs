namespace CarsAndDrivers.Models
{
    using System;

    using CarsAndDrivers.Data.Common.Models;

    public class CarProfile : DeletableEntity
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
    }
}
