using System.Collections.Generic;

namespace AutoOwnership.Models
{
    public class CarModelBrandViewModel
    {
       public IEnumerable<string> BrandNames { get; set; }
       public IEnumerable<string> ModelNames { get; set; }
        public Car Car { get; set; }

        public int SelectedModelId { get; set; }

        public int SelectedBrandId { get; set; } 
    }
}