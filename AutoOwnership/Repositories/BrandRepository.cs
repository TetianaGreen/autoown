using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoOwnership.DAL;
using System.Web.Mvc;
using AutoOwnership.Abstract;

namespace AutoOwnership.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private EFDbContext _context = new EFDbContext();
        public BrandRepository(EFDbContext context) : base(context)
        {
        }

        public IEnumerable<Brand> Brands
        {
            get { return _context.Brands; }
        }

        public IEnumerable<string> GetBrandNames()
        {
            var brands = _context.Brands.ToArray();
            List<string> names = new List<string>();
            for (int i = 0; i < brands.Length-1; i++)
            {
                names.Add(brands[i].Name);
            }

            return names;
        }
    }
}