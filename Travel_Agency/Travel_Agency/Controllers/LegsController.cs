using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Travel_Agency.DAL;
using Travel_Agency.Models;
using HtmlAgilityPack;

namespace Travel_Agency.Controllers
{
    public class LegsController : Controller
    {
        private ITravelRepository _repo;

        public LegsController(ITravelRepository repo)
        {
            _repo = repo;
        }

        // GET api/legs/5
        public ActionResult GetLegs(int id)
        {
            var q = _repo.GetLegsForTrip(id).FirstOrDefault();
            if (q != null)
            {
                ViewBag.Viable = q.Trip.Viable;
            }
            
            
            ViewBag.tripname = _repo.GetTripName(id);
            ViewBag.tripId = id;            
            return PartialView("_TripLeg", _repo.GetLegsForTrip(id));
        }        

        public ActionResult GetDetails(int legid)
        {
            List<String> names = new List<String>();
            var q = _repo.GetLegById(legid);
            //get start location image url
            ViewBag.StartLocation = GetLocationURL(q.StartLocation);
            ViewBag.EndLocation = GetLocationURL(q.FinishLocation);
            foreach (Guest g in q.Guests)
            {
                names.Add(g.FirstName);
            }
            ViewBag.Guests = names;

            return PartialView("_LegDetails", q);
            //return PartialView("_LegDetails", _repo.GetLegById(legid));
        }

        public ActionResult LegInfo(int id)
        {
            List<String> names = new List<String>();
            var q = _repo.GetLegById(id);
            //get start location image url
            ViewBag.StartLocation = GetLocationURL(q.StartLocation);
            ViewBag.EndLocation = GetLocationURL(q.FinishLocation);
            foreach (Guest g in q.Guests)
            {
                names.Add(g.FirstName);
            }
            ViewBag.Guests = names;
            return PartialView("_LegInfo", q);
            
        }

        private string GetLocationURL(string p)
        {
            List<String> sources = new List<String>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://en.wikipedia.org/wiki/" + p);
            var nodes = doc.DocumentNode.SelectNodes("//img[@src]");
            sources = nodes == null ? new List<string>() : nodes.ToList().ConvertAll(r => r.Attributes.ToList().ConvertAll(i => i.Value)).SelectMany(j => j).ToList();
            string lower = "";
            foreach (string s in sources)
            {
                lower = s.ToLower();
                if (lower.Contains("commons") && lower.Contains("collage") || lower.Contains("commons") && lower.Contains("montage") || (((lower.Contains("montage") && lower.Contains("commons")) && (lower.Contains("jpg") || lower.Contains("png")))))
                {
                    return s;
                }
            }
            return "";
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.TripID = id; 
            return PartialView("_CreateLeg");
        }

    }
}
