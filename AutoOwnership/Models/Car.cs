using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoOwnership.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public Model Model { get; set; }
        public int? ModelId { get; set; }

        public short? YearOfIssue { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }

    }

}