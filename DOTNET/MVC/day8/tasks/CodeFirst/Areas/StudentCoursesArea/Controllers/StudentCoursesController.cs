using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Data;
using CodeFirst.Models;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace CodeFirst.Areas.StudentCoursesArea.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly CodeFirstContext _context;

        public StudentCoursesController(CodeFirstContext context)
        {
            _context = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index(int sid)
        {
            Student? student = _context.Students.Find(sid);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Student = student;

            return _context.StudentCourse != null ?
                        View(await _context.StudentCourse
                        .Where(sc => sc.Student.Id == sid)
                        .Include(sc=>sc.Course)
                        .ToListAsync())
                        :
                        Problem("Entity set 'CodeFirstContext.StudentCourse'  is null.");
        }

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int sid, int id)
        {
            if (_context.StudentCourse == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(sc => sc.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public IActionResult Create(int sid)
        {
            Student? student = _context.Students.Find(sid);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Student = student;
            ViewBag.courses = _context.Course.ToList();
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int sid, int cid, [Bind("Id, Grade")] StudentCourse studentCourse)
        {
            Student? student = _context.Students.Find(sid);
            Course? course = _context.Course.Find(cid);
            if (student == null || course == null)
            {
                return View(studentCourse);
            }

            studentCourse.Student = student;
            studentCourse.Course = course;

            _context.Add(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int sid, int id)
        {
            if (_context.StudentCourse == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            ViewBag.courses = _context.Course.ToList();
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int sid, int cid, [Bind("Id, Course, Grade")] StudentCourse studentCourse)
        {
            try
            {
                Student? student = _context.Students.Find(sid);
                Course? course = _context.Course.Find(cid);
                if (student == null || course == null)
                {
                    return View(studentCourse);
                }

                studentCourse.Student = student;
                studentCourse.Course = course;

                _context.Update(studentCourse);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCourseExists(studentCourse.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int sid, int id)
        {
            if (_context.StudentCourse == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int sid, int id)
        {
            if (_context.StudentCourse == null)
            {
                return Problem("Entity set 'CodeFirstContext.StudentCourse'  is null.");
            }
            var studentCourse = await _context.StudentCourse.FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse != null)
            {
                _context.StudentCourse.Remove(studentCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return (_context.StudentCourse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
