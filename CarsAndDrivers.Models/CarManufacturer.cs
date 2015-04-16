namespace CarsAndDrivers.Models
{
    using System.Collections.Generic;

    using CarsAndDrivers.Data.Common.Models;

    public class CarManufacturer : DeletableEntity
    {
        public CarManufacturer()
        {
            this.CarModels = new HashSet<CarModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
