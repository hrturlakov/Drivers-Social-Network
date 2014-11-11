using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndDrivers.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
    }
}
