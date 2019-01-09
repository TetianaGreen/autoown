using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOwnership.Models;

namespace AutoOwnership.Abstract
{
   public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> Cars { get; }
        void SaveCar(Car car);
        void SaveCarFromViewModel(CarModelBrandViewModel viewModel, Car car);
        IEnumerable<Car> GetListOfCarsForEdit(Owner owner, IEnumerable<Car> allCars);
    }
}
