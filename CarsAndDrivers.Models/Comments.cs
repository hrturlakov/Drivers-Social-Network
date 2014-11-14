using CarsAndDrivers.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndDrivers.Models{
    
    public class Comments : DeletableEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Comment { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
