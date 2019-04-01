using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitiyTransferISTA1.Models;

namespace IdentitiyTransferISTA1.Controllers
{
    public class CyclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cycles
        public ActionResult Index()
        {
            return View(db.Cycles.ToList());
        }

        // GET: Cycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // GET: Cycles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Type_Cycle")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                db.Cycles.Add(cycles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cycles);
        }

        // GET: Cycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // POST: Cycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Type_Cycle")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cycles);
        }

        // GET: Cycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // POST: Cycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cycles cycles = db.Cycles.Find(id);
            db.Cycles.Remove(cycles);
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
