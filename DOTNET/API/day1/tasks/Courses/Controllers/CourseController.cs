using Courses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            if (CourseList.Courses.Count == 0)
                return NotFound();
            else
                return Ok(CourseList.Courses);
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteCourse(int id)
        {
            var course = CourseList.Courses.FirstOrDefault(c=>c.Id == id);
            if (course == null)
                return NotFound();
            else
            {
                CourseList.Courses.Remove(course);
                return Ok(CourseList.Courses);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult put(int id, Course _course)
        {
            var course = CourseList.Courses.FirstOrDefault(c => c.Id == id);
            if (id != _course.Id)
                return BadRequest();
            else if (course == null)
                return NotFound();
            else
            {
                course.Id = _course.Id;
                course.Name = _course.Name;
                course.Description = _course.Description;
                course.Duration = _course.Duration;

                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult post(Course? course)
        {
            if (course == null)
                return BadRequest();
            else
            {
                CourseList.Courses.Add(course);
                return CreatedAtAction(nameof(post), course);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id) 
        {
            var course = CourseList.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();
            else
                return Ok(course);
        }

        [HttpGet("{name}")]
        public IActionResult CourseByName(string name)
        {
            var course = CourseList.Courses.FirstOrDefault(c => c.Name == name);
            if (course == null)
                return NotFound();
            else
                return Ok(course);
        }
    }
}
