using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetManagementService.Models;
using FleetManagementService.Models.Repositories;

namespace FleetManagementService.Controllers
{
    public class ContainersController : Controller
    {
        //FMSDataContext context = new FMSDataContext();
        ContainerRepository repository = new ContainerRepository();

        public ActionResult Details(int id)
        {
            Container container = repository.Get(id);
            if (container == null)
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
            //ViewBag.VesselId = new SelectList(repository..Vessels, "VesselId", "Name)";
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