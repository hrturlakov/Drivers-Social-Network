﻿namespace CarsAndDrivers.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile
    {
        public UserProfile()
        {
            this.CarProfiles = new HashSet<CarProfile>();
        }
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

        public virtual IEnumerable<CarProfile> CarProfiles { get; set; }
    }
}
