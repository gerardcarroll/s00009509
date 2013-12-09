using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data;
using System.Data.Entity;
using PagedList;

namespace s00009509.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        //
        // GET: /Home/

        public ActionResult Index(int? empId, int? page)
        {
            if (Request.IsAjaxRequest())
            {
                var e = (db.Employees.Where(em => em.EmployeeID == empId)).FirstOrDefault();

                //to display emp details in box
                return PartialView("_EmpDetails", e);
            }

            // setup PagedList settings
            int pageSize = 10;
            int pageNumber = page ?? 1;
                        
            return View(db.Orders.OrderBy(o=>o.OrderID).ToPagedList(pageNumber,pageSize));
        }



        public ActionResult EmpIndex(int? employeeId, int? page)
        {
            // setup PagedList settings
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var e1 = db.Orders.Where(e => e.EmployeeID == employeeId).OrderBy(o => o.OrderID);

            ViewBag.empID = employeeId;

            if (e1 != null)
            {
                var q = db.Employees.Find(employeeId);
                ViewBag.Title = "Orders By " + q.FirstName + " " + q.LastName;
                
                //to display orders for the particular employee
                return PartialView("_EmpOrders", e1.ToPagedList(pageNumber, pageSize));
               
            }

            return View("Index", db.Orders.OrderBy(o => o.OrderID).ToPagedList(pageNumber, pageSize));
        }        

        //
        // GET: /Home/Edit/5
        
        public ActionResult Edit(int id)
        {
            Order order = db.Orders.Find(id);

            ViewBag.Employee = db.Employees.Select(e => new { e.EmployeeID, e.LastName }).Distinct().ToList();
            
            ViewBag.Shipper = db.Shippers.Select(s => new { s.ShipperID, s.CompanyName }).Distinct().ToList();
            
            return (order == null) ? View() : View(order);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            if(ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(order);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int orderid)
        {
            Order order = db.Orders.Find(orderid);
            if (order == null)
            {
                return HttpNotFound();
            }

            return PartialView("_Delete", order);              
        }

        
        
        public ActionResult DeleteConfirm(int orderId)
        {
            try
            {
                // get all rows with OrderID in Order_details table                
                var q = db.Order_Details.Where(od => od.OrderID == orderId);

                //delete all of these rows
                foreach (Order_Detail i in q)
                {
                    db.Order_Details.Remove(i);
                }                

                //now get the row from Orders table
                Order x = db.Orders.Find(orderId);
                    
                //delete the Order
                db.Orders.Remove(x);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
