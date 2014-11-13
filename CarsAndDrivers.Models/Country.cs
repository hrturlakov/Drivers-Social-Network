namespace CarsAndDrivers.Models
{
    using CarsAndDrivers.Data.Common.Models;

    public class Country : DeletableEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
