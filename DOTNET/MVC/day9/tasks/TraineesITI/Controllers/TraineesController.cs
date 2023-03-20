using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using TraineesITI.Data;
using TraineesITI.Models;
using TraineesITI.Repositories;
using TraineesITI.Repositories.Tracks;
using TraineesITI.Repositories.Trainees;

namespace TraineesITI.Controllers
{
    public class TraineesController : Controller
    {
        public IModelRepo<Trainee> TraineeRepo { get; }
        public IModelRepo<Track> TrackRepo { get; }

        public TraineesController(IModelRepo<Trainee> traineeRepo, IModelRepo<Track> tracksRepo)
        {
            TraineeRepo = traineeRepo;
            TrackRepo = tracksRepo;
        }

        // GET: Trainees
        public IActionResult Index()
        {
            ViewBag.Tracks = TrackRepo.GetAll();
            return View(TraineeRepo.GetAll());
        }

        [HttpPost]
        // GET: Trainees
        public IActionResult Index(int id)
        {
            ViewBag.Tracks = TrackRepo.GetAll();
            return View(TraineeRepo.Where(t => t.TrackId == id));
        }

        // GET: Trainees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Trainee? trainee = TraineeRepo.GetById(id);

                if (trainee == null)
                {
                    return NotFound();
                }

                return View(trainee);
            }
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            ViewBag.Tracks = TrackRepo.GetAll();
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,TrackId,Gender,Email,Phone,Birthdate")] Trainee trainee)
        {
            if (TraineeRepo.TryInsert(trainee))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tracks = TrackRepo.GetAll();
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public IActionResult Edit(int? id)
        {
            var trainee = TraineeRepo.GetById(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewBag.Tracks = TrackRepo.GetAll();
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,TrackId,Gender,Email,Phone,Birthdate")] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            if (TraineeRepo.TryUpdate(trainee))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tracks = TrackRepo.GetAll();
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public IActionResult Delete(int? id)
        {
            Trainee? trainee = TraineeRepo.GetById(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!TraineeRepo.TryDelete(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
