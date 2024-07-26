namespace NetCareer.Models.ViewModels
{
    public class ContactDTO
    {
        public required string ContactId { get; set; }
        public required string ContactName { get; set; }
        public required DateTime LastMessageDate { get; set; }
        public required string LastMessageContent { get; set; }
        public bool IsSent { get; set; }
        public bool IsRead { get; set; }
        public string? ImageURL { get; set; }
    }
}
