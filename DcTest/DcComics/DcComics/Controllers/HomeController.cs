using DcComics.DAL;
using DcComics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DcComics.Controllers
{
    public class HomeController : Controller
    {
        private DCcontext db = new DCcontext();
        public ActionResult Index()
        {
            var batman = db.Heroes.Find(1);
            batman.Power = batman.Power.Urlify();
            db.SaveChanges();
            return View(db.Heroes.ToList());
        }
    }
}