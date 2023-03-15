using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerOrders.Areas.Customers.Data;
using CustomerOrders.Areas.Orders.Data;
using CustomerOrders.Data;
using CustomerOrders.Models;

namespace CustomerOrders.Areas.Customers.Controllers
{
    [MyExceptionHandler]
    public class OrdersController : Controller
    {
        private CustomerOrdersContext db = new CustomerOrdersContext();

        public ActionResult Index(int cid)
        {
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View(customer.Orders);
        }

        // GET: CustomerOrders/CustomerOrders/Details/5
        public ActionResult Details(int cid, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            Order order = customer.Orders.Find(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View(order);
        }

        // GET: CustomerOrders/CustomerOrders/Create
        public ActionResult Create(int cid)
        {
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View();
        }

        // POST: CustomerOrders/CustomerOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int cid, [Bind(Include = "Id,Date,Price")] Order order)
        {
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            if (ModelState.IsValid)
            {
                order.Customer = customer;
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View(order);
        }

        // GET: CustomerOrders/CustomerOrders/Edit/5
        public ActionResult Edit(int cid, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            Order order = customer.Orders.Find(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View(order);
        }

        // POST: CustomerOrders/CustomerOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int cid, [Bind(Include = "Id,Date,Price")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: CustomerOrders/CustomerOrders/Delete/5
        public ActionResult Delete(int cid, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            Order order = customer.Orders.Find(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name = customer.Name;
            ViewBag.Id = customer.Id;
            return View(order);
        }

        // POST: CustomerOrders/CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int cid, int id)
        {
            Customer customer = db.Customers.Find(cid);
            if (customer == null)
            {
                throw new UserNotFoundException();
            }
            Order order = customer.Orders.Find(o => o.Id == id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
