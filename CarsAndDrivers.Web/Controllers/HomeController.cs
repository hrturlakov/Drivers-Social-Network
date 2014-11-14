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
using CarsAndDrivers.ViewModels.Home;

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
            var indexView = new IndexViewModel();
            var carsData = this.Data.CarProfiles.All().AsQueryable();
            indexView.NewCarPosts = carsData.OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CarProfileViewModel>();
            indexView.TopCarPosts = carsData.OrderByDescending(c => c.Likes.Sum(l => l.Value)).Take(3).Project().To<CarProfileViewModel>();
            indexView.NewDrivers = this.Data.UserProfiles.All().OrderByDescending(u => u.CreatedOn).Take(4).Project().To<UserProfileViewModel>();
            return View(indexView);
        }
    }
}