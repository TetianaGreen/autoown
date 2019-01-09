using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoOwnership.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext():base()
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}