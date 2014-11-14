namespace CarsAndDrivers.ViewModels.Home
{
    using System.Collections;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<CarProfileViewModel> NewCarPosts { get; set; }

        public IEnumerable<CarProfileViewModel> TopCarPosts { get; set; }

        public IEnumerable<UserProfileViewModel> NewDrivers { get; set; }

        public IEnumerable<UserProfileViewModel> OnlineUsers { get; set; }

        public IEnumerable<CommentsViewModel> LastComments { get; set; }
    }
}