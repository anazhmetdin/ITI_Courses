using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace image.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return RedirectToAction("Result", new { id = collection["id"], name = collection["name"], image = collection["image"] });
        }
        public ActionResult Result(string id, string name, string image)
        {
            ViewBag.data = new Dictionary<string, string>() { { "id", id }, { "name", name }, { "image", image+".jpg" } };
            return View();
        }
    }
}