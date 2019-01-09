using System;
using System.Collections.Generic;

namespace AutoOwnership.Models
{
    public class OwnerCarViewModel
    {
        public int SelectedId { get; set; }
        public Owner OwnerToEdit { get; set; }
        public IEnumerable<Car> CarList { get; set; }
        public IEnumerable<Car> OwnersCars { get; set; }
    }
}