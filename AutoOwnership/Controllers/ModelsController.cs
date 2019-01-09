using AutoOwnership.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoOwnership.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Models
        public ActionResult Index()
        {
            return View(_unitOfWork.Models.GetModelNames());
        }
    }
}