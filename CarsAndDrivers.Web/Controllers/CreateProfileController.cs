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
            this.GetCountries();
            return View(new UserProfileViewModelStOne());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CreateProfile/StepOne
        public ActionResult StepOne(UserProfileViewModelStOne model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                var userProfile = Mapper.Map<UserProfile>(model);

                this.Data.UserProfiles.Add(userProfile);
                this.Data.SaveChanges();

                return RedirectToAction("StepTwo", "CreateProfile");
            }
            else
            {
                this.GetCountries();
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
            this.GetManufactures();
            return View(new CarProfileViewModelStThree());
        }

        // POST: CreateProfile/StepThree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepThree(CarProfileViewModelStThree carModel)
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
    }
}