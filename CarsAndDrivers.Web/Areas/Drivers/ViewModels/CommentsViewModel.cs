namespace CarsAndDrivers.Areas.Drivers.ViewModels
{
    using System;

    using CarsAndDrivers.Models;
    using CarsAndDrivers.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string SenderUserName { get; set; }

        public string SenderAvatarUrl { get; set; }

        public int? UserProfileId { get; set; }

        [Required]
        [MinLength(3)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [UIHint("CommentTime")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
                .ForMember(m => m.SenderUserName, opt => opt.MapFrom(c => c.Sender.User.UserName))
                .ForMember(m => m.SenderAvatarUrl, opt => opt.MapFrom(m => m.Sender.AvatarUrl))
                .ForMember(m => m.UserProfileId, opt => opt.MapFrom(c => c.UserProfileId))
                .ReverseMap();
        }
    }
}