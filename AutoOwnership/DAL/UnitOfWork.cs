using AutoOwnership.Abstract;
using AutoOwnership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoOwnership.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;
        public UnitOfWork(EFDbContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);
            Owners = new OwnerRepository(_context);
            Models = new ModelRepository(_context);
            Brands = new BrandRepository(_context);
        }

        public ICarRepository Cars { get; private set; }
        public IModelRepository Models { get; private set; }
        public IOwnerRepository Owners { get; private set; }
        public IBrandRepository Brands { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}