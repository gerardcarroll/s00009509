using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace s00009509.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        //
        // GET: /Home/

        public ActionResult Index(int? empId, int? employeeID)
        {
            string test = "";

            //if(Request.IsAjaxRequest())
            //{
            //    var e1 = db.Orders.Where(e => e.EmployeeID == EmployeeID);
            //    return PartialView("_EmpOrders");
            //}
            if(employeeID != null)
            {
                //Thread.Sleep(2000);
                var e1 = db.Orders.Where(e => e.EmployeeID == employeeID);
                return PartialView("_EmpOrders", e1);
            }

            if (empId != null)
            {
                //Thread.Sleep(2000);
                var e = (from em in db.Employees
                         where em.EmployeeID == empId
                         select em).FirstOrDefault();
                return PartialView("_EmpDetails", e);
            }
                        
            return View(db.Orders);
        }

        //[HttpPost]

        public ActionResult EmpIndex(int? employeeId)
        {
            if (employeeId != null)
            {
                var e = (from em in db.Employees
                        where em.EmployeeID == employeeId
                        select em).FirstOrDefault();
                return PartialView("_EmpDetails", e);
            }

            return View();
        }


        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
