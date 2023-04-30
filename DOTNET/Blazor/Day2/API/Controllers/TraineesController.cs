using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Data.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly APIContext _context;

        public TraineesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Trainees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainee>>> GetTrainee()
        {
          if (_context.Trainee == null)
          {
              return NotFound();
          }
            return await _context.Trainee.ToListAsync();
        }

        // GET: api/Trainees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainee>> GetTrainee(int id)
        {
          if (_context.Trainee == null)
          {
              return NotFound();
          }
            var trainee = await _context.Trainee.FindAsync(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return trainee;
        }

        // PUT: api/Trainees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainee(int id, Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
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

        // POST: api/Trainees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainee>> PostTrainee(Trainee trainee)
        {
          if (_context.Trainee == null)
          {
              return Problem("Entity set 'APIContext.Trainee'  is null.");
          }
            _context.Trainee.Add(trainee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainee", new { id = trainee.Id }, trainee);
        }

        // DELETE: api/Trainees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            if (_context.Trainee == null)
            {
                return NotFound();
            }
            var trainee = await _context.Trainee.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            _context.Trainee.Remove(trainee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraineeExists(int id)
        {
            return (_context.Trainee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
