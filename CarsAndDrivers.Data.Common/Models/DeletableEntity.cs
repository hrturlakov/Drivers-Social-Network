namespace CarsAndDrivers.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
