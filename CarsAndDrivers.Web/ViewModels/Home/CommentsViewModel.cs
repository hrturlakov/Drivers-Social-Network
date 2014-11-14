namespace CarsAndDrivers.ViewModels.Home
{
    using CarsAndDrivers.Models;

    public class CommentsViewModel
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Comment { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}