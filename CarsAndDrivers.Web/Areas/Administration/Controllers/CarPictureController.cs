namespace CarsAndDrivers.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarsAndDrivers.Data;
    using CarsAndDrivers.Areas.Administration.Controllers.Base;

    using Model = CarsAndDrivers.Models.CarPicture;
    using ViewModel = CarsAndDrivers.Areas.Administration.ViewModels.CarPictures.CarPictureViewModel;
    using System.Collections;

    public class CarPictureController : KendoGridAdministrationController
    {
        public CarPictureController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Administration/CarPicture
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.CarPictures.All().Project().To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.CarPictures.GetById(id) as T;
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