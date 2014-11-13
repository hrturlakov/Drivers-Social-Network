namespace CarsAndDrivers.Models
{
    using CarsAndDrivers.Data.Common.Models;

    public class CarModel : DeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
    }
}
