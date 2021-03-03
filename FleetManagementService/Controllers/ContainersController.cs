using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetManagementService.Models;

namespace FleetManagementService.Controllers
{
    public class ContainersController : Controller
    {
        private FMSDataContext db = new FMSDataContext();

        // GET: Containers
        public ActionResult Index()
        {
            var containers = db.Containers.Include(c => c.Vessel);
            return View(containers.ToList());
        }

        // GET: Containers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // GET: Containers/Create
        public ActionResult Create()
        {
            ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name");
            return View();
        }

        // POST: Containers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContainerId,Name,VesselId,NoVessel")] Container container)
        {
            int duplicateCount = db.Containers.Where(a => a.Name.Equals(container.Name)).Count();
            if (duplicateCount != 0)
            {
                ViewBag.Message = container.Name + " is already taken. Please use a different container name.";
                ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
                return View(container);
            }

            int? selectedVesselId = container.VesselId;
            var selectedVessel = db.Vessels.Find(selectedVesselId);
            if (selectedVessel.Containers.Count() == selectedVessel.Capacity)
            {
                ViewBag.Message = selectedVessel.Name + " is full. Please choose another Vessel.";
                ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
                return View(container);
            }

            if (container.NoVessel == true)
            {
                container.VesselId = null;
            }


            if (ModelState.IsValid)
            {
                db.Containers.Add(container);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
            return View(container);
        }

        // GET: Containers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
            return View(container);
        }

        // POST: Containers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContainerId,Name,VesselId,NoVessel")] Container container)
        {
            Container selectedContainer = db.Containers.Find(container.ContainerId);

            int duplicateCount = db.Containers.Where(a => a.Name.Equals(container.Name)).Count();
            if ((duplicateCount != 0) && (selectedContainer.Name != container.Name))
            {
                ViewBag.Message = container.Name + " is already taken. Please use a different container name.";
                ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
                return View(container);
            }


            int? selectedVesselId = container.VesselId;
            var selectedVessel = db.Vessels.Find(selectedVesselId);
            if ((selectedVessel.Containers.Count() == selectedVessel.Capacity) && (selectedContainer.VesselId != container.VesselId))
            {
                ViewBag.Message = selectedVessel.Name + " is full. Please choose another Vessel.";
                ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
                return View(container);
            }

            if (container.NoVessel == true)
            {
                container.VesselId = null;
            }

            if (ModelState.IsValid)
            {
                //db.Entry(container).State = EntityState.Modified;
                db.Set<Container>().AddOrUpdate(container);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VesselId = new SelectList(db.Vessels, "VesselId", "Name", container.VesselId);
            return View(container);
        }

        // GET: Containers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Container container = db.Containers.Find(id);
            db.Containers.Remove(container);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
