namespace DeveloperTickets.BL
{
    public record DepartmentReadDto (int Id, string Name, ICollection<TicketReadDto> Tickets);
}