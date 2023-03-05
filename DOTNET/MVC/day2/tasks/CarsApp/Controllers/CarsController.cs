using CarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsApp.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            ViewBag.cars = CarList.instance;
            return View();
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.car = CarList.instance.FirstOrDefault(car => car.Num == id);
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Car car = new Car() { Num = Int32.Parse(collection["Num"]),
                    Color = collection["Color"], Model = collection["Model"],
                    Manufacture = collection["Manufacture"] };

                CarList.instance.Add(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.car = CarList.instance.FirstOrDefault(car => car.Num == id);
            return View();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var edited = CarList.instance.FirstOrDefault(car => car.Num == id);

                if (edited != null)
                {
                    edited.Num = Int32.Parse(collection["Num"]);
                    edited.Manufacture = collection["Manufacture"];
                    edited.Color = collection["color"];
                    edited.Model = collection["model"];
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            var edited = CarList.instance.FirstOrDefault(car => car.Num == id);

            CarList.instance.Remove(edited);

            return RedirectToAction("Index");
        }
    }
}
