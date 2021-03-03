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
    public class VesselsController : Controller
    {
        private FMSDataContext db = new FMSDataContext();

        // GET: Vessels
        public ActionResult Index()
        {
            var vessels = db.Vessels.Include(v => v.Fleet);
            return View(vessels.ToList());
        }

        // GET: Vessels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // GET: Vessels/Create
        public ActionResult Create()
        {
            ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name");
            return View();
        }

        // POST: Vessels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VesselId,Name,Capacity,FleetId,NoFleet")] Vessel vessel)
        {
            int duplicateCount = db.Vessels.Where(a => a.Name.Equals(vessel.Name)).Count();
            if (duplicateCount != 0)
            {
                ViewBag.Message = vessel.Name + " is already taken. Please use a different vessel name.";
                ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
                return View(vessel);
            }
            if (vessel.NoFleet == true)
            {
                vessel.FleetId = null;
            }

            if (ModelState.IsValid)
            {
                db.Vessels.Add(vessel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
            return View(vessel);
        }

        // GET: Vessels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
            return View(vessel);
        }

        // POST: Vessels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VesselId,Name,Capacity,FleetId,NoFleet")] Vessel vessel)
        {
            Vessel selectedVessel = db.Vessels.Find(vessel.VesselId);

            int duplicateCount = db.Vessels.Where(a => a.Name.Equals(vessel.Name)).Count();
            if ((duplicateCount != 0) && (selectedVessel.Name != vessel.Name))
            {
                ViewBag.Message = vessel.Name + " is already taken. Please use a different vessel name.";
                ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
                return View(vessel);
            }
            if (vessel.NoFleet == true)
            {
                vessel.FleetId = null;
            }

            if (ModelState.IsValid)
            {
                //db.Entry(vessel).State = EntityState.Modified;
                db.Set<Vessel>().AddOrUpdate(vessel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
            return View(vessel);
        }

        // GET: Vessels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vessel vessel = db.Vessels.Find(id);
            int containerCount = vessel.Containers.Count();
            if (containerCount != 0)
            {
                ViewBag.Message = vessel.Name + " has containers assigned to it. Please remove them before deleting the Vessel.";
                ViewBag.FleetId = new SelectList(db.Fleets, "FleetId", "Name", vessel.FleetId);
                return View(vessel);
            }
                // IEnumerable<Container> containersDel = db.Containers.Where(m =>m.VesselId==id);

            db.Vessels.Remove(vessel);
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
