using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CustomerOrders.Areas.Orders.Data;
using CustomerOrders.Data;

namespace CustomerOrders.Areas.Orders.Controllers
{
    public class OrdersController : Controller
    {
        private CustomerOrdersContext db = new CustomerOrdersContext();

        // GET: Orders/Orders
        public ActionResult Index()
        {
            ViewBag.customers = db.Customers.ToList();
            return View(db.Orders.ToList());
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            return RedirectToAction("Index", "Orders", new RouteValueDictionary() { { "cid", id }, { "area", "Customers" } });
        }

        // GET: Orders/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customers = db.Customers.ToList();
            return View(order);
        }

        // GET: Orders/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
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
