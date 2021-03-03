using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FleetManagementService.Models;
using FleetManagementService.Models.Repositories;

namespace FleetManagementService.Controllers
{
    public class VesselController : Controller
    {
        //FMSDataContext context = new FMSDataContext();
        VesselRepository repository = new VesselRepository();

        public ActionResult Details(int id)
        {
            Vessel vessel = repository.Get(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(vessel);
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
        public ActionResult Create(Vessel vessel)
        {
            if (!ModelState.IsValid) return View(vessel);

            repository.Add(vessel);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var vessel = repository.Get(id);
            if (vessel == null) return HttpNotFound();
            else return View(vessel);
        }

        [HttpPost()]
        public ActionResult Edit(Vessel vessel)
        {
            if (!ModelState.IsValid) return View(vessel);

            repository.Update(vessel);
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