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
using TraineesITI.Repositories.Tracks;

namespace TraineesITI.Controllers
{
    public class TracksController : Controller
    {
        public IModelRepo<Track> TracksRepo { get; }

        public TracksController(IModelRepo<Track> tracksRepo)
        {
            TracksRepo = tracksRepo;
        }

        // GET: Tracks
        public IActionResult Index()
        {
              return View(TracksRepo.GetAll());
        }

        // GET: Tracks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Track? track = TracksRepo.GetById(id);

                if (track == null)
                {
                    return NotFound();
                }

                return View(track);
            }
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] Track track)
        {
            if (ModelState.IsValid && TracksRepo.TryInsert(track))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = TracksRepo.GetById(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && TracksRepo.TryUpdate(track))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Delete/5
        public IActionResult Delete(int? id)
        {
            Track? track = TracksRepo.GetById(id);
            
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!TracksRepo.TryDelete(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
