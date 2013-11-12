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

    }
}
