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
    public class BeesController : Controller
    {
        private BeeContext db = new BeeContext();

        // GET: Bees
        public ActionResult Index()
        {
            return View(db.Bees.ToList());
        }

        // GET: Bees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bee bee = db.Bees.Find(id);
            if (bee == null)
            {
                return HttpNotFound();
            }
            return View(bee);
        }

        // GET: Bees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,isAngry,Role,Species,Sound,canSting")] Bee bee)
        {
            if (ModelState.IsValid)
            {
                db.Bees.Add(bee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bee);
        }

        // GET: Bees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bee bee = db.Bees.Find(id);
            if (bee == null)
            {
                return HttpNotFound();
            }
            return View(bee);
        }

        // POST: Bees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,isAngry,Role,Species,Sound,canSting")] Bee bee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bee);
        }

        // GET: Bees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bee bee = db.Bees.Find(id);
            if (bee == null)
            {
                return HttpNotFound();
            }
            return View(bee);
        }

        // POST: Bees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bee bee = db.Bees.Find(id);
            db.Bees.Remove(bee);
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
