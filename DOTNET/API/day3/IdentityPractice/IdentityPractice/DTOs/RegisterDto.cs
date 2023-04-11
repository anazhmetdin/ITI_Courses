namespace IdentityPractice.DTOs
{
    public record RegisterDto (string username, string email, string password, DateTime hiringdate, string? adminSecret = null);
}