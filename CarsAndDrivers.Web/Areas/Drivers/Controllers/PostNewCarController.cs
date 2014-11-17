using CarsAndDrivers.Areas.Drivers.ViewModels;
using CarsAndDrivers.Controllers;
using CarsAndDrivers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarsAndDrivers.ViewModels.CreateProfile;
using CarsAndDrivers.Models;
using AutoMapper;
using System.IO;
using Microsoft.AspNet.Identity;

namespace CarsAndDrivers.Areas.Drivers.Controllers
{
    public class PostNewCarController : BaseController
    {
        public PostNewCarController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Drivers/PostNewCar
        public ActionResult Profile(int? id)
        {
            var userProfile = this.Data.UserProfiles.All().Where(u => u.Id == id)
                 .Project().To<UserProfileDetailsViewModel>().FirstOrDefault();

            if (userProfile == null)
            {
                throw new HttpException(404, "User profile, not found");
            }

            userProfile.Comments = this.Data.Comments.All().Where(c => c.UserProfile.Id == userProfile.Id)
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CommentsViewModel>().ToList();

            return View(userProfile);
        }

        // GET: Drivers/Profile/UpdateProfile/{id}
        //[ChildActionOnly]
        public ActionResult PostCar()
        {
            this.GetManufactures();
            return PartialView("_PostCar", new CarProfileViewModelStThree());
        }

        // POST: Drivers/Profile/UpdateProfile/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostCar(CarProfileViewModelStThree carModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var userProfile = this.Data.UserProfiles.All().FirstOrDefault(u => u.UserId == userId);
                carModel.UserProfileId = userProfile.Id;

                var carProfile = Mapper.Map<CarProfile>(carModel);

                if (carModel.UploadCarPictures.FirstOrDefault() != null)
                {
                    var uploadDir = this.GetUserPicturesDirectory(User.Identity.GetUserName());

                    foreach (var picture in carModel.UploadCarPictures)
                    {
                        var picturePath = Path.Combine(Server.MapPath(uploadDir), picture.FileName);
                        var pictureUrl = Path.Combine(uploadDir, picture.FileName);
                        var carPicture = new CarPicture()
                        {
                            Url = pictureUrl
                        };

                        carProfile.CarPicrutes.Add(carPicture);
                        picture.SaveAs(picturePath);
                    }
                }

                userProfile.CarProfiles.Add(carProfile);
                this.Data.CarProfiles.Add(carProfile);
                this.Data.SaveChanges();

                return RedirectToAction("All", "Details", new { id = userProfile.Id });
            }
            else
            {
                GetManufactures();
                GetModels(carModel.Manufacturer);
                return View(carModel);
            }
        }

        public ActionResult LoadCarModels(string value)
        {
            GetModels(value);
            return PartialView("_LoadCarModelsPartialView");
        }
    }
}