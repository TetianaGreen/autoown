using AutoOwnership.Abstract;
using AutoOwnership.DAL;
using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace AutoOwnership.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public EFDbContext EFDbContext
        {
            get { return Context as EFDbContext; }
        }

        public CarRepository(EFDbContext context) : base(context) { }

        public IEnumerable<Car> Cars
        {
            get { return EFDbContext.Cars; }
        }

        public void SaveCarFromViewModel(CarModelBrandViewModel viewModel, Car car)
        {
            if (car.CarId == 0)
            {
                EFDbContext.Cars.Add(car);
            }
            else
            {
                Car dbEntry = EFDbContext.Cars.Find(viewModel.Car.CarId);
                if (dbEntry != null)
                {
                    dbEntry.Model = viewModel.Car.Model;
                    dbEntry.Model.Brand = viewModel.Car.Model.Brand;
                    dbEntry.Price = viewModel.Car.Price;
                    dbEntry.YearOfIssue = viewModel.Car.YearOfIssue;
                }
            }
            EFDbContext.SaveChanges();
        }

        public override IEnumerable<Car> GetAll()
        {
            return Context.Set<Car>().Include(m => m.Model.Brand).ToList();
        }

        public void SaveCar(Car car)
        {
            if (car.CarId == 0)
            {
                EFDbContext.Cars.Add(car);
            }
            else
            {
                Car dbEntry = EFDbContext.Cars.Find(car.CarId);
                if (dbEntry != null)
                {
                    dbEntry.Price = car.Price;
                    dbEntry.YearOfIssue = car.YearOfIssue;
                }
            }
            EFDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetListOfCarsForEdit(Owner owner, IEnumerable<Car> allCars)
        {
            IEnumerable<Car> carsForEdit = allCars.Except(owner.Cars);
            return carsForEdit;
        }
    }
}