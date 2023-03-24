using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentInstructor.Data;
using DepartmentInstructor.Models;
using System.Diagnostics;

namespace DepartmentInstructor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly Context _context;

        public DepartmentsController(Context context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
          if (_context.Department == null)
          {
              return NotFound();
          }
            return await _context.Department.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            if (_context.Department == null)
            {
                return NotFound();
            }
            var department = await _context.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // GET: api/Departments/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Department>> GetDepartment(string name)
        {
            if (_context.Department == null)
            {
                return NotFound();
            }
            var department = await _context.Department.FirstOrDefaultAsync(d => d.Name == name);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'Context.Department'  is null.");
            }

            department.Id = 0;

            _context.Department.Add(department);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch(Exception x)
            {
                Debug.WriteLine(x);
            }
            
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.Department == null)
            {
                return NotFound();
            }
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
