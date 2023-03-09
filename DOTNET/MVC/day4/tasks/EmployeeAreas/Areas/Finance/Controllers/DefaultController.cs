using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAreas.Areas.Finance.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Finance/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}