using AutoOwnership.Abstract;
using AutoOwnership.DAL;
using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoOwnership.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public EFDbContext EFDbContext
        {
            get { return Context as EFDbContext; }
        }

        public OwnerRepository(EFDbContext context) : base(context) { }

        public IEnumerable<Owner> Owners
        {
            get { return EFDbContext.Owners; }
        }


        public void SaveOwner(Owner owner)
        {
            if (owner.OwnerId == 0)
            {
                EFDbContext.Owners.Add(owner);
            }
            else
            {
                Owner dbEntry = EFDbContext.Owners.Find(owner.OwnerId);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = owner.FirstName;
                    dbEntry.LastName = owner.LastName;
                    dbEntry.DrivingExperience = owner.DrivingExperience;
                    dbEntry.BirthDate = owner.BirthDate;
                    dbEntry.Cars = owner.Cars;
                }
            }
            EFDbContext.SaveChanges();
        }

        public override IEnumerable<Owner> GetAll()
        {
            return Context.Set<Owner>().Include(o=>o.Cars.Select(m=>m.Model.Brand)).ToList();
        }

        public IEnumerable<Car> GetListOfCarsForEdit(Owner owner)
        {
            var allCars = EFDbContext.Cars.ToList();
            IEnumerable<Car> carsForEdit = allCars.Except(owner.Cars);
            return carsForEdit;
        }
    }
}