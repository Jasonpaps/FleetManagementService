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
    public class FleetsController : Controller
    {
        private FMSDataContext db = new FMSDataContext();

        // GET: Fleets
        public ActionResult Index()
        {
            return View(db.Fleets.ToList());
        }

        // GET: Fleets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // GET: Fleets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fleets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FleetId,Name")] Fleet fleet)
        {
            int duplicateCount = db.Fleets.Where(a => a.Name.Equals(fleet.Name)).Count();
            if (duplicateCount != 0)
            {
                ViewBag.Message = fleet.Name + " is already taken. Please use a different fleet name.";
                return View(fleet);
            }

            if (ModelState.IsValid)
            {
                db.Fleets.Add(fleet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fleet);
        }

        // GET: Fleets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FleetId,Name")] Fleet fleet)
        {
            Fleet selectedFleet = db.Fleets.Find(fleet.FleetId);

            int duplicateCount = db.Fleets.Where(a => a.Name.Equals(fleet.Name)).Count();
            if ((duplicateCount != 0) && (selectedFleet.Name != fleet.Name))
            {
                ViewBag.Message = fleet.Name + " is already taken. Please use a different fleet name.";
                return View(fleet);
            }

            if (ModelState.IsValid)
            {
                //db.Entry(fleet).State = EntityState.Modified;
                db.Set<Fleet>().AddOrUpdate(fleet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fleet);
        }

        // GET: Fleets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fleet fleet = db.Fleets.Find(id);
            int vesselCount = fleet.Vessels.Count();
            if (vesselCount != 0)
            {
                ViewBag.Message = fleet.Name + " has containers assigned to it. Please remove them before deleting the Vessel.";
                return View(fleet);
            }
            db.Fleets.Remove(fleet);
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
