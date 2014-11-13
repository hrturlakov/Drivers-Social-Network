namespace CarsAndDrivers.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using Microsoft.AspNet.Identity;

    using CarsAndDrivers.Data;
    using CarsAndDrivers.ViewModels.CreateProfile;
    using CarsAndDrivers.Models;

    //[Authorize]
    public class CreateProfileController : BaseController
    {
        public CreateProfileController(IApplicationData data)
            : base(data)
        {
        }

        // GET: CreateProfile/StepOne
        //[ChildActionOnly]
        public ActionResult StepOne()
        {
            GetCountries();
            return View(new UserProfileViewModelStOne());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CreateProfile/StepOne
        public ActionResult StepOne(UserProfileViewModelStOne model)
        {
            if (ModelState.IsValid)
            {
                var userProfile = new UserProfile()
                {
                    UserId = User.Identity.GetUserId(),
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    Country = model.Country,
                    DrivingExperience = model.DrivingExperience,
                    AboutYou = model.AboutYou
                };
                
                //var userProfile = Mapper.DynamicMap<UserProfile>(model);

                this.Data.UserProfiles.Add(userProfile);
                this.Data.SaveChanges();

                return RedirectToAction("StepTwo", "CreateProfile");
            }
            else
            {
                GetCountries();
                return View(model);
            }
        }

        // GET: CreateProfile/StepTwo
        //[ChildActionOnly]
        [HttpGet]
        public ActionResult StepTwo()
        {
            return View();
        }

        // POST: CreateProfile/StepTwo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepTwo(UserProfileViewModelStTwo model)
        {
            var validImageTypes = new string[]
                {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };

            if (ModelState.IsValid)
            {
                if (!validImageTypes.Contains(model.Avatar.ContentType))
                {
                    ModelState.AddModelError("Avatar", "Please choose either a GIF, JPG or PNG image.");
                }
                else if (model.Avatar.ContentLength == 0)
                {
                    ModelState.AddModelError("Avatar", "Wrong image file.");
                }
                else if (!validImageTypes.Contains(model.Picture.ContentType))
                {
                    ModelState.AddModelError("Picture", "Please choose either a GIF, JPG or PNG image.");
                }
                else if (model.Picture.ContentLength == 0)
                {
                    ModelState.AddModelError("Picture", "Wrong image file.");
                }
                else
                {
                    var currentUserId = User.Identity.GetUserId();
                    var userProfile = this.Data.UserProfiles.All().FirstOrDefault(u => u.UserId == currentUserId);
                    var uploadDir = this.GetUserProfileDirectory(User.Identity.GetUserName());

                    var avatarPath = Path.Combine(Server.MapPath(uploadDir), model.Avatar.FileName);
                    var avatarUrl = Path.Combine(uploadDir, model.Avatar.FileName);
                    model.Avatar.SaveAs(avatarPath);
                    userProfile.AvatarUrl = avatarUrl;

                    var picturePath = Path.Combine(Server.MapPath(uploadDir), model.Picture.FileName);
                    var pictureUrl = Path.Combine(uploadDir, model.Picture.FileName);
                    model.Picture.SaveAs(picturePath);
                    userProfile.PictureUrl = pictureUrl;

                    this.Data.UserProfiles.Update(userProfile);
                    this.Data.SaveChanges();

                    return RedirectToAction("StepThree", "CreateProfile");
                }

                return View(model);
            }

            return View(model);
        }


        // GET: CreateProfile/StepThree
        //[ChildActionOnly]
        public ActionResult StepThree()
        {
            GetManufactures();
            return View(new CarProfileViewModelStThree());
        }

        // POST: CreateProfile/StepThree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepThree(CarProfileViewModelStThree carModel)
        {
            if (ModelState.IsValid)
            {
                if (carModel.CarPictures != null)
                {
                    var uploadDir = this.GetUserPicturesDirectory(User.Identity.GetUserName());

                    foreach (var picture in carModel.CarPictures)
                    {
                        var picturePath = Path.Combine(Server.MapPath(uploadDir), picture.FileName);
                        picture.SaveAs(picturePath);
                    }    
                }
                
                var userId = User.Identity.GetUserId();
                var userProfile = this.Data.UserProfiles.All().AsQueryable().FirstOrDefault(u => u.UserId == userId);

                var carProfile = new CarProfile()
                {
                    UserProfile = userProfile,
                    Title = carModel.Title,
                    ReleaseYear = carModel.ReleaseYear,
                    Manufacturer = carModel.Manufacturer,
                    Model = carModel.Model,
                    Engine = carModel.Engine,
                    HorsePower = carModel.HorsePower,
                    Color = carModel.Color,
                    Description = carModel.Description
                };

                userProfile.CarProfiles.Add(carProfile);
                this.Data.CarProfiles.Add(carProfile);
                this.Data.SaveChanges();

                return RedirectToAction("Index", "Home");
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

        private void GetCountries()
        {
            var countries = this.Data.Countries.All().OrderBy(c => c.Name);
            ViewBag.Countries = new SelectList(countries, "Name", "Name");
        }

        private void GetManufactures()
        {
            var manufacturers = this.Data.CarManufacturers.All().OrderBy(c => c.Name);
            ViewBag.Manufacturers = new SelectList(manufacturers, "Name", "Name");
        }

        private void GetModels(string value)
        {
            var models = this.Data.CarModels.All().Where(m => m.CarManufacturer.Name == value).ToList();
            ViewBag.Models = new SelectList(models, "Name", "Name");
        }
    }
}