namespace CarsAndDrivers.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarsAndDrivers.Data.Common.Models;

    public class Like : DeletableEntity
    {
        [Key, Column(Order = 0)]
        public string UserID { get; set; }

        public int CarProfileID { get; set; }

        public virtual CarProfile UserProfile { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
