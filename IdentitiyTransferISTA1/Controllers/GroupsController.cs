using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using IdentitiyTransferISTA1.Models;
using System.Web.Security;

namespace IdentitiyTransferISTA1.Controllers
{
    [Authorize(Roles = "Admins,Professors")]
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public async Task<ActionResult> Index()
        {
            var groups = db.Groups
                .Include(g => g.Cycles)
                .Include(g => g.Specialisations)
                .OrderBy(g => g.idCycle);

            ViewBag.idCycle = new SelectList(db.Cycles, "id", "Type_Cycle");
            ViewBag.idSpesialisation = new SelectList(db.Specialisations, "id", "nomSpecialisation");
            return View(await groups.ToListAsync());
        }

        //actions to Sort by cycles : and im not using it !!!!
        public async Task<ActionResult> premier_annee()
        {
            //geting current user's Email and passing it thru ViewBag :
            var userId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var UserEM = user.Email;
            ViewBag.mess = UserEM.ToString();

            //getting groups of the first cycle :
            var Gsorted = from n in db.Groups
                          where n.idCycle.Equals(1)
                          select n;


            return View(await Gsorted.ToListAsync());
        }

        ////actions to Sort by cycles using extention methode: and im not using it !!!!
        public async Task<ActionResult> Deuxieme_annee()
        {
            var Gsorted = db.Groups
                .Where(c => c.idCycle.Equals(2));


            return View(await Gsorted.ToListAsync());
        }
        // GET: Groups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = await db.Groups.FindAsync(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.idCycle = new SelectList(db.Cycles, "id", "Type_Cycle");
            ViewBag.idSpesialisation = new SelectList(db.Specialisations, "id", "nomSpecialisation");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,numGroup,urlSched,idCycle,idSpesialisation")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(groups);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCycle = new SelectList(db.Cycles, "id", "Type_Cycle", groups.idCycle);
            ViewBag.idSpesialisation = new SelectList(db.Specialisations, "id", "nomSpecialisation", groups.idSpesialisation);
            return View(groups);
        }

        // GET: Groups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = await db.Groups.FindAsync(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCycle = new SelectList(db.Cycles, "id", "Type_Cycle", groups.idCycle);
            ViewBag.idSpesialisation = new SelectList(db.Specialisations, "id", "nomSpecialisation", groups.idSpesialisation);
            return View(groups);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,numGroup,urlSched,idCycle,idSpesialisation")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groups).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCycle = new SelectList(db.Cycles, "id", "Type_Cycle", groups.idCycle);
            ViewBag.idSpesialisation = new SelectList(db.Specialisations, "id", "nomSpecialisation", groups.idSpesialisation);
            return View(groups);
        }

        // GET: Groups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = await db.Groups.FindAsync(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Groups groups = await db.Groups.FindAsync(id);
            db.Groups.Remove(groups);
            await db.SaveChangesAsync();
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
