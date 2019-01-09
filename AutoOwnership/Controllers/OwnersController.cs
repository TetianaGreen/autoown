using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoOwnership.DAL;
using AutoOwnership.Models;
using AutoOwnership.Abstract;

namespace AutoOwnership.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Owners
        public ActionResult Index()
        {
            return View(_unitOfWork.Owners.GetAll());
        }

        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Owner> owners = _unitOfWork.Owners.GetAll();
            var owner = owners.FirstOrDefault(o => o.OwnerId == id);
            if (owner == null)
            {
                return HttpNotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Owners.Add(owner);
                _unitOfWork.Owners.SaveOwner(owner);
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = _unitOfWork.Owners.Get(id);

            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Owner owner)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Owners.SaveOwner(owner);
                TempData["message"] = string.Format("The owner has been saved");
                return RedirectToAction("Index");
            }
            else
            {
                return View(owner);
            }

        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = _unitOfWork.Owners.Get(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = _unitOfWork.Owners.Get(id);
            _unitOfWork.Owners.Remove(owner);

            return RedirectToAction("Index");
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
