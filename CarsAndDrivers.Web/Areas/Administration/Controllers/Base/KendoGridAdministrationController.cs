namespace CarsAndDrivers.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System.Data.Entity;
    using AutoMapper;
    using CarsAndDrivers.Data;
    using CarsAndDrivers.Data.Common.Models;
    using CarsAndDrivers.Areas.Administration.ViewModels.Base;

    public abstract class KendoGridAdministrationController : AdminController
    {
        public KendoGridAdministrationController(IApplicationData data)
            : base(data)
        {
        }

        protected abstract DataSourceResult GetData([DataSourceRequest]DataSourceRequest request);
        
        protected abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var dbModels = GetData(request);

            //var dbModels = this.GetData()
            //    .ToDataSourceResult(request);
            //var userProfiles = this.Data.UserProfiles.All()
            //   .ToDataSourceResult(request, u => Mapper.Map<TViewModel>(u));

            return this.Json(dbModels);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.DynamicMap<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.DynamicMap<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
                model.ModifiedOn = dbModel.ModifiedOn;
            }
        }

        [NonAction]
        protected virtual void Delete<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Deleted);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}