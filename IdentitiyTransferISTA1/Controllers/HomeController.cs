using IdentitiyTransferISTA1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitiyTransferISTA1.Controllers
{

    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ISTA";

            return View();
        }

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                var UserGD = user.groupid;
                if (UserGD != null)
                {
                    var UserEMPS = db.Groups.FirstOrDefault(g => g.id == UserGD);
                    var UserEMP = UserEMPS.urlSched;
                    ViewBag.Message = UserEMP.ToString();
                }
                else ViewBag.Message = "desolé vous n est pas ajouter ";
            }


            //ViewBag.Message = "https://docs.google.com/spreadsheets/d/1fGl7Y3VmVWVqBBQ2ATYpOZvhg6woW_HLx3EMvZOmDSk/htmlembed?authuser=0";

            return View();
        }
    }
}