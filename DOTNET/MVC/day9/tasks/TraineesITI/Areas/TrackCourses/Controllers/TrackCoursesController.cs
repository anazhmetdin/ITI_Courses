using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Data;
using TraineesITI.Models;
using TraineesITI.Repositories;
using TraineesITI.Repositories.Courses;
using TraineesITI.Repositories.Tracks;
using TraineesITI.Repositories.Trainees;

namespace TraineesITI.Areas.TrackCourses.Controllers
{
    [Area("TrackCourses")]
    public class TrackCoursesController : Controller
    {
        public IModelRepo<Course> CoursesRepo { get; }
        public IModelRepo<Track> TracksRepo { get; }
        public IModelRepo<TrackCourse> ModelRepo { get; }

        public TrackCoursesController(IModelRepo<Course> coursesRepo,
            IModelRepo<Track> tracksRepo,
            IModelRepo<TrackCourse> modelRepo)
        {
            CoursesRepo = coursesRepo;
            TracksRepo = tracksRepo;
            ModelRepo = modelRepo;
        }

        // GET: TrackCourses/TrackCourses
        public IActionResult Index(int tid)
        {
            ViewBag.Track = TracksRepo.GetById(tid);
            return View(ModelRepo.Where(t=> t.TrackId == tid));
        }

        // GET: TrackCourses/TrackCourses/Details/5
        public IActionResult Details(int tid, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var model = ModelRepo.GetById(id);

                if (model == null)
                {
                    return NotFound();
                }

                ViewBag.Track = TracksRepo.GetById(tid);
                return View(model);
            }
        }

        // GET: Courses/Create
        public IActionResult Create(int tid)
        {
            ViewBag.Track = TracksRepo.GetById(tid);
            ViewBag.Courses = CoursesRepo.GetAll();
            return View();
        }

        // POST: TrackCourses/TrackCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int tid, [Bind("Id,TrackId,CourseId")] TrackCourse trackCourse)
        {
            if (tid == trackCourse.TrackId && ModelRepo.TryInsert(trackCourse))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Track = TracksRepo.GetById(tid);
            ViewBag.Courses = CoursesRepo.GetAll();
            return View(trackCourse);
        }

        // GET: TrackCourses/TrackCourses/Edit/5
        public IActionResult Edit(int tid, int? id)
        {
            var model = ModelRepo.GetById(id);
            if (model == null || model.TrackId != tid)
            {
                return NotFound();
            }
            ViewBag.Track = TracksRepo.GetById(tid);
            ViewBag.Courses = CoursesRepo.GetAll();
            return View(model);
        }

        // POST: TrackCourses/TrackCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int tid, int id, [Bind("Id,TrackId,CourseId")] TrackCourse trackCourse)
        {
            if (tid != trackCourse.TrackId || id != trackCourse.Id)
            {
                return NotFound();
            }

            if (ModelRepo.TryUpdate(trackCourse))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Track = TracksRepo.GetById(tid);
            ViewBag.Courses = CoursesRepo.GetAll();
            return View(trackCourse);
        }

        // GET: TrackCourses/TrackCourses/Delete/5
        public IActionResult Delete(int tid, int? id)
        {
            var model = ModelRepo.GetById(id);

            if (model == null || model.TrackId != tid)
            {
                return NotFound();
            }

            ViewBag.Track = TracksRepo.GetById(tid);
            return View(model);
        }

        // POST: TrackCourses/TrackCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int tid, int id)
        {
            if (!ModelRepo.TryDelete(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
