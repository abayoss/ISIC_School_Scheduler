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
    [Authorize(Roles = "Admins")]
    public class SpecialisationsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specialisations
        public ActionResult Index()
        {
            return View(db.Specialisations.ToList());
        }

        // GET: Specialisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisations specialisations = db.Specialisations.Find(id);
            if (specialisations == null)
            {
                return HttpNotFound();
            }
            return View(specialisations);
        }

        // GET: Specialisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specialisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nomSpecialisation")] Specialisations specialisations)
        {
            if (ModelState.IsValid)
            {
                db.Specialisations.Add(specialisations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialisations);
        }

        // GET: Specialisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisations specialisations = db.Specialisations.Find(id);
            if (specialisations == null)
            {
                return HttpNotFound();
            }
            return View(specialisations);
        }

        // POST: Specialisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nomSpecialisation")] Specialisations specialisations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialisations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialisations);
        }

        // GET: Specialisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisations specialisations = db.Specialisations.Find(id);
            if (specialisations == null)
            {
                return HttpNotFound();
            }
            return View(specialisations);
        }

        // POST: Specialisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialisations specialisations = db.Specialisations.Find(id);
            db.Specialisations.Remove(specialisations);
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
