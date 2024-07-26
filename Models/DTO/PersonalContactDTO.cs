namespace NetCareer.Models.DTO
{
    public class PersonalContactDTO
    {
        public required string ContactId { get; set; }
        public required string ContactName { get; set; }
        public string? ImageURL { get; set; }
    }
}
