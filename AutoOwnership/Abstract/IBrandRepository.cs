using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoOwnership.Abstract
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> Brands { get; }
        IEnumerable<string> GetBrandNames();
    }
}