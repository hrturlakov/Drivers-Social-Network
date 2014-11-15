using CarsAndDrivers.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndDrivers.Models
{
    public class CarPicture : DeletableEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int CarProfileId { get; set; }

        public virtual CarProfile CarProfile { get; set; }
    }
}
