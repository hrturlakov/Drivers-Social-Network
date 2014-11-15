using CarsAndDrivers.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndDrivers.Models{
    
    public class Comment : DeletableEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string SenderId { get; set; }

        public virtual UserProfile Sender { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
