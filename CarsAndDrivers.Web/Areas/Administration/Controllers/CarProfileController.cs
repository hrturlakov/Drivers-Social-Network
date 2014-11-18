namespace CarsAndDrivers.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarsAndDrivers.Data;
    using CarsAndDrivers.Areas.Administration.ViewModels.UserProfiles;
    using CarsAndDrivers.Areas.Administration.Controllers.Base;

    using Model = CarsAndDrivers.Models.CarProfile;
    using ViewModel = CarsAndDrivers.Areas.Administration.ViewModels.CarProfiles.CarProfileViewModel;

    public class CarProfileController : KendoGridAdministrationController
    {
        public CarProfileController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Administration/CarProfile
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.CarProfiles.All().Project().To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.UserProfiles.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel vModel)
        {
            var dbModel = base.Create<Model>(vModel);
            if (dbModel != null) vModel.Id = dbModel.Id;
            return this.GridOperation(vModel, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel vModel)
        {
            base.Update<Model, ViewModel>(vModel, vModel.Id);
            return this.GridOperation(vModel, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Delete<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }
    }
}