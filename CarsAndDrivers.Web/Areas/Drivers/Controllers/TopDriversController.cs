using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsAndDrivers.Areas.Drivers.Controllers
{
    public class TopDriversController : Controller
    {
        // GET: Profiles/TopDrivers
        public ActionResult Index(int page = 1)
        {
            ViewBag.page = page;
            return View();
        }
    }
}