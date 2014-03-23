using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Agency.DAL;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
{
    public class GuestController : Controller
    {
        private ITravelRepository _repo;

        public GuestController(ITravelRepository repo)
        {
            _repo = repo;
        }        

        public ActionResult AddGuest(int id)
        {
            var q = _repo.GetLegById(id);
            ViewBag.Guests = _repo.GetAllGuestNames();
            return PartialView("_AddGuest", q);
        }
        
    }
}
