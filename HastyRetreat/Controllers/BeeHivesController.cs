using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HastyRetreat.Data;
using HastyRetreat.Models;

namespace HastyRetreat.Controllers
{
    public class BeeHivesController : Controller
    {
        private BeeContext db = new BeeContext();

        // GET: BeeHives
        public ActionResult Index()
        {
            return View(db.BeeHives.ToList());
        }

        // GET: BeeHives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeeHive beeHive = db.BeeHives.Find(id);
            if (beeHive == null)
            {
                return HttpNotFound();
            }
            return View(beeHive);
        }

        // GET: BeeHives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeeHives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateStarted,Type")] BeeHive beeHive)
        {
            if (ModelState.IsValid)
            {
                db.BeeHives.Add(beeHive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beeHive);
        }

        // GET: BeeHives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeeHive beeHive = db.BeeHives.Find(id);
            if (beeHive == null)
            {
                return HttpNotFound();
            }
            return View(beeHive);
        }

        // POST: BeeHives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateStarted,Type")] BeeHive beeHive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beeHive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beeHive);
        }

        // GET: BeeHives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeeHive beeHive = db.BeeHives.Find(id);
            if (beeHive == null)
            {
                return HttpNotFound();
            }
            return View(beeHive);
        }

        // POST: BeeHives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeeHive beeHive = db.BeeHives.Find(id);
            db.BeeHives.Remove(beeHive);
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
