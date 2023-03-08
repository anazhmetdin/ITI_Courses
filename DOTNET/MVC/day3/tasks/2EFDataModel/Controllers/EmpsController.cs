using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2EFDataModel.Models;

namespace _2EFDataModel.Controllers
{
    public class EmpsController : Controller
    {
        private EMPLOYEESEntities1 db = new EMPLOYEESEntities1();

        // GET: Emps
        public ActionResult Index()
        {
            var emps = db.Emps.Include(e => e.City).Include(e => e.Dept);
            var depts = db.Depts.ToList();
            ViewBag.depts = depts;
            return View(emps.ToList());
        }
        public ActionResult Filter(int id)
        {
            var emps = db.Emps.Where(e => e.dID == id).ToList();
            var depts = db.Depts.ToList();
            ViewBag.depts = depts;
            return View("Index", emps);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return RedirectToAction("Filter", "Emps", new {id = collection["DeptID"] });
        }

        // GET: Emps/Details/5
        public ActionResult Details(int? id)
        {
            Emp emp = db.Emps.Find(id);
            return View(emp);
        }

        // GET: Emps/Create
        public ActionResult Create()
        {
            ViewBag.CtyID = new SelectList(db.Cities, "cityID", "CityName");
            ViewBag.dID = new SelectList(db.Depts, "DeptID", "DeptName");
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpFname,EmpLname,EmpSalary,EmpHDate,dID,CtyID")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CtyID = new SelectList(db.Cities, "cityID", "CityName", emp.CtyID);
            ViewBag.dID = new SelectList(db.Depts, "DeptID", "DeptName", emp.dID);
            return View(emp);
        }

        // GET: Emps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            ViewBag.CtyID = new SelectList(db.Cities, "cityID", "CityName", emp.CtyID);
            ViewBag.dID = new SelectList(db.Depts, "DeptID", "DeptName", emp.dID);
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpFname,EmpLname,EmpSalary,EmpHDate,dID,CtyID")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CtyID = new SelectList(db.Cities, "cityID", "CityName", emp.CtyID);
            ViewBag.dID = new SelectList(db.Depts, "DeptID", "DeptName", emp.dID);
            return View(emp);
        }

        // GET: Emps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp emp = db.Emps.Find(id);
            db.Emps.Remove(emp);
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
