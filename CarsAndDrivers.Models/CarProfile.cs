namespace CarsAndDrivers.Models
{
    using System;
    using System.Collections.Generic;

    using CarsAndDrivers.Data.Common.Models;

    public class CarProfile : DeletableEntity
    {
        private ICollection<Like> likes;
        private ICollection<CarPicture> carPictures;
        
        public CarProfile()
        {
            this.likes = new HashSet<Like>();
            this.carPictures = new HashSet<CarPicture>();
        }

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

        public virtual ICollection<Like> Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public virtual ICollection<CarPicture> CarPicrutes
        {
            get { return carPictures; }
            set { carPictures = value; }
        }
    }
}
