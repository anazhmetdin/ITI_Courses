using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAreas.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Admin/Error
        public ActionResult Error()
        {
            throw new Exception("Custom Employee Error");
        }
    }
}