using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerOrders.Areas.Customers.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Customers/Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}