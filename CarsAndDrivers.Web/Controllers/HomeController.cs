using CarsAndDrivers.Data;
using CarsAndDrivers.Data.Common.Repository;
using CarsAndDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsAndDrivers.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationData data;

        public HomeController(IApplicationData data)
        {
            this.data = data;
        }

        //[ChildActionOnly]
        public ActionResult Index()
        {
            var profiles = this.data.UserProfiles.All();
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