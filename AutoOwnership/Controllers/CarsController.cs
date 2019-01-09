using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoOwnership.DAL;
using AutoOwnership.Models;
using AutoOwnership.Abstract;
using System.Web.Script.Serialization;

namespace AutoOwnership.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(_unitOfWork.Cars.GetAll());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Car> cars = _unitOfWork.Cars.GetAll();
            var car = cars.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            CarModelBrandViewModel viewModel = new CarModelBrandViewModel()
            {
                ModelNames = _unitOfWork.Models.GetModelNames(),
                BrandNames = _unitOfWork.Brands.GetBrandNames(),
                Car = new Car()
            };
            ViewBag.BrandList = _unitOfWork.Brands.GetAll();
            return View(viewModel);
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModelBrandViewModel viewmodel)
        {
            Car car = new Car();
            if (ModelState.IsValid)
            {
                car.Model = _unitOfWork.Models.Get(viewmodel.SelectedModelId);
                car.Model.Brand = _unitOfWork.Brands.Get(viewmodel.SelectedBrandId);
                car.Price = viewmodel.Car.Price;
                car.YearOfIssue = car.YearOfIssue;

                _unitOfWork.Cars.Add(car);
                _unitOfWork.Cars.SaveCarFromViewModel(viewmodel,car);

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _unitOfWork.Cars.Get(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cars.SaveCar(car);
                TempData["message"] = string.Format("The car has been saved");
                return RedirectToAction("Index");
            }
            else
            {
                return View(car);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Car> cars = _unitOfWork.Cars.GetAll();
            Car car = cars.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IEnumerable<Car> cars = _unitOfWork.Cars.GetAll();
            Car car = cars.FirstOrDefault(c => c.CarId == id);
            _unitOfWork.Cars.Remove(car);
            return RedirectToAction("Index");
        }


        public ActionResult GetModelList(int BrandId)
        {
            List<Model> modelNameList = _unitOfWork.Models.GetModelListByBrandId(BrandId).ToList();         
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(modelNameList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
