using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class JobPost
    {
        public int Id { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Required]
        public string? Company { get; set; }
        [Required]
        public string? JobType { get; set; }
        [Required]
        public string? WorkArrangement { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public string? Location { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid salary")]
        public int? SalaryRange { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        [NotMapped]
        public int ApplicantsTotal { get; set; }
    }
}
