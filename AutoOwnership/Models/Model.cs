using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoOwnership.Models
{
    public class Model
    {
        public int ModelId { get; set; }

        public Brand Brand { get; set; }

        public int? BrandId { get; set; }
        public string Name { get; set; }
        public CarType CarType { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}