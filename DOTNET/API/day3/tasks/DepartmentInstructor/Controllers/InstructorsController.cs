using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentInstructor.Data;
using DepartmentInstructor.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DepartmentInstructor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstructorsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public InstructorsController(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructor()
        {
          if (_context.Instructor == null)
          {
              return NotFound();
          }
            return await _context.Instructor.ToListAsync();
        }

        // GET: api/Instructors/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            if (_context.Instructor == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructor.FindAsync(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }
        // GET: api/Instructors/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Instructor>> GetInstructor(string name)
        {
            if (_context.Instructor == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructor.FirstOrDefaultAsync(i => i.Name == name);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }

            _context.Entry(instructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
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

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor)
        {
          if (_context.Instructor == null)
          {
              return Problem("Entity set 'Context.Instructor'  is null.");
          }
            _context.Instructor.Add(instructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstructor", new { id = instructor.Id }, instructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            if (_context.Instructor == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructor.Remove(instructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructorExists(int id)
        {
            return (_context.Instructor?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult LoginInstructor (InstructorLogin instructorLogin)
        {
            if (_context.Instructor.Any(i => i.Email == instructorLogin.Email && i.Password == instructorLogin.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"] ?? throw new SecurityTokenNotYetValidException()));
                var clims = new[]
                {
                    new Claim("Email", instructorLogin.Email)
                };
                var token = new JwtSecurityToken(
                    claims: clims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );
                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenAsString);
            }
            return Unauthorized();
        }
    }
}
