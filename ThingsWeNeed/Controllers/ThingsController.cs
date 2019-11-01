using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.Controllers
{
    public class ThingsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Things
        public ActionResult Index()
        {
            return View(db.Things.ToList());
        }

        // GET: Things/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thing thing = db.Things.Find(id);
            if (thing == null)
            {
                return HttpNotFound();
            }
            return View(thing);
        }

        // GET: Things/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Things/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThingId,Name,Needed,HouseholdId")] Thing thing)
        {
            if (ModelState.IsValid)
            {
                db.Things.Add(thing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thing);
        }

        // GET: Things/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thing thing = db.Things.Find(id);
            if (thing == null)
            {
                return HttpNotFound();
            }
            return View(thing);
        }

        // POST: Things/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThingId,Name,Needed,HouseholdId")] Thing thing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thing);
        }

        // GET: Things/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thing thing = db.Things.Find(id);
            if (thing == null)
            {
                return HttpNotFound();
            }
            return View(thing);
        }

        // POST: Things/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thing thing = db.Things.Find(id);
            db.Things.Remove(thing);
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
