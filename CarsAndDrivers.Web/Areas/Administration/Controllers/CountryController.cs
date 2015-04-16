namespace CarsAndDrivers.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarsAndDrivers.Data;
    using CarsAndDrivers.Areas.Administration.Controllers.Base;

    using Model = CarsAndDrivers.Models.Country;
    using ViewModel = CarsAndDrivers.Areas.Administration.ViewModels.Countries.CountryViewModel;

    public class CountryController : KendoGridAdministrationController
    {
        public CountryController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Countries.All().Project().To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Countries.GetById(id) as T;
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