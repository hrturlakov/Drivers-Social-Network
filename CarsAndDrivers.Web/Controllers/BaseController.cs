namespace CarsAndDrivers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using CarsAndDrivers.Data;

    public abstract class BaseController : Controller
    {
        public BaseController(IApplicationData data)
        {
            this.Data = data;
        }

        protected IApplicationData Data { get; set; }

        [NonAction]
        protected void GetCountries()
        {
            var countries = this.Data.Countries.All().OrderBy(c => c.Name);
            ViewBag.Countries = new SelectList(countries, "Name", "Name");
        }

        [NonAction]
        protected void GetManufactures()
        {
            var manufacturers = this.Data.CarManufacturers.All().OrderBy(c => c.Name);
            ViewBag.Manufacturers = new SelectList(manufacturers, "Name", "Name");
        }

        [NonAction]
        protected void GetModels(string value)
        {
            var models = this.Data.CarModels.All().Where(m => m.CarManufacturer.Name == value).ToList();
            ViewBag.Models = new SelectList(models, "Name", "Name");
        }

        [NonAction]
        protected string GetUserProfileDirectory(string username)
        {
            string userDirectory = GetUserDirectory(username);

            string profileDirectory = userDirectory + "/profile";
            bool existProfileDirectory = Directory.Exists(Server.MapPath(profileDirectory));
            if (!existProfileDirectory)
            {
                Directory.CreateDirectory(Server.MapPath(profileDirectory));
            }

            return profileDirectory;
        }

        [NonAction]
        protected string GetUserPicturesDirectory(string username)
        {
            string userDirectory = GetUserDirectory(username);
           
            string picturesDirectory = userDirectory + "/pictures";
            bool existPicturesDirectory = Directory.Exists(Server.MapPath(picturesDirectory));
            if (!existPicturesDirectory)
            {
                Directory.CreateDirectory(Server.MapPath(picturesDirectory));
            }

            return picturesDirectory;
        }

        [NonAction]
        private string GetUserDirectory(string username)
        {
            string userDirectory = "/uploads/" + username;
            bool exists = Directory.Exists(Server.MapPath(userDirectory));

            if (!exists)
            {
                Directory.CreateDirectory(Server.MapPath(userDirectory));
            }

            return userDirectory;
        }
    }
}