using DeveloperTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.BL
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketManager(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public int CreateTicket(TicketCreateDto ticket)
        {
            var newTicket = _ticketRepo.AddTicket(new Ticket
            {
                DepartmentId = ticket.DepartmentId,
                Title = ticket.Title,
                Description = ticket.Description,
            });

            _ticketRepo.SaveChanges();

            return newTicket?.Entity.Id??-1;
        }

        private TicketReadDto MapTicketDto(Ticket t)
        {
            return new TicketReadDto(t.Id, t.Description, t.Title, t.DeveloperTickets.Count);
        }

        public IEnumerable<TicketReadDto> ReadAllTickets()
        {
            return _ticketRepo.GetAll()
                .Select(MapTicketDto);
        }

        public TicketReadDto? ReadTicket(int ticketId)
        {
            Ticket? ticket = _ticketRepo.GetTicket(ticketId);

            if (ticket == null)
            {
                return null;
            }

            return MapTicketDto(ticket);
        }

        public bool RemoveTicket(int ticketId)
        {
            _ticketRepo.RemoveById(ticketId);

            return _ticketRepo.SaveChanges() > 0;
        }

        public bool UpdateTicket(TicketDto ticket)
        {
            _ticketRepo.UpdateTicket(new Ticket
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                DepartmentId = ticket.DepartmentId
            });

            return _ticketRepo.SaveChanges() > 0;
        }

        public TicketReadDto? AssignDevelopers(int ticketId, AssignedDevelopersDto developers)
        {
            Ticket? ticket = _ticketRepo.GetTicket(ticketId);

            if (ticket == null)
            {
                return null;
            }

            ticket.DeveloperTickets.Clear();

            developers.DevelopersIds.ForEach(id => ticket.DeveloperTickets.Add(new DeveloperTicket() { DeveloperId = id, TicketId = ticketId }));
            _ticketRepo.SaveChanges();

            var newTicket = MapTicketDto(ticket);

            _ticketRepo.SaveChanges();

            return newTicket;
        }
    }
}
