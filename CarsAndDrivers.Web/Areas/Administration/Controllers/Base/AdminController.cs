namespace CarsAndDrivers.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using CarsAndDrivers.Controllers;
    using CarsAndDrivers.Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IApplicationData data)
            : base(data)
        {
        }
    }
}