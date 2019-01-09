using AutoOwnership.Abstract;
using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoOwnership.DAL;

namespace AutoOwnership.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public EFDbContext EFDbContext
        {
            get { return Context as EFDbContext; }
        }

        public ModelRepository(EFDbContext context) : base(context) { }

        public IEnumerable<Model> Models
        {
            get { return EFDbContext.Models; }
        }

        public IEnumerable<string> GetModelNames()
        {
            var models = EFDbContext.Models.ToArray();
            List<string> names = new List<string>();
            for (int i = 0; i < models.Length - 1; i++)
            {
                names.Add(models[i].Name);
            }
            return names;
        }

        public Model GetModelByName(string name)
        {
            Model model = EFDbContext.Models.Where(m => m.Name == name).FirstOrDefault();
            return model;
        }

        public IEnumerable<Model> GetModelListByBrandId(int BrandId)
        {
            IEnumerable<Model> models = EFDbContext.Models.Where(m => m.Brand.BrandId == BrandId);
            return models;
        }

        public CarType GetCarTypeByModeName(string name)
        {
            CarType cartype = EFDbContext.Models.Where(m => m.Name == name).FirstOrDefault().CarType;
            return cartype;
        }
    }
}