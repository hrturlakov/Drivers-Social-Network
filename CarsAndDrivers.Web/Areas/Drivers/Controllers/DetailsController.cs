namespace CarsAndDrivers.Areas.Drivers.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarsAndDrivers.Areas.Drivers.ViewModels;
    using CarsAndDrivers.Controllers;
    using CarsAndDrivers.Data;
    using CarsAndDrivers.Models;
    
    [Authorize]
    public class DetailsController : BaseController
    {
        public DetailsController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Profiles/Current
        public ActionResult All(int? id, int page = 1)
        {
            var userProfile = this.Data.UserProfiles.All().Where(u => u.Id == id)
                .Project().To<UserProfileDetailsViewModel>().FirstOrDefault();
            
            if (userProfile == null)
            {
                throw new HttpException(404, "User profile, not found");
            }

            userProfile.Comments = this.Data.Comments.All().Where(c => c.UserProfile.Id == userProfile.Id)
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CommentsViewModel>().ToList();
            
            var displayedCarProfiles = 4;
            var skipedCarProfiles = (page - 1) * displayedCarProfiles;
            var numberOfPages = userProfile.CarProfiles.Count() / displayedCarProfiles;
            if (userProfile.CarProfiles.Count() % 4 != 0) numberOfPages++;

            ViewBag.NumberOfPages = numberOfPages;

            userProfile.CarProfiles = this.Data.CarProfiles.All().Where(c => c.UserProfile.Id == userProfile.Id)
                .OrderByDescending(c => c.CreatedOn).Skip(skipedCarProfiles).Take(displayedCarProfiles).Project().To<CarProfileDetailsViewModel>().ToList();

            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(int id, string comment)
        {
            var userProfile = this.Data.UserProfiles.GetById(id);
            var senderId = User.Identity.GetUserId();
            var senderProfile = this.Data.UserProfiles.All().Where(s => s.UserId == senderId).FirstOrDefault();
            var newComment = new Comment()
            {
                SenderId = senderId,
                Sender = senderProfile,
                Text = comment,
                UserProfile = userProfile
            };
            userProfile.Comments.Add(newComment);
            this.Data.SaveChanges();

            var lastComments = this.Data.Comments.All().Where(c => c.UserProfile.Id == userProfile.Id)
                .OrderByDescending(c => c.CreatedOn).Take(4).Project().To<CommentsViewModel>().ToList();

            return this.PartialView("_Comments", lastComments);
        }
    }
}