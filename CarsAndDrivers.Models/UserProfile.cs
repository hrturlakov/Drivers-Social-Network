namespace CarsAndDrivers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarsAndDrivers.Data.Common.Models;

    public class UserProfile : DeletableEntity
    {
        private ICollection<CarProfile> carProfiles;
        private ICollection<Comments> comments;
        
        public UserProfile()
        {
            this.carProfiles = new HashSet<CarProfile>();
            this.comments = new HashSet<Comments>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int DrivingExperience { get; set; }

        public string AboutYou { get; set; }

        public string AvatarUrl { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<CarProfile> CarProfiles
        {
            get { return carProfiles; }
            set { carProfiles = value; }
        }

        public virtual ICollection<Comments> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
