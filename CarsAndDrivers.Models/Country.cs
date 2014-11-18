namespace CarsAndDrivers.Models
{
    using System.ComponentModel.DataAnnotations;
    using CarsAndDrivers.Data.Common.Models;

    public class Country : DeletableEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
