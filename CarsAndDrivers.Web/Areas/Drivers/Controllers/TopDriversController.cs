namespace CarsAndDrivers.Areas.Drivers.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using CarsAndDrivers.Controllers;
    using CarsAndDrivers.Data;
    using CarsAndDrivers.Areas.Drivers.ViewModels;

    public class TopDriversController : BaseController
    {
        public TopDriversController(IApplicationData data)
            : base(data)
        {
        }
        // GET: Profiles/TopDrivers
        public ActionResult Index()
        {
            var topDrivers = this.Data.UserProfiles.All()
                .OrderByDescending(u => u.Id).Take(12).Project().To<UserProfileDetailsViewModel>().ToList();
            return View(topDrivers);
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