namespace CarsAndDrivers.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    
    using CarsAndDrivers.Data;
    using CarsAndDrivers.ViewModels.CreateProfile;
    using CarsAndDrivers.ViewModels.UserSettings;

    [Authorize]
    public class UserSettingsController : BaseController
    {
        public UserSettingsController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult UserMenu()
        {
            var userId = User.Identity.GetUserId();
            var profile = this.Data.UserProfiles.All()
                .Where(p => p.UserId == userId).Project().To<UserProfileMenuViewModel>().FirstOrDefault();
            
            if (profile == null)
            {
                profile = new UserProfileMenuViewModel() { AvatarUrl = "/images/default/avatar.jpg" };   
            }

            return PartialView("_UserMenu", profile);
        }

        // GET: UserSettings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var profile = this.Data.UserProfiles.All()
                .Where(p => p.UserId == userId).Project().To<UserProfileViewModelStOne>().FirstOrDefault();
            
            this.GetCountries();
            
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: UserSettings/UpdateProfile
        public ActionResult UpdateProfile(UserProfileViewModelStOne model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                var userProfile = this.Data.UserProfiles.GetById(model.Id);
                Mapper.Map(model, userProfile);

                this.Data.UserProfiles.Update(userProfile);
                this.Data.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.GetCountries();
                return View(model);
            }
        }

        // GET: UserSettings/UpdatePicture
        public ActionResult UpdatePicture()
        {
            return View();
        }

        // POST: UserSettings/UpdatePicture
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePicture(UserProfileViewModelStTwo model)
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

                    return RedirectToAction("Index", "Home");
                }

                return View(model);
            }

            return View(model);
        }
    }
}