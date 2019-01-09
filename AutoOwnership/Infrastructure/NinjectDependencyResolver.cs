using AutoOwnership.Abstract;
using AutoOwnership.DAL;
using AutoOwnership.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoOwnership.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<ICarRepository>().To<CarRepository>();//do i need this?
            _kernel.Bind<IOwnerRepository>().To<OwnerRepository>();
            _kernel.Bind<IBrandRepository>().To<BrandRepository>();
            _kernel.Bind<IModelRepository>().To<ModelRepository>();
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}