using CarsAndDrivers.Data;
using CarsAndDrivers.Data.Common.Repository;
using CarsAndDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarsAndDrivers.ViewModels.CreateProfile;

namespace CarsAndDrivers.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        //[ChildActionOnly]
        public ActionResult Index()
        {
            var profiles = this.Data.UserProfiles.All().Project().To<UserProfileViewModelStOne>();
            return View(profiles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}