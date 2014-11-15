namespace CarsAndDrivers.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    
    using AutoMapper.QueryableExtensions;
    
    using CarsAndDrivers.Data;
    using CarsAndDrivers.ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        //[ChildActionOnly]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewCarProfiles()
        {
            var newCarPosts = this.Data.CarProfiles.All()
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CarProfileViewModel>();
            return PartialView("_NewCarProfiles", newCarPosts);
        }

        public ActionResult TopCarProfiles()
        {
            var topCarPosts = this.Data.CarProfiles.All()
                .OrderByDescending(c => c.Likes.Sum(l => l.Value)).Take(3).Project().To<CarProfileViewModel>();
            return PartialView("_TopCarProfiles", topCarPosts);
        }

        public ActionResult NewDrivers()
        {
            var newDrivers = this.Data.UserProfiles.All()
                .OrderByDescending(u => u.CreatedOn).Take(4).Project().To<UserProfileViewModel>();
            return PartialView("_NewDrivers", newDrivers);
        }

        public ActionResult OnlineUsers()
        {
            return PartialView("_OnlineUsers");
        }

        public ActionResult LatestComments()
        {
            var latestComments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CommentsViewModel>().ToList();
            return PartialView("_LatestComments", latestComments);
        }

        public ActionResult BestDriver()
        {
            return PartialView("_BestDriver");
        }
    }
}