﻿using System;
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
            ViewBag.message = "RAD 301 Music Store Orders";
            
            var allOrders = db.Orders.Where(o => searchTerm == null || o.FirstName.Contains(searchTerm));
            
            //Switch on sortOrder to decide orderBy
            switch (sortOrder)
            {
                case "descend": allOrders = allOrders.OrderByDescending(o => o.OrderDate);
                    break;

                case "ascend": allOrders = allOrders.OrderBy(o => o.OrderDate);
                    break;

                case "Value_desc": allOrders = allOrders.OrderByDescending(o => o.Total);
                    break;

                case "Value_asc": allOrders = allOrders.OrderBy(o => o.Total);
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
