using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeAreas.Areas.HR.Data;
using EmployeeAreas.Data;

namespace EmployeeAreas.Areas.HR.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeAreasContext db = new EmployeeAreasContext();

        // GET: HR/Employees/Error
        public ActionResult Error()
        {
            throw new Exception("Custom Employee Error");
        }
        // GET: HR/Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: HR/Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id can't be null");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Can't find this employee");
            }
            return View(employee);
        }

        // GET: HR/Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,Username,Password,Gender,Salary,JoinDate,Email,Phone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: HR/Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id can't be null");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Can't find this employee");
            }
            return View(employee);
        }

        // POST: HR/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Username,Password,Gender,Salary,JoinDate,Email,Phone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: HR/Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Can't find this employee");
            }
            return View(employee);
        }

        // POST: HR/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
