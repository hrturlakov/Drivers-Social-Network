namespace CarsAndDrivers.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    
    using AutoMapper.QueryableExtensions;
    
    using CarsAndDrivers.Data;
    using CarsAndDrivers.ViewModels.Home;

    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult NewCarProfiles()
        {
            var newCarPosts = this.Data.CarProfiles.All()
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CarProfileViewModel>();
            return PartialView("_NewCarProfiles", newCarPosts);
        }

        [ChildActionOnly]
        public ActionResult TopCarProfiles()
        {
            var topCarPosts = this.Data.CarProfiles.All()
                .OrderByDescending(c => c.Likes.Sum(l => l.Value)).Take(3).Project().To<CarProfileViewModel>();
            return PartialView("_TopCarProfiles", topCarPosts);
        }

        [ChildActionOnly]
        public ActionResult NewDrivers()
        {
            var newDrivers = this.Data.UserProfiles.All()
                .OrderByDescending(u => u.CreatedOn).Take(4).Project().To<UserProfileViewModel>();
            return PartialView("_NewDrivers", newDrivers);
        }

        [ChildActionOnly]
        public ActionResult OnlineUsers()
        {
            return PartialView("_OnlineUsers");
        }

        [ChildActionOnly]
        public ActionResult LatestComments()
        {
            var latestComments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CommentsViewModel>().ToList();
            return PartialView("_LatestComments", latestComments);
        }

        [ChildActionOnly]
        public ActionResult BestDriver()
        {
            return PartialView("_BestDriver");
        }

        [ChildActionOnly]
        public ActionResult AsideAd()
        {
            return PartialView("_AsideAd");
        }

        [ChildActionOnly]
        public ActionResult BottomAd()
        {
            return PartialView("_BottomAd");
        }

        [ChildActionOnly]
        public ActionResult SocialNetworks()
        {
            return PartialView("_SocialNetworks");
        }
    }
}