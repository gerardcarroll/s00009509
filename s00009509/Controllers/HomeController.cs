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

        public ActionResult Index(string searchTerm, string sortOrder)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.TotalSortParam = sortOrder == "Total" ? "Total_desc" : "Total";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            var allOrders = db.Orders.Where(o => searchTerm == null || o.FirstName.Contains(searchTerm));
            
            switch (sortOrder)
            {
                case "Date_desc": allOrders = allOrders.OrderByDescending(o => o.OrderDate);
                    break;

                case "Date": allOrders = allOrders.OrderBy(o => o.OrderDate);
                    break;

                case "Total_desc": allOrders = allOrders.OrderByDescending(o => o.Total);
                    break;

                case "Total": allOrders = allOrders.OrderBy(o => o.Total);
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
