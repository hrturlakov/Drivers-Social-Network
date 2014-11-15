namespace CarsAndDrivers.Areas.Drivers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;

    public class CarProfileDetailsViewModel : IMapFrom<CarProfile>, IHaveCustomMappings
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

        public string CarPictureUrl { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CarProfile, CarProfileDetailsViewModel>()
                .ForMember(m => m.CarPictureUrl, opt => opt.MapFrom(c => c.CarPicrutes.FirstOrDefault().Url))
                .ReverseMap();
        }
    }
}