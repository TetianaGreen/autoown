using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOwnership.Abstract
{
    public interface IModelRepository : IRepository<Model>
    {
        IEnumerable<Model> Models { get; }

        IEnumerable<string> GetModelNames();
        Model GetModelByName(string name);
        IEnumerable<Model> GetModelListByBrandId(int BrandId);
        CarType GetCarTypeByModeName(string name);
    }
}
