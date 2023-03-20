using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Areas.TraineeCourses.Models;
using TraineesITI.Data;
using TraineesITI.Models;
using TraineesITI.Repositories;
using TraineesITI.Repositories.Tracks;

namespace TraineesITI.Areas.TraineeCourses.Controllers
{
    [Area("TraineeCourses")]
    public class TraineeCoursesController : Controller
    {
        public IModelRepo<Trainee> TraineeRepo { get; }
        public IModelRepo<TrackCourse> TrackCourseRepo { get; }
        public IModelRepo<TraineeCourse> ModelRepo { get; }

        public TraineeCoursesController(IModelRepo<TrackCourse> trackCourseRepo,
            IModelRepo<Trainee> traineeRepo,
            IModelRepo<TraineeCourse> modelRepo)
        {
            TrackCourseRepo = trackCourseRepo;
            TraineeRepo = traineeRepo;
            ModelRepo = modelRepo;
        }

        // GET: TraineeCourses/TraineeCourses
        public IActionResult Index(int tid)
        {
            ViewBag.Trainee = TraineeRepo.GetById(tid);
            return View(ModelRepo.Where(t => t.TraineeId == tid));
        }

        // GET: TraineeCourses/TraineeCourses/Details/5
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

                ViewBag.Trainee = TraineeRepo.GetById(tid);
                return View(model);
            }
        }

        // GET: TraineeCourses/TraineeCourses/Create
        public IActionResult Create(int tid)
        {
            ViewBag.Trainee = TraineeRepo.GetById(tid);
            ViewBag.Courses = TrackCourseRepo
                .Where(c=>c.TrackId == ViewBag.Trainee.TrackId)
                .Select(c=>c.Course).ToList();
            return View();
        }

        // POST: TraineeCourses/TraineeCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int tid, [Bind("Id,TraineeId,CourseId,Grade")] TraineeCourse traineeCourse)
        {
            if (tid == traineeCourse.TraineeId && ModelRepo.TryInsert(traineeCourse))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Trainee = TraineeRepo.GetById(tid);
            ViewBag.Courses = TrackCourseRepo
                .Where(c => c.TrackId == ViewBag.Trainee.TrackId)
                .Select(c => c.Course).ToList();
            return View(traineeCourse);
        }

        // GET: TraineeCourses/TraineeCourses/Edit/5
        public IActionResult Edit(int tid, int? id)
        {
            var model = ModelRepo.GetById(id);
            if (model == null || model.TraineeId != tid)
            {
                return NotFound();
            }
            ViewBag.Trainee = TraineeRepo.GetById(tid);
            ViewBag.Courses = TrackCourseRepo
                .Where(c => c.TrackId == ViewBag.Trainee.TrackId)
                .Select(c => c.Course).ToList();
            return View(model);
        }

        // POST: TraineeCourses/TraineeCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int tid, int id, [Bind("Id,TraineeId,CourseId,Grade")] TraineeCourse traineeCourse)
        {
            if (tid != traineeCourse.TraineeId || id != traineeCourse.Id)
            {
                return NotFound();
            }

            if (ModelRepo.TryUpdate(traineeCourse))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Trainee = TraineeRepo.GetById(tid);
            ViewBag.Courses = TrackCourseRepo
                .Where(c => c.TrackId == ViewBag.Trainee.TrackId)
                .Select(c => c.Course).ToList();
            return View(traineeCourse);
        }

        // GET: TraineeCourses/TraineeCourses/Delete/5
        public IActionResult Delete(int tid, int? id)
        {
            var model = ModelRepo.GetById(id);

            if (model == null || model.TraineeId != tid)
            {
                return NotFound();
            }

            ViewBag.Trainee = TraineeRepo.GetById(tid);
            return View(model);
        }

        // POST: TraineeCourses/TraineeCourses/Delete/5
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
