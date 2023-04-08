using DeveloperTickets.BL;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTickets.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketManager _ticketManager;

        public TicketsController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_ticketManager.ReadAllTickets());
        }

        [HttpGet("{Id}")]
        public IActionResult Details(int Id)
        {
            var ticket = _ticketManager.ReadTicket(Id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var deleted = _ticketManager.RemoveTicket(Id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(TicketCreateDto ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Id = _ticketManager.CreateTicket(ticket);
            return CreatedAtAction(actionName: nameof(Details), routeValues: new { Id }, new { Message = "Created Successfully" });
        }

        [HttpPost("{Id}")]
        public IActionResult EditDevelopers(int Id, AssignedDevelopersDto developers)
        {
            return Ok(_ticketManager.AssignDevelopers(Id, developers));
        }
    }
}
