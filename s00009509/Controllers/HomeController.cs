using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s00009509.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreDBDataContext db = new MusicStoreDBDataContext();

        public ActionResult Index()
        {
            var q = from o in db.Orders
                    select o;

            return View(q);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
