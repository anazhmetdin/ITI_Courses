namespace ProductNotification.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
