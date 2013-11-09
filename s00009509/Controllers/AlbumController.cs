using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s00009509.Controllers
{
    public class AlbumController : Controller
    {
        MvcMusicStoreEntities db = new MvcMusicStoreEntities();
        //
        // GET: /Album/Index/1

        public ActionResult Index(int id)
        {
            ViewBag.Message = String.Format("Albums for Order No: {0}", id);
            var q = from a in db.Albums
                    join od in db.OrderDetails on a.AlbumId equals od.AlbumId
                    where od.OrderId == id
                    select a;

            return View(q);
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Album/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
