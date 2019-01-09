using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOwnership.Abstract
{
   public interface IOwnerRepository: IRepository<Owner>
    {
        IEnumerable<Owner> Owners { get; }
        void SaveOwner(Owner owner);
        IEnumerable<Car> GetListOfCarsForEdit(Owner owner);
    }
}
