using AutoOwnership.Abstract;
using AutoOwnership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoOwnership.Controllers
{
    public class BrandsController : Controller
    {
        private IBrandRepository _repository;


        public BrandsController(IBrandRepository brandRepository)
        {
            _repository = brandRepository;

        }
        // GET: Brands
        public ActionResult Index()
        {

            return View(_repository.GetAll());
        }

        public ActionResult BrandsForDropDownList()
        {
            var brands = _repository.GetAll();
            return PartialView("DropDownView", brands);
        }
    }
}