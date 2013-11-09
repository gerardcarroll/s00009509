using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s00009509
{
    public class HomeController : Controller
    {
        MvcMusicStoreEntities db = new MvcMusicStoreEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index(string searchTerm, int sort = 0)
        {
            var allOrders = db.Orders.Where(o => searchTerm == null || o.FirstName.Contains(searchTerm));

            switch (sort)
            {
                case 1: allOrders = allOrders.OrderByDescending(o => o.OrderDate);
                    break;

                case 2: allOrders = allOrders.OrderBy(o => o.OrderDate);
                    break;

                case 3: allOrders = allOrders.OrderByDescending(o => o.Total);
                    break;

                case 4: allOrders = allOrders.OrderBy(o => o.Total);
                    break;
            }
             
            return View(allOrders);
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
