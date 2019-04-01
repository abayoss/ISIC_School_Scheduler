using IdentitiyTransferISTA1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitiyTransferISTA1.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(Db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = Db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Db.Roles.Add(Role);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Role);

            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = Db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole Role)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Db.Entry(Role).State = EntityState.Modified;
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Role);
            }
            catch
            {
                return View(Role);
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = Db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole myRole)
        {
            try
            {
                // TODO: Add delete logic here
                IdentityRole Role = Db.Roles.Find(myRole.Id);
                Db.Roles.Remove(Role);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
