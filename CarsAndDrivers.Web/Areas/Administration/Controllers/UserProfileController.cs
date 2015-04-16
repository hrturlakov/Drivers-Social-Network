namespace CarsAndDrivers.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarsAndDrivers.Data;
    using CarsAndDrivers.Areas.Administration.ViewModels.UserProfiles;
    using CarsAndDrivers.Areas.Administration.Controllers.Base;

    using Model = CarsAndDrivers.Models.UserProfile;
    using ViewModel = CarsAndDrivers.Areas.Administration.ViewModels.UserProfiles.UserProfileViewModel;

    public class UserProfileController : KendoGridAdministrationController
    {
        public UserProfileController(IApplicationData data)
            : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.UserProfiles.All().Project().To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.UserProfiles.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Delete<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }
    }
}