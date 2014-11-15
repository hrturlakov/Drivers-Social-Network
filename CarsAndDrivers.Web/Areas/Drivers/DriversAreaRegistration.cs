namespace CarsAndDrivers.Areas.Drivers
{
    using System.Web.Mvc;

    public class DriversAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Drivers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Drivers_default",
                "Drivers/{controller}/{action}/{id}",
                new { action = "All", id = UrlParameter.Optional }
            );
        }
    }
}