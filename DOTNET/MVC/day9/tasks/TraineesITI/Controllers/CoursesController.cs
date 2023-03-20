using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineesITI.Data;
using TraineesITI.Models;
using TraineesITI.Repositories;
using TraineesITI.Repositories.Courses;
using TraineesITI.Repositories.Tracks;

namespace TraineesITI.Controllers
{
    public class CoursesController : Controller
    {
        public IModelRepo<Course> CoursesRepo { get; }

        public CoursesController(IModelRepo<Course> coursesRepo)
        {
            CoursesRepo = coursesRepo;
        }

        // GET: Courses
        public IActionResult Index()
        {
              return View(CoursesRepo.GetAll());
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Course? course = CoursesRepo.GetById(id);

                if (course == null)
                {
                    return NotFound();
                }

                return View(course);
            }
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Topic")] Course course)
        {
            if (ModelState.IsValid && CoursesRepo.TryInsert(course))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = CoursesRepo.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Topic")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && CoursesRepo.TryUpdate(course))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            Course? course = CoursesRepo.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!CoursesRepo.TryDelete(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
