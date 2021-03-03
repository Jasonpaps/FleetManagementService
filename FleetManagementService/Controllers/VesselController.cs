using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FleetManagementService.Models;

namespace FleetManagementService.Controllers
{
    public class VesselController : Controller
    {
        //FMSDataContext context = new FMSDataContext();
        VesselController repository = new VesselController();

        public ActionResult Details(int id)
        {
            Vessel vessel = repository.Get(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(container);
            }
        }

        // GET: Containers
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Container container)
        {
            if (!ModelState.IsValid) return View(container);

            repository.Add(container);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var container = repository.Get(id);
            if (container == null) return HttpNotFound();
            else return View();
        }

        [HttpPost()]
        public ActionResult Edit(Container container)
        {
            if (!ModelState.IsValid) return View(container);

            repository.Update(container);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}