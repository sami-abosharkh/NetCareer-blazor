using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? User { get; set; }
        [Required, MaxLength(30)]
        public string? FirstName { get; set; }
        [Required, MaxLength(30)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Headline { get; set; }
        [MaxLength(2000)]
        public string? Summary { get; set; }
        [Required]
        public string? Location { get; set; }
        public string? Industry { get; set; }
        public required string ProfilePicture { get; set; }
    }
}
